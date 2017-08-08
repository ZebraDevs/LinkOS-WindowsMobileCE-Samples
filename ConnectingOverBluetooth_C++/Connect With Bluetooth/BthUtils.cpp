/********************************************** 
 * CONFIDENTIAL AND PROPRIETARY 
 *
 * The source code and other information contained herein is the confidential and the exclusive property of
 * ZIH Corp. and is subject to the terms and conditions in your end user license agreement.
 * This source code, and any other information contained herein, shall not be copied, reproduced, published, 
 * displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
 * expressly permitted under such license agreement.
 * 
 * Copyright ZIH Corp. 2011
 *
 * ALL RIGHTS RESERVED 
 ***********************************************/



#include "stdafx.h"
#include "BthUtils.h"


//Function: BthUtils (constructor)
//Purpose:	Initialize: Winsock and class data members
				

BthUtils::BthUtils()
{
	WORD wVersionRequested;
	WSADATA wsaData;
	wVersionRequested = MAKEWORD( 2, 2 );
	WSAStartup( wVersionRequested, &wsaData );

	m_pDeviceList			= NULL;
	m_pStart				= NULL;
	m_pEnd					= NULL;
	m_pCurrentDevice		= NULL;
	m_iNumDevices			= 0;
	pCallBackFunction		= NULL;
	m_hReadThread			= NULL;
	m_socketServer			= INVALID_SOCKET;
	m_socketClient			= INVALID_SOCKET;
	BthGetMode(&m_dwBluetoothMode);
	if(m_dwBluetoothMode==BTH_POWER_OFF)
	{
		BthSetMode(BTH_DISCOVERABLE);
	}
}

//Function: ~BthUtils (destructor)
//Purpose:	Set radio mode back to original state
//				release the linked list, sockets
//				terminate the ReadThread thread
				

BthUtils::~BthUtils()
{
	//Set radio mode back to original state
	BthSetMode(m_dwBluetoothMode);
	if(m_pStart)
	{
		for(m_pCurrentDevice	= m_pStart;m_pCurrentDevice;)
		{
			DeviceList *temp	= m_pCurrentDevice;
			m_pCurrentDevice	= m_pCurrentDevice->NextDevice;
			free(temp);
		}
		m_pStart=NULL;
	}

	if(m_socketClient)
	    closesocket (m_socketClient);
    if(m_socketServer)
        closesocket (m_socketServer);
	
	
	if(m_hReadThread)
	{
		DWORD dwExitCode = 0;
		TerminateThread(m_hReadThread, dwExitCode);
	}

	WSACleanup();

}

//Function: DiscoverDevices
//Purpose:	Searches Bluetooth devices in range
//				Populates the link list with the name and address of the devices found
//Return: If error occurs, returns the appropriate WSAGetLastError, otherwise returns zero.
				
