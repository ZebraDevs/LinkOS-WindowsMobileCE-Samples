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
 File:   BluetoothDiscoverForm.cs

 Description: Form and code demonstrating how to discover nearby devices via
 * Bluetooth. Code detects all broadcasting Bluetooth devices, not just Zebra
 * Bluetooth devices. Demo also allows users to connect to Zebra devices via
 * Bluetooth that have been discovered.

 $Revision: 1 $
 $Date: 2010/06/03 $
 *******************************************************************************/

using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using ZSDK_API.Discovery;
using System.Threading;
using ZSDK_API.ApiException;
using ZSDK_API.Comm;
using ZSDK_API.Printer;

namespace Bluetooth_Discovery_Demo
{

    public partial class BluetoothDiscoveryForm : Form
    {
        String macAddress;
        private ZebraPrinterConnection connection;
        private ZebraPrinter printer;

        public BluetoothDiscoveryForm()
        {
            InitializeComponent();
        }

        /**
         * When discoverButton is clicked, start new thread to discover nearby bluetooth
         * devices
         * **/
        private void discoverButtonClicked(object sender, EventArgs e)
        {
            if (connection != null && connection.IsConnected())
            {
                connection.Close();
            }
            updateGuiFromWorkerThread("Discovery in progress...", Color.HotPink);
            
            discoveredPrintersListBox.Items.Clear();
            Thread t = new Thread(doBluetoothDiscovery);
            t.Start();
        }

        /**
         * When connectButton is clicked, start new thread to connect to the mac address
         * that is selected in the listbox
         * **/
        private void connectButtonClicked(object sender, EventArgs e)
        {
            macAddress = (String)discoveredPrintersListBox.SelectedItem;
            Thread t = new Thread(doConnectBT);
            t.Start();
        }
        /**
         * When disconnectButton is clicked, spawn a thread to disconnect from the
         * currently connected printer
         * **/
        public void onDisconnectButtonClicked(Object sender, EventArgs args)
        {
            disconnect();
        }

        /**
         * Called when the frame has been closed. Closes the open connection to 
         * a printer if one exists. 
         * **/
        public void onFrameClose(Object sender, CancelEventArgs args)
        {
            if (connection != null && connection.IsConnected())
            {
                connection.Close();
                connection = null;
            }
        }
        /**
         * Use BlutoothDiscoverer class to get an array of printers detected
         * Display printers in listbox
         * **/
        private void doBluetoothDiscovery()
        {
            
            updateButtonFromWorkerThread(false);
            Thread.Sleep(1000);
            try
            {
                DiscoveredPrinter[] printers = BluetoothDiscoverer.FindPrinters();
                displayPrinters(printers);
                updateButtonFromWorkerThread(true);
            }
            catch (DiscoveryException ex)
            {
                handleException(ex.Message);
                updateButtonFromWorkerThread(true);
            }
        }

        /**
         * Check that macAddress is valid
         * Connect to device using BluetoothPrinterConnection class
         * **/

        private void doConnectBT()
        {
            if (connection != null)
            {
                doDisconnect();
            }
            updateButtonFromWorkerThread(false);
            if (this.macAddress == null || this.macAddress.Length != 12)
            {
                updateGuiFromWorkerThread("Invalid MAC Address", Color.Red);
                disconnect();
            }
            else
            {
                updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod);
                try
                {
                    connection = new BluetoothPrinterConnection(this.macAddress);
                    connection.Open();
                    Thread.Sleep(1000);
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


                /**
                 * Get printer from ZebraPrinterFactory
                 * Get printer language
                 * Thread.Sleep allow statusBar updates to be seen before they change
                 * **/

                printer = null;
                if (connection != null && connection.IsConnected())
                {
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

                        updateGuiFromWorkerThread("Connected to " + macAddress, Color.Green);
                        Thread.Sleep(1000);
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
                    updateButtonFromWorkerThread(true);
                }
            }
        }

        /**
         * Start disconnect thread
         * **/
        public void disconnect()
        {
            Thread t = new Thread(doDisconnect);
            t.Start();
        }

        /**
         * Close connection to printer
         * **/
        private void doDisconnect()
        {
            updateButtonFromWorkerThread(false);
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
            connection = null;
            updateButtonFromWorkerThread(true);
        }

        /********************************************************************************
         * The following methods update the discovered printers listbox
         * *****************************************************************************/
        private void handleException(String message)
        {
            updateGuiFromWorkerThread(message, Color.Red);
            BeginInvoke(new MyProgressEventsHandler(UpdateDiscoveredPrinters), new object[] { this, new DiscoveredPrinter[] { } });
        }

        private delegate void MyProgressEventsHandler(object sender, DiscoveredPrinter[] printers);

        private void UpdateDiscoveredPrinters(object sender, DiscoveredPrinter[] printers)
        {
            foreach (DiscoveredPrinter printer in printers)
            {
                discoveredPrintersListBox.Items.Add(printer.Address);
            }
            discoveryButton.Enabled = true;
        }

        private void displayPrinters(DiscoveredPrinter[] printers)
        {
            updateGuiFromWorkerThread("Discovered " + printers.Length + " printers", Color.Green);
            BeginInvoke(new MyProgressEventsHandler(UpdateDiscoveredPrinters), new object[] { this, printers });
        }

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
         * The following methods enable and disable buttons as needed
         * ****************************************************************************/

        public void updateButtonFromWorkerThread(bool enabled)
        {
            Invoke(new ButtonStatusHandler(UpdateButton), enabled);
        }
        private delegate void ButtonStatusHandler(bool enabled);
        private void UpdateButton(bool enabled)
        {
            discoveryButton.Enabled = enabled;
            connectButton.Enabled = enabled;
            disconnectButton.Enabled = enabled;
        }
    }

    
}