/********************************************** 
 * CONFIDENTIAL AND PROPRIETARY 
 *
 * The source code and other information contained herein is the confidential and the exclusive property of
 * ZIH Corp. and is subject to the terms and conditions in your end user license agreement.
 * This source code, and any other information contained herein, shall not be copied, reproduced, published, 
 * displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
 * expressly permitted under such license agreement.
 * 
 * Copyright ZIH Corp. 2010
 *
 * ALL RIGHTS RESERVED 
 ***********************************************
 File:   ImageRotate.cs

 Descr:  This file defines the functions of the GUI components.  
         It allows for the rotation of a user selected image by calling
         the Rotator class defined in the Rotator.cs file.  It then prints
         the rotated image to a Zebra CPCL printer by using the ZSDK_API.dll 
         to connect and send data to the printer via Bluetooth.

 $Revision: 4.0 $
 $Date: 06/17/2010 $
 * 
 * Created by Zebra Development Services Group
***********************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using ZSDK_API.ApiException;
using ZSDK_API.Comm;
using ZSDK_API.Printer;

namespace WinSDKImageRotate
{
    public partial class ImageRotate : Form
    {
        private string _sFileName = "";
        /// <summary>
        /// Name (and path) of file to send to the printer.
        /// </summary>
        public string sFileName
        {
            get { return _sFileName; }
            set
            {
                _sFileName = value;
                ImagePathtextBox.Text = _sFileName;
            }
        }

        String macAddress;
        ZebraPrinterConnection connection;
        ZebraPrinter printer;
        Bitmap image;

        public ImageRotate()
        {
            InitializeComponent();
            
        }    

        /**
         * When the "Print" button is clicked, get the image, connect and print, then disconnect
         * **/
        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (ImagePathtextBox.Text != "")
            {
                GetImage();
                connectBT(macAddressTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please select or enter the path of an image file to print.");
            }
            
        }

         /***********************************************************************
         * The following methods handle connection to printer
         * ********************************************************************/

        /**
         * Spawn a new thread that connects to the printer
         * **/
        private void connectBT(String macAddress)
        {

            this.macAddress = macAddress;
            Thread t = new Thread(doConnectBT);
            t.Start();
        }


        /**
        * Check that macAddress is valid
        * Connect to device using BluetoothPrinterConnection class
        * **/
        private void doConnectBT()
        {
            updateButtonFromWorkerThread(false);
            /**
             * If a connection already exists, disconnect it
             * **/
            if (connection != null)
            {
                Thread t = disconnect();
                t.Join();
            }
            if (this.macAddress == null || this.macAddress.Length != 12)
            {
                updateGuiFromWorkerThread("Invalid MAC Address", Color.Red);
                disconnect();
            }
            else
            {
                /** 
                 * Attempt to connect to printer via Bluetooth
                 * **/
                updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod);
                try
                {
                     connection = new BluetoothPrinterConnection(this.macAddress);
                     threadedConnect(this.macAddress);
                }
                catch (ZebraPrinterConnectionException)
                {
                    updateGuiFromWorkerThread("Unable to connect with printer", Color.Red);
                    disconnect();
                }
                catch (ZebraException)
                {
                    updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                    disconnect();
                }

                catch (Exception)
                {
                    updateGuiFromWorkerThread("Error communicating with printer", Color.Red);
                    disconnect();
                }
                updateButtonFromWorkerThread(true);
            }
            
        }

        /**
         * When a ZebraPrinterConnection has been established, this method 
         * gets the printer and gathers information from the printer such as 
         * the printer language and prints to the printer
         * **/

        private void threadedConnect(String addressName)
        {
            try
            {
                /**
                 * Open the connection
                 * **/
                connection.Open();
                Thread.Sleep(1000);
            }
            catch (ZebraPrinterConnectionException)
            {
                updateGuiFromWorkerThread("Unable to connect with printer", Color.Red);
                disconnect();
            }
            catch (Exception)
            {
                updateGuiFromWorkerThread("Error communicating with printer", Color.Red);
                disconnect();
            }

            printer = null;
            if (connection != null && connection.IsConnected())
            {
                /**
                 * Get the printer instance and the printer language, then print image
                 * **/
                try
                {
                    updateGuiFromWorkerThread("Getting printer...", Color.Goldenrod);
                    Thread.Sleep(1000);
                    printer = ZebraPrinterFactory.GetInstance(connection);
                    updateGuiFromWorkerThread("Got Printer, getting Language...", Color.LemonChiffon);
                    Thread.Sleep(1000);
                    PrinterLanguage pl = printer.GetPrinterControlLanguage();
                    updateGuiFromWorkerThread("Printer Language " + pl.ToString(), Color.LemonChiffon);
                    Thread.Sleep(1000);
                    updateGuiFromWorkerThread("Formatting Image", Color.AliceBlue);
                    printer.GetGraphicsUtil().PrintImage(image, 0, 0, 550, 412, false);
                    updateGuiFromWorkerThread("Printing To " + addressName, Color.Green);
                    Thread.Sleep(2000);
                    disconnect();
                }
                catch (ZebraPrinterConnectionException)
                {
                    updateGuiFromWorkerThread("Unknown Printer Language", Color.Red);
                    printer = null;
                    Thread.Sleep(1000);
                    disconnect();
                }
                catch (ZebraPrinterLanguageUnknownException)
                {
                    updateGuiFromWorkerThread("Unknown Printer Language", Color.Red);
                    printer = null;
                    Thread.Sleep(1000);
                    disconnect();
                }
            }
            updateButtonFromWorkerThread(true);
        }
         /**
         * Start disconnect thread
         * **/
        public Thread disconnect()
        {
            Thread t = new Thread(doDisconnect);
            t.Start();
            return t;
        }

        /**
         * Close connection to printer
         * **/

        private void doDisconnect()
        {
            try
            {
                if (connection != null && connection.IsConnected())
                {
                    updateGuiFromWorkerThread("Disconnecting...", Color.Honeydew);
                    
                    connection.Close();
                }
            }
            catch (ZebraException)
            {
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
            }
            Thread.Sleep(1000);
            updateGuiFromWorkerThread("Not Connected", Color.Red);
            Thread.Sleep(1000);
            updateButtonFromWorkerThread(true);
            connection = null;
        }
        /*******************************************************************************
         * End printer connection methods
         * ****************************************************************************/


        /*******************************************************************************
         * The following methods update the status bar at top of screen
         * ****************************************************************************/

        public void updateGuiFromWorkerThread(String message, Color color)
        {
            Invoke(new StatusEventHandler(UpdateUI), new StatusArguments(message, color));
        }

        private delegate void StatusEventHandler(StatusArguments e);

        private void UpdateUI(StatusArguments e)
        {
            statusBar.Text = e.message;
            statusBar.BackColor = e.color;
        }

        public class StatusArguments : System.EventArgs
        {
            public String message;
            public Color color;

            public StatusArguments(String message, Color color)
            {
                this.message = message;
                this.color = color;
            }
        }
        /*******************************************************************************
         * End status bar update methods
         * ****************************************************************************/

        /*******************************************************************************
         * The following methods enable and disable buttons as needed
         * ****************************************************************************/

        public void updateButtonFromWorkerThread(bool enabled)
        {
            Invoke(new ButtonStatusHandler(UpdateButton), enabled);
        }
        private delegate void ButtonStatusHandler(bool enabled);
        private void UpdateButton(bool enabled)
        {
           
        }

        private void GetImage()
        {
            try
            {

                // Select rotation
                
                int angletorotate = 0;
               
                if (radioButton90.Checked)
                {
                    angletorotate = 90;
                }
                else if (radioButton180.Checked)
                {
                    angletorotate = 180;
                }
                else if (radioButton270.Checked)
                {
                    angletorotate = 270;
                }
                else
                {
                    image = new Bitmap(sFileName);
                    return;
                }

                Bitmap mybitmap = new Bitmap(sFileName);
                // Make the width the height and height the width if the rotation angle is 90 or 270
                bool aspectRatio = (angletorotate == 90 || angletorotate == 270);
                int newWidth = (aspectRatio ? mybitmap.Height : mybitmap.Width);
                int newHeight = (aspectRatio ? mybitmap.Width : mybitmap.Height);

                // Create a Bitmap that will be the rotated Bitmap
                Bitmap rotatedBitmap = new Bitmap(newWidth, newHeight);

                int WidthMinusOne = newWidth - 1;
                int HeightMinusOne = newHeight - 1;

                // Lock images into system memory
                BitmapData myLockedBitmap = mybitmap.LockBits(new Rectangle(0, 0, mybitmap.Width, mybitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
                BitmapData rotatedLockedBitmap = rotatedBitmap.LockBits(new Rectangle(0, 0, rotatedBitmap.Width, rotatedBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);

                unsafe
                {
                    int* myPtr = (int*)myLockedBitmap.Scan0.ToPointer();
                    int* rotatedPtr = (int*)rotatedLockedBitmap.Scan0.ToPointer();

                    //Rotate the image
                        if(angletorotate == 90)
                        {
                            for (int y = 0; y < mybitmap.Height; ++y)
                            {
                                int destinationX = WidthMinusOne - y;
                                for (int x = 0; x < mybitmap.Width; ++x)
                                {
                                    int sourcePosition = (x + y * mybitmap.Width);
                                    int destinationY = x;
                                    int destinationPosition = (destinationX + destinationY * newWidth);
                                    rotatedPtr[destinationPosition] = myPtr[sourcePosition];
                                }
                            }
                        }
                        else if(angletorotate == 180)
                        {
                            for (int y = 0; y < mybitmap.Height; ++y)
                            {
                                int destinationY = (HeightMinusOne - y) * newWidth;
                                for (int x = 0; x < mybitmap.Width; ++x)
                                {
                                    int sourcePosition = (x + y * mybitmap.Width);
                                    int destinationX = WidthMinusOne - x;
                                    int destinationPosition = (destinationX + destinationY);
                                    rotatedPtr[destinationPosition] = myPtr[sourcePosition];
                                }
                            }
                        }

                        else if (angletorotate == 270)
                        {
                            for (int y = 0; y < mybitmap.Height; ++y)
                            {
                                int destinationX = y;
                                for (int x = 0; x < mybitmap.Width; ++x)
                                {
                                    int sourcePosition = (x + y * mybitmap.Width);
                                    int destinationY = HeightMinusOne - x;
                                    int destinationPosition = (destinationX + destinationY * newWidth);
                                    rotatedPtr[destinationPosition] = myPtr[sourcePosition];
                                }
                            }
                        }
                        // Unlock images.
                        mybitmap.UnlockBits(myLockedBitmap);
                        rotatedBitmap.UnlockBits(rotatedLockedBitmap);
                        
                        // set rotated image
                        image = new Bitmap(rotatedBitmap);
                }

               
            }
            catch (ZebraPrinterConnectionException i)
            {
                MessageBox.Show(i.StackTrace);
            }

        }

        /**
            * When folder icon is clicked, file explorer window is opened
            * **/
        private void pbxFolder_Click(object sender, EventArgs e)
        {
            try
            {
                // Let user navigate through the file system and select an image to send to the printer.
                OpenFileDialog dlgFile = new OpenFileDialog();
                dlgFile.Filter = "Image Files (*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png|All files (*.*)|*.*";
                dlgFile.FilterIndex = 1;
                if (dlgFile.ShowDialog() == DialogResult.OK)
                {
                    sFileName = dlgFile.FileName;
                }
            }
            catch
            {
            }
        }

    }
}