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
using System.Drawing;
using System.Windows.Forms;
using ZSDK_API.Discovery;
using System.Threading;
using ZSDK_API.ApiException;
using System.Collections.Generic;

namespace ZebraDeveloperDemos {
    public partial class DiscoveryDemoForm : Form, DiscoveryHandler {

        public DiscoveryDemoForm() {
            InitializeComponent();
            discoveryMethodsComboBox.SelectedIndex = discoveryMethodsComboBox.Items.IndexOf("Multicast");
        }

        private void discoveryMethodsComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int methodSelection = discoveryMethodsComboBox.SelectedIndex;
            switch (methodSelection) {
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

        private void showMulticastPanel() {
            directBroadcastPanel.Visible = false;
            subnetPanel.Visible = false;
            multicastPanel.Visible = true;
        }

        private void showDirectBroadcastPanel() {
            directBroadcastPanel.Visible = true;
            subnetPanel.Visible = false;
            multicastPanel.Visible = false;
        }

        private void showSubnetPanel() {
            directBroadcastPanel.Visible = false;
            subnetPanel.Visible = true;
            multicastPanel.Visible = false;
        }

        private void hidePanels() {
            directBroadcastPanel.Visible = false;
            subnetPanel.Visible = false;
            multicastPanel.Visible = false;
        }

        private int discoveryMethodIndex;
        private int multicastValue;
        private String directedBroadcastAddress;
        private String subnetAddress;

        private void discoverButtonClicked(object sender, EventArgs e) {
            discoveryButton.Enabled = false;
            updateGuiFromWorkerThread("Discovery in progress...", Color.HotPink);
            discoveredPrintersListBox.Items.Clear();

            this.discoveryMethodIndex = discoveryMethodsComboBox.SelectedIndex;
            this.multicastValue = Convert.ToInt32(multicastHopUpDown.Value);
            this.directedBroadcastAddress = directBroadcastTextBox.Text;
            this.subnetAddress = subnetTextBox.Text;

            Thread t = new Thread(doDiscovery);
            t.Start();
        }

        private void doDiscovery() {
            switch (this.discoveryMethodIndex) {
                case 0:
                    doMulticast(this.multicastValue);
                    break;
                case 1:
                    doDirectBroadcast(this.directedBroadcastAddress);
                    break;
                case 2:
                    doLocalBroadcast();
                    break;
                case 3:
                    doSubnetSearch(this.subnetAddress);
                    break;
                case 4:
                    doBluetoothDiscovery();
                    break;
                default:
                    doFindPrintersNearMe();
                    break;
            }
        }

        private void doMulticast(int hops) {
            try {
                NetworkDiscoverer.Multicast(this, hops);
            } catch (DiscoveryException ex) {
                handleException(ex.Message);
            }
        }

        private void doDirectBroadcast(String directBroadcastRange) {
            try {
                DiscoveredPrinter[] printers = NetworkDiscoverer.DirectedBroadcast(directBroadcastRange);
                displayPrinters(printers);
            } catch (DiscoveryException ex) {
                handleException(ex.Message);
            }
        }

        private void doLocalBroadcast() {
            try {
                DiscoveredPrinter[] printers = NetworkDiscoverer.LocalBroadcast();
                displayPrinters(printers);
            } catch (DiscoveryException ex) {
                handleException(ex.Message);
            }
        }

        private void doSubnetSearch(String subnetRange) {
            try {
                DiscoveredPrinter[] printers = NetworkDiscoverer.SubnetSearch(subnetRange);
                displayPrinters(printers);
            } catch (DiscoveryException ex) {
                handleException(ex.Message);
            }
        }

        private void doFindPrintersNearMe() {
            try {
                NetworkDiscoverer.FindPrinters(this);
            } catch (DiscoveryException ex) {
                handleException(ex.Message);
            }
        }

        private void doBluetoothDiscovery() {
            try
            {
                displayPrinters(BluetoothDiscoverer.FindPrinters());
            }
            catch (DiscoveryException ex)
            {
                handleException(ex.Message);
            }
            catch (ZebraGeneralException)
            {
                handleException("Bluetooth not available");
            }
        }

        private void handleException(String message) {
            updateGuiFromWorkerThread(message, Color.Red);
            BeginInvoke(new MyProgressEventsHandler(UpdateDiscoveredPrinters), new object[] { this, new DiscoveredPrinter[] { } });
        }

        private delegate void MyProgressEventsHandler(object sender, DiscoveredPrinter[] printers);

        private delegate void MulticastEventHandler(DiscoveredPrinter printer);

        private static String GetPrinterDisplayName(DiscoveredPrinter printer) {
            String printerName = printer.Address;
            if (printer is DiscoveredPrinterBluetooth) {
                printerName += " (" + ((DiscoveredPrinterBluetooth)printer).FriendlyName + ")";
            } else if (printer is DiscoveredPrinterNetwork) {
                DiscoveredPrinterNetwork thisDiscoveredPrinterNetwork = (DiscoveredPrinterNetwork)printer;
                if (false == thisDiscoveredPrinterNetwork.Address.Equals(thisDiscoveredPrinterNetwork.DnsName)) {
                    printerName += " (" + thisDiscoveredPrinterNetwork.DnsName + ")";
                }
            }
            return printerName;
        }

        private void UpdateDiscoveredPrinters(object sender, DiscoveredPrinter[] printers) {
            foreach (DiscoveredPrinter printer in printers) {
                discoveredPrintersListBox.Items.Add(GetPrinterDisplayName(printer));
            }
            discoveryButton.Enabled = true;
        }

        private void displayPrinters(DiscoveredPrinter[] printers) {
            updateGuiFromWorkerThread("Discovered " + printers.Length + " printers", Color.Green);
            BeginInvoke(new MyProgressEventsHandler(UpdateDiscoveredPrinters), new object[] { this, printers });
        }

        public void updateGuiFromWorkerThread(String message, Color color) {
            Invoke(new StatusEventHandler(UpdateUI), new StatusArguments(message, color));
        }

        private delegate void StatusEventHandler(StatusArguments e);

        private void UpdateUI(StatusArguments e) {
            statusBar.Text = e.message;
            statusBar.BackColor = e.color;
        }

        private class StatusArguments : System.EventArgs {
            public String message;
            public Color color;

            public StatusArguments(String message, Color color) {
                this.message = message;
                this.color = color;
            }
        }

        public void FoundPrinter(DiscoveredPrinter printer) {
            Invoke(new MulticastEventHandler(UpdateListForMulticast), printer);
            Thread.Sleep(50); //artificial sleep so the user can see the printers being discovered
        }

        public void DiscoveryFinished() {
            updateGuiFromWorkerThread("Discovered " + discoveredPrintersListBox.Items.Count + " printers", Color.Green);
            Invoke((EventHandler)delegate {
                discoveryButton.Enabled = true;
            });
        }

        public void DiscoveryError(string message) {
            handleException(message);
        }

        private void UpdateListForMulticast(DiscoveredPrinter printer) {
            updateGuiFromWorkerThread("Discovered " + discoveredPrintersListBox.Items.Count + " printers", Color.Green);
            discoveredPrintersListBox.Items.Add(GetPrinterDisplayName(printer));
        }
    }
}