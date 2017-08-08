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
 ***********************************************
 File:   ConnectionPanel.cs

 Description: Form and code demonstrating how to connect to a Zebra Printing device
 * via IP/DNS, Bluetooth, or Serial port.

 $Revision: 1 $
 $Date: 06/14/2010 $
 *******************************************************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using ZSDK_API.ApiException;
using ZSDK_API.Comm;
using ZSDK_API.Printer;


namespace Connectivity_Demo{
    public partial class ConnectionPanel : Form {

        ZebraPrinter printer;
        ZebraPrinterConnection connection;
        String ipAddress;
        int port;
        String MACAddress;
        String portName;
        int baudRate;
        int dataBits;
        Parity parity;
        StopBits stopBits;
        Handshake handshake;

        public ConnectionPanel() {
            InitializeComponent();
			connectionMethodCombo.SelectedIndex = 0;
            this.SerialBaudRate = 9600;
            this.SerialComPortName = "COM1";
            this.SerialDataBits = 8;
            this.SerialHandshake = System.IO.Ports.Handshake.None;
            this.SerialParity = System.IO.Ports.Parity.None;
            this.SerialStopBits = System.IO.Ports.StopBits.One;
        }

        /**
         * When test button is clicked, the application attempts to connect
         * to a Zebra Printing Device based on the type of connection selected,
         * */
        public void onTestButtonClick(Object sender, EventArgs args)
        {
            //If a connection already exists, disconnect it
            updateButtonFromWorkerThread(false);
            if (connection != null)
                disconnect();

            updateButtonFromWorkerThread(false);
            String connectionType = ConnectionType;

            //If selected connection type is IP/DNS, connect via TCP
            if (connectionType.Equals("IP/DNS"))
            {
                try
                {
                    connectTCP(IPAddress, PortNum);
                }
                catch (FormatException)
                {
                    updateGuiFromWorkerThread("Invalid data on form", Color.Red);
                    updateButtonFromWorkerThread(true);
                }
            }

            //Connect via Bluetooth if Bluetooth was selected
            else if (connectionType.Equals("Bluetooth(R)"))
            {
                connectBT(BluetoothMacAddress);
            }

            //Connect via serial if serial is selected
            else if (connectionType.Equals("Serial"))
            {
                try
                {
                    connectSerial(SerialComPortName, SerialBaudRate, SerialDataBits, SerialParity, SerialStopBits, SerialHandshake);
                }
                catch (FormatException)
                {
                    updateGuiFromWorkerThread("Invalid data on form", Color.Red);
                    disconnect();
                    updateButtonFromWorkerThread(true);
                }
            }
            else
            {
                disconnect();
                updateButtonFromWorkerThread(true);
            }
        }

        /**
         * Once connected, automatically generates a small test command and send 
         * it to the printer for printing to demonstrate that a connection exists. 
         * */
        public void sendLabel()
        {
            // Get the bytes data and send it to printer.
            if (printer != null)
            {
                byte[] configLabel = getConfigLabel(printer.GetPrinterControlLanguage());
                connection.Write(configLabel);
                updateGuiFromWorkerThread("Sending Data", Color.CornflowerBlue);
                Thread.Sleep(2000);
            }
            disconnect();
        }

        /**
         * Generates an array of bytes that contain a small test command
         * for printing on a Zebra printer
         * */
        private byte[] getConfigLabel(PrinterLanguage printerLanguage)
        {
            String configLabel = "";

            // Check for printer language and prepare command appropriate to it.
            if (printerLanguage == PrinterLanguage.ZPL)
            {
                configLabel = "^XA^FO17,16^GB379,371,8^FS^FT65,255^A0N,135,134^FDTEST^FS^XZ";
            }
            else if (printerLanguage == PrinterLanguage.CPCL)
            {
                configLabel = "! 0 200 200 406 1\r\n" + "ON-FEED IGNORE\r\n"
                   + "BOX 20 20 380 380 8\r\n"
                   + "T 0 6 137 177 TEST\r\n"
                   + "PRINT\r\n";
            }
            return Encoding.Default.GetBytes(configLabel);
        }

        public String ConnectionType {
            get {
                return connectionMethodCombo.Text;
            }
            set {
            }
        }

        public String IPAddress {
            get {
                return ipDnsAddress.Text;
            }
            set {
                ipDnsAddress.Text = value;
            }
        }


        /************************************************************************
         * The following properties handle retrieving data from the GUI fields
         * *********************************************************************/
        public int PortNum {
            get {
                int retVal = 6101;
                if (portNumber.Text.Equals("") == false) {
                    retVal = Convert.ToInt32(portNumber.Text);
                }
                return retVal;
            }
            set {
                portNumber.Text = Convert.ToString(value);
            }
        }

        public String BluetoothMacAddress {
            get {
                return macAddress.Text;
            }
            set {
                macAddress.Text = value;
            }
        }

        public String SerialComPortName {
            get {
                String retVal = "COM1";
                if (portNamesCombo.Text.Equals("") == false) {
                    retVal = portNamesCombo.Text;
                }
                return retVal;
            }
            set {
                portNamesCombo.Text = value;
            }
        }

