(function(f,c,e){var b="Rho.Printer";var a=e.apiReqFor(b);function d(){var g=null;this.getId=function(){return g};if(1==arguments.length&&arguments[0][e.rhoIdParam()]){if(b!=arguments[0][e.rhoClassParam()]){throw"Wrong class instantiation!"}g=arguments[0][e.rhoIdParam()]}else{g=e.nextId()}}e.createPropsProxy(d.prototype,[{propName:"ID",propAccess:"r"},{propName:"deviceName",propAccess:"r"},{propName:"printerType",propAccess:"r"},{propName:"deviceAddress",propAccess:"r"},{propName:"devicePort",propAccess:"rw"},{propName:"connectionType",propAccess:"r"},{propName:"isConnected",propAccess:"r"}],a,function(){return this.getId()});e.createMethodsProxy(d.prototype,[{methodName:"connect",nativeName:"connect",persistentCallbackIndex:0,valueCallbackIndex:2},{methodName:"connectWithOptions",nativeName:"connectWithOptions",persistentCallbackIndex:1,valueCallbackIndex:3},{methodName:"requestState",nativeName:"requestState",persistentCallbackIndex:1,valueCallbackIndex:3},{methodName:"disconnect",nativeName:"disconnect",persistentCallbackIndex:0,valueCallbackIndex:2},{methodName:"printFile",nativeName:"printFile",persistentCallbackIndex:2,valueCallbackIndex:4},{methodName:"printImageFromFile",nativeName:"printImageFromFile",persistentCallbackIndex:4,valueCallbackIndex:6},{methodName:"printRawString",nativeName:"printRawString",persistentCallbackIndex:2,valueCallbackIndex:4},{methodName:"enumerateSupportedControlLanguages",nativeName:"enumerateSupportedControlLanguages",persistentCallbackIndex:0,valueCallbackIndex:2},{methodName:"getProperty",nativeName:"getProperty",persistentCallbackIndex:1,valueCallbackIndex:3},{methodName:"getProperties",nativeName:"getProperties",persistentCallbackIndex:1,valueCallbackIndex:3},{methodName:"getAllProperties",nativeName:"getAllProperties",persistentCallbackIndex:0,valueCallbackIndex:2},{methodName:"setProperty",nativeName:"setProperty",valueCallbackIndex:2},{methodName:"setProperties",nativeName:"setProperties",valueCallbackIndex:1}],a,function(){return this.getId()});e.createRawPropsProxy(d.prototype,[]);d.CONNECTION_TYPE_ANY="CONNECTION_TYPE_ANY";d.CONNECTION_TYPE_BLUETOOTH="CONNECTION_TYPE_BLUETOOTH";d.CONNECTION_TYPE_ON_BOARD="CONNECTION_TYPE_ON_BOARD";d.CONNECTION_TYPE_TCP="CONNECTION_TYPE_TCP";d.CONNECTION_TYPE_USB="CONNECTION_TYPE_USB";d.PRINTER_LANGUAGE_CPCL="PRINTER_LANGUAGE_CPCL";d.PRINTER_LANGUAGE_EPS="PRINTER_LANGUAGE_EPS";d.PRINTER_LANGUAGE_ZPL="PRINTER_LANGUAGE_ZPL";d.PRINTER_STATE_IS_BATTERY_LOW="PRINTER_STATE_IS_BATTERY_LOW";d.PRINTER_STATE_IS_COVER_OPENED="PRINTER_STATE_IS_COVER_OPENED";d.PRINTER_STATE_IS_DRAWER_OPENED="PRINTER_STATE_IS_DRAWER_OPENED";d.PRINTER_STATE_IS_PAPER_OUT="PRINTER_STATE_IS_PAPER_OUT";d.PRINTER_STATE_IS_READY_TO_PRINT="PRINTER_STATE_IS_READY_TO_PRINT";d.PRINTER_STATUS_ERROR="PRINTER_STATUS_ERROR";d.PRINTER_STATUS_ERR_IO="PRINTER_STATUS_ERR_IO";d.PRINTER_STATUS_ERR_MEMORY="PRINTER_STATUS_ERR_MEMORY";d.PRINTER_STATUS_ERR_NETWORK="PRINTER_STATUS_ERR_NETWORK";d.PRINTER_STATUS_ERR_NOT_CONNECTED="PRINTER_STATUS_ERR_NOT_CONNECTED";d.PRINTER_STATUS_ERR_NOT_FOUND="PRINTER_STATUS_ERR_NOT_FOUND";d.PRINTER_STATUS_ERR_PARAM="PRINTER_STATUS_ERR_PARAM";d.PRINTER_STATUS_ERR_PROCESSING="PRINTER_STATUS_ERR_PROCESSING";d.PRINTER_STATUS_ERR_RESPONSE="PRINTER_STATUS_ERR_RESPONSE";d.PRINTER_STATUS_ERR_TIMEOUT="PRINTER_STATUS_ERR_TIMEOUT";d.PRINTER_STATUS_ERR_UNSUPPORTED="PRINTER_STATUS_ERR_UNSUPPORTED";d.PRINTER_STATUS_SUCCESS="PRINTER_STATUS_SUCCESS";d.PRINTER_TYPE_ANY="PRINTER_TYPE_ANY";d.PRINTER_TYPE_APD="PRINTER_TYPE_APD";d.PRINTER_TYPE_EPSON="PRINTER_TYPE_EPSON";d.PRINTER_TYPE_NATIVE="PRINTER_TYPE_NATIVE";d.PRINTER_TYPE_ZEBRA="PRINTER_TYPE_ZEBRA";e.createPropsProxy(d,[],a);e.createMethodsProxy(d,[{methodName:"enumerateSupportedTypes",nativeName:"enumerateSupportedTypes",persistentCallbackIndex:0,valueCallbackIndex:2},{methodName:"searchPrinters",nativeName:"searchPrinters",persistentCallbackIndex:1,valueCallbackIndex:3},{methodName:"stopSearch",nativeName:"stopSearch",valueCallbackIndex:0},{methodName:"getPrinterByID",nativeName:"getPrinterByID",valueCallbackIndex:1},{methodName:"enumerate",nativeName:"enumerate",persistentCallbackIndex:0,valueCallbackIndex:2}],a);e.createPropsProxy(d,[{propName:"defaultInstance:getDefault:setDefault",propAccess:"rw",customSet:function(g){if(!g||"function"!=typeof g.getId){throw"Default object should provide getId method!"}d.setDefaultID(g.getId())}},{propName:"defaultID:getDefaultID:setDefaultID",propAccess:"rw"}],a);d.getId=function(){return d.getDefaultID()};e.createPropsProxy(d,[{propName:"ID",propAccess:"r"},{propName:"deviceName",propAccess:"r"},{propName:"printerType",propAccess:"r"},{propName:"deviceAddress",propAccess:"r"},{propName:"devicePort",propAccess:"rw"},{propName:"connectionType",propAccess:"r"},{propName:"isConnected",propAccess:"r"}],a,function(){return this.getId()});e.createMethodsProxy(d,[{methodName:"connect",nativeName:"connect",persistentCallbackIndex:0,valueCallbackIndex:2},{methodName:"connectWithOptions",nativeName:"connectWithOptions",persistentCallbackIndex:1,valueCallbackIndex:3},{methodName:"requestState",nativeName:"requestState",persistentCallbackIndex:1,valueCallbackIndex:3},{methodName:"disconnect",nativeName:"disconnect",persistentCallbackIndex:0,valueCallbackIndex:2},{methodName:"printFile",nativeName:"printFile",persistentCallbackIndex:2,valueCallbackIndex:4},{methodName:"printImageFromFile",nativeName:"printImageFromFile",persistentCallbackIndex:4,valueCallbackIndex:6},{methodName:"printRawString",nativeName:"printRawString",persistentCallbackIndex:2,valueCallbackIndex:4},{methodName:"enumerateSupportedControlLanguages",nativeName:"enumerateSupportedControlLanguages",persistentCallbackIndex:0,valueCallbackIndex:2},{methodName:"getProperty",nativeName:"getProperty",persistentCallbackIndex:1,valueCallbackIndex:3},{methodName:"getProperties",nativeName:"getProperties",persistentCallbackIndex:1,valueCallbackIndex:3},{methodName:"getAllProperties",nativeName:"getAllProperties",persistentCallbackIndex:0,valueCallbackIndex:2},{methodName:"setProperty",nativeName:"setProperty",valueCallbackIndex:2},{methodName:"setProperties",nativeName:"setProperties",valueCallbackIndex:1}],a,function(){return this.getId()});e.createRawPropsProxy(d,[]);e.namespace(b,d)})(Rho.jQuery,Rho,Rho.util);