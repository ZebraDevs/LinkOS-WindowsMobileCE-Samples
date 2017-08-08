/********************************************** 
 * CONFIDENTIAL AND PROPRIETARY 
 *
 * The source code and other information contained herein is the confidential and the exclusive property of
 * ZIH Corporation and is subject to the terms and conditions in your end user license agreement.
 * This source code, and any other information contained herein, shall not be copied, reproduced, published, 
 * displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
 * expressly permitted under such license agreement.
 * 
 * Copyright ZIH Corporation 2010
 *
 * ALL RIGHTS RESERVED 
 ***********************************************/

/**************************************************************************************************
 File:   ListFormatMain.cs

 Descr:  Contains classes and routines to connect and disconnect mobile device 
 * with zebra printer using bluetooth connection. This demo application allows 
 * users to retrieve format files stored at zebra printer,select format file 
 * and print it with variable user fields.

 Date: 06/18/2010 
 * 
 *************************************************************************************************/


using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZSDK_API.Printer;
using ZSDK_API.Comm;
using ZSDK_API.Sgd;
using ZSDK_API.Util.Internal;
using ZSDK_API.ApiException;

namespace ListFormatDemo
{
    public partial class ListFormatMain : Form
    {
        // store label name of variable fields
        List<Label> labels = new List<Label>();
        
        // store the user input values of variable fields
        List<TextBox> userInputVars = new List<TextBox>();

        //ZebraPrinterConnection interface reference used for referring Bluetooth printer connection object
        private ZebraPrinterConnection zebraPrinterConnection = null;

        //ZebraPrinter interface reference used to obtain various properties of a Zebra printer
        private ZebraPrinter printer = null;

        bool isConnected = false;
       
        public ListFormatMain()
        {
            InitializeComponent();
            Retrieve.Enabled = false;
        }

       /****************************************************************************************************
       Desc: Called when Connect button is clicked. Open a bluetooth connection with printer using MAC address
       *****************************************************************************************************/

        private void connectButton_Click(object sender, EventArgs e)
        {
            // Validate bluetooth MAC address
            if (macAddrBox.Text.Length != 12)
            {
                MessageBox.Show("Enter valid MAC address!");
                return;
            }

            // Open the connetion for further communication
            if (zebraPrinterConnection == null && macAddrBox.Text.Length == 12)
            {
                zebraPrinterConnection = new BluetoothPrinterConnection(macAddrBox.Text);
                statusLabel.BackColor = Color.Gold;
                statusLabel.Text = "Status : Connecting to..." + macAddrBox.Text;
                Application.DoEvents();
                try
                {
                    zebraPrinterConnection.Open();
                    while (!zebraPrinterConnection.IsConnected()) { }
                }
                catch (ZebraPrinterConnectionException)
                {
                    statusLabel.BackColor = Color.Red;
                    statusLabel.Text = "Status : Disconnected.";
                    zebraPrinterConnection = null;
                    isConnected = false;
                    MessageBox.Show("Unable to connect with printer.");
                    return;
                }
                catch (ZebraException)
                {
                    statusLabel.BackColor = Color.Red;
                    statusLabel.Text = "Status : Disconnected.";
                    zebraPrinterConnection = null;
                    isConnected = false;
                    MessageBox.Show("Unable to connect with printer.\r\nCheck that printer is on.");
                    return;
                }
                catch (Exception)
                {
                    statusLabel.BackColor = Color.Red;
                    statusLabel.Text = "Status : Disconnected.";
                    zebraPrinterConnection = null;
                    isConnected = false;
                    MessageBox.Show("Connection Failed.");
                    return;
                }
                statusLabel.BackColor = Color.Green;
                statusLabel.Text = "Status : Connected." + macAddrBox.Text;
                isConnected = true;
                Retrieve.Enabled = true;
                
            }

        }


