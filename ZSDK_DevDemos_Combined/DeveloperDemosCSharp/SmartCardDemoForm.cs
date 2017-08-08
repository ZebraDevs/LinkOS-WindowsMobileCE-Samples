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
using ZSDK_API.Discovery;
using System.Threading;
using ZSDK_API.Printer;

namespace ZebraDeveloperDemos {
    public partial class SmartCardDemoForm : ZebraForm {

        private delegate void GenericEventHandler();
        MenuItem lastButtonPressed;

        public SmartCardDemoForm() {
            connectionEstablished += new PrinterConnectionHandler(connectionIsEstablished);
            connectionClosed += new PrinterConnectionHandler(connectionIsClosed);
            InitializeComponent();
            zebraConnectionPanel = connectionPanel;
            lastButtonPressed = sendCtAtrButton;
        }

        private void ConnectedButtonSettings() {
            sendCtAtrButton.Enabled = false;
            sendCtDataButton.Enabled = false;
        }

        private void connectionIsClosed() {
            Invoke(new GenericEventHandler(NoConnectionButtonSettings));
        }

        private void NoConnectionButtonSettings() {
            sendCtAtrButton.Enabled = true;
            sendCtDataButton.Enabled = true;
        }

        private void sendCtAtrButtonPressed(object sender, EventArgs e) {
            handleButtonPressedEvent(sender);
        }
        
        private void sendCtDataButtonPressed(object sender, EventArgs e) {
            handleButtonPressedEvent(sender);
        }

        private String tempResponseString;

        private void handleButtonPressedEvent(object sender) {
            Invoke(new GenericEventHandler(ConnectedButtonSettings));

            this.tempResponseString = "Waiting for response...";
            Invoke(new GenericEventHandler(updateResponseTextBox));
            lastButtonPressed = (MenuItem)sender;
            connect();
        }

        private void updateResponseTextBox() {
            responseTextBox.Text = this.tempResponseString;
        }

        private void connectionIsEstablished() {
            Thread t = new Thread(doCommand);
            t.Start();
            t.Join(10000);
            disconnect();
        }

        private void doCommand() {
            SmartcardReader reader = getPrinter().GetSmartcardReader();
            if (reader != null) {
                updateGuiFromWorkerThread("Sending Command...", Color.Gold);
                Thread.Sleep(1000);

                byte[] smartCardResponse;

                if (lastButtonPressed == sendCtAtrButton) {
                    smartCardResponse = reader.GetATR();
                } else {
                    smartCardResponse = reader.DoCommand("8010000008");
                }
                reader.Close();
                formatAndDisplayResponse(smartCardResponse);
            } else {
                updateGuiFromWorkerThread("Printer does not support Smartcard reader", Color.Red);
            }
        }

        private void formatAndDisplayResponse(byte[] response) {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in response) {
                sb.Append(b.ToString("X2"));
            }
            this.tempResponseString = sb.ToString();
            Invoke(new GenericEventHandler(updateResponseTextBox));
        }

        private void SmartCardDemoForm_Closing(object sender, CancelEventArgs e) {
            if (getConnection() != null) {
                getConnection().Close();
            }
        }
    }
}