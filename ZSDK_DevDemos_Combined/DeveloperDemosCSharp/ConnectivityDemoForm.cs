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
using ZSDK_API.Printer;
using System.Text;
using System.Threading;

namespace ZebraDeveloperDemos {

    public partial class ConnectivityDemoForm : ZebraForm {

        public ConnectivityDemoForm() {
            InitializeComponent();
            connectionEstablished += new PrinterConnectionHandler(sendLabel);
            connectionClosed += new PrinterConnectionHandler(connectionIsClosed);
            zebraConnectionPanel = connectionPanel;
        }

        private void connectButton_Click(object sender, EventArgs e) {
            connect();
        }

        public void sendLabel() {
            ZebraPrinter printer = getPrinter();
            if (printer != null) {
                byte[] configLabel = getConfigLabel(printer.GetPrinterControlLanguage());
                getConnection().Write(configLabel);
                updateGuiFromWorkerThread("Sending Data", Color.CornflowerBlue);
                Thread.Sleep(2000);
            }
            disconnect();
        }

        public void connectionIsClosed() {
            Invoke(new EventHandler(updateConnectButton));
        }

        private void updateConnectButton(object sender, EventArgs e) {
            connectButton.Enabled = true;
        }

        private byte[] getConfigLabel(PrinterLanguage printerLanguage) {
            String configLabel = "";
            if (printerLanguage == PrinterLanguage.ZPL) {
                configLabel = "^XA^FO17,16^GB379,371,8^FS^FT65,255^A0N,135,134^FDTEST^FS^XZ";
            } else if (printerLanguage == PrinterLanguage.CPCL) {
                configLabel = "! 0 200 200 406 1\r\n" + "ON-FEED IGNORE\r\n"
                   + "BOX 20 20 380 380 8\r\n"
                   + "T 0 6 137 177 TEST\r\n"
                   + "PRINT\r\n";
            }
            return Encoding.Default.GetBytes(configLabel);
        }
    }
}
