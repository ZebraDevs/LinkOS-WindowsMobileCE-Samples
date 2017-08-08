/********************************************** 
 * CONFIDENTIAL AND PROPRIETARY 
 *
 * The source code and other information contained herein is the confidential and the exclusive property of
 * ZIH Corporation and is subject to the terms and conditions in your end user license agreement.
 * This source code, and any other information contained herein, shall not be copied, reproduced, published, 
 * displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
 * expressly permitted under such license agreement.
 * 
 * Copyright ZIH Corporation 2010
 *
 * ALL RIGHTS RESERVED 
 ***********************************************/

/********************************************************************************************************************
 File:   WinCEComm.cs
 
 Descr:  Contains classes and routines to demonstrate USB/Bluetooth connectivity between WinCE device and 
 * Zebra ZPL printer.
 
 Date: 11/11/2011 
  
 *********************************************************************************************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using ZSDK_API.Comm;
using ZSDK_API.ApiException;
using ZSDK_API;

namespace USBComm
{
    public partial class WinCEComm : Form
    {

        protected ZebraPrinterConnection thePrinterConn = null;
        protected String statusString = null;
        public WinCEComm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void USBComm_Load(object sender, EventArgs e)
        {
           
            commType.SelectedIndex = 0;
            usbPanel.Location = new Point(29, 71);
            usbPanel.Width = 568;
            usbPanel.Height = 240;
            usbPanel.Controls.Add(usbLabelSend);
            usbPanel.Controls.Add(usbLabelResponse);
            usbPanel.Controls.Add(usbSndList);
            
            usbPanel.Controls.Add(usbListResponse);
            usbPanel.Controls.Add(usbBtnSend);            
            bluetoothPanel.Location = new Point(29, 71);
            bluetoothPanel.Width = 568;
            bluetoothPanel.Height = 252;
            bluetoothPanel.Controls.Add(btAddrLabel);
            bluetoothPanel.Controls.Add(btAddress);
            bluetoothPanel.Controls.Add(btConnect);
            bluetoothPanel.Controls.Add(btDisconnect);
            bluetoothPanel.Controls.Add(bluetoothLabelSend);
            bluetoothPanel.Controls.Add(bluetoothLabelResponse);
            bluetoothPanel.Controls.Add(bluetoothSndList);
            bluetoothPanel.Controls.Add(bluetoothListResponse);
            bluetoothPanel.Controls.Add(bluetoothBtnSend);
            bluetoothPanel.Hide();
            
        }

        private void commType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (commType.SelectedIndex == 0)
            {
                bluetoothPanel.Hide();
                usbListResponse.Items.Clear();
                usbPanel.Show();
                
            }
            else
            {
                usbPanel.Hide();
                bluetoothListResponse.Items.Clear();
                bluetoothPanel.Show();                
            }
        }

        /****************************************************************************************************
        Description: Opens a usb connection with the printer. Sends selected zpl command to the printer and reads
        response.
        *****************************************************************************************************/
        private void usbBtnSend_Click(object sender, EventArgs e)
        {
            String cmdSend = null;
            String readResponse = null;
            int nBytes = 0;

            if (usbSndList.SelectedIndex >= 0)
            {
                try
                {
                    // Instantiate connection for ZPL USB port with a given port name. 
                    thePrinterConn = new UsbPrinterConnection("LPT1:"); // "LPT" is the default prefix for most Windows CE/Mobile USB ports 

                    // Open the connection - physical connection is established here.
                    thePrinterConn.Open();

                    // This example prints "This is a ZPL test." near the top of the label.
                    cmdSend = usbSndList.SelectedItem.ToString() + "\r\n";

                    // Send the data to printer as a byte array.
                    thePrinterConn.Write(Encoding.Default.GetBytes(cmdSend));

                    statusString = "Command Sent: " + cmdSend.Trim();
                    usbListResponse.Items.Add(statusString);
                    Thread.Sleep(500);
                    nBytes = thePrinterConn.BytesAvailable();
                    byte[] bData = new byte[nBytes];
                    bData = thePrinterConn.Read();
                    readResponse = System.Text.ASCIIEncoding.ASCII.GetString(bData, 0, bData.Length);
                    statusString = "Received Data: " + readResponse;

                    // If response is longer than devide the received byte stream into multiple 
                    // streams of 46 characters to diplay it properly in listbox.
                    if (statusString.Length < 46)
                    {
                        usbListResponse.Items.Add(statusString);
                    }
                    else
                    {
                        String tempStatusString = statusString;
                        while (tempStatusString.Length > 0)
                        {
                            if ((tempStatusString.Length - 46) > 0)
                            {
                                usbListResponse.Items.Add(tempStatusString.Substring(0, 46));
                                tempStatusString = tempStatusString.Remove(0, 46);
                            }
                            else
                            {
                                usbListResponse.Items.Add(tempStatusString.Substring(0, tempStatusString.Length));
                                tempStatusString = tempStatusString.Remove(0, tempStatusString.Length);
                            }
                        }
                    }

                    usbListResponse.Refresh();

                    // Close the connection to release resources.
                    thePrinterConn.Close();
                    thePrinterConn = null;

                }
                catch (ZebraPrinterConnectionException)
                {
                    // Handle communications error here.
                    MessageBox.Show("Unable to connect with printer.");
                    return;
                }
                catch (ZebraException)
                {
                    MessageBox.Show("Unable to connect with printer.\r\nCheck that printer is on.");
                    return;
                }
                catch (Exception)
                {
                    MessageBox.Show("Exception Thrown");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select a command to be Sent...");
                return;
            }
        

        }

        /****************************************************************************************************
        Description: Opens a bluetooth connection with the Zebra printer. 
        *****************************************************************************************************/
        private void btConnect_Click(object sender, EventArgs e)
        {
            if (btAddress.Text.Length < 12)
            {
                MessageBox.Show("Please Enter valid MAC address");
            }
            else
            {
                try
                {
                    // Instantiate a connection for given Bluetooth(R) MAC Address.
                    thePrinterConn = new BluetoothPrinterConnection(btAddress.Text);

                    // Open the connection - physical connection is established here.
                    thePrinterConn.Open();
                    statusString = "Connected";
                    bluetoothListResponse.Items.Add(statusString);
                }
                catch (ZebraPrinterConnectionException)
                {
                    // Handle communications error here.
                    MessageBox.Show("Unable to connect with printer.");
                    return;
                }
                catch (ZebraException)
                {
                    MessageBox.Show("Unable to connect with printer.\r\nCheck that printer is on or it supports Bluetooth.");
                    return;
                }
                catch (Exception)
                {
                    MessageBox.Show("Exception Thrown");
                    return;
                }
            }

        }

        /****************************************************************************************************
        Description: Closes the bluetooth connection with the Zebra printer. 
        *****************************************************************************************************/
        private void btDisconnect_Click(object sender, EventArgs e)
        {
            if (thePrinterConn != null)
            {
                statusString = "Not Connected";
                bluetoothListResponse.Items.Add(statusString);
                thePrinterConn.Close();
            }
            thePrinterConn = null;
        }

        /****************************************************************************************************
        Description: Sends a selected ZPL command to the Zebra printer over bluetooth and reads response. 
        *****************************************************************************************************/
        private void bluetoothBtnSend_Click(object sender, EventArgs e)
        {
            String cmdSend = null;
            String readResponse = null;
            int nBytes = 0;
            if (thePrinterConn != null)
            {
                if (bluetoothSndList.SelectedIndex >= 0)
                {
                    cmdSend = bluetoothSndList.SelectedItem.ToString();
                    thePrinterConn.Write(Encoding.Default.GetBytes(cmdSend));
                    statusString = "Command Sent: " + cmdSend.Trim();
                    bluetoothListResponse.Items.Add(statusString);
                    Thread.Sleep(500);
                    nBytes = thePrinterConn.BytesAvailable();
                    byte[] bData = new byte[nBytes];
                    bData = thePrinterConn.Read();
                    readResponse = System.Text.ASCIIEncoding.ASCII.GetString(bData, 0, bData.Length);
                    statusString = "Received Data: " + readResponse;
                    bluetoothListResponse.Items.Add(statusString);
                }
                else
                {
                    MessageBox.Show("Select command to be sent.");
                }
            }
            else
            {
                MessageBox.Show("The printer isn't connected. Please connect the printer before sending commnd...");
            }

        }

        private void usbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBtExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}