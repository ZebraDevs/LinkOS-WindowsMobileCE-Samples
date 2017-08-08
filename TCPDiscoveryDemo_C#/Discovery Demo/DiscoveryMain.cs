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
 File:   DiscoveryMain.cs

 Description: Form and code demonstrating how to discover and connect to printers
 * located on the network.

 $Revision: 1 $
 $Date: 06/30/2010 $
 *******************************************************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZSDK_API.Discovery;
using ZSDK_API.Printer;
using ZSDK_API.ApiException;
using ZSDK_API.Comm;
using System.Threading;

namespace Discovery_Demo
{
    public partial class DiscoveryMain : Form
    {
        private String ipAddress = "127.0.0.1";
        private int portNumber = 6101;
        private ZebraPrinterConnection connection;
        private ZebraPrinter printer;

        public DiscoveryMain()
        {
            InitializeComponent();
            discoveryMethodsComboBox.SelectedIndex = discoveryMethodsComboBox.Items.IndexOf("Multicast");
        }

        /**
         * Change GUI elements visible based on which discovery type is selected in the
         * drop down box.
         * **/
        private void discoveryMethodsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int methodSelection = discoveryMethodsComboBox.SelectedIndex;
            switch (methodSelection)
            {
                case 0:
                    showMulticastPanel();
                    break;
                case 1:
                    showDirectBroadcastPanel();
                    break;
                case 3:
                    showSubnetPanel();
                    break;
                default:
                    hidePanels();
                    break;
            }

        }

        /**
         * Show GUI elements for multicast selection
         * **/
        private void showMulticastPanel()
        {
            directBroadcastPanel.Visible = false;
            subnetPanel.Visible = false;
            multicastPanel.Visible = true;
            
        }

        /**
         * Show GUI elements for DirectBroadcast selection
         * **/
        private void showDirectBroadcastPanel()
        {
            directBroadcastPanel.Visible = true;
            subnetPanel.Visible = false;
            multicastPanel.Visible = false;
           
        }

        /**
         * Show GUI elements for subnet selection
         * **/
        private void showSubnetPanel()
        {
            directBroadcastPanel.Visible = false;
            subnetPanel.Visible = true;
            multicastPanel.Visible = false;   
        }

        /** 
         * Hide GUI elements
         * **/
        private void hidePanels()
        {
            directBroadcastPanel.Visible = false;
            subnetPanel.Visible = false;
            multicastPanel.Visible = false;   
        }

        private int discoveryMethodIndex;
        private int multicastValue;
        private String directedBroadcastAddress;
        private String subnetAddress;


        /**
         * When the discovery button is clicked, initiate discovery based on the selection
         * and information provided in the GUI
         * **/
        private void discoveryButton_Click(object sender, EventArgs e)
        {
            updateButtonFromWorkerThread(false);
            updateGuiFromWorkerThread("Discovery in progress...", Color.HotPink);
            discoveredPrintersListBox.Items.Clear();

            this.discoveryMethodIndex = discoveryMethodsComboBox.SelectedIndex;
            this.multicastValue = Convert.ToInt32(multicastHopUpDown.Value);
            this.directedBroadcastAddress = directBroadcastTextBox.Text;
            this.subnetAddress = subnetTextBox.Text;

            Thread t = new Thread(doDiscovery);
            t.Start();

        }

        private void doDiscovery()
        {
            switch (this.discoveryMethodIndex)
            {
                case 0:
                    doMulticast(this.multicastValue);
                    break;
                case 1:
                    doDirectBroadcast(this.directedBroadcastAddress);
                    break;
                case 2:
                    doLocalBroadcast();
                    break;
                default:
                    doSubnetSearch(this.subnetAddress);
                    break;
            }
        }

        

        private void doMulticast(int hops)
        {
            try
            {
                DiscoveredPrinter[] printers = NetworkDiscoverer.Multicast(hops);
                displayPrinters(printers);
            }
            catch (DiscoveryException ex)
            {
                handleException(ex.Message);
            }
        }

        private void doDirectBroadcast(String directBroadcastRange)
        {
            try
            {
                DiscoveredPrinter[] printers = NetworkDiscoverer.DirectedBroadcast(directBroadcastRange);
                displayPrinters(printers);
            }
            catch (DiscoveryException ex)
            {
                handleException(ex.Message);
            }
        }