int BthUtils::DiscoverDevices()
{
	WSAQUERYSET		wsaq;
	HANDLE			hLookup;
	DeviceList *	tempDevice;
	
	union {
		CHAR buf[5000];
		double __unused;	// ensure proper alignment
	};
	
	LPWSAQUERYSET pwsaResults = (LPWSAQUERYSET) buf;
	DWORD dwSize  = sizeof(buf);
	BOOL bHaveName;

    ZeroMemory(&wsaq, sizeof(wsaq));
	wsaq.dwSize = sizeof(wsaq);
	wsaq.dwNameSpace = NS_BTH;
	wsaq.lpcsaBuffer = NULL;

	if (ERROR_SUCCESS != WSALookupServiceBegin (&wsaq, LUP_CONTAINERS, &hLookup))
	{
		return WSAGetLastError();
	}

	ZeroMemory(pwsaResults, sizeof(WSAQUERYSET));
	pwsaResults->dwSize = sizeof(WSAQUERYSET);
	pwsaResults->dwNameSpace = NS_BTH;
	pwsaResults->lpBlob = NULL;
	
	if(m_pStart)
	{
		for(m_pCurrentDevice=m_pStart;m_pCurrentDevice;)
		{
			DeviceList *temp=m_pCurrentDevice;
			m_pCurrentDevice=m_pCurrentDevice->NextDevice;
    		free(temp);
		}
	}
	m_pEnd=m_pStart=NULL;
	m_iNumDevices=0;
	while (true)
	{	
		if(WSALookupServiceNext (hLookup, LUP_RETURN_NAME | LUP_RETURN_ADDR, &dwSize, pwsaResults)!=ERROR_SUCCESS)
			break;
		ASSERT (pwsaResults->dwNumberOfCsAddrs == 1);
		//Populate the link list		
		tempDevice=(DeviceList*)malloc(sizeof(DeviceList));
		tempDevice->NextDevice=NULL;
		if(m_pStart==NULL)
		{
			m_pStart = tempDevice;
			m_pEnd=m_pStart;
		}
		else
		{
			m_pEnd->NextDevice =tempDevice;
			m_pEnd=tempDevice;
		}
		m_iNumDevices++;
		m_pEnd->bthAddress = ((SOCKADDR_BTH *)pwsaResults->lpcsaBuffer->RemoteAddr.lpSockaddr)->btAddr;
		bHaveName = pwsaResults->lpszServiceInstanceName && *(pwsaResults->lpszServiceInstanceName);
		//If device name is available, add to node
		StringCchPrintf(m_pEnd->bthName, ARRAYSIZE(m_pEnd->bthName),L"%s",bHaveName ? pwsaResults->lpszServiceInstanceName : L"");
	}
    
	WSALookupServiceEnd(hLookup);
//	LeaveCriticalSection(&criticalSection);
	return 0;
}

//Function: GetDeviceInfo
//Purpose:	Returns name and address of all the devices in the link list in DeviceInfo. This is used by the UI to display the names and addresses of the devices found
//Output:	DeviceInfo: name and address
//Return: Success returns zero.

int BthUtils::GetDeviceInfo(DeviceInfo *pPeerDevicesInfo)
{
	int iCtr=0;
	for (m_pCurrentDevice = m_pStart;(m_pCurrentDevice);m_pCurrentDevice=m_pCurrentDevice->NextDevice,iCtr++) 
	{ 
		StringCchPrintf(pPeerDevicesInfo[iCtr].szDeviceNameAddr, ARRAYSIZE(pPeerDevicesInfo[iCtr].szDeviceNameAddr),  L"%s:(%04x%08x)", m_pCurrentDevice->bthName, GET_NAP(m_pCurrentDevice->bthAddress), GET_SAP(m_pCurrentDevice->bthAddress));		
	} 
	return 0;
}

//Function: OpenServerConnection
//Purpose:	Opens a server socket for listening. Registers the service. Creates a thread, ReadThread for reading incoming messages.
//Input:	The SDP record of the service to register, size of the SDP record, channel offset in the record, pointer to the UI function that displays the messages in the UI
//Return: If error occurs, returns the appropriate WSAGetLastError, otherwise returns zero.


int BthUtils::OpenServerConnection(BYTE *rgbSdpRecord, int cSdpRecord, int iChannelOffset, void (*funcPtr)(WCHAR *))
{
	int iNameLen=0;
	if(m_socketServer==INVALID_SOCKET)
	{
		m_socketServer = socket (AF_BT, SOCK_STREAM, BTHPROTO_RFCOMM);
		if (m_socketServer  == INVALID_SOCKET) 
		{
			return WSAGetLastError ();
		}
	
		SOCKADDR_BTH sa;
		memset (&sa, 0, sizeof(sa));
		sa.addressFamily = AF_BT;
		sa.port = 0;
		if (bind (m_socketServer, (SOCKADDR *)&sa, sizeof(sa))) 
		{
			return WSAGetLastError ();
		}
		iNameLen = sizeof(sa);
		if (getsockname(m_socketServer, (SOCKADDR *)&sa, &iNameLen))	
		{
			return WSAGetLastError ();
		}

		if(RegisterService(rgbSdpRecord, cSdpRecord, iChannelOffset, (UCHAR)sa.port)!=0)
			return WSAGetLastError();

		if (listen (m_socketServer, SOMAXCONN)) 
		{
			return WSAGetLastError ();
		}
	}
	pCallBackFunction=funcPtr;
	return 0;
}