        public int SerialBaudRate {
            get {
                int retVal = 9600;
                if (baudRateCombo.Text.Equals("") == false) {
                    retVal = Convert.ToInt32(baudRateCombo.Text);
                }
                return retVal;
            }
            set {
                baudRateCombo.Text = Convert.ToString(value);
            }
        }

        public int SerialDataBits {
            get {
                int retVal = 8;
                if (dataBitsCombo.Text.Equals("") == false) {
                    retVal = Convert.ToInt32(dataBitsCombo.Text);
                }
                return retVal;
            }
            set {
                dataBitsCombo.Text = Convert.ToString(value);
            }
        }

        public Parity SerialParity {
            get {
                Parity retVal = Parity.None;
                if (parityCombo.Text.Equals("") == false) {
                    retVal = (Parity)Enum.Parse(typeof(Parity), parityCombo.Text, true);
                }
                return retVal;
            }
            set {
                parityCombo.Text = value.ToString();
            }
        }

        public StopBits SerialStopBits {
            get {
                return convertStopBitsTextToEnum(stopBitsCombo.Text);
            }
            set {
                stopBitsCombo.Text = convertStopBitsEnumToText(value);
            }
        }

        private String convertStopBitsEnumToText(StopBits value) {
            String retVal = "1";
            switch (value) {
                case StopBits.OnePointFive:
                    retVal = "1.5";
                    break;
                case StopBits.Two:
                    retVal = "2";
                    break;
                case StopBits.One:
                default:
                    retVal = "1";
                    break;
            }

            return retVal;
        }

        private StopBits convertStopBitsTextToEnum(String stopBitsText) {
            StopBits retVal = StopBits.One;
            if (stopBitsText.Equals("1.5") == true) {
                retVal = StopBits.OnePointFive;
            } else if (stopBitsText.Equals("2") == true) {
                retVal = StopBits.Two;
            }
            return retVal;
        }

        public Handshake SerialHandshake {
            get {
                Handshake retVal = Handshake.None;
                if (handshakeCombo.SelectedIndex > -1) {
                    retVal = (Handshake)handshakeCombo.SelectedIndex;
                }
                return retVal;
            }
            set {
                handshakeCombo.Text = value.ToString();
            }
        }
        private void connectionMethod_SelectedValueChanged(object sender, EventArgs e) {
            String selectedConnectionMethod = ((ComboBox)sender).Text;
            
            ipDnsPanel.Visible = false;
            bluetoothPanel.Visible = false;
            serialPanel.Visible = false;

            switch (selectedConnectionMethod) {
                case "IP/DNS":
                    ipDnsPanel.Visible = true;
                    break;
                case "Bluetooth(R)":
                    bluetoothPanel.Visible = true;
                    break;
                case "Serial":
                    serialPanel.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void portNumber_KeyPress(object sender, KeyPressEventArgs e) {
            //numeric values only
            if((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
        /***********************************************************************
         * End GUI handling properties
         * ********************************************************************/

        /***********************************************************************
         * The following methods handle connection to printer
         * ********************************************************************/
        private void connectTCP(String ipAddress, int portNumber)
        {
            this.ipAddress = ipAddress;
            this.port = portNumber;
            Thread t = new Thread(doConnectTcp);
            t.Start();
        }

        /**
        * Create an instance of TcpPrinterConnection class to connect
        * device using TCP connection.
        **/
        private void doConnectTcp()
        {
            updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod);
            try
            {
                connection = new TcpPrinterConnection(this.ipAddress, this.port);
                threadedConnect(this.ipAddress);
            }
            catch (ZebraException)
            {
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                Thread.Sleep(1000);
                disconnect();
            }
        }

        private void connectBT(String macAddress)
        {
            this.MACAddress = macAddress;
            Thread t = new Thread(doConnectBT);
            t.Start();
        }

        /**
        * Check that MAC address is valid.
        * Create an instance of BluetoothPrinterConnection class to connect
        * device using bluetooth connection.
        **/
        private void doConnectBT()
        {
            if (this.macAddress == null || this.MACAddress.Length != 12)
            {
                updateGuiFromWorkerThread("Invalid MAC Address", Color.Red);
                disconnect();
            }
            else
            {
                updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod);
                try
                {
                    try
                    {
                        connection = new BluetoothPrinterConnection(this.MACAddress);
                        threadedConnect(this.MACAddress);
                    }
                    catch (ZebraException)
                    {
                        updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                        Thread.Sleep(1000);
                        disconnect();
                    }
                }
                catch (ZebraPrinterConnectionException)
                {
                    updateGuiFromWorkerThread("Unable to connect with printer", Color.Red);
                    disconnect();
                }
                catch (ZebraException)
                {
                    updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                    disconnect();
                }

                catch (Exception)
                {
                    updateGuiFromWorkerThread("Error communicating with printer", Color.Red);
                    disconnect();
                }
            }
            
        }
        private void connectSerial(String portName, int baudRate, int dataBits, Parity parity, StopBits stopBits, Handshake handshake)
        {
            this.portName = portName;
            this.baudRate = baudRate;
            this.dataBits = dataBits;
            this.parity = parity;
            this.stopBits = stopBits;
            this.handshake = handshake;
            Thread t = new Thread(doConnectSerial);
            t.Start();
        }

       /**
       * Create an instance of SerialPrinterConnection class to connect
       * device using Rs 232 serial connection.
       **/
        private void doConnectSerial()
        {
            updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod);
            try
            {
                connection = new SerialPrinterConnection(this.portName, this.baudRate, this.dataBits, this.parity, this.stopBits, this.handshake);
                threadedConnect(this.portName);
            }
            catch (ZebraException)
            {
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                disconnect();
            }
        }

        /**
        * Common function used to open the connection depending on connection
        * type such as IP/DNS, Serial and Bluetooth(R). Sends a sample label 
        * to print for checking connectivity and then close the connection.
        **/
        private void threadedConnect(String addressName)
        {
            // Open the connection
            try
            {
                connection.Open();
                Thread.Sleep(1000);
            }
            catch (ZebraPrinterConnectionException)
            {
                updateGuiFromWorkerThread("Unable to connect with printer", Color.Red);
                disconnect();
            }
            catch (Exception)
            {
                updateGuiFromWorkerThread("Error communicating with printer", Color.Red);
                disconnect();
            }

            printer = null;

            // If connection opened successfully than get the printer language and display it.
            // Also sends a sample lable to print and than close the connection.
            if (connection != null && connection.IsConnected())
            {
                try
                {
                    updateGuiFromWorkerThread("Getting printer...", Color.Goldenrod);
                    Thread.Sleep(1000);
                    printer = ZebraPrinterFactory.GetInstance(connection);
                    updateGuiFromWorkerThread("Got Printer, getting Language...", Color.LemonChiffon);
                    Thread.Sleep(1000);
                    PrinterLanguage pl = printer.GetPrinterControlLanguage();
                    updateGuiFromWorkerThread("Printer Language " + pl.ToString(), Color.LemonChiffon);
                    Thread.Sleep(1000);
                    updateGuiFromWorkerThread("Connected to " + addressName, Color.Green);
                    Thread.Sleep(1000);
                    sendLabel();
                    Thread.Sleep(1000);
                    disconnect();
                }
                catch (ZebraPrinterConnectionException)
                {
                    updateGuiFromWorkerThread("Unknown Printer Language", Color.Red);
                    printer = null;
                    Thread.Sleep(1000);
                    disconnect();
                }
                catch (ZebraPrinterLanguageUnknownException)
                {
                    updateGuiFromWorkerThread("Unknown Printer Language", Color.Red);
                    printer = null;
                    Thread.Sleep(1000);
                    disconnect();
                }
            }
        }
         
        /**
        * Start disconnect thread
        **/
        public void disconnect()
        {
            Thread t = new Thread(doDisconnect);
            t.Start();
        }

        /**
        * Close connection to printer
        **/
        private void doDisconnect()
        {
            try
            {
                if (connection != null && connection.IsConnected())
                {
                    updateGuiFromWorkerThread("Disconnecting...", Color.Honeydew);
                    
                    connection.Close();
                }
            }
            catch (ZebraException)
            {
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
            }
            Thread.Sleep(1000);
            updateGuiFromWorkerThread("Not Connected", Color.Red);
            Thread.Sleep(1000);
            updateButtonFromWorkerThread(true);
            updateGuiFromWorkerThread("Ready", Color.Yellow);
            connection = null;
            updateButtonFromWorkerThread(true);
        }
        /*******************************************************************************
         * End printer connection methods
         * ****************************************************************************/


        /*******************************************************************************
         * The following methods update the status bar at top of screen
         * ****************************************************************************/

        public void updateGuiFromWorkerThread(String message, Color color)
        {
            Invoke(new StatusEventHandler(UpdateUI), new StatusArguments(message, color));
        }

        private delegate void StatusEventHandler(StatusArguments e);

        private void UpdateUI(StatusArguments e)
        {
            statusBar.Text = e.message;
            statusBar.BackColor = e.color;
        }

        public class StatusArguments : System.EventArgs
        {
            public String message;
            public Color color;

            public StatusArguments(String message, Color color)
            {
                this.message = message;
                this.color = color;
            }
        }
        /*******************************************************************************
         * End status bar update methods
         * ****************************************************************************/


        /*******************************************************************************
         * The following methods enable and disable buttons as needed
         * ****************************************************************************/

        public void updateButtonFromWorkerThread(bool enabled)
        {
            Invoke(new ButtonStatusHandler(UpdateButton), enabled);
        }
        private delegate void ButtonStatusHandler(bool enabled);
        private void UpdateButton(bool enabled)
        {
            connectButton.Enabled = enabled;
        }

        /*******************************************************************************
         * End enable button methods
         * ****************************************************************************/

    }

}