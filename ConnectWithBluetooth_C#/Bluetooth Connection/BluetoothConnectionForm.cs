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
 File:    BluetoothConnectionForm.cs

 Description: Form and code demonstrating how to connect a windows mobile
 * device to a Zebra Printer over Bluetooth.

 $Revision: 1 $
 $Date: 2010/06/04 $
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

namespace Bluetooth_Connection
{
    public partial class BluetoothConnectionForm : Form
    {
        String macAddress;
        ZebraPrinterConnection connection;
        ZebraPrinter printer;
        
        public BluetoothConnectionForm()
        {
            InitializeComponent();
        }

        /**
         * When the "Connect" button is clicked, start the connection sequence
         * **/
        private void onConnectButtonClick(Object sender, EventArgs args)
        {
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
         * the printer language
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
                 * Get the printer instance and the printer language
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
                    updateGuiFromWorkerThread("Connected to " + addressName, Color.Green);
                    Thread.Sleep(1000);
                    //disconnect();
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
            updateGuiFromWorkerThread("Ready", Color.Yellow);
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
            connectButton.Enabled = enabled;
        }
        /*******************************************************************************
         * End enable button methods
         * ****************************************************************************/

    }
}