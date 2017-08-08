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
 File:    Printer Default.cs

 Description: Form and code demonstrating how to do a factory default on a Zebra printer using the ZSDK.
 This application is meant for a windows mobile device and connects to a Zebra Printer over Bluetooth.

 Revision: 1.0 
 Date: 06/25/10
 *******************************************************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using ZSDK_API.ApiException;
using ZSDK_API.Comm;
using ZSDK_API.Printer;



namespace Printer_Default
{
    public partial class PrinterDefaultForm : Form
    {
        String macAddress;
        ZebraPrinterConnection connection;
        ZebraPrinter printer;

        public PrinterDefaultForm()
        {
            InitializeComponent();
        }
        /**
         * When the "Default Printer" button is clicked, start the connection sequence
         * **/
        private void DefaultButton_Click(object sender, EventArgs e)
        {
            DefaultButton.Enabled = false;
            connectBT(macAddressTextBox.Text);
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

            }

        }

        /**
         * When a ZebraPrinterConnection has been established, this method 
         * gets the printer and gathers information from the printer such as 
         * the printer language.  ToolsUtil will then be used to default the printer.
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
                 * Get the printer instance and the printer language, then do a factory default on the printer.
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
                    ToolsUtil printer_default = printer.GetToolsUtil();
                    printer_default.RestoreDefaults();
                    updateGuiFromWorkerThread("Restoring Defaults", Color.Aqua);
                    Thread.Sleep(1000);
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
  * Called when the frame has been closed. Closes the open connection to 
  * a printer if one exists. 
  * **/
        private void OnClose(object sender, EventArgs e)
        {
            connection.Close();
        }

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

            connection = null;
            Invoke(new EventHandler(enablebutton));
        }
        private void enablebutton(object sender, EventArgs e)
        {
            DefaultButton.Enabled = true;
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


        private void disconnectButton_Click(object sender, EventArgs e)
        {
            disconnect();
        }
    }
}