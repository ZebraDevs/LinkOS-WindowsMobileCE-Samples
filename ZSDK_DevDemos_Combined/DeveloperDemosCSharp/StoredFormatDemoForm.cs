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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ZSDK_API.ApiException;
using ZSDK_API.Comm;
using ZSDK_API.Printer;
using System.Text;

namespace ZebraDeveloperDemos {

    public partial class StoredFormatDemoForm : ZebraForm {

        List<Label> labels = new List<Label>();
        List<TextBox> userInputVars = new List<TextBox>();

        private delegate void GenericEventHandler();

        public StoredFormatDemoForm() {
            InitializeComponent();
            connectionPanel.BringToFront();
            zebraConnectionPanel = connectionPanel;
            connectionEstablished += (Connected);
            connectionClosed += (Disconnected);
        }

        private void leftSideButtonPressed(object sender, EventArgs e) {
            if (leftSideButton.Text.Equals("Back")) {
                leftSideButton.Enabled = false;
                RemoveVariableFields();
                formatListPanel.BringToFront();
                Invoke(new GenericEventHandler(ConnectedButtonSettings));
            } else if (leftSideButton.Text.Equals("Disconnect")) {
                toggleMenuButtons(false);
                connectionPanel.BringToFront();
                disconnect();
            }
        }

        private void RemoveVariableFields() {
            SuspendLayout();
            for (int i = 0; i < labels.Count; i++) {
                varFieldPanel.Controls.Remove(labels[i]);
                labels[i].Dispose();
                varFieldPanel.Controls.Remove(userInputVars[i]);
                userInputVars[i].Dispose();
            }
            quantity.Value = 1;
            labels.Clear();
            labels.TrimExcess();
            userInputVars.Clear();
            userInputVars.TrimExcess();
            varFieldPanel.AutoScrollPosition = new Point(0,0);
            ResumeLayout(false);
        }

        private void Connected() {
            Invoke(new GenericEventHandler(ConnectedButtonSettings));
            Invoke(new GenericEventHandler(DisplayFormatsThread));
        }

        private void ConnectedButtonSettings() {
            formatListPanel.BringToFront();
            leftSideButton.Text = "Disconnect";
            rightSideButton.Text = "Refresh";
            toggleMenuButtons(true);
        }

        private void Disconnected() {
            Invoke(new GenericEventHandler(NoConnectionButtonSettings));
        }

        private void NoConnectionButtonSettings() {
            rightSideButton.Text = "List Formats";
            rightSideButton.Enabled = true;
            leftSideButton.Text = "";
            leftSideButton.Enabled = false;
        }


        private void DisplayFormatsThread() {
            formatListPanel.BringToFront();
            Thread t = new Thread(doDisplayFormatsThread);
            t.Start();
        }

        private void doDisplayFormatsThread() {
            try {
                GetListOfFormats();
            } catch (ZebraException) {
                Invoke(new GenericEventHandler(bringConnectionPanelToFront));
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
            }
        }

        private void bringConnectionPanelToFront() {
            connectionPanel.BringToFront();
        }

        private delegate void FormatListEventHandler(List<String> formatList);

        private void GetListOfFormats() {
            ZebraPrinterConnection connection = getConnection();
            ZebraPrinter printer = ZebraPrinterFactory.GetInstance(connection);

            String[] zplFormatExtensions = new String[] { "ZPL" };
            String[] cpclFormatExtensions = new String[] { "FMT", "LBL" };
            String[] extensions = printer.GetPrinterControlLanguage() == PrinterLanguage.ZPL ? zplFormatExtensions : cpclFormatExtensions;

            List<String> formatList = new List<String>();
            foreach (String format in printer.GetFileUtil().RetrieveFileNames(extensions)) {
                formatList.Add(format);
            }
            Invoke(new FormatListEventHandler(DisplayNames), new object[] { formatList });
        }

        private void DisplayNames(List<String> formatList) {
            formatListBox.DataSource = formatList;
            formatListBox.Refresh();
            formatSelectButton.Enabled = true;
            toggleMenuButtons(true);
        }

        private void rightSideButtonPressed(object sender, EventArgs e) {
            toggleMenuButtons(false);
            if (rightSideButton.Text.Equals("List Formats")) {
                connect();
            } else if (rightSideButton.Text.Equals("Print")) {
                SendLabelsToPrinter();
                toggleMenuButtons(true);
            } else if (rightSideButton.Text.Equals("Refresh")) {
                formatSelectButton.Enabled = false;
                formatListBox.DataSource = null;
                Invoke(new GenericEventHandler(DisplayFormatsThread));
            }
        }

