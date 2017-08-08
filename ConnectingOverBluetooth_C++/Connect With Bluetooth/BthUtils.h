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



#pragma once
#include <winsock2.h>
#include <ws2bth.h>
#include <bthapi.h>
#include <bthutil.h>


#define MAX_NAME_SIZE 128
#define MAX_ADDR_SIZE 15
#define MAX_MESSAGE_SIZE 256

#ifndef ARRAYSIZE
#define ARRAYSIZE(a)   (sizeof(a)/sizeof(a[0]))
#endif


struct DeviceList
{ 
	BT_ADDR bthAddress;
	TCHAR bthName[40];
	DeviceList *NextDevice;
};

struct DeviceInfo 
{
	WCHAR szDeviceNameAddr[MAX_NAME_SIZE];

}; 

class BthUtils
{
public:
	BthUtils();
	~BthUtils();
	int DiscoverDevices();
	int GetNumDevices(){return m_iNumDevices;};
	int GetDeviceInfo(DeviceInfo *pPeerDevicesInfo);
	int GetLocalDeviceName(DeviceInfo *pLocalDeviceInfo);
	int GetDeviceInfo(DeviceInfo *pPeerDeviceInfo, int iSelectedItem);
	int OpenServerConnection(BYTE *rgbSdpRecord, int cSdpRecord, int iChannelOffset, void (*funcPtr)( WCHAR*));
	int SendMessageToServer(WCHAR *strGUID, char *szMessage, int iSelectedDeviceIndex);


private:
	DeviceList *m_pDeviceList, *m_pStart, *m_pEnd, *m_pCurrentDevice;
	int m_iNumDevices;
	void (*pCallBackFunction)( WCHAR* ) ;
	HANDLE m_hReadThread;
	SOCKET m_socketServer, m_socketClient;
	SOCKADDR_BTH m_saClient;
	DWORD m_dwBluetoothMode;

	int RegisterService(BYTE *rgbSdpRecord, int cSdpRecord, int iChannelOffset, UCHAR channel);
	int OpenClientConnection(WCHAR *strGUID, int iSelectedDeviceIndex);
	void CloseClientConnection();
	int GetGUID(WCHAR *psz, GUID *pGUID) ;

};