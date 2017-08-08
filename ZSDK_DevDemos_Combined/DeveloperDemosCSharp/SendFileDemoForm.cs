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
using System.IO;
using ZSDK_API.Printer;
using System.Text;
using System.Threading;

namespace ZebraDeveloperDemos {
    public partial class SendFileDemoForm : ZebraForm {

        public SendFileDemoForm() {
            InitializeComponent();
            connectionEstablished += new PrinterConnectionHandler(connected);
            connectionClosed += new PrinterConnectionHandler(disconnected);
            zebraConnectionPanel = connectionPanel;
        }

        private void connectButton_Click(object sender, EventArgs e) {
            connectButton.Enabled = false;
            connect();
        }

        private void connected() {
            updateGuiFromWorkerThread("Sending file...", Color.Plum);
            Invoke(new EventHandler(sendFile));
            disconnect();
        }

        private void disconnected() {
            Invoke(new EventHandler(updateConnectButton));
        }

        private void updateConnectButton(object sender, EventArgs e) {
            connectButton.Enabled = true;
        }

        private void sendFile(object sender, EventArgs e) {
            string filePath = @"\TEMP\TEST.LBL";
            try {
                createFile(filePath);
                Thread.Sleep(500);
                getPrinter().GetFileUtil().SendFileContents(filePath);
            } catch (IOException e1) {
                updateGuiFromWorkerThread(e1.Message, Color.Red);
            }
        }

        private void createFile(string filePath) {
            ZebraPrinter printer = getPrinter();
            PrinterLanguage printerLang = printer.GetPrinterControlLanguage();

            if (File.Exists(filePath)) {
                File.Delete(filePath);
            }

            using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate)) {
                if (printerLang.Equals(PrinterLanguage.ZPL)) {
                    Byte[] zplLabel = Encoding.Default.GetBytes("^XA^FO17,16^GB379,371,8^FS^FT65,255^A0N,135,134^FDTEST^FS^XZ");
                    fileStream.Write(zplLabel, 0, zplLabel.Length);
                } else if (printerLang.Equals(PrinterLanguage.CPCL)) {
                    Byte[] cpclLabel = Encoding.Default.GetBytes("! 0 200 200 406 1\r\n" + "ON-FEED IGNORE\r\n"
                    + "BOX 20 20 380 380 8\r\n"
                    + "T 0 6 137 177 TEST\r\n"
                    + "PRINT\r\n");
                    fileStream.Write(cpclLabel, 0, cpclLabel.Length);
                }
                fileStream.Close();
            }
        }
    }
}