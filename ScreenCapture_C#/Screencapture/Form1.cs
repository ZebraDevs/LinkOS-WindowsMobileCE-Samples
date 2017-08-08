/********************************************** 
 * CONFIDENTIAL AND PROPRIETARY 
 *
 * The source code and other information contained herein is the confidential and the exclusive property of
 * ZIH Corp. and is subject to the terms and conditions in your end user license agreement.
 * This source code, and any other information contained herein, shall not be copied, reproduced, published, 
 * displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
 * expressly permitted under such license agreement.
 * 
 * Copyright ZIH Corp. 2012
 *
 * ALL RIGHTS RESERVED 
 ***********************************************/
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using ZSDK_API.Comm;
using ZSDK_API.ApiException;
using ZSDK_API.Printer;




namespace Screencapture
{
    
    public partial class Form1 : Form
    {
        Bitmap screen_image;

        enum RasterOperation : uint
        {
            SRC_COPY = 0x00CC0020
        }

        [DllImport("coredll.dll")]
        static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, RasterOperation rasterOperation);

        [DllImport("coredll.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("coredll.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, DeviceCapsIndex nIndex);

        enum DeviceCapsIndex : int
        {
            HORZRES = 8,
            VERTRES = 10,
        }

        public static Size PixelDimensions
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                return new Size(GetDeviceCaps(hdc, DeviceCapsIndex.HORZRES), GetDeviceCaps(hdc, DeviceCapsIndex.VERTRES));
            }
        }

        public static Bitmap GetScreenCapture()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            Size size = PixelDimensions;
            Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format16bppRgb565);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                IntPtr dstHdc = graphics.GetHdc();
                BitBlt(dstHdc, 0, 0, size.Width, size.Height, hdc, 0, 0, RasterOperation.SRC_COPY);
                graphics.ReleaseHdc(dstHdc);
            }
            return bitmap;
        }


        public Form1()
        {
            InitializeComponent();
            
        }


        private void menuItem1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Threading.Thread.Sleep(10000);
            try
            {
                screen_image = GetScreenCapture();  //Get bitmap image of the screen 
                String myMacAddress = textBox1.Text; //Printer's Bluetooth MAC Address.
                ZebraPrinterConnection zebraPrinterConnection = new BluetoothPrinterConnection(myMacAddress);
                zebraPrinterConnection.Open();
                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(zebraPrinterConnection);

                int x = 10;
                int y = 200;
                zebraPrinterConnection.Write(Encoding.Default.GetBytes("! 0 200 200 1200 1\r\n"));
                printer.GetGraphicsUtil().PrintImage(screen_image, x, y, -1, -1, true);  //Print the screen caputre image.
                zebraPrinterConnection.Write(Encoding.Default.GetBytes("FORM\r\nPRINT\r\n"));
                zebraPrinterConnection.Close();


            }
            catch
            {
                MessageBox.Show("Unable to print screen image");
            }

            this.Show();
        }

    }
}