        private void doLocalBroadcast()
        {
            try
            {
                DiscoveredPrinter[] printers = NetworkDiscoverer.LocalBroadcast();
                displayPrinters(printers);
            }
            catch (DiscoveryException ex)
            {
                handleException(ex.Message);
            }
        }

        private void doSubnetSearch(String subnetRange)
        {
            try
            {
                DiscoveredPrinter[] printers = NetworkDiscoverer.SubnetSearch(subnetRange);
                displayPrinters(printers);
            }
            catch (DiscoveryException ex)
            {
                handleException(ex.Message);
            }
        }

        /**
         * Delegate definitions for updating the GUI from a different thread.
         * **/
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
            updateButtonFromWorkerThread(true);
        }

        private void displayPrinters(DiscoveredPrinter[] printers)
        {
            updateGuiFromWorkerThread("Discovered " + printers.Length + " printers", Color.Green);
            BeginInvoke(new MyProgressEventsHandler(UpdateDiscoveredPrinters), new object[] { this, printers });
        }

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

        private class StatusArguments : System.EventArgs
        {
            public String message;
            public Color color;

            public StatusArguments(String message, Color color)
            {
                this.message = message;
                this.color = color;
            }
        }

        /**
         * Handle configuring and sending a test label to the currently connected printer
         * **/
        public void sendLabel()
        {
            ZebraPrinter printer = getPrinter();
            if (printer != null)
            {
                byte[] configLabel = getConfigLabel(printer.GetPrinterControlLanguage());
                getConnection().Write(configLabel);
                updateGuiFromWorkerThread("Sending Data", Color.CornflowerBlue);
                Thread.Sleep(2000);
            }
            disconnect();
        }
        private byte[] getConfigLabel(PrinterLanguage printerLanguage)
        {
            String configLabel = "";
            if (printerLanguage == PrinterLanguage.ZPL)
            {
                configLabel = "^XA^FO17,16^GB379,371,8^FS^FT65,255^A0N,135,134^FDTEST^FS^XZ";
            }
            else if (printerLanguage == PrinterLanguage.CPCL)
            {
                configLabel = "! 0 200 200 406 1\r\n" + "ON-FEED IGNORE\r\n"
                   + "BOX 20 20 380 380 8\r\n"
                   + "T 0 6 137 177 TEST\r\n"
                   + "PRINT\r\n";
            }
            return Encoding.Default.GetBytes(configLabel);
        }

        /************************************************************************************
         * The following methods handle connecting to and disconnecting from a 
         * printer over TCP
         * **********************************************************************************/

        private void doConnectTcp()
        {
            updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod);
            try
            {
                connection = new TcpPrinterConnection(this.ipAddress, this.portNumber);
                threadedConnect(this.ipAddress);
                sendLabel();
                disconnect();
            }
            catch (ZebraException)
            {
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                doDisconnect();
            }
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
                    printer = ZebraPrinterFactory.GetInstance(connection);
                    PrinterLanguage pl = printer.GetPrinterControlLanguage();
                    updateGuiFromWorkerThread("Printer Language " + pl.ToString(), Color.LemonChiffon);
                    Thread.Sleep(1000);
                    updateGuiFromWorkerThread("Connected to " + addressName, Color.Green);
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
            }
        }

        public void disconnect()
        {
            Thread t = new Thread(doDisconnect);
            t.Start();
        }

        private void doDisconnect()
        {
            try
            {
                if (connection != null && connection.IsConnected())
                {
                    updateGuiFromWorkerThread("Disconnecting", Color.Honeydew);
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

        /*******************************************************************************
         * End connection methods
         * *****************************************************************************/
        public ZebraPrinter getPrinter()
        {
            return printer;
        }

        public ZebraPrinterConnection getConnection()
        {
            return connection;
        }

        /**
         * When the connect button is clicked, attempt to connect to the ip address
         * selected in the list box using the port specified in the text box.
         * **/
        private void connectButton_Click(object sender, EventArgs e)
        {
            updateButtonFromWorkerThread(false);
            ipAddress = (String)discoveredPrintersListBox.SelectedItem;
            if (portTextBox.Text != null && portTextBox.Text != "")
            {
                portNumber = Convert.ToInt32(portTextBox.Text);
            }
            Thread t = new Thread(doConnectTcp);
            t.Start();
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
            connectButton.Enabled = enabled;
            discoveryButton.Enabled = enabled;
        }
        /*******************************************************************************
         * End enable button methods
         * ****************************************************************************/
        
    }
}