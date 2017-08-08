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
using System.Drawing;
using System.IO.Ports;

namespace ZebraDeveloperDemos {
    public partial class ConnectionPanel : UserControl {
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

        public void SetStatus(String message, Color color) {
            statusLabel.Text = message;
            statusLabel.BackColor = color;
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
        public String UsbPortName {
            get {
                String retVal = "LPT1";
                if (UsbPortNameCombo.Text.Equals("") == false) {
                    retVal = UsbPortNameCombo.Text;
                }
                return retVal;
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
            usbPanel.Visible = false;

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
                case "USB":
                    usbPanel.Visible = true;
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
    }
}