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
 ***********************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ZebraDeveloperDemos {
    public partial class SignatureCaptureDemoForm : ZebraForm {

        private delegate void GenericEventHandler();
        bool isMouseDown = false;
        int lastPointX = -1;
        int lastPointY = -1;
        Bitmap b;
        Graphics g;
        Pen pen;


        public SignatureCaptureDemoForm() {
            connectionEstablished += new PrinterConnectionHandler(connectionIsEstablished);
            connectionClosed += new PrinterConnectionHandler(connectionIsClosed);
            InitializeComponent();
            zebraConnectionPanel = connectionPanel;
            b = new Bitmap(signatureBox.Width, signatureBox.Height);
            g = Graphics.FromImage(b);
            g.Clear(Color.White);
            signatureBox.Image = b;
            pen = new Pen(Color.Black, 2);
        }

        private void connectionIsEstablished() {
            Invoke(new GenericEventHandler(ConnectedButtonSettings));
        }

        private void ConnectedButtonSettings() {
            connectButton.Text = "Disconnect";
            connectButton.Enabled = true;
            printButton.Enabled = true;
        }

        private void connectionIsClosed() {
            Invoke(new GenericEventHandler(NoConnectionButtonSettings));
        }

        private void NoConnectionButtonSettings() {
            connectButton.Text = "Connect";
            connectButton.Enabled = true;
            printButton.Enabled = false;
        }

        private void connectButton_Click(object sender, EventArgs e) {
            if (connectButton.Text.Equals("Connect")) {
                connect();
            } else {
                disconnect();
            }
        }
        
        private Bitmap bitmapToPrint;

        private void printButton_Click(object sender, EventArgs e) {
            this.bitmapToPrint = (Bitmap)b.Clone();

            Thread t = new Thread(doPrintImage);
            t.Start();

            g.Clear(Color.White);
            signatureBox.Invalidate();
        }

        private void doPrintImage() {
            getPrinter().GetGraphicsUtil().PrintImage(this.bitmapToPrint, 0, 0, this.bitmapToPrint.Width, this.bitmapToPrint.Height, false);
        }

        private void signatureBox_MouseDown(object sender, MouseEventArgs e) {
            isMouseDown = true;
            lastPointX = e.X;
            lastPointY = e.Y;
        }

        private void signatureBox_MouseMove(object sender, MouseEventArgs e) {
            if (isMouseDown) {
                g.DrawLine(pen, lastPointX, lastPointY, e.X, e.Y);
                signatureBox.Invalidate();
                lastPointX = e.X;
                lastPointY = e.Y;
            }
        }

        private void signatureBox_MouseUp(object sender, MouseEventArgs e) {
            isMouseDown = false;
        }
    }
}