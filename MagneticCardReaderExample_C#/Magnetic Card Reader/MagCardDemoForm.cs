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
 File:   MagCardDemoForm.cs

 Description: Form and code demonstrating how to connect to a Zebra printer and
 * read a magnetic card from the card reader on the printer. The printer must
 * have a magnetic card reader in order for this application to work. 

 $Revision: 1 $
 $Date: 2010/06/07 $
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

namespace Magnetic_Card_Reader
{
    public partial class MagCardDemoForm : Form
    {
        String macAddress;
        ZebraPrinterConnection connection;
        ZebraPrinter printer;

        public MagCardDemoForm()
        {
            InitializeComponent();
        }

        /**
         * Called when "Connect" button is clicked
         * Starts Bluetooth connection
         * **/
        public void onConnectButtonClick(Object sender, EventArgs args)
        {
            UpdateTracks(new String[] { "", "", "" });
            connectBT(macTextBox.Text.Trim());
            updateButtonFromWorkerThread(false);
        }

        /**
         * Called when "Read" Button is clicked
         * Starts card reading if device is already connected to a printer
         * **/
        public void onReadButtonClick(Object sender, EventArgs args)
        {
            UpdateTracks(new String[]{"","",""});
            updateButtonFromWorkerThread(false);
            Thread t = new Thread(doReadMagCard);
            t.Start();
        }

        /**
         * When disconnectButton is clicked, spawn a thread to disconnect from the
         * currently connected printer
         * **/
        public void disconnectButtonClicked(Object sender, EventArgs args)
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
         * Thread for reading magnetic card swiped through printer
         * **/
        private void doReadMagCard() {
            updateGuiFromWorkerThread("Waiting for swipe...", Color.Gold);
            if (printer != null) {
                MagCardReader mcr = printer.GetMagCardReader();
                if (mcr != null) {
                    String[] tracks = mcr.Read(10 * 1000);
                    updateGuiTracks(tracks);
                    updateGuiFromWorkerThread("Done", Color.Blue);
                } else {
                    updateGuiFromWorkerThread("Failed to swipe", Color.Red);
                }
            } else {
                updateGuiFromWorkerThread("Connection error", Color.Red);
            }
            updateButtonFromWorkerThread(true);
        }

        /** 
         * Delegate and method for updating track values from thread
         * **/
        private delegate void MagCardEventHandler(String[] e);
        public void updateGuiTracks(String[] tracks) {
            object[] pList = { tracks };
            Invoke(new MagCardEventHandler(UpdateTracks), pList);
        }
        private void UpdateTracks(String[] tracks) {
            track1Value.Text = tracks[0];
            track2Value.Text = tracks[1];
            track3Value.Text = tracks[2];
        }

        /***********************************************************************
         * The following methods handle connection to printer
         * ********************************************************************/

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
            
            if (connection != null)
            {
                Thread t = disconnect();
                t.Join();
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
                    try
                    {
                        connection = new BluetoothPrinterConnection(this.macAddress);
                        threadedConnect(this.macAddress);
                    }
                    catch (ZebraException)
                    {
                        updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                        Thread.Sleep(1000);
                        disconnect();
                    }
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
            updateButtonFromWorkerThread(true);
            
        }
        private void threadedConnect(String addressName)
        {
            try
            {
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
            Thread.Sleep(1000);
            updateButtonFromWorkerThread(true);
            updateGuiFromWorkerThread("Ready", Color.Yellow);
            connection = null;
            updateButtonFromWorkerThread(true);
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
            readButton.Enabled = enabled;
            connectButton.Enabled = enabled;
            disconnectButton.Enabled = enabled;
        }
        /*******************************************************************************
         * End enable button methods
         * ****************************************************************************/

    }
}