/**************************************************************************************************** 
 * CONFIDENTIAL AND PROPRIETARY 
 *
 * The source code and other information contained herein is the confidential and the exclusive property of
 * Zebra Technologies Corporation and is subject to the terms and conditions in your end user license agreement.
 * This source code, and any other information contained herein, shall not be copied, reproduced, published, 
 * displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
 * expressly permitted under such license agreement.
 * 
 * Copyright Zebra Technologies Corporation 2010
 *
 * ALL RIGHTS RESERVED 
 *****************************************************************************************************/

/*********************************************************************************************
 File:   CameraPrintForm.cs

 Descr:  Contains classes and routines to connect and disconnect mobile device with zebra 
 * printer using bluetooth connection. This demo application allows the user to take a picture 
 * with the WinMobile Device's camera and print it to the printer.

 Date: 06/23/2010 
 
 Rev Date: 06/25/2010
 *********************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Forms;        // Required to use the camera.  Also, need to add reference
using ZSDK_API.Printer;
using ZSDK_API.Comm;
using ZSDK_API.Util.Internal;
using ZSDK_API.ApiException;

namespace CameraPrint
{
    public partial class CameraPrintForm : Form
    {
        

        private ZebraPrinterConnection zebraPrinterConnection = null;
        private String VersionString = "1.0";

        /***************************************************************************************************
        Desc: Constructor
        ****************************************************************************************************/
        public CameraPrintForm()
        {
            InitializeComponent();

            statusLabel.Text = "Status: Disconnected.";
           
            this.Text = "CameraPrint ";
            this.Text += VersionString;
        }

        private void CameraPrintForm_Load(object sender, EventArgs e)
        {
           
        }

        /**********************************************************************************
        Desc: This sends the selected image file to zebra printer for printing.
        ***********************************************************************************/
        private void printImage(String filePath)
        {
            if (zebraPrinterConnection != null && macAddrBox.Text.Length == 12)
            {
                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(zebraPrinterConnection);

                // Send image to print
                printer.GetGraphicsUtil().PrintImage(filePath, 0, 0, 550, 412, false);
            }
        }

        /**********************************************************************************
        Desc: This function is called when Camera Print button is clicked. Pops up Camera 
         * capture dialog box and allows user to take an image and send that image to print.
        ***********************************************************************************/
        private void CameraPrintButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("After taking the photo, some devices require exiting the Camera App for the image to be sent to the printer.", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            // Opens camera capture dialog box
            CameraCaptureDialog cam = new CameraCaptureDialog();
            cam.Owner = this;
            try
            {
                DialogResult result = cam.ShowDialog();

                // Send image for printing
                if (result == DialogResult.OK)
                {
                    printImage(cam.FileName);
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No Camera Found");
                return;
            }

            
        }

        /****************************************************************************************************
        Desc: Called when Connect button is clicked. Open a bluetooth connection with printer using MAC address
        *****************************************************************************************************/
        private void connectButton_Click(object sender, EventArgs e)
        {
            //Check validity of mac address
            if (macAddrBox.Text.Length != 12)
            {
                MessageBox.Show("Enter valid MAC address!");
                return;
            }

            //Creating a bluetooth connection with zebra printer
            if (zebraPrinterConnection == null && macAddrBox.Text.Length == 12)
            {
                zebraPrinterConnection = new BluetoothPrinterConnection(macAddrBox.Text);
                statusLabel.Text = "Status: Connecting to..." + macAddrBox.Text;
                statusLabel.BackColor = System.Drawing.Color.Gold;
                Application.DoEvents();
                try
                {
                    zebraPrinterConnection.Open();
                    while (!zebraPrinterConnection.IsConnected()) { }
                }
                catch (ZebraPrinterConnectionException)
                {
                    statusLabel.Text = "Status: Disconnected.";
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                    zebraPrinterConnection = null;
                    MessageBox.Show("Unable to connect with printer.");
                    return;
                }
                catch (ZebraException)
                {
                    statusLabel.BackColor = Color.Red;
                    statusLabel.Text = "Status : Disconnected.";
                    zebraPrinterConnection = null;
                    MessageBox.Show("Unable to connect with printer.\r\nCheck that printer is on.");
                    return;
                }
                catch (Exception)
                {
                    statusLabel.BackColor = Color.Red;
                    statusLabel.Text = "Status : Disconnected.";
                    zebraPrinterConnection = null;
                    MessageBox.Show("Connection Failed.");
                    return;
                }
                statusLabel.Text = "Status: Connected to " + macAddrBox.Text;
                statusLabel.BackColor = System.Drawing.Color.Green;
            }
        }

        /*****************************************************************************************************
        Desc: Called when Disconnect button is clicked. Close the Bluetooth connection with printer.
        ******************************************************************************************************/
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Close the connection
                if (zebraPrinterConnection != null)
                {
                    zebraPrinterConnection.Close();
                }
            }
            catch (ZebraPrinterConnectionException)
            {
                MessageBox.Show("Unable to disconnect with printer.");
                return;
            }
            catch (ZebraException)
            {
                MessageBox.Show("Unable to disconnect with printer.\r\nCheck that printer is on.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Disconnect Failed.");
                return;
            }
            zebraPrinterConnection = null;
            statusLabel.BackColor = Color.Red;
            statusLabel.Text = "Status : Disconnected.";
        }
     }
}