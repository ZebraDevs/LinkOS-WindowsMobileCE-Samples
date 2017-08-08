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
using System.Windows.Forms;
using ZSDK_API.Comm;
using ZSDK_API.Printer;
using System.Threading;
using ZSDK_API.ApiException;
using System.Drawing;
using System.IO.Ports;

namespace ZebraDeveloperDemos {

    public delegate void PrinterConnectionHandler();

    public class ZebraForm : Form {
        public event PrinterConnectionHandler connectionEstablished;
        public event PrinterConnectionHandler connectionClosed;

        protected ConnectionPanel zebraConnectionPanel;

        private ZebraPrinterConnection connection;
        private ZebraPrinter printer;

        public void connect() {
            String connectionType = zebraConnectionPanel.ConnectionType;
            if (connectionType.Equals("IP/DNS")) {
                try {
                    connectTCP(zebraConnectionPanel.IPAddress, zebraConnectionPanel.PortNum);
                } catch (FormatException) {
                    updateGuiFromWorkerThread("Invalid data on form", Color.Red);
                }
            } else if (connectionType.Equals("Bluetooth(R)")) {
                connectBluetooth(zebraConnectionPanel.BluetoothMacAddress);
            } else if (connectionType.Equals("Serial")) {
                try {
                    connectSerial(zebraConnectionPanel.SerialComPortName, zebraConnectionPanel.SerialBaudRate, zebraConnectionPanel.SerialDataBits, zebraConnectionPanel.SerialParity, zebraConnectionPanel.SerialStopBits, zebraConnectionPanel.SerialHandshake);
                } catch (FormatException) {
                    updateGuiFromWorkerThread("Invalid data on form", Color.Red);
                }
            } else if (connectionType.Equals("USB")) {
                connectUsb(zebraConnectionPanel.UsbPortName);
            } else {
                connectionClosed();
            }
        }

        private String portName;
        private int baudRate;
        private int dataBits;
        private Parity parity;
        private StopBits stopBits;
        private Handshake handshake;

        private void connectSerial(String portName, int baudRate, int dataBits, Parity parity, StopBits stopBits, Handshake handshake) {
            this.portName = portName;
            this.baudRate = baudRate;
            this.dataBits = dataBits;
            this.parity = parity;
            this.stopBits = stopBits;
            this.handshake = handshake;
            Thread t = new Thread(doConnectSerial);
            t.Start();
        }

        private void doConnectSerial() {
            updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod);
            try {
                connection = new SerialPrinterConnection(this.portName, this.baudRate, this.dataBits, this.parity, this.stopBits, this.handshake);
                threadedConnect(this.portName);
            } catch (ZebraException) {
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                connectionClosed();
            }
        }

        private String ipAddress;
        private int portNumber;

        private void connectTCP(String ipAddress, int portNumber) {
            this.ipAddress = ipAddress;
            this.portNumber = portNumber;
            Thread t = new Thread(doConnectTcp);
            t.Start();
        }

        private void doConnectTcp() {
            updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod);
            try {
                connection = new TcpPrinterConnection(this.ipAddress, this.portNumber);
                threadedConnect(this.ipAddress);
            } catch (ZebraException) {
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                connectionClosed();
            }
        }

        private String macAddress;

        private void connectBluetooth(String macAddress) {
            this.macAddress = macAddress.Trim();
            Thread t = new Thread(doConnectBT);
            t.Start();
        }

        private void doConnectBT() {
            if (this.macAddress.Length != 12) {
                updateGuiFromWorkerThread("Invalid MAC Address", Color.Red);
                disconnect();
            } else {
                updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod);
                try {
                    connection = new BluetoothPrinterConnection(this.macAddress);
                    threadedConnect(this.macAddress);
                } catch (ZebraException) {
                    updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                    connectionClosed();
                }
            }
        }

        private String usbPort;

        private void connectUsb(String usbPort) {
            this.usbPort = usbPort.Trim() + ":";
            Thread t = new Thread(doConnectUsb);
            t.Start();
        }

        private void doConnectUsb() {
                updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod);
                try {
                    connection = new UsbPrinterConnection(this.usbPort);
                    threadedConnect(this.usbPort);
                } catch (ZebraException) {
                    updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
                    connectionClosed();
                }
        }

        private void threadedConnect(String addressName) {
            try {
                connection.Open();
                Thread.Sleep(1000);
            } catch (ZebraPrinterConnectionException) {
                updateGuiFromWorkerThread("Unable to connect with printer", Color.Red);
                disconnect();
            } catch (ZebraGeneralException e) {
                updateGuiFromWorkerThread(e.Message, Color.Red);
                disconnect();
            } catch (Exception) {
                updateGuiFromWorkerThread("Error communicating with printer", Color.Red);
                disconnect(); 
            }

            printer = null;
            if (connection != null && connection.IsConnected()) {
                try {
                    printer = ZebraPrinterFactory.GetInstance(connection);
                    PrinterLanguage pl = printer.GetPrinterControlLanguage();
                    updateGuiFromWorkerThread("Printer Language " + pl.ToString(), Color.LemonChiffon);
                    Thread.Sleep(1000);
                    updateGuiFromWorkerThread("Connected to " + addressName, Color.Green);
                    Thread.Sleep(1000);
                    this.connectionEstablished();
                } catch (ZebraPrinterConnectionException) {
                    updateGuiFromWorkerThread("Unknown Printer Language", Color.Red);
                    printer = null;
                    Thread.Sleep(1000);
                    disconnect();
                } catch (ZebraPrinterLanguageUnknownException) {
                    updateGuiFromWorkerThread("Unknown Printer Language", Color.Red);
                    printer = null;
                    Thread.Sleep(1000);
                    disconnect();
                }
            }
        }

        public void disconnect() {
            Thread t = new Thread(doDisconnect);
            t.Start();
        }

        private void doDisconnect() {
            try {
                if (connection != null && connection.IsConnected()) {
                    updateGuiFromWorkerThread("Disconnecting", Color.Honeydew);
                    connection.Close();
                }
            } catch (ZebraException) {
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red);
            }
            Thread.Sleep(1000);
            connectionClosed();
            updateGuiFromWorkerThread("Not Connected", Color.Red);
            connection = null;
        }

        public void updateGuiFromWorkerThread(String message, Color color) {
            Invoke(new StatusEventHandler(UpdateUI), new StatusArguments(message, color));
        }

        private delegate void StatusEventHandler(StatusArguments e);

        private void UpdateUI(StatusArguments e) {
            zebraConnectionPanel.SetStatus("Status: " + e.message, e.color);
        }

        public ZebraPrinterConnection getConnection() {
            return connection;
        }

        public ZebraPrinter getPrinter() {
            return printer;
        }

        private class StatusArguments : System.EventArgs {
            public String message;
            public Color color;

            public StatusArguments(String message, Color color) {
                this.message = message;
                this.color = color;
            }
        }
    }
}