        private void SendLabelsToPrinter() {
            FieldDescriptionData[] varFieldNames = GetVarFieldNames();
            Dictionary<int, String> fieldNumbersAndNames = new Dictionary<int, String>();
            for (int i = 0; i < labels.Count; i++) {
                int fnNumber = varFieldNames[i].FieldNumber;
                fieldNumbersAndNames[fnNumber] = userInputVars[i].Text;
            }
            PrintLabels(formatListBox.SelectedItem.ToString(), fieldNumbersAndNames, Convert.ToInt32(quantity.Value));
            printJobSentPanel.BringToFront();
        }

        private String formatName;
        private Dictionary<int, String> fieldNumbersAndNames;
        private int numLabels;

        private void PrintLabels(String formatName, Dictionary<int, String> fieldNumbersAndNames, int qty) {
            this.formatName = formatName;
            this.fieldNumbersAndNames = fieldNumbersAndNames;
            this.numLabels = qty;

            Thread t = new Thread(doPrintLabels);
            t.Start();
        }

        private void doPrintLabels() {
            for (int i = 0; i < this.numLabels; i++) {
                getPrinter().GetFormatUtil().PrintStoredFormat(this.formatName, this.fieldNumbersAndNames, "utf-8");
            }
        }

        private void formatSelectButton_Click(object sender, EventArgs e) {
            if (formatListBox.SelectedItem != null) {
                RemoveVariableFields();
                SuspendLayout();
                Invoke(new GenericEventHandler(BackAndPrintButtonUpdate));
                FieldDescriptionData[] varFieldNames = GetVarFieldNames();

                titleLabel.Text = "Format " + formatListBox.SelectedItem.ToString() + ":";

                for (int i = 0; i < varFieldNames.Length; i++)
                {
                    String labelText = varFieldNames[i].FieldName == null ? Convert.ToString(varFieldNames[i].FieldNumber) : varFieldNames[i].FieldName;
                    Label label = new Label();
                    label.Text = labelText + " :";
                    labels.Add(label);
                    userInputVars.Add(new TextBox());
                }

                layoutVariables();
                ResumeLayout(false);
            }
        }

        private void layoutVariables() {
            const int HorizontalPositionOfLabelStart = 21;
            const int VerticalPositionOfLabelStart = 55;
            const int SpacingBetweenGuiElements = 30;
            for (int i = 0; i < labels.Count; i++) {
                labels[i].Location = new Point(HorizontalPositionOfLabelStart, VerticalPositionOfLabelStart + (i * SpacingBetweenGuiElements));
                labels[i].Size = new Size(65, 20);
                userInputVars[i].Location = new Point(HorizontalPositionOfLabelStart + 80, VerticalPositionOfLabelStart + (i * SpacingBetweenGuiElements));
                userInputVars[i].Size = new Size(120, 20);
            }

            int verticalLoc = VerticalPositionOfLabelStart + (labels.Count * SpacingBetweenGuiElements);
            quantityLabel.Location = new Point(HorizontalPositionOfLabelStart, verticalLoc + 5);
            quantity.Location = new Point(HorizontalPositionOfLabelStart + 110, verticalLoc);

            AutoScaleDimensions = new SizeF(96F, 96F);

            for (int i = 0; i < labels.Count; i++) {
                varFieldPanel.Controls.Add(labels[i]);
                varFieldPanel.Controls.Add(userInputVars[i]);
            }
        }

        private void BackAndPrintButtonUpdate() {
            varFieldPanel.BringToFront();
            leftSideButton.Text = "Back";
            rightSideButton.Text = "Print";
        }

        private FieldDescriptionData[] GetVarFieldNames() {
            String formatName = formatListBox.SelectedItem.ToString();
            FieldDescriptionData[] fieldNames = new FieldDescriptionData[] { };
            try {
                ZebraPrinter printer = getPrinter();
                byte[] formatData = printer.GetFormatUtil().RetrieveFormatFromPrinter(formatName);
                String formatString = Encoding.UTF8.GetString(formatData, 0, formatData.Length);
                fieldNames = printer.GetFormatUtil().GetVariableFields(formatString);
            } catch (ZebraPrinterConnectionException) {
                updateGuiFromWorkerThread("Communication Error", Color.Red);
            }
            return fieldNames;
        }

        private void toggleMenuButtons(bool state) {
            rightSideButton.Enabled = state;
            leftSideButton.Enabled = state;

        }

        private void reprintButton_Click(object sender, EventArgs e) {
            SendLabelsToPrinter();
        }

        private void exitButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void backToListFormatsButton_Click(object sender, EventArgs e) {
            ConnectedButtonSettings();
        }

        private void reEnterDataButton_Click(object sender, EventArgs e) {
            varFieldPanel.BringToFront();
        }

        private void StoredFormatDemoForm_Closing(object sender, CancelEventArgs e) {
            if (getConnection() != null) {
                getConnection().Close();
            }
            RemoveVariableFields();
        }

    }
}