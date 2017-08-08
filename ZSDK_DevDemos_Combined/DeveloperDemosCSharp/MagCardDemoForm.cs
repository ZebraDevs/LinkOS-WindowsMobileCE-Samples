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
using System.Threading;
using ZSDK_API.Printer;

namespace ZebraDeveloperDemos {

    public partial class MagCardDemoForm : ZebraForm {

        public MagCardDemoForm() {
            connectionEstablished += new PrinterConnectionHandler(connectionIsEstablished);
            connectionClosed += new PrinterConnectionHandler(connectionIsClosed);
            InitializeComponent();
            zebraConnectionPanel = connectionPanel;
        }

        private void doConnect(object sender, EventArgs e) {
            if (connectButton.Text.Equals("Connect")) {
                connectButton.Enabled = false;
                connect();
            } else {
                disconnect();
            }
        }

        private void magCardButtonPressed(object sender, EventArgs e) {
            readMagCardButton.Enabled = false;
            Thread t = new Thread(doReadMagCard);
            t.Start();
        }

        private void doReadMagCard() {
            updateGuiFromWorkerThread("Waiting for swipe...", Color.Gold);
            ZebraPrinter printer = getPrinter();
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
        }

        private delegate void MagCardEventHandler(String[] e);
        public void updateGuiTracks(String[] tracks) {
            object[] pList = { tracks };
            Invoke(new MagCardEventHandler(UpdateUI), pList);
        }

        private void UpdateUI(String[] tracks) {
            track1Value.Text = tracks[0];
            track2Value.Text = tracks[1];
            track3Value.Text = tracks[2];
            readMagCardButton.Enabled = true;
        }

        private delegate void GenericEventHandler();
        private void connectionIsEstablished() {
            Invoke(new GenericEventHandler(ConnectedButtonSettings));
        }

        private void ConnectedButtonSettings() {
            connectButton.Text = "Disconnect";
            connectButton.Enabled = true;
            readMagCardButton.Enabled = true;
        }

        private void connectionIsClosed() {
            Invoke(new GenericEventHandler(NoConnectionButtonSettings));
        }

        private void NoConnectionButtonSettings() {
            connectButton.Text = "Connect";
            connectButton.Enabled = true;
            readMagCardButton.Enabled = false;
        }

        private void MagCardDemoForm_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (getConnection() != null) {
                getConnection().Close();
            }
        }
    }
}