//Function: RegisterService
//Purpose:	Publishes the SDP record.
//Input:	The SDP record of the service to register, size of the SDP record, channel offset in the record, channel number assigned automatically by OpenServerConnection
//Return: If error occurs, returns the appropriate WSAGetLastError, otherwise returns zero.

int BthUtils::RegisterService(BYTE *rgbSdpRecord, int cSdpRecord, int iChannelOffset, UCHAR channel)
{
		ULONG recordHandle = 0;
	
	struct bigBlob
	{
		BTHNS_SETBLOB   b;

	}*pBigBlob;

	pBigBlob = (bigBlob *)malloc(sizeof(struct bigBlob)+cSdpRecord);
	ULONG ulSdpVersion = BTH_SDP_VERSION;
	pBigBlob->b.pRecordHandle   = &recordHandle;
	pBigBlob->b.pSdpVersion     = &ulSdpVersion;
	pBigBlob->b.fSecurity       = 0;
	pBigBlob->b.fOptions        = 0;
	pBigBlob->b.ulRecordLength  = cSdpRecord;

	memcpy (pBigBlob->b.pRecord, rgbSdpRecord, cSdpRecord);
	pBigBlob->b.pRecord[iChannelOffset] = (unsigned char)channel;
	BLOB blob;
	blob.cbSize    = sizeof(BTHNS_SETBLOB) + cSdpRecord - 1;
	blob.pBlobData = (PBYTE) pBigBlob;

	WSAQUERYSET Service;
	memset (&Service, 0, sizeof(Service));
	Service.dwSize = sizeof(Service);
	Service.lpBlob = &blob;
	Service.dwNameSpace = NS_BTH;
	if (WSASetService(&Service,RNRSERVICE_REGISTER,0) == SOCKET_ERROR)
	{
		free(pBigBlob);
		return WSAGetLastError();
	}
	else
	{
		free(pBigBlob);
		return 0;
	}
}



//Function: SendMessageToServer
//Purpose:	Opens a client socket to connect to the server. Called when the local device initiates the chat.
//Input:	string containing the GUID of the service running on the server that the client wants to connect.
//			iSelectedDeviceIndex is the selected device in the UI that the local device wants to connect. 		
//Return: If error occurs, returns the appropriate WSAGetLastError, otherwise returns zero.

int BthUtils::SendMessageToServer(WCHAR *strGUID, char *szMessage, int iSelectedDeviceIndex)
{
	int iRetVal=0, iLenMessage=0, iBytesSent=0 ;
	if(m_socketClient==INVALID_SOCKET)
	{
		iRetVal=OpenClientConnection(strGUID, iSelectedDeviceIndex);
		if(iRetVal!=0)
		{
			return iRetVal;
		}
	}
	iLenMessage = (strlen (szMessage) + 1) * sizeof(char);
    if (iLenMessage > sizeof (char)) 
    {
		iBytesSent = send (m_socketClient, (char *)szMessage, iLenMessage, 0);
		if (iBytesSent != iLenMessage)
        {
	        return WSAGetLastError ();
        }
	}

	CloseClientConnection();
	m_socketClient=INVALID_SOCKET;

	return 0;
}

//Function: OpenClientConnection
//Purpose:	Opens a client socket to connect to the server.
//Input:	string containing the GUID of the service running on the server that the client wants to connect.
//			iSelectedDeviceIndex is the selected device in the UI that the local device wants to connect. 							
//Return: If error occurs, returns the appropriate WSAGetLastError, otherwise returns zero.
			