        /*****************************************************************************************************
        Desc: Called when Disconnect button is clicked.Close the Bluetooth connection with printer.
        ******************************************************************************************************/
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Close the connection
                if (zebraPrinterConnection != null)
                {
                    zebraPrinterConnection.Close();
                }
            }
            catch (ZebraPrinterConnectionException)
            {
                MessageBox.Show("Unable to disconnect with printer.");
                return;
            }
            catch (ZebraException)
            {
                MessageBox.Show("Unable to disconnect with printer.\r\nCheck that printer is on.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Disconnect Failed.");
                return;
            }
            zebraPrinterConnection = null;
            RemoveVariableFields();
            statusLabel.BackColor = Color.Red;
            statusLabel.Text = "Status : Disconnected.";
            isConnected = false;
            macAddrBox.Text = "";
            cbFormatList.DataSource = null;
            quantityLabel.Location = new Point(5, 5);
            quantity.Location = new Point(110,5);
            Retrieve.Enabled = false;
            
        }


        
        /*****************************************************************************************************
        Desc: This function is called when Retrieve button is clicked. Gets the list of label formats stored 
         * at printer and display that list on UI using combobox.
        ******************************************************************************************************/
        private void getListOfAllFormats()
        {
            //Get the instance of ZebraPrinter to obtain properties of Zebra printer
            if (zebraPrinterConnection != null)
                printer = ZebraPrinterFactory.GetInstance(zebraPrinterConnection);
            else
            {
                MessageBox.Show("Device isn't Connected.");
                return;
            }
            try
            {
                if (printer != null && isConnected)
                {
                    String[] formats;

                    /**
                     * MADE CHANGES HERE!!!!!!!****************************
                     * 
                     * **/


                    //String printerLanguage = SGD.GET("device.languages", zebraPrinterConnection);
                    PrinterLanguage lang = printer.GetPrinterControlLanguage();

                    // select the format type according to printer language
                    // if ( printerLanguage == "zpl" )
                    if(lang == PrinterLanguage.ZPL)
                    {
                        formats = new String[] { "ZPL" };
                    }
                    else
                    {
                        formats = new String[] { "FMT", "LBL" };
                    }
                    /**
                     * END CHANGES
                     * **/


                    // Retrieve the list of format files store at printer and display it in combobox
                    String[] formatNames = printer.GetFileUtil().RetrieveFileNames(formats);
                    cbFormatList.DataSource = formatNames;
                }
                else
                {
                    MessageBox.Show("Device isn't Connected.");
                    return;
                }

            }
            catch (ZebraPrinterLanguageUnknownException)
            {
                MessageBox.Show("Printer Control Language Error: \r\n Make sure that printer has supported control language.");
                return;
            }
            catch (ZebraPrinterConnectionException)
            {
                MessageBox.Show("Communication Error:\r\n Check Printer is on Or Connection has been established.\r\n");
                return;
            }
            catch (ZebraException)
            {
                MessageBox.Show("Zebra Printer Error: Can't retrieve formats stored at printer");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Retrieving Formats");
                return;
            }
            
        }

        /*****************************************************************************************************
        Desc: This function is called when user select the format.Displays textboxes and Numeric field value
         * so user can enter variable field values and select no of copies to be printed.
        ******************************************************************************************************/
        private void cbFormatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormatList.SelectedItem != null)
            {
                // Before insering new controls remove previously inserted UI controls
                RemoveVariableFields();
                SuspendLayout();

                
                //Get the list of variable user input fields
                FieldDescriptionData[] varFieldNames = GetVarFieldNames();

                //Insert user input controls on control panel
                for (int i = 0; i < varFieldNames.Length; i++)
                {
                    String labelText = varFieldNames[i].FieldName == null ? Convert.ToString(varFieldNames[i].FieldNumber) : varFieldNames[i].FieldName;
                    Label label = new Label();
                    label.Text = labelText + " :";
                    labels.Add(label);
                    userInputVars.Add(new TextBox());
                }

                // Arrange the user field controls at proper location and in order
                layoutVariables();
                ResumeLayout(false);
            }

        }

        /*****************************************************************************************************
        Desc: Called before adding new UI controls on varFieldPanel.Flushes all previously drawn controls on 
         * control panel.
        ******************************************************************************************************/
        private void RemoveVariableFields()
        {
            SuspendLayout();

            //Removes all labels and user unput textboxes
            for (int i = 0; i < labels.Count; i++)
            {
                varFieldPanel.Controls.Remove(labels[i]);
                labels[i].Dispose();
                varFieldPanel.Controls.Remove(userInputVars[i]);
                userInputVars[i].Dispose();
            }
            
            //Removes all the elements stored in labels & useInputVars collections.
            quantity.Value = 1;
            labels.Clear();
            labels.TrimExcess();
            userInputVars.Clear();
            userInputVars.TrimExcess();
            varFieldPanel.AutoScrollPosition = new Point(0, 0);
            ResumeLayout(false);
        }

        /*****************************************************************************************************
        Desc: This function is called when user selects format file.It will display no of variable user fields
         * on control panel and arrage them at proper location and in proper order.
        ******************************************************************************************************/
        private void layoutVariables()
        {
            const int HorizontalPositionOfLabelStart = 11;
            const int VerticalPositionOfLabelStart = 25;
            const int SpacingBetweenGuiElements = 25;
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Location = new Point(HorizontalPositionOfLabelStart, VerticalPositionOfLabelStart + (i * SpacingBetweenGuiElements));
                labels[i].Size = new Size(65, 20);
                userInputVars[i].Location = new Point(HorizontalPositionOfLabelStart + 80, VerticalPositionOfLabelStart + (i * SpacingBetweenGuiElements));
                userInputVars[i].Size = new Size(120, 20);
            }

            int verticalLoc = VerticalPositionOfLabelStart + (labels.Count * SpacingBetweenGuiElements);
            quantityLabel.Location = new Point(HorizontalPositionOfLabelStart, verticalLoc + 5);
            quantity.Location = new Point(HorizontalPositionOfLabelStart + 80, verticalLoc);

            AutoScaleDimensions = new SizeF(96F, 96F);

            for (int i = 0; i < labels.Count; i++)
            {
                varFieldPanel.Controls.Add(labels[i]);
                varFieldPanel.Controls.Add(userInputVars[i]);
            }
            varFieldPanel.AutoScroll = true;
        }

        /*****************************************************************************************************
        Desc: Gets variable user field information from format file stored at Zebra printer. Stores that information
         * into an array for later processing.
        ******************************************************************************************************/

        private FieldDescriptionData[] GetVarFieldNames()
        {
            String formatName = null;

            // Create an array to store variable user field information of selected format file
            FieldDescriptionData[] fieldNames = new FieldDescriptionData[] { };
            try
            {
                if (cbFormatList.SelectedItem != null)
                {
                    formatName = cbFormatList.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Please select format file to be printed.");
                    return fieldNames;
                }
                
                ZebraPrinter printer = getPrinter();

                // Get the format file information
                if (printer != null)
                {                    
                    byte[] formatData = printer.GetFormatUtil().RetrieveFormatFromPrinter(formatName);
                    String formatString = Encoding.UTF8.GetString(formatData, 0, formatData.Length);
                    fieldNames = printer.GetFormatUtil().GetVariableFields(formatString);
                   
                }
                else
                {
                    MessageBox.Show("Device isn't connected.");
                    return fieldNames;
                }
            
            }
            catch (ZebraPrinterConnectionException)
            {
                MessageBox.Show("Communication Error:\r\n Check Printer is on Or Connection has been established.\r\n");
                return fieldNames;
            }
            catch (ZebraException)
            {
                MessageBox.Show("Zebra Printer Error: Can't retrieve variable field names");
                return fieldNames;
            }
            catch (Exception)
            {
                MessageBox.Show("Error in retrieving variable field names");
                return fieldNames;
            }
            return fieldNames;
        }

        public ZebraPrinter getPrinter()
        {
            return printer;
        }

        private void Retrieve_Click(object sender, EventArgs e)
        {
            getListOfAllFormats();
            if(cbFormatList.Items.Count != 0)
                cbFormatList.SelectedIndex = 0;
        }

        /*****************************************************************************************************
        Desc: This function is called when Print button is clicked. It sends print request to Zebra printer
         * with the selected format file,user input fields and format encoding type.
        ******************************************************************************************************/

        private void Print_Click(object sender, EventArgs e)
        {
            ZebraPrinter printer = null;

            //Get the list of variable user input fields
            FieldDescriptionData[] varFieldNames = GetVarFieldNames();

            try
            {
                if (zebraPrinterConnection != null && isConnected)
                {
                    printer = getPrinter();
                }
                else
                {
                    MessageBox.Show("Device isn't connected.");
                    return;
                }

                if(printer != null)
                {
                String formatName = cbFormatList.SelectedItem.ToString();

                //Store Field Name and Field Number in dictionary structure
                Dictionary<int, String> fieldNumbersAndNames = new Dictionary<int, string>();
                for (int i = 0; i < labels.Count; i++)
                {
                    int fnNumber = varFieldNames[i].FieldNumber;
                    fieldNumbersAndNames[fnNumber] = userInputVars[i].Text;
                }

                // Print choosen format label to number of times user selected.
                for (int i = 0; i < quantity.Value; i++)
                    printer.GetFormatUtil().PrintStoredFormat(formatName, fieldNumbersAndNames, "UTF-8");
                }
                else
                {
                    MessageBox.Show("Can't send print request \r\n please check printer is configured properly.");
                    return;
                }
            }
            catch(ZebraPrinterConnectionException)
            {
                MessageBox.Show("Communication Error:\r\n Check Printer is on Or Connection has been established.\r\n");
                return;
            }
            catch(ZebraException)
            {
                MessageBox.Show("Print Error:\r\n Check Printer is on Or Connection has been established.\r\n");
                return;
            }
            catch(Exception)
            {
                MessageBox.Show("Printing Error:\r\n Check all variable field values are supplied properly.\r\n");
                return;
            }

        }

        /*****************************************************************************************************
        Desc: This function is called when Form is closing.
        ******************************************************************************************************/

        private void ListFormatMain_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                // Close the connection
                if (zebraPrinterConnection != null)
                {
                    zebraPrinterConnection.Close();
                }
            }
            catch (ZebraPrinterConnectionException)
            {
                MessageBox.Show("Unable to disconnect with printer.");
                return;
            }
            catch (ZebraException)
            {
                MessageBox.Show("Unable to disconnect with printer.\r\nCheck that printer is on.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Disconnect Failed.");
                return;
            }
        }

        

        

        
       

    }
}