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
using ZSDK_API.Comm;
using ZSDK_API.Printer;
using System.Threading;
using ZSDK_API.ApiException;

namespace ZebraDeveloperDemos {

    public partial class PrinterStatusDemoForm : ZebraForm {

        public PrinterStatusDemoForm() {
            InitializeComponent();
            connectionEstablished += new PrinterConnectionHandler(connected);
            connectionClosed += new PrinterConnectionHandler(disconnected);
            zebraConnectionPanel = connectionPanel;
            connectionPanel.BringToFront();
        }

        private void leftSideButton_Click(object sender, EventArgs e) {
            leftSideButton.Enabled = false;
            if(leftSideButton.Text.Equals("Connect")) {
               connect();
            } else {
                Thread t = new Thread(doDisconnect);
                t.Start();
            }
        }

        private void doDisconnect() {
            disconnect();
            Invoke(new EventHandler(updateConnectButton));
        }

        private void updateConnectButton(object sender, EventArgs e) {
            statusPanel.SendToBack();
            leftSideButton.Text = "Connect";
            leftSideButton.Enabled = true;
        }
        private void connected() {
            Invoke(new EventHandler(connectedThread));
        }

        private void disconnected() {
            Invoke(new EventHandler(updateConnectButton));
        }

        private void connectedThread(object sender, EventArgs e) {
            statusPanel.BringToFront();
            leftSideButton.Text = "Disconnect";
            leftSideButton.Enabled = true;

            Thread t = new Thread(statusUpdateThread);
            t.Start();
        }

        private void statusUpdateThread() {
            try {
                ZebraPrinterConnection connection = getConnection();
                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(connection);
                String statusMessages;

                while (getConnection() != null && connection.IsConnected()) {
                    PrinterStatus printerStatus = printer.GetCurrentStatus();
                    PrinterStatusMessages messages = new PrinterStatusMessages(printerStatus);
                    String[] messagesArray = messages.GetStatusMessage();

                    statusMessages = "Ready to Print: " + Convert.ToString(printerStatus.IsReadyToPrint);
                    statusMessages += "\r\nLabels in Batch: " + Convert.ToString(printerStatus.LabelsRemainingInBatch);
                    statusMessages += "\r\nLabels in Buffer: " + Convert.ToString(printerStatus.NumberOfFormatsInReceiveBuffer) + "\r\n\r\n";
                    
                    foreach (String message in messagesArray) {
                        statusMessages += message + "\r\n";
                    }
                    Invoke(new statusEventHandler(updateStatusMessage), statusMessages);
                    Thread.Sleep(4000);
                }
            } catch (ZebraException) {
                disconnected();
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
            }
        }

        private delegate void statusEventHandler(String statusMessages);

        private void updateStatusMessage(String messages) {
            statusMessages.Text = messages;
        }

        private void PrinterStatusDemoForm_Closed(object sender, EventArgs e) {
            disconnect();
        }
    }
}