int BthUtils::OpenClientConnection(WCHAR *strGUID, int iSelectedDeviceIndex)
{

	if (m_socketClient==INVALID_SOCKET)
	{
		GUID ServerGuid;

		if(GetGUID(strGUID, &ServerGuid))
			return -1;
		m_socketClient = socket (AF_BT, SOCK_STREAM, BTHPROTO_RFCOMM);

		if (m_socketClient == INVALID_SOCKET) 
		{
			return WSAGetLastError();
		}
			
		SOCKADDR_BTH sa;
		SOCKADDR *sdr;

		memset (&sa, 0, sizeof(sa));
		sa.addressFamily = AF_BT;			
		//Search for the selected device in the list box in the link list
		m_pCurrentDevice=m_pStart;
		sa.serviceClassId=ServerGuid;
		
		if(iSelectedDeviceIndex==-1)
		{
			sa.btAddr=m_saClient.btAddr;
		}
		else
		{
			for (int iCount = 0 ;(m_pCurrentDevice)&&iCount!=iSelectedDeviceIndex;m_pCurrentDevice=m_pCurrentDevice->NextDevice,iCount++);
			sa.btAddr = m_pCurrentDevice->bthAddress;
		}
		
		sa.port = 6 && 0xff;
		sdr = (SOCKADDR FAR*)&sa;
		if (connect (m_socketClient, (SOCKADDR*)&sa, sizeof(sa)) == SOCKET_ERROR) 
		{
			m_socketClient=INVALID_SOCKET;
			return WSAGetLastError();
		}
	}
	return 0;
}
//Function: CloseClientConnection
//Purpose:	Closes a client socket to connect to the server.
//Return: None.
void BthUtils::CloseClientConnection()
{
	closesocket(m_socketClient);
	//CloseHandle ((LPVOID)m_socketClient);
}

//Function: GetGUID
//Purpose:	Conversts a string containing the GUID into a GUID datatype.
//Input:		string cotaining the GUID
//Output:	GUID type
//Return: Returns -1 in case of an error, otherwise returns zero.

int BthUtils::GetGUID(WCHAR *psz, GUID *pGUID) 
{
	int data1, data2, data3;
	int data4[8];

	if (11 ==  swscanf(psz, L"%08x-%04x-%04x-%02x%02x-%02x%02x%02x%02x%02x%02x\n",
					&data1, &data2, &data3,
					&data4[0], &data4[1], &data4[2], &data4[3], 
					&data4[4], &data4[5], &data4[6], &data4[7])) {
		pGUID->Data1 = data1;
		pGUID->Data2 = data2 & 0xffff;
		pGUID->Data3 = data3 & 0xffff;

		for (int i = 0 ; i < 8 ; ++i)
			pGUID->Data4[i] = data4[i] & 0xff;

		return 0;
	}
	return -1;
}

//Function: GetLocalDeviceName
//Purpose:	Returns the name of the owner set in the registry
//Output:	DeviceInfo: (only)name
//Return: Returns -1 in case of an error, otherwise returns zero.

int BthUtils::GetLocalDeviceName(DeviceInfo *pLocalDeviceInfo)

{
    HKEY hKey;
    DWORD dwRegType, dwRegSize;
	if(RegOpenKeyEx(HKEY_CURRENT_USER,L"ControlPanel\\Owner",0,0,&hKey)==ERROR_SUCCESS)
	{
		if(RegQueryValueEx(hKey,L"Name",0,&dwRegType,(LPBYTE)pLocalDeviceInfo->szDeviceNameAddr,&dwRegSize)==ERROR_SUCCESS)
		{
			if (dwRegSize>MAX_NAME_SIZE) 
			{
				RegCloseKey(hKey);
				return -1; 
			}
			RegCloseKey(hKey);
		}
		RegCloseKey(hKey);
	}
    return 0;
}

//Function: GetDeviceInfo
//Purpose:	Searches the link list for the specified device and returns address and name in DeviceInfo
//Input:		The current device index selected in the UI
//Output:	DeviceInfo: name and address
//Return: Returns -1 in case of an error, otherwise returns zero.

int BthUtils::GetDeviceInfo(DeviceInfo *pPeerDeviceInfo, int iSelectedItem)
{
	int iCtr=0;

	for (m_pCurrentDevice = m_pStart;(m_pCurrentDevice);m_pCurrentDevice=m_pCurrentDevice->NextDevice,iCtr++) 
	{ 
		if(iCtr==iSelectedItem)
		{
			StringCchPrintf(pPeerDeviceInfo[0].szDeviceNameAddr, ARRAYSIZE(pPeerDeviceInfo[0].szDeviceNameAddr), L"%s:(%04x%08x)", m_pCurrentDevice->bthName, GET_NAP(m_pCurrentDevice->bthAddress), GET_SAP(m_pCurrentDevice->bthAddress));		
			return 0;
		}
	} 
	return -1;
}
