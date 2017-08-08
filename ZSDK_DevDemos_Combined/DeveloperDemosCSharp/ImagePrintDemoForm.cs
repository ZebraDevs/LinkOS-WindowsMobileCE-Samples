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
using System.Windows.Forms;
using Microsoft.WindowsMobile.Forms;
using ZSDK_API.ApiException;

namespace ZebraDeveloperDemos {
    public partial class ImagePrintDemoForm : ZebraForm {

        private delegate void GenericEventHandler();
        private delegate void MenuEventHandler(bool state);

        public ImagePrintDemoForm() {
            InitializeComponent();
            connectionEstablished += new PrinterConnectionHandler(Connected);
            connectionClosed += new PrinterConnectionHandler(Disconnected);

            connectionPanel.BringToFront();
            zebraConnectionPanel = connectionPanel;
        }

        private void cameraButton_Click(object sender, EventArgs e) {
            MessageBox.Show("After taking the photo, some devices require exiting the Camera App for the image to be sent to the printer.", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            
            CameraCaptureDialog cam = new CameraCaptureDialog();
            cam.Owner = this;
            try {
                DialogResult result = cam.ShowDialog();
                if (result == DialogResult.OK) {
                    printImage(cam.FileName);
                }
            } catch (Exception) {
                updateGuiFromWorkerThread("Camera error or no camera", Color.Red);
            }
        }

        private void cameraButton_Click_CE_Device(object sender, EventArgs e) {
            updateGuiFromWorkerThread("No Camera available", Color.Red);
        }
        
        private bool storeImage;
        private String destinationOnPrinter;
        private String filePath;

        private void printImage(String filePath) {
            screenPanel.BringToFront();
            this.storeImage = storeImageOnPrinter.Checked;
            this.destinationOnPrinter = fileNameOnPrinterText.Text;
            this.filePath = filePath;

            updateGuiFromWorkerThread("Formatting Graphic...", Color.LightBlue);
            connectionPanel.BringToFront();
            Thread t = new Thread(doPrintImage);
            t.Start();
        }

        private void doPrintImage() {
            try {
                Invoke(new MenuEventHandler(toggleMenu), new object[] { false });
                if (this.storeImage) {
                    getPrinter().GetGraphicsUtil().StoreImage(this.destinationOnPrinter, this.filePath, 550, 412);
                } else {
                    getPrinter().GetGraphicsUtil().PrintImage(this.filePath, 0, 0, 550, 412, false);
                }
                updateGuiFromWorkerThread("Sent Graphic", Color.LawnGreen);
            } catch (ZebraGeneralException) {
                updateGuiFromWorkerThread("Error communicating with printer", Color.Red);
            }
            Invoke(new MenuEventHandler(toggleMenu), new object[] { true });
        }

        private void fileExplorerButton_Click(object sender, EventArgs e) {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = " |*.jpg;*.gif;*.bmp;*.png;*.tif";
            DialogResult fileDialogResult = fDialog.ShowDialog();
            if (DialogResult.OK == fileDialogResult)
            {
                printImage(fDialog.FileName);
            }
        }

        private void connectMenu_Click(object sender, EventArgs e) {
            toggleMenu(false);
            if (connectMenu.Text.Equals("Connect")) {
                connect();
            } else {
                disconnect();
            }
        }

        private void Connected() {
            Invoke(new GenericEventHandler(SetMenuStateAfterConnecting));
        }

        private void SetMenuStateAfterConnecting() {
            connectMenu.Text = "Disconnect";
            getImageMenu.Enabled = true;
            connectMenu.Enabled = true;
        }

        private void Disconnected() {
            Invoke(new GenericEventHandler(SetMenuStateAfterDisconnecting));
        }

        private void SetMenuStateAfterDisconnecting() {
            connectMenu.Text = "Connect";
            getImageMenu.Enabled = false;
            connectMenu.Enabled = true;
        }

        private void toggleMenu(bool state) {
            connectMenu.Enabled = state;
            getImageMenu.Enabled = state;
        }

        private void ImagePrintDemoForm_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (getConnection() != null) {
                getConnection().Close();
            }
        }

        private void storeImageOnPrinter_CheckStateChanged(object sender, EventArgs e) {
            if (storeImageOnPrinter.Checked == true) {
                fileNameOnPrinterText.Visible = true;
                fileNameOnPrinterText.Enabled = true;
                fileNameOnPrinterLabel.Visible = true;
            } else {
                fileNameOnPrinterText.Visible = false;
                fileNameOnPrinterText.Enabled = false;
                fileNameOnPrinterLabel.Visible = false;
            }
        }
    }
}