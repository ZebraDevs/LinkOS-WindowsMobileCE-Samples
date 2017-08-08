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
using System.Text;
using ZSDK_API.Printer;
using System.Threading;
using ZSDK_API.ApiException;


namespace ZebraDeveloperDemos {

    public partial class ListFormatsDemoForm : ZebraForm {
        private delegate void ButtonEnablingEventHandler(bool state);
        private delegate void ListBoxEventHandler(String listOfFiles);

        public ListFormatsDemoForm() {
            InitializeComponent();
            this.zebraConnectionPanel = connectionPanel;
            connectionEstablished += new PrinterConnectionHandler(connected);
            connectionClosed += new PrinterConnectionHandler(connectionIsClosed);
        }

        private void connectDisconnectButtonPressed(object sender, EventArgs e) {
            Invoke(new ButtonEnablingEventHandler(toggleButtonEnabled), false);
            fileListPanel.SendToBack();
            if (getConnection() != null && getConnection().IsConnected()) {
                disconnect();
            } else {
                connect();
            }
        }

        private void listFormatsButton_Click(object sender, EventArgs e) {
            fileListPanel.SendToBack();
            Thread t = new Thread(getListOfAllFormats);
            t.Start();
        }

        private void getListOfAllFormats() {
            Invoke(new ButtonEnablingEventHandler(toggleButtonEnabled), false);
            updateGuiFromWorkerThread("Retrieving Formats...", Color.Gold);
            ZebraPrinter printer = getPrinter();
            try {
                String[] formats;
                PrinterLanguage pl = printer.GetPrinterControlLanguage();
                if (pl == PrinterLanguage.ZPL) {
                    formats = new String[] { "ZPL" };
                } else {
                    formats = new String[] { "FMT", "LBL" };
                }
                String[] formatNames = printer.GetFileUtil().RetrieveFileNames(formats);
                StringBuilder sb = new StringBuilder();
                sb.Append("Printer Format Files:\r\n");
                foreach (String formatName in formatNames) {
                    sb.Append("\r\n" + formatName);
                }
                updateGuiFromWorkerThread("Done Retrieving Formats...", Color.Lime);
                Thread.Sleep(500);
                Invoke(new ListBoxEventHandler(displayNames), sb.ToString());
            } catch (ZebraException) {
                updateGuiFromWorkerThread("Error Retrieving Formats", Color.Red);
            }
            Invoke(new ButtonEnablingEventHandler(toggleButtonEnabled), true);
        }

        private void listFilesButton_Click(object sender, EventArgs e) {
            fileListPanel.SendToBack();
            Thread t = new Thread(getListOfAllFiles);
            t.Start();
        }

        private void getListOfAllFiles() {
            Invoke(new ButtonEnablingEventHandler(toggleButtonEnabled), false);
            updateGuiFromWorkerThread("Retrieving Files...", Color.Gold);
            ZebraPrinter printer = getPrinter();
            try {
                String[] fileNames = printer.GetFileUtil().RetrieveFileNames();
                StringBuilder sb = new StringBuilder();
                sb.Append("All Files:\r\n");
                foreach (String fileName in fileNames) {
                    sb.Append("\r\n" + fileName);
                }
                updateGuiFromWorkerThread("Done Retrieving Files...", Color.Lime);
                Thread.Sleep(500);
                Invoke(new ListBoxEventHandler(displayNames), sb.ToString());
            } catch (ZebraException) {
                updateGuiFromWorkerThread("Error Retrieving Files", Color.Red);
            }
            Invoke(new ButtonEnablingEventHandler(toggleButtonEnabled), true);
        }


        public void toggleButtonEnabled(bool state) {
            connectButton.Enabled = state;
            optionsMenu.Enabled = state;
        }

        private void displayNames(String listOfFiles) {
            fileListPanel.BringToFront();
            filesOnPrinterListBox.Text = listOfFiles;
        }

        private void connected() {
            Invoke(new PrinterConnectionHandler(enableDisconnectButton));
        }

        private void enableDisconnectButton() {
            optionsMenu.Enabled = true;
            connectButton.Text = "Disconnect";
            connectButton.Enabled = true;
        }

        private void connectionIsClosed() {
            Invoke(new PrinterConnectionHandler(enableConnectButton));
        }

        private void enableConnectButton() {
            connectButton.Text = "Connect";
            connectButton.Enabled = true;
        }

        private void ListFormatsDemoForm_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (getConnection() != null) {
                getConnection().Close();
            }
        }

    }
}