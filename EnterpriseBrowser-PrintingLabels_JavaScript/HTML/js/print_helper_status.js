var myPrinterID;
var print_script;
var printerList = [];
var myPrinter;
var mock = false;

function create_print_job(s1, s2)
{
	print_script = "^XA^XFE:TEST.ZPL^FS^FN1^FD" + s1 + "^FS^FN2^FD" + s2 + "^FS^XZ";
}
function start_discovery(search_type, address)
{
	if (mock)
		discover_mock_printer(address);
	else
	{
	    if ("IP" == search_type)
	        discover_TCP(address);
	    else
	        discover_BT(address);
	}
}
function discover_BT(address)
{
    document.getElementById("connect_info").innerHTML +="<br>Searching Bluetooth...Give me a few seconds.";
    Rho.Printer.searchPrinters({
        connectionType:Rho.PrinterZebra.CONNECTION_TYPE_BLUETOOTH,
        printerType: Rho.Printer.PRINTER_TYPE_ZEBRA,
        timeout:60000,
        deviceAddress:address
        }, function (cb){
        	if('PRINTER_STATUS_SUCCESS' == cb.status )
            	found_printer_callback(cb);
        	else
        	    document.getElementById("connect_info").innerHTML += "<br>" + cb.message;
        }
    );
}
function discover_TCP(address)
{
    document.getElementById("connect_info").innerHTML += "<br>Searching network...";
    Rho.Printer.searchPrinters({
        connectionType:Rho.PrinterZebra.CONNECTION_TYPE_TCP,
        printerType: Rho.Printer.PRINTER_TYPE_ZEBRA,
        timeout:60000,
        deviceAddress:address,
        devicePort:9100
        }, function (cb){
        	if('PRINTER_STATUS_SUCCESS' == cb.status )
            	found_printer_callback(cb);
        	else
        	    document.getElementById("connect_info").innerHTML += "<br>" + cb.message;
        }
    );
}

function found_printer_callback(cb)
{
	var connect_stat = document.getElementById("connect_info");
    if (typeof cb.printerID != "undefined")
    {
        connect_stat.innerHTML += "<br>Found a printer:" + cb.printerID;
        found_printer(cb.printerID);
    }
    else
    {
        connect_stat.innerHTML += "<br>Done Searching";
        finish_discovery();
    }
}

function found_printer(id)
{
    printerList.push(id);
}
function finish_discovery()
{
    var connect_stat = document.getElementById("connect_info");
    if (printerList.length == 0)
        connect_stat.innerHTML += "<br>No Printers Found";
    else if (printerList.length == 1)
    {
    	myPrinterID = printerList[0];
        printer_selected(myPrinterID);
        connect();
    }
    else
    {
        connect_stat.innerHTML += "<br>Multiple Printers Found - Pairing with the first";
    	myPrinterID = printerList[0];
        printer_selected(myPrinterID);
        connect();
    }
}
function connect()
{
	var connect_stat = document.getElementById("connect_info");
	// check if printer is already connected
	if ((null != myPrinter) && (myPrinter.isConnected))
	{
		connect_stat.innerHTML += "<br>Printer connection found: " + myPrinter.deviceName;
		check_status();
		return;
	}
	// make the connection	
	connect_stat.innerHTML += "<br>Connecting to " + myPrinterID;
	if (mock)
		myPrinter = getMockPrinterByID(myPrinterID);
	else
		myPrinter = Rho.Printer.getPrinterByID(myPrinterID);

	// Let's try connecting
	myPrinter.connect(function (cb){
		connect_stat.innerHTML += "<br>Connect Status: " + cb;
		
	    // This will be the Zebra's `Friendly Name`
	    // by default it is the serial number
	    connect_stat.innerHTML += "<br>Friendly Name: " + myPrinter.deviceName;

	    // This will be the BT MC Address
	    // since we are connecting via BlueTooth
	    connect_stat.innerHTML += "<br>Address: " + myPrinter.deviceAddress;
	    connect_stat.innerHTML += "<br>Connected? " + myPrinter.isConnected;
	    
	    check_status();
	});
}
function disconnect()
{
	document.getElementById("connect_info").innerHTML += "<br>Disconnecting from printer";
	if (myPrinter)
		myPrinter.disconnect();
}

var statusTimer;
function check_status()
{
	// This function will continue to check the printer status until it is OK
	var connect_stat = document.getElementById("connect_info");
	myPrinter.requestState(['PRINTER_STATE_IS_READY_TO_PRINT', 'PRINTER_STATE_IS_PAPER_OUT',
    'PRINTER_STATE_IS_COVER_OPENED', 'PRINTER_STATE_IS_BATTERY_LOW'],function (cb){
        if ("PRINTER_STATUS_SUCCESS" == cb.status)
        {
            if (cb.PRINTER_STATE_IS_READY_TO_PRINT)
        	{
                connect_stat.innerHTML += "<br>Printer is ready to print.";
        	    print_now();
            } // if printer state is not ready, check back every 5 seconds until printer is ready
        	else if (cb.PRINTER_STATE_IS_COVER_OPENED)
            {
        		connect_stat.innerHTML += "<br>Printer media cover is open";
        		statusTimer = setTimeout(check_status, 5000);
            }
        	else if (cb.PRINTER_STATE_IS_PAPER_OUT)
           {
        		connect_stat.innerHTML += "<br>Printer paper is out";
                statusTimer = setTimeout(check_status, 5000);
            }
            else if (cb.PRINTER_STATE_IS_BATTERY_LOW)
            {
                connect_stat.innerHTML += "<br>Printer battery is low";
                statusTimer = setTimeout(check_status, 5000);
            }
            else
            {
                connect_stat.innerHTML += "<br>Printer is paused";
                statusTimer = setTimeout(check_status, 5000);
            }
        }
        else
        {
        	error("Printer is in error: " + cb.message + ", printer: " + cb.stringResponce);
        }
    });
}
function print_now()
{
	error("Still don't know how to print it");
}



function getMockPrinterByID(id)
{
	return new MockPrinter(id, "AC3FA40C8E9D", id);
}
function MockPrinter(id, address, name)
{
	this.ID = id;
	this.deviceAddress = address;
	this.deviceName = "MyMockPrinter";
	this.isConnected = true;
	this.printerType = "PRINTER_TYPE_ZEBRA";
	this.connect = function connect(callback)
	{
		callback("OK");
	};
	this.disconnect = function disconnect()
	{
		this.isConnected = false;
	};
}
MockPrinter.prototype.requestState = function(statusList, callback)
{
	var mockState = new MockPrinterState();
	callback.call(this, mockState);
}
function MockPrinterState()
{
	this.status = "PRINTER_STATUS_SUCCESS";
	this.PRINTER_STATE_IS_READY_TO_PRINT = true;
	this.PRINTER_STATE_IS_COVER_OPENED = false;
	this.PRINTER_STATE_IS_DRAWER_OPENED = false;
	this.PRINTER_STATE_IS_PAPER_OUT = false;
	this.PRINTER_STATE_IS_BATTERY_LOW = false;
}
function discover_mock_printer(address)
{
    var printerID = "Mock_Printer_1";
    document.getElementById("connect_info").innerHTML += "<br>Found a printer:" + printerID;
    found_printer(printerID);
    finish_discovery();
}
