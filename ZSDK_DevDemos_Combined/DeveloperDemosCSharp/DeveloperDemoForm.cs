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
using System.Reflection;

namespace ZebraDeveloperDemos
{
    public partial class DeveloperDemoForm : Form {

        public DeveloperDemoForm() {
            InitializeComponent();
        }

        private void connectivityDemoButton_Click(object sender, EventArgs e) {
            ConnectivityDemoForm connectivityDemoForm = new ConnectivityDemoForm();
            connectivityDemoForm.ShowDialog();
        }

        private void discoveryDemoButton_Click(object sender, EventArgs e) {
            DiscoveryDemoForm discoveryDemoForm = new DiscoveryDemoForm();
            discoveryDemoForm.ShowDialog();
        }

        private void listFormatsDemoButton_Click(object sender, EventArgs e) {
            ListFormatsDemoForm listFormatsDemoForm = new ListFormatsDemoForm();
            listFormatsDemoForm.ShowDialog();
        }

        private void sendFileDemoButton_Click(object sender, EventArgs e) {
            SendFileDemoForm sendFileDemoForm = new SendFileDemoForm();
            sendFileDemoForm.ShowDialog();
        }

        private void storedFormatDemoButton_Click(object sender, EventArgs e) {
            StoredFormatDemoForm storedFormatDemoForm = new StoredFormatDemoForm();
            storedFormatDemoForm.ShowDialog();
        }

        private void imagePrintDemoButton_Click(object sender, EventArgs e) {
            ImagePrintDemoForm imagePrintDemoForm = new ImagePrintDemoForm();
            imagePrintDemoForm.ShowDialog();
        }

        private void magCardDemoButton_Click(object sender, EventArgs e) {
            MagCardDemoForm magCardDemoForm = new MagCardDemoForm();
            magCardDemoForm.ShowDialog();
        }

        private void smartCardDemoButton_Click(object sender, EventArgs e) {
            SmartCardDemoForm smartCardDemoForm = new SmartCardDemoForm();
            smartCardDemoForm.ShowDialog();
        }

        private void printerStatusDemoButton_Click(object sender, EventArgs e) {
            PrinterStatusDemoForm printerStatusDemoForm = new PrinterStatusDemoForm();
            printerStatusDemoForm.ShowDialog();
        }
        
        private void signatureCaptureDemoButton_Click(object sender, EventArgs e) {
            SignatureCaptureDemoForm sigCaptureDemoForm = new SignatureCaptureDemoForm();
            sigCaptureDemoForm.ShowDialog();
        }

        private String getTitle() {
            Object[] customAttribs = Assembly.GetExecutingAssembly().GetCustomAttributes(false);
            foreach (Object attrib in customAttribs) {
                if (attrib is AssemblyDescriptionAttribute) {
                    return ((AssemblyDescriptionAttribute)attrib).Description;
                }
            }
            return "Developer Demos";
        }
    }
}