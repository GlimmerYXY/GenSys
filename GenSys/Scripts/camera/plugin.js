// JavaScript Document
var pageEnum = {
	TypeLoginPage: 0,
	TypePreviewPage: 1,
	TypePlaybackPage: 2,
	TypeLiveParamPage: 3,
	TypeNormalVideoParamPage: 4,
	TypePrivateZonePage: 5,
	TypeMotionParamPage: 6,
	TypeNoVideoParamPage: 7,
	TypeRoiPage: 8,
	TypePLinePage: 9,
	TypePZonePage: 10,
	TypeGLostLPage: 11,
	TypeHDetePage: 12,
	TypeFDetePage: 13,
	TypePCCountPage: 14,
	TypeClipPage: 15,
	TypePIRParamPage:16,
	TypeIntrusionDetecPage:17,
	TypeTypeMeterRecognitionPage:18,
	TypeHGInt:19,
	TypeFloodlight:20
};

var eventEnum = {
	MsgUserLoginEvent: 0,
	MsgPreviewEvent: 1,
	MsgPlayBackEvent: 2,
	MsgStatusEvent: 3,
	MsgPlaybackCapEvent: 4,
	MsgGetAndSetParamEvent: 5,
	MsgRemoteUpgradeEvent: 6,
	MsgRemoteTestEvent: 7,
	MsgPlaybackRecEvent: 8,
	MsgBitrateEvent: 9,
	MsgAlarmIntManageEvent: 10,
	MsgDebugStringEvent: 11,
	MsgTimeLineEvent:12,
	MsgDownloadBoxEvent:13,
	MsgPtzControlEvent:14,
	MsgFishEyeSoftEvent:15
};

var RecFileTypeEnum = {
	RSFileType : 1,
	RSAVIFileType : 2,
	RSMP4FileType : 4
};

var CapFileTypeEnum = {
	RSBMPFileType : 0,
	RSPNGFileType : 1,
	RSJPGFileType : 2
};

var methodEnum = {
	MsgNoType: 0,
	MainMsgInitPlugin: 1,
	MainMsgUnInitPlugin: 2,
	MainMsgUserLogin: 3,
	MainMsgUserLogout: 4,
	MainMsgPreview: 5,
	SubMsgPreviewStart: 6,
	SubMsgPreviewStop: 7,
	SubMsgPreviewCodeType: 8, //main stream or sub stream
	SubMsgCapture: 9,
	SubMsgRecord: 10,
	SubMsgPreviewRatio: 11,

	MainMsgSearchRec: 12,
	SubMsgSearchDay: 13,
	SubMsgSearchMonth: 14,
	MainMsgSetPlayBackMode: 15,
	MainMsgGetLoginInfo: 16,
	SubMsgSound: 17,
	MainMsgPathInfo: 18,
	SubMsgGetPathInfo: 19,
	SubMsgGetSelPath: 20,
	SubMsgSetPathInfo: 21,
	MainMsgGetLanguage: 22,
	SubMsgPlaybackCapSuccess: 23, //
	SubMsgPlaybackCapFail: 24,
	MainMsgBrowserFile: 25,
	SubMsgBrowserPic: 26,
	SubMsgBrowserDir: 27,
	MainMsgGetOcxVersion: 28,
	SubMsgZoomView: 29,
	MainMsgPTZcontrol: 30,
	MainMsgGetWeekStart: 31,
	MainMsgChangePage: 32,
	MainMsgGetAndSetParameter: 33,
	SubMsgGetParameter: 34,
	SubMsgSetParameter: 35,
	MainMsgRemoteUpgrade: 36,
	SubMsgGetUpgradeFile: 37,
	SubMsgStartUpgrade: 38,
	SubMsgStopUpgrade: 39,
	MainMsgCtrlParamPageVideo: 40,
	MainMsgRemoteTest: 41,
	SubMsgPlaybackRecSuccess: 42,
	SubMsgPlaybackRecFail: 43,
	MainMsgBitrate: 44,
	MainMsgGetSysLangType: 45,
	MainMsgDisconnection: 46,
	MainMsgTalkerOperator: 47,
	MainMsgSetGoodLAreaStatus: 48,
	MainMsgPLWriteLine: 49,
	MainMsgPLWriteLineTwoway: 50,
	MainMsgGLLRuleType: 51,
	MainMsgRuleNum: 52,
	MainMsgSelectResolutionset: 53,
	MainMsgRemoteParamBackup: 54,
	SubMsgGetParamFile: 55,
	SubMsgSetParamFile: 56,
	SubMsgPreviewInit: 57,
	SubMsgPreviewSplit: 58,
	SubMsgPreviewPrePage: 59,
	SubMsgPreviewNextPage: 60,
	MainMsgDebugFlag: 61,
	MainMsgInitWindow: 62,
	SubMsgInitPreview: 63,
	SubMsgInitPlayback: 64,
	SubMsgInitLiveParam: 65,
	SubMsgInitMotionParam: 66,
	SubMsgInitImgControlParam: 67,
	SubMsgInitPrivacyZoneParam: 68,
	SubMsgInitWindowAll: 69,
	SubMsgPreviewPageIndex: 70,
	SubMsgFullScreen: 71,
	SubMsgSelectWnd: 72,
	SubMsgResetIndex: 73,
	SubMsgGetViewsIndex: 74,
	MainMsgPlayback: 75,
	SubMsgPlaybackStart: 76,
	SubMsgPlaybackStop: 77,
	SubMsgPlaybackSplit: 78,
	SubMsgPlaybackCodeType: 79,
	SubMsgPlaybackRatio: 80,
	SubMsgPlaybackPlayMode: 81,
	SubMsgPlaybackPageIndex: 82,
	SubMsgGetPlaybackTime: 83,
	SubMsgSetPlaybackTime: 84,
	MainMsgParamvideo: 85,
	SubMsgParamChangeChn: 86,
	SubMsgDownloadStart: 87,
	SubMsgDownloadStop: 88,
	SubMsgDownloadStatus: 89,
	MainMsgTimeline:90,
	MainMsgDownloadBox:91,
	SubMsgInitTimeline:92,
	SubMsgInitTimelineData:93,
	SubMsgShowMovePointer:94,
	SubMsgHideMovePointer:95,
	SubMsgDownloadInit:96,
	SubMsgDownloadData:97,
	SubMsgSetVolume:98,
	SubMsgSetSync:99,
	SubMsgTimelineZoom:100,
	MainMsgDualTalk:101,
	SubMsgDbclkFullscreen:102,
	SubMsgFishEye:103,
	SubMsgFishEyePtzPos:104,
	MainMsgAutoUpgrade:105,
	MainMsgModifyPsw:106,
	SubMsgBitrate:107,
	SubMsgSetColor:108,
	MainMsgExportEXCEL:109,
	SubMsgFishEyeSoftPtz:110,
	SubMsgSetFishEyeSoftMode:111,
	MainMsgIPCSaveToDev:112,
	SubMsgGetFishEyeSoftChSelect:113,
	SubMsgSetDelayTime:114,
	SubMsgClearPlayFlag:115,
	MainMsgOpenSafariByUrl:116,
	SubMsg3DPosition: 117,
	SubMsgPlaybackNo:118,
	SubMsgShowPlaybackTime:119,
	SubMsgGetActivateKey:120,
	SubMsgGetActivateFile:121,
	SubMsgSendActivateFile:122,
	MainMsgResolution:123,
	SubMsgResolution:124,
	MainMsgSimpleCmd:125,
	SubMsgDownloadErrNo:126,
	MainMsgValidate:127,
	MainMsgGetCustomerInfo:128,
	SubMsgGetDDNSArr:129,
	SubMsgGetCInfoArr:130,
	SubMsgUpdateAutoConn:131,
	MainMsgImgToFull:132,

	SubMsgEmailTest: 301,
	SubMsgDDNSTest: 302,
	SubMsgRemoteReboot: 303,
	SubMsgFtpTest: 323,
	SubMsgHddFormat: 309,
    SubMsgAddAllDevice:312,   // A key to add message signaling function
	SubMsgActivateCloud: 321,
    SubMsgCloudCheck:327,   //c10 cloud check
	SubMsgRebootIPC: 329,
	SubMsgIPCLoadDefault: 330,
    MsgRemoteOneKeyAddIPC : 333,
	SubMsgZeroChnStatus:336,
	SubMsgRemoteCheck: 337,
	SubMsgValidIPTest:365,
	SubMsgGetDDNSID: 403,
	SubMsgStopEmailTest:412,
	SubMsgNewEmailTest:413,
	MsgRoutePeat:420,
	MsgRouteAdd:421,
	MsgNewStreamset:425,
	MsgIMPReq:436,
	SubMsgSearchSmartCount:710,
	SubMsgFishEyeWheelScroll:711
};

var alarmEnum = {
	RSNetMsgLoginForbidIP: 113,
	MsgPirAlarm:187,
	MsgVLossAlarm: 189,
	MsgDevStatReport: 190,
	MsgMotionAlarm: 191,
	MsgIOAlarm: 192,
	MsgFtpUpgradeAlarm: 203,
	MsgIntelPeaAlarm: 205,
	MsgOscRuleAlarm: 206,
	MsgVideoHideAlarm:207,
	MsgBitrateInfo:208,
	MsgRecordStatusReport: 212,
	MsgHddStatusReport: 213,
	MsgIntelIpcPeaAlarm:215,
	MsgIpcOSCAlarm:216,
	MsgIntelIpcPeaAreaAlarm:218,
	MsgAlarmIntManage:251,
	MsgAlarmFishEyeIpcStat:252,
	MsgAlarmPTZIpcStat:253,
	MsgDevPreviewChangeReport:258,
	MsgDevChModeReport:259,
	MsgSoundAlarmReport:272,
	MsgDevAllStatusReq: 610,
	MsgRemoteCHStatusReq: 611,
	MsgStatusRequest:890
};

var retEnum = {
	RSNetMsgConnectFail: 2,
	Reconnecting: 3,
	FILE_PLAY_END:11,
	RSNetMsgLoginSuccess: 101,
	RSNetMsgLoginNoUserName: 103,
	RSNetMsgLoginPasswordError: 104,
	RSNetMsgLoginFail: 105,
	RSNetMsgLoginNoRight: 106,
	RSNetMsgIpFilter: 107,
	RSNetMsgOverMaxUser: 108,
	RSNetMsgNotSupportLoginType: 109,
	RSNetMsgLoginUserDisable:110,
	RSNetMsgLoginForceChangePWD:111,
	RSNetMsgLoginForceCloseBrowser:112,
	RSNetMsgSendInfoSuccess:125,
	RSNetMsgSendInfoFailed:126,
	RSNetMsgPreviewOpenStreamSuccess: 202,
	RSNetMsgPreviewOpenStreamFail: 203,
	RSNetMsgPreviewStreamClosed: 204,
	RSNetMsgPreviewMaxPrevNumErr: 208,
	RSNetMsgRecordPlayDevicePlayback: 306,
	RSNetMsgRecordPlayHDDFormat:307,
	RSNetMsgNoBandWidth: 308,
	RSNetMsgNoPreviewAuth: 309,
	RSNetMsgNoPlaybackAuth:310,
	RSNetMsgIsModifyHdd:311,
	RSNetMsgRecordPlayMutexPlayback:322,
	RSMetMsgPreviewActivateFaile:323,
	RSNetMsgDualtalkClosed:350,
	SingleClick: 50000,
	DoubleClick: 50001,
	RecordStatus: 50002,
	EscPress: 50003,
	CreateDecodeFailed: 50004,
	RightClick:50005
};

var streamTypeEnum = {
	MainStreamType: 0,
	SubStreamType: 1,
	MobileStreamType: 2,
	ZeroStreamType:4
};

var videoDisplayMode = {
	Original: 0,
	Overspread: 1,
	FourToThree: 2,
	SixteenToNine: 3
};
var devTypeEnum = {
	DEV_DVR: 0, //simulation DVR
	DEV_MVR: 1, //vehicle-mounted
	DEV_INTEL: 2,
	DEV_NVR: 3, //NVR
	DEV_IPC: 4, //IPC
	DEV_HDVR: 6 //HDVR
}

var ptzTypeEnum = {
	MsgPTZUp: 1,
	MsgPTZDown: 2,
	MsgPTZLeft: 3,
	MsgPTZRight: 4,
	MsgPTZUpLeft: 5,
	MsgPTZUpRight: 6,
	MsgPTZDownLeft: 7,
	MsgPTZDownRight: 8,
	MsgPTZZoomIn: 11, //
	MsgPTZZoomOut: 12, //
	MsgPTZFocusNear: 13, //
	MsgPTZFocusFar: 14, //
	MsgPTZIRISOpen: 15, //
	MsgPTZIRISClose: 16, //
	MsgPTZAutoScan: 21,
	MsgPTZCruise: 51,
	MsgPTZCruise_DetectPresetNum: 52,
	MsgPTZSetPPCruise:53,  //
	MsgPTZCallPPCruise	:54,  //
	MsgPTZStartPattermCruise:55 , //
	MsgPTZEndPattermCruise:56 ,         //
	MsgPTZCallPattermCruise:57 ,         //
	MsgPTZGuard:90,
	MsgPTZSetPreset: 91,
	MsgPTZClearPreset: 92,
	MsgPTZCallPreset: 93,
	Open_Screen_PTZ: 97,
	Close_Screen_PTZ: 98,
	MsgPTZLineScanA: 98,  //
	MsgPTZLineScanB: 99,   //
	MsgPTZDefault:   100,
	MsgPTZ_ZOOM_POSITION:   101,
	MsgPTZ_FOCUS_POSITION:   102,
	MsgPTZ_ZOOM_MOVE:   103,
	MsgPTZ_FOCUS_MOVE:   104,
	MsgPTZ_AUTO_FOCUS:   105,
	MsgPTZ_AREA_FOCUS:   106,
	MsgPTZ_REFRESH_INFOR: 107,
	MsgPTZ_CALIBRATION_SETTING:108,
	MsgPTZ_TOUR_START:109,
	MsgPTZ_TOUR_STOP:110,
	MsgPTZ_PATTERN_START:111,
	MsgPTZ_PATTERN_STOP:112,
	MsgPTZ_PATTERN_RECORD_START:113,
	MsgPTZ_PATTERN_RECORD_STOP:114,
	MsgPTZ_OSD:115,
	MsgPTZ_3D_POSITION:116,
	MsgPTZ_LIGHT:117,
	MsgPTZ_RAIN:118
};

var VideoCtrlEnum = {
	ParamVideoClearData: 1,
	ParamVideoClearAllData: 2,
	ParamVideoSelectAllData: 3,
	ParamVideoStartPlay: 4,
	ParamVideoStopPlay: 5,
	ParamVideoSaveData: 6
};

var SplitModeEnum = {
	WINDOW_MODE_1: 0,
	WINDOW_MODE_4: 1,
	WINDOW_MODE_6: 2,
	WINDOW_MODE_8: 3,
	WINDOW_MODE_9: 4,
	WINDOW_MODE_10: 5,
	WINDOW_MODE_10_1: 6,
	WINDOW_MODE_12: 7,
	WINDOW_MODE_13: 8,
	WINDOW_MODE_13_1: 9,
	WINDOW_MODE_14: 10,
	WINDOW_MODE_16: 11,
	WINDOW_MODE_20: 12,
	WINDOW_MODE_25: 13,
	WINDOW_MODE_36: 14
};

var errCodeEnum = {
	Code_Success: 0,
	Code_ParamerErr: 1,
	Code_UnInitErr: 2,
	Code_UnknownErr: 3,
	Code_NoPermission:4
}

var ptzControlEnum = {
	EPtzControlNormal: 0,
	EPtzControlCruise: 1,
	EPtzControlPreset: 2,
	EPtzPresetNum_t: 3,
	EPtzControlSetPPCruise: 4,
	EPtzControlCallCruise: 5,
	EPtzControlAreaScan: 6,
	EPtzControlPosition3D: 7
}

var playbackModeEnum = {
	PLAY_MODE_NORMAL: 0x0001,
	PLAY_MODE_STOP: 0x0002,
	PLAY_MODE_PAUSE: 0x0003,
	PLAY_MODE_SLOW: 0x0004,
	PLAY_MODE_SLOW4: 0x0005,
	PLAY_MODE_SLOW8: 0x0006,
	PLAY_MODE_SLOW16: 0x0007,
	PLAY_MODE_FAST_FORWARD2: 0x0010,
	PLAY_MODE_FAST_FORWARD4: 0x0011,
	PLAY_MODE_FAST_FORWARD8: 0x0012,
	PLAY_MODE_FAST_FORWARD16: 0x0013,
	PLAY_MODE_FAST_FORWARD32: 0x0014,
	PLAY_MODE_SINGLE_FRAME: 0x0030,
}

var paramPage = {
	MsgParamSystemBase: 502,
	MsgParamHdd: 503,
	MsgParamUser: 505,
	MsgParamColor: 508,
	MsgParamVideoCover: 509,
	MsgParamPtz: 510,
	MsgParamNetworkBase: 511,
	MsgParamDDNS: 512,
	MsgParamEmail: 514,
	MsgParamMotion: 516,
	MsgParamAbnormal: 517,
	MsgParamIOAlarm: 518,
	MsgParamRecord: 519,
	MsgParamSchedule: 520,
	MsgParamDefault: 521,
	MsgParamIntelligent:522,
	MsgParamGeneral: 524,
	MsgParamMaintain: 525,
	MsgParamPlatform: 529,
	MsgParamIpc: 530,
	MsgParam3G: 533,
	MsgParamIPFilter: 547,
	MsgParamRtsp: 548,
	MsgParamFtp: 549,
	MsgParamFtpAutoUpgrade: 556,
	MsgParamSystemIDCtrl: 558,
	MsgParamNormalCloSto: 563,
	MsgParamNormalCloStoEm:564,
	MsgParamPerimeterLine: 566,
	MsgParamGoodsLostLegacy: 568,
	MsgParamModifyMainStream: 570,
	MsgParamModifySubStream: 571,
	MsgParamModifyMobileStream: 572,
	MsgParamModifyLiving: 573,
	MsgParamModifyEmailSchedule: 578,
	MsgParamVoice: 581,
	MsgParamIDSet: 582,
	MsgParamIntelliRec:585,
	MsgParamIPCImageSet: 587,
	MsgParamCustomProtocol: 589,
	MsgParamOD: 592,
	MsgParamAnalogCam: 597,
	MsgParamIPCROI: 591,
	MsgParamCaptureSet: 598,
	MsgParamCapSchedule: 599,
	MsgParamChnInfo: 701,
	MsgParamRecInfo: 702,
	MsgParamPerimeter: 703,
	MsgParamIntHD:705,
	MsgParamIntFD:706,
	MsgParamIntPCC:707,
	MsgParamIntManage: 708, // 2016.03.09
	MsgParamElectricityGrid: 709,
	MsgParamFtpAutoUpgrade: 556,
	MsgParamSystemIDCtrl: 558,
	MsgParamZeroChn:601,
	MsgParamFishEye:711,// 2016.08.29
	MsgParamSwitch:713,
	MsgParamIPCCameaFocusInfo:714,
	MsgParamPreviewCtrl:715,
	MsgParamSwannWifi:717,
	MsgParamGB28181:722,
	MsgParamPir:723,
	MsgParamJDVCAMeterRecongition:724,
	MsgParamJDVCAIntrusionDetection:725,
	MsgParamJDVCARedMantleDetection:726,
	MsgParamUrmetHttp:804,
	MsgParamNewCloudestorage:805,
	MsgParamOutPut:807,
	MsgNewIOAlarm:808,
	MsgParamNetFilter:809,
	MsgParamALTEReport:810,
	MsgParamNewEmail:813,
	MsgParamAlarmLinkagePTZ:814,
	MsgParamModifyAlarmStream:815,
	MsgParamXINQIAOFaceDetection:817,
	MsgParamIOAlarmManage:818,
	MsgParamIeee8021xParam:819,
	MsgParamHttps:822,
	MsgParamCertificates:823,
	MsgParamSnmp:825,
	MsgHGIntParam:826,
    MsgHttpsFileParam:827,
    MsgFloodLightParam:838,
    MsgIPCNetInfoParam:848,
    MsgIPCImpParam:858,
	MsgSoundAlarmParam:861,
	
	MsgParamDevLog: 160608,
	MsgParamScheduleIPC: 160825,
	MsgParamExportIPC: 161121,
	MsgParamTour:171109
}
var fileStatusEnum = {
	FileDown_Not: 101,
	FileDown_Waitting: 102,
	FileDown_Downing: 103,
	FileDown_Complete: 104,
	FileDown_Failed: 105
};

var MaskModeEnum = { //Motion PrivacyZone Mode, Lattice, rectangular, or other
	CannotDraw_MODE: 255, //can't draw Mode
	Polygon_MODE: 2, //Polygon Mode
	GRID_MODE: 1, //Grid Mode
	RECT_MODE: 0, //Rectangular Mode
};

//RemoteChnStatusRpt.DevChnInfo.Abilities
//RsNetAlarmRpt.Abilities
//DevStatRpt.Abilities
var AbilityTypeEnum={
	MAINSTREAM:0,
	SUBSTREAM:1,
	SNAPSTREAM:2,
	OSD:3,
	COLOR:4,
	TIME:5,
	COVER:6,
	MOTIONSET:7,/*motion Ability*/
	MOTIONAREA:8,/*motion video*/
	IO:9,/*The front-end equipment support IO report to the police*/
	PTZ:10,
	IMAGE:11,
	TIIPC:12,
	NOSUPMAINSTREAMPARAM:13,
	NOSUPSUBSTREAMPARAM:14,
	NOSUPMOBILESTREAMPARAM:15,
	INTELLIGENT:16,
	IMAGE_IRIS:17,
	H265:18,
	FISHEYE:19,
	BINOCULARS:20,
	OSDTRANSPARENCY:21,//OSD
	CORRIDOR_ANGLEROTATION:22,//support corridor/angle rotation
	PIR:23,
	SMART_MOTIION:24,
	SUPPROT_WIREFREE:25,//wireless//wireless channel preview can not AutoReconnect
	WHITE_LIGHT:26,
	LOUD_SPEAKER:27,
	AFOCUS:28
};

var CHNStatus={
	CHN_BOTTOM:-1,/*Did not add*/
	CHN_NETWRONG:0,/*Unable to connect to the IPC*/
	CHN_UNAUTHER:1,/*Failed user authentication*/
	CHN_ONLINE:2,/*be connected successfully,auto open preview*/
	CHN_CONNECT:3,/*connecting*/
	CHN_BANDLIMIT:4,/*Stream restricted and be disconnected*/
	CHN_VIDEOLOSS:5,
	CHN_SLEEP:6/*device is online,bug in sleep state,need manually open preview*/
}

var recTypeEnum={
	NormalRecord	:0x1,
	AlarmRecord		:0x2,
	MotionRecord	:0x4,
	IORecord		:0x8,
	PEARecord		:0x10,
	PEALineRecord	:0x10,
	AVDRecord		:0x20,
	OSCRecord		:0x40,
	AllIntelliRec	:0x80,
	SensorRecord	:0x100,
	PEAAreaRecord	:0x200,
	OCCRecord		:0x400,//private zone
	NetbreakRecord	:0x800,//netbreak
	HDRecord		:0x1000,
	FDRecord		:0x2000,
	PCCRecord		:0x4000,
	MothionAndIo	:0x8000,
	PIRRecord       :0x10000,
	SoundRecord     :0x20000,
  	ManualRecord    :0x40000,
	INE_ALL_RECORD	:(0x10|0x20|0x40|0x200|0x1000|0x2000|0x4000),
	AlarmAssemble   :0x7FFFFFFF,//5.0 Use both
	AllRecord	:0xFFFFFFFF,
}

//playback search enumeration--for ipc --bit value
var recordTypeEnum = {
	AllRecordType: 0,
	NormalRecordType: 1,
	AlarmRecordType: 2,
	MotionRecordType: 3,
	IORecordType: 4,
	PEARecordType:5,
	PEALineRecordType:6,
	AVDRecordType:7,
	OSCRecordType:8,
	AllIntelliRecType:9,
	SensorRecordType: 10,
	PEAAreaRecordType:11,
	OCCRecordType:12,
	NetbreakRecordType:13,
	HDRecordType:14,
	FDRecordType:15,
	PCCRecordType:16,
	MotionAndIORecordType:17,
	PIRRecordType:18,
	AlarmAssembleRecordType:19,
	SoundRecordType:20
};

var fishEyeDisplayMode_hard = {
	FishEye_1:0,
	Panoramic_180:1,
	Partition_PTZ4:2,
	FishEye_PTZ3:3,
	Panoramic_360:4,
	Panoramic_360_PTZ1:5,
	Panoramic_360_PTZ3:6,
	Panoramic_360_PTZ6:7,
	Panoramic_360_PTZ8:8,
	Partition_PTZ2:9,
	FishEye_PTZ8:10
}

var fishEyeDisplayMode_soft = {
	FISH_CEILING_EYE:0,		// top+fishEye
	FISH_CEILING_VR:1,	        // top+VR
	FISH_CEILING_CYLIND3D:2,      // top+CYLIND3D
	FISH_CEILING_CYLIND360:3,			//  top+ 360
	FISH_CEILING_CYLIND180:4,			//  top+  180
	FISH_CEILING_2PTZ:5,		//  top+2ptz
	FISH_CEILING_4PTZ:6,		//   top+4ptz
	FISH_CEILING_CYLIND360_1PTZ:7,//  top+360+18ptz
	FISH_CEILING_CYLIND360_3PTZ:8,// top+360+3ptz
	FISH_CEILING_CYLIND360_6PTZ:9,//  top+360+6ptz
	FISH_CEILING_CYLIND360_8PTZ:10,//  top+360+8ptz
	FISH_CEILING_EYE_3PTZ:11,		// 	   top+fishEye+3ptz
	FISH_CEILING_EYE_8PTZ:12,		//   top+fishEye+8ptz

	FISH_DESKTOP_EYE:13,			// desktop+fishEye
	FISH_DESKTOP_VR:14,	        // desktop+VR
	FISH_DESKTOP_CYLIND3D:15,      // desktop+CYLIND3D
	FISH_DESKTOP_CYLIND360:16,			// desktop+360
	FISH_DESKTOP_CYLIND180:17,		// desktop+180
	FISH_DESKTOP_4PTZ:18,		// desktop+4ptz
	FISH_DESKTOP_CYLIND360_1PTZ:19,// desktop+360+1PTZ
	FISH_DESKTOP_CYLIND360_3PTZ:20,//  desktop+360+3PTZ
	FISH_DESKTOP_CYLIND360_6PTZ:21,//  desktop+360+6PTZ
	FISH_DESKTOP_CYLIND360_8PTZ:22,// desktop+360+8PTZ
	FISH_DESKTOP_EYE_3PTZ:23,		//     desktop+3PTZ
	FISH_DESKTOP_EYE_8PTZ:24,		//     desktop+8PTZ

	FISH_WALL_EYE:25,				//  wall+fishEye
	FISH_WALL_VR:26,               //wall+VR
	FISH_WALL_NORMAL:27,			// wall+normal
	FISH_WALL_4PTZ:28,				//           wall+4PTZ
	FISH_WALL_NORMAL_3PTZ:29,		//  wall+normal+3PTZ
	FISH_WALL_NORMAL_8PTZ:30,		//  wall+normal+8PTZ
	FISH_WALL_EYE_3PTZ:31,			//        wall+3PTZ
	FISH_WALL_EYE_8PTZ:32			//      wall+8PTZ
	
}

var UserSetRightEnum = {
	Parameter:0,	//
	ManageDisk:1,	//
	RemoteLogin:2,	//
	Maintain:3,		//
	LogSearch:4,	//
	CuriseRight:5,	//
	SEQControl:6,	//
	ManualRecord:7,	//
	ManualCapture:8,//
	AudioRight:9,	//
	UserRightMax:10	//10
}

var ParamersEnum = {
	QUERY_ALL:1000,
	QUERY_ALL2:1100,
	QUERY_ALL_DEFAULT:1200,
	GET_ALL:1300,
	SAVE_ALL:2000
}

var PageControlEnum = {
	BIT0_E:0,//Bit0 indicates whether or not  display image control page, 0 means showed that 1 is hidden
	BIT1_E:1,    //Bit1 indicates whether or not display IRIS function , 1 display , 0 not display
	BIT2_E:2,    //Bit2 indicates c96 dedicated h. 265 ipc image page parameter, 0 indicates not c96 customer, 1 indicates c96 customer
	BIT3_E:3,    //Indicates whether or not the display intelligence analysis page.0 means hide, 1 display
	BIT4_E:4,    //area encode page for ipc
	BIT5_E:5,    //Whether show intelligent management function
	BIT6_E:6,	 //Whether show Analog channelpage(DVR PRODUCT)
	BIT7_E:7,	 //Wheher PTZ  Page show COAX1 COAX2, or just show COAX
	BIT8_E:8,    //display or hide the import-export page
	BIT9_E:9,    //display or hide power grid page;
	BIT10_E:10,   //snap picture 
	BIT11_E:11,   //substream playback
	BIT12_E:12,   //fisheye ipc
	BIT13_E:13,   //hydvr whether display sharpness pic
	BIT14_E:14,   //whether or not use dynamic occlusion  
	BIT15_E:15,   //display or hide sensercontrol page
	BIT16_E:16,   // 1:show new rtsp page, 0:show old rtsp page
	BIT17_E:17,   // 1:show new NTP page, 0:show old ntp page
	BIT18_E:18,   //1:IE recoed flag enable, 0: IE recoed flag disable  
	BIT19_E:19,	 //Whether use AMR function , 1 use ,0 not used  
	BIT20_E:20   //  0:old , 1:all alarm status and device capbiliti use RemoteChnStatusRpt struct(2016,11.14 add)
}

var ipcPtzModel = {
	model_default:0,
	model_preset:1,
	model_watch:2,
	model_linescan:3,
	model_track:4,
	model_pattern:5,
	model_restore:6
}

var playType = {
	normalPlay:0,
	fishEyeSoftPlay:1
}

var PageIntelligentEnum = {
	PID:0,//wether display PID intelligent function, 1 : show that ;
	LCD:1,    //wether display LCD intelligent function, 1 : show that ;
	SOD:2,    //wether display SOD intelligent function, 1 : show that ;
	PD:3,    //wether display PD intelligent function, 1 : show that ;
	FD:4,    //wether display FD intelligent function, 1 : show that ;
	CC:5,    //wether display CC intelligent function, 1 : show that ;
}


var RecordStatusEnum ={
	RecordStatusStop:0,
	RecordStatusNormal:1,
	RecordStatusManual:2,   
	RecordStatusMotion:3,
	RecordStatusIOAlarm:4,
	RecordStatusMotionIO:5,
	RecordStatusIntelligentall:6,
	RecordStatusPir:7,
	RecordStatusMotionPir:8,
	RecordStatusPirIO:9,
	RecordStatusMotionPirIO:10,
	RecordStatusIOIntelligentall:11,//I S
	RecordStatusMotionIntelligentall:12,//M S
	RecordStatusMotionIOIntelligentall:13,//M I S
	RecordStatusPIRIntelligentall:14,//P S
	RecordStatusMotionPIRIntelligentall:15,//M P S
	RecordStatusPIRIOIntelligentall:16,//P I S
	RecordStatusMotionPIRIOIntelligentall:17//M P I S
};

var enumEncType = {
	IPC_Reserve_e:0,
	IPC_RS_H264_e:1,
	IPC_RS_H265_e:2,
	IPC_Onvif_H264_e:3,
	IPC_Onvif_H265_e:4,
	IPC_ENCODE_H265_e:5,
	IPC_RS_H264_plus_e:6,
	IPC_RS_H265_plus_e:7,
	IPC_RS_H264_H265_plus_e:8,
    IPC_RS_H264_AVBR_e:9  //Support rayshap H264, dummy H264 +, analog channel to use
};

/*video code model
var ipcVideoType = {
	VT_H264:0,
	VT_H265:1,
	VT_MJPEG:2,
	VT_H264_PLUS:3,
	VT_H265_PLUS:4
}*/


//Plug-in object
function OcxClass() {
	this.obj = document.getElementById("ipcocx"); //Control Object
	this.bInit = 0;

	Init(this); //initialization
	function Init(p) {
		if (typeof(p.obj.SendMsgToPlugin) == "undefined") { //To determine whether a plug-in installed (load) success
			p.bInit = 0;
		} else {
			p.SendMsgToPlugin = function(jsonData) {
                console.log("[MsgToPlugin]:"+JSON.stringify(jsonData));
				var ret = p.obj.SendMsgToPlugin(JSON.stringify(jsonData));
				//alert("MainType:"+ xml.MainType + ",SubType:" + xml.SubType +"," + ret);
				return JSON.parse(ret);
			};
			p.SetLanguageXML = function(xml) {
				p.obj.SetLanguageXML(xml);
			};
			p.bInit = 1;

		}
	}
	//log in
	this.OcxInit = function(index) {
        console.log("OcxInit");
		var param = {};
		param.MainType = methodEnum.MainMsgInitPlugin;
		param.SubType = methodEnum.MsgNoType;
		var obj = {};
		obj.ClientIndex = index;
		obj.ID = gDevice.id;

		var objTmp = {};
		objTmp.Floder = "Device";
		objTmp.Record = "Record";
		objTmp.Download = "Download";
		var defCap = "Capture";
		if(gDevice.devType == devTypeEnum.DEV_HDVR && lgCls.version == gVar.CtArr[142]){
			defCap = "Snapshot";
		}
		objTmp.Capture = defCap;
		if(gDevice.devType == devTypeEnum.DEV_HDVR) {
			if(lgCls.version == gVar.CtArr[105]) {
				if($.browser.safari) {
					objTmp.RecFileType = RecFileTypeEnum.RSMP4FileType; //
				} else {
					objTmp.RecFileType = RecFileTypeEnum.RSAVIFileType; //
				}
			} else if(lgCls.version == gVar.CtArr[0]) {
				objTmp.RecFileType = RecFileTypeEnum.RSMP4FileType; //
				objTmp.CapFileType = CapFileTypeEnum.RSJPGFileType;
			}else if(lgCls.version == gVar.CtArr[142]){
				objTmp.RecFileType = RecFileTypeEnum.RSAVIFileType;
			}else {
				objTmp.RecFileType = RecFileTypeEnum.RSFileType;
			}
		} else if(gDevice.devType == devTypeEnum.DEV_NVR) {
			if(lgCls.version == gVar.CtArr[0]) {
				objTmp.RecFileType = RecFileTypeEnum.RSMP4FileType; //
			} else if(lgCls.version == gVar.CtArr[142]){
				objTmp.RecFileType = RecFileTypeEnum.RSAVIFileType;
			}else {
				objTmp.RecFileType = RecFileTypeEnum.RSFileType;
			}
		} else if(gDevice.devType == devTypeEnum.DEV_IPC) {
			objTmp.RecFileType = RecFileTypeEnum.RSFileType;
			if(lgCls.version == gVar.CtArr[116]){
				objTmp.Floder = "";
			}else if(lgCls.version == gVar.CtArr[0]) {
				objTmp.CapFileType = CapFileTypeEnum.RSJPGFileType;
			}
		}

		objTmp.SwitchTime = 10;
		objTmp.PlayBackRatio = 0;

		obj.Path = objTmp;
		param.Data = obj;

		try {
			var ret = this.SendMsgToPlugin(param);
			if (ret.Code == errCodeEnum.Code_Success) {
				gDevice.bInit = 1;
			}else if(ret.Code == errCodeEnum.Code_NoPermission){
				//alert("The configuration file creation failure,it can be resolved as following:"+"\n"+"1.Run the browser under administrator."+ "\n" +"2.Add the URL to the trusted list");
				g_noPermission = true;
				gDevice.bInit = 1;
			} else {
				gDevice.bInit = 0;
			}
		} catch (e) {
			//TODO handle the exception
			gDevice.bInit = 0;
		}

		return gDevice.bInit;
	};

	this.GetWeekStart = function() {
        console.log("GetWeekStart");
		var param = {};
		param.MainType = methodEnum.MainMsgGetWeekStart;
		param.SubType = methodEnum.MsgNoType;
		return this.SendMsgToPlugin(param);
	};

	this.SetDebugFlag = function(flag) {
        console.log("SetDebugFlag");
		var param = {};
		param.MainType = methodEnum.MainMsgDebugFlag;
		param.SubType = flag;

		return this.SendMsgToPlugin(param);
	};

	this.UserLogin = function() {
        console.log("UserLogin");
		var param = {};
		param.MainType = methodEnum.MainMsgUserLogin;
		param.SubType = methodEnum.MsgNoType;

		var obj = {};
		obj.IP = gVar.ip;
		obj.Port = gVar.mediaport;
		obj.UserName = gVar.user;
		obj.Password = gVar.passwd;
		switch(gVar.lg){
			case "CHS":
				gVar.nLanguage = 1;
				break;
			case "ENU":
				gVar.nLanguage = 2;
				break;
			case "RUS":
				gVar.nLanguage = 3;
				break;
			case "ITA":
				gVar.nLanguage = 4;
				break;
			case "FRA":
				gVar.nLanguage = 5;
				break;
			case "DEU":
				gVar.nLanguage = 6;
				break;
			case "ESN":
				gVar.nLanguage = 7;
				break;
			case "ELL":
				gVar.nLanguage = 8;
				break;
			case "PLK":
				gVar.nLanguage = 9;
				break;
			case "POS":
				gVar.nLanguage = 10;
				break;
			case "HOL":
				gVar.nLanguage = 11;
				break;
			case "PTG":
				gVar.nLanguage = 12;
				break;
			case "PTB":
				gVar.nLanguage = 13;
				break;
			case "CHT":
				gVar.nLanguage = 14;
				break;
			case "TUR":
				gVar.nLanguage = 15;
				break;
			case "SVE":
				gVar.nLanguage = 16;
				break;
			case "JPN":
				gVar.nLanguage = 17;
				break;
			case "HUN":
				gVar.nLanguage = 18;
				break;
			case "BRG":
				gVar.nLanguage = 19;
				break;
			case "UKA":
				gVar.nLanguage = 20;
				break;
			default:
				gVar.nLanguage = 2;
				break;
		}
		obj.Lan = gVar.nLanguage;
		//obj.SysTime = gVar.synchr * 1;
		obj.LoginClientType = gVar.loginClientType;
		param.Data = obj;
        //alert(JSON.stringify(param));
		return this.SendMsgToPlugin(param);
	};

	this.initWindow = function(subMsg, data) {
        console.log("initWindow");
		var param = {};
		param.MainType = methodEnum.MainMsgInitWindow;
		param.SubType = subMsg;
		param.Data = data;
		return this.SendMsgToPlugin(param);
	};

	this.setPageIndex = function(index) {
        console.log("setPageIndex");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgPreviewPageIndex;
		param.Data = {
			"PageIndex": index
		};
		return this.SendMsgToPlugin(param);
	};

	this.restPreviewIndex = function() {
        console.log("restPreviewIndex");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgResetIndex;

		return this.SendMsgToPlugin(param);
	};

	this.getPreviewViewsIndex = function() {
        console.log("getPreviewViewsIndex");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgGetViewsIndex;

		return this.SendMsgToPlugin(param);
	};

	this.Disconnection = function(deviceID) {
        console.log("Disconnection");
		var param = {};
		param.MainType = methodEnum.MainMsgDisconnection;
		param.SubType = methodEnum.MsgNoType;

		var data = {};
		data.ID = deviceID;

		param.Data = data;

		return this.SendMsgToPlugin(param);
	};

	this.OcxChangePage = function(pageType) {
        console.log("OcxChangePage");
		var param = {};
		param.MainType = methodEnum.MainMsgChangePage;
		param.SubType = pageType;
		var obj = {};
		obj.ID = gDevice.id;
		obj.Padding = 2;
		obj.margin = 2;
		obj.wndBgColor = {
			"r": 0,
			"g": 0,
			"b": 0,
			"a": 1
		};
		obj.videoColor = {
			"r": 30,
			"g": 30,
			"b": 30,
			"a": 1
		};
		obj.selColor = {
			"r": 125,
			"g": 125,
			"b": 0,
			"a": 1
		};
		obj.videoNums = 32;
		obj.showMode = 4;
		param.Data = obj;
		var ret = this.SendMsgToPlugin(param);
	};

	this.GetOcxVersion = function() {
        console.log("GetOcxVersion");
		var param = {};
		param.MainType = methodEnum.MainMsgGetOcxVersion;
		param.SubType = methodEnum.MsgNoType;

		return this.SendMsgToPlugin(param);
	};

	this.GetSysLangType = function() {
        console.log("GetSysLangType");
		var param = {};
		param.MainType = methodEnum.MainMsgGetSysLangType;
		param.SubType = methodEnum.MsgNoType;

		return this.SendMsgToPlugin(param);
	};
	
	this.IPCFirstLoginSetPwd = function(ipcIp,ipcPort,ipcName,ipcPwd){
		var param = {};
		param.MainType = methodEnum.MainMsgIPCSaveToDev;
		param.SubType = methodEnum.MsgNoType;
		
		var obj = {};
		obj.IP = ipcIp;
		obj.Port = ipcPort;
		obj.UserName = ipcName;
		obj.Password = ipcPwd;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}

	//Live Page
	this.SetPreviewRecordStatus = function(chn,type,bshow,r,g,b){
        console.log("SetPreviewRecordStatus");
		var param = {};
		param.MainType = alarmEnum.MsgDevAllStatusReq;
		param.SubType = type;

		var obj = {};
		obj.Channel = chn;
		obj.r = r;
		obj.g = g;
		obj.b = b;
		obj.bshow = bshow;

		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}
	
	this.setPreviewFullScreen = function(bFullScreen) {
        console.log("setPreviewFullScreen");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgFullScreen;

		var obj = {};
		obj.ID = gDevice.id;
		obj.FullScreen = bFullScreen;

		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}

	this.setPreviewShowMode = function(showMode) {
        console.log("setPreviewShowMode");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgPreviewSplit;

		var obj = {};
		obj.ID = gDevice.id;
		obj.ShowMode = showMode;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}

	this.PreviewPlay = function(chnArr,PlayType) {
        console.log("PreviewPlay");
      //remove video loss channel
      var chOpen = [];
      if(g_UiType == 50){
          for(var i=0; i<chnArr.length; i++){
              if(gDevice.devState[chnArr[i]].VLossState == 1){
                  //
              }else{
                  chOpen.push(chnArr[i]);
              }
          }
          if(chOpen.length<=0){
              return errCodeEnum.Code_ParamerErr;
          }
		}else{//4.0.....
            chOpen = chnArr;
		}

        var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgPreviewStart;

		var obj = {};
		obj.ID = gDevice.id;
		obj.chnArr = chOpen;
		if(typeof PlayType == "undefined") {
			obj.PlayType = playType.normalPlay;
		}else{
			obj.PlayType = PlayType;
		}
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};
	
	this.ClearPlayFlag = function(){
        console.log("ClearPlayFlag");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgClearPlayFlag;
		return this.SendMsgToPlugin(param);
	}
	
	this.SetFishEyeSoftMode = function(chn, mode) {
        console.log("SetFishEyeSoftMode");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgSetFishEyeSoftMode;

		var obj = {};
		obj.Channel = chn;
		obj.Mode = mode;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};
	
	this.GetFishEyeSoftFishEyeSoftChSelect = function(chn) {
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgGetFishEyeSoftChSelect;

		var obj = {};
		obj.Channel = chn;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.PreviewStop = function(chnArr) {
        console.log("PreviewStop");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgPreviewStop;

		var obj = {};
		obj.chnArr = chnArr;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.PreViewCap = function(chArr) {
        console.log("PreViewCap");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgCapture;

		var obj = {};
		obj.ID = gDevice.id;
		obj.chArr = chArr;

		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.GetCapDir = function(str) {
        console.log("GetCapDir");
		if (!$.browser.safari) {
			str = str.substring(0, str.lastIndexOf("\\"));
		}
		var param = {};
		param.MainType = methodEnum.MainMsgBrowserFile;
		param.SubType = methodEnum.SubMsgBrowserDir;
		var obj = {};
		obj.DirPath = str;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.PreViewSelectWnd = function(channel) {
        console.log("PreViewSelectWnd");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = retEnum.SingleClick;

		var obj = {};
		obj.Channel = channel;

		param.Data = obj;

		return this.SendMsgToPlugin(param);
	}
	
	this.PreViewRightMenu = function(data) {
        console.log("PreViewRightMenu");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = retEnum.RightClick;

		param.Data = data;

		return this.SendMsgToPlugin(param);
	}

	this.GetCapImage = function(str) {
        console.log("GetCapImage");
		var param = {};
		param.MainType = methodEnum.MainMsgBrowserFile;
		param.SubType = methodEnum.SubMsgBrowserPic;
		var obj = {};
		obj.PicPath = str;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.PreViewRec = function(type, chArr) {
        console.log("PreViewRec");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgRecord;

		var obj = {};
		obj.Record = type;
		obj.chArr = chArr;

		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.PreViewSound = function(type) {
        console.log("PreViewSound");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgSound;
		var obj = {};
		obj.bOpen = type;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.PreViewZoom = function() {
        console.log("PreViewZoom");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgZoomView;

		var obj = {};
		obj.ID = gDevice.id;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};
	
	this.PreView3DPosition = function() {
        console.log("PreView3DPosition");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsg3DPosition;

		var obj = {};
		obj.ID = gDevice.id;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.PreviewVolume = function(volume) {
        console.log("PreviewVolume");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgSetVolume;
		var obj = {};
		obj.Volume = volume;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	}
	
	this.PreviewDbclkFullscreen = function(bFullscreen){
        console.log("PreviewDbclkFullscreen");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgDbclkFullscreen;
		var obj = {};
		obj.bFullscreen = bFullscreen;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	}
	
	this.PreviewFishEyeMode = function(fisheye){
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgFishEye;
		var obj = {};
		obj.FishEye = fisheye;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}
	
	this.SetFishEyePtzPos = function(posArr,channel){
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgFishEyePtzPos;

		var obj = {};
		obj.Channel = channel;
		obj.posArr = posArr;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	}
	
	this.FishEyeSoftPTZ = function(data){
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgFishEyeSoftPtz;

		var obj = {};
		obj.Channel = data.Channel;
		obj.PtzType = data.PtzType;
		obj.Speed = data.Speed;
		obj.Flag = data.Flag;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	}
	

	this.VoiceIntercom = function(type) {
        console.log("VoiceIntercom");
		var param = {};
		param.MainType = methodEnum.MainMsgTalkerOperator;
		param.SubType = type;

		var obj = {};
		obj.ID = gDevice.id;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};
	
	this.DualTalk = function(bSwitch) {
        console.log("DualTalk");
		var param = {};
		param.MainType = methodEnum.MainMsgDualTalk;
		param.SubType = methodEnum.MsgNoType;
		var obj = {};
		obj.ID = gDevice.id;
		obj.Switch = bSwitch;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};
	this.SetDualTalkVolume = function(volume) {
		var param = {};
		param.MainType = methodEnum.MainMsgDualTalk;
		param.SubType = methodEnum.SubMsgSetVolume;
		var obj = {};
		obj.ID = gDevice.id;
		obj.Volume = volume;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.Logout = function() {
        console.log("Logout");
		var param = {};
		param.MainType = methodEnum.MainMsgUserLogout;
		param.SubType = methodEnum.MsgNoType;

		var obj = {};
		obj.ID = gDevice.id;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.SetVideoratio = function(mode) {
        console.log("SetVideoratio");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgPreviewRatio;

		var obj = {};
		obj.ID = gDevice.id;
		obj.RatioType = mode; //0:self-adaption，1：original proportion
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.SetStreamType = function(streamTypeArr, chnArr) {
        console.log("SetStreamType");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgPreviewCodeType;

		var zerochn = $.inArray(gDevice.loginRsp.ChannelNum, chnArr);
		if(zerochn != -1){
			streamTypeArr[zerochn] = streamTypeEnum.ZeroStreamType;
		}
		var obj = {};
		obj.ID = gDevice.id;
		obj.StreamTypeArr = streamTypeArr; //0:main，1：sub，2：mobile
		obj.chnArr = chnArr;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};
	
	this.SetDelayTime = function(time) {
        console.log("SetDelayTime");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgSetDelayTime;

		var obj = {};
		obj.DelayTime = time;
		obj.devType = gDevice.devType;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};
	
	this.SendZeroSpiltType = function(data) {
        console.log("SendZeroSpiltType");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgZeroChnStatus;

		param.Data = data;
		param.Data.ID = gDevice.id;

		return this.SendMsgToPlugin(param);
	};

	this.PTZcontrol = function(SubType, Data) {
        console.log("PTZcontrol");
		var param = {};
		param.MainType = methodEnum.MainMsgPTZcontrol;
		param.SubType = SubType;
		Data["ID"] = gDevice.id;
		param.Data = Data;

		return this.SendMsgToPlugin(param);
	};

	this.ShowStreamRate = function(chnArr,flag, millisec) {
        console.log("ShowStreamRate");
		var param = {};
		param.MainType = methodEnum.MainMsgBitrate;
		param.SubType = methodEnum.SubMsgBitrate;
		var obj = {};
		obj.Flag = flag;
		if (typeof millisec == "undefined")
			millisec = 1000;
		obj.Interval = millisec;
		obj.ID = gDevice.id;
		obj.chnArr = chnArr;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};
	this.ShowResolution = function(chnArr,flag, millisec) {
        console.log("ShowResolution");
		var param = {};
		param.MainType = methodEnum.MainMsgResolution;
		param.SubType = methodEnum.SubMsgResolution;
		var obj = {};
		obj.Flag = flag;
		if (typeof millisec == "undefined")
			millisec = 1000;
		obj.Interval = millisec;
		obj.ID = gDevice.id;
		obj.chnArr = chnArr;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.SetGoodLAreaStatus = function(RuleIndex, AreaIndex, isUse) {
		var param = {};
		param.MainType = methodEnum.MainMsgSetGoodLAreaStatus;
		param.SubType = methodEnum.MsgNoType;

		var obj = {};
		obj.ID = gDevice.id;
		obj.RuleIndex = RuleIndex;
		obj.AreaIndex = AreaIndex;
		obj.isUse = isUse;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.PLWriteLine = function(RuleIndex, isTowway, single) {
		var param = {};
		param.MainType = methodEnum.MainMsgPLWriteLine;
		param.SubType = methodEnum.MsgNoType;

		var obj = {};
		obj.ID = gDevice.id;
		obj.RuleIndex = RuleIndex;
		obj.LineTwoWay = isTowway;
		obj.RuleType = single;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.PLWriteLineTwoway = function(RuleIndex, isTowway) {
		var param = {};
		param.MainType = methodEnum.MainMsgPLWriteLineTwoway;
		param.SubType = methodEnum.MsgNoType;

		var obj = {};
		obj.ID = gDevice.id;
		obj.RuleIndex = RuleIndex;
		obj.LineTwoWay = isTowway;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.GllRuletype = function(RuleIndex, ruleboth) {
		var param = {};
		param.MainType = methodEnum.MainMsgGLLRuleType;
		param.SubType = methodEnum.MsgNoType;

		var obj = {};
		obj.ID = gDevice.id;
		obj.RuleIndex = RuleIndex;
		obj.RuleTypeBoth = ruleboth;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.RuleNum = function(RuleIndex, page) {
		var param = {};
		param.MainType = methodEnum.MainMsgRuleNum;
		param.SubType = methodEnum.MsgNoType;

		var obj = {};
		obj.RuleIndex = RuleIndex;
		obj.page = page;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};
	
	this.GetDDNSArr = function(index) {
		var param = {};
		param.MainType = methodEnum.MainMsgGetCustomerInfo;
		param.SubType = methodEnum.SubMsgGetDDNSArr;
		var obj = {};
		obj.index = index;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};
	
	this.GetCInfoArr = function() {
		var param = {};
		param.MainType = methodEnum.MainMsgGetCustomerInfo;
		param.SubType = methodEnum.SubMsgGetCInfoArr;
		return this.SendMsgToPlugin(param);
	};
	
	this.bSupportFull = function(bSupport) {
		var param = {};
		param.MainType = methodEnum.MainMsgImgToFull;
		param.SubType = methodEnum.MsgNoType;
		var obj = {};
		obj.bSupportFull = bSupport;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	//playback
	this.SearchByMon = function(RecordType, RecordTime) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgSearchMonth;
		var obj = {};
		obj.ID = gDevice.id;
		obj.RecordType = RecordType;
		obj.RecordTime = RecordTime;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.SearchByDay = function(chnArr, RecordType, RecordTime, pbStreamType,RecMode) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgSearchDay;
		var obj = {};
		obj.chnArr = chnArr;
		obj.ID = gDevice.id;
		obj.RecordType = RecordType;
		obj.RecordTime = RecordTime;
		
		if (typeof pbStreamType != "undefined"){
			obj.pbStreamType = pbStreamType;
		}
		
		if(typeof RecMode =="undefined"){
			RecMode=0;
		}
		obj.RecMode = RecMode;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.PlaybackPlay = function(chnArr, date, rectype, synchronous,mode,playtype) {
        console.log("PlaybackPlay");
        var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgPlaybackStart;

		var obj = {};
		obj.ID = gDevice.id;
		obj.chnArr = chnArr;
		obj.date = date;
		obj.rectype = rectype;
		obj.synchronous = synchronous;
		if(typeof playtype == "undefined") {
			obj.PlayType = playType.normalPlay;
		}else{
			obj.PlayType = playtype;
		}
		if(typeof mode =='undefined'){
			mode=0
		}
		obj.mode=mode;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};
	
	this.SetPlaybackFishEyeSoftMode = function(chn, mode) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgSetFishEyeSoftMode;

		var obj = {};
		obj.Channel = chn;
		obj.Mode = mode;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.PlaybackStop = function(chnArr) {
        console.log("PlaybackStop");
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgPlaybackStop;

		var obj = {};
		obj.chnArr = chnArr;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.PlaybackRec = function(type, chArr) {
        console.log("PlaybackRec");
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgRecord;

		var obj = {};
		obj.Record = type;
		obj.chArr = chArr;

		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.PlaybackCap = function(chArr) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgCapture;

		var obj = {};
		obj.ID = gDevice.id;
		obj.chArr = chArr;

		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.PlaybackZoom = function() {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgZoomView;

		var obj = {};
		obj.ID = gDevice.id;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.setPlaybackFullScreen = function(bFullScreen) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgFullScreen;

		var obj = {};
		obj.ID = gDevice.id;
		obj.FullScreen = bFullScreen;

		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}

	this.PlayBackSelectWnd = function(channel) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = retEnum.SingleClick;

		var obj = {};
		obj.Channel = channel;

		param.Data = obj;

		return this.SendMsgToPlugin(param);
	}

	this.setPlaybackPageIndex = function(index) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgPlaybackPageIndex;
		param.Data = {
			"PageIndex": index
		};
		return this.SendMsgToPlugin(param);
	};

	this.SetPlaybackVideoratio = function(mode) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgPlaybackRatio;

		var obj = {};
		obj.ID = gDevice.id;
		obj.RatioType = mode; //0:self-adaption，1：original proportion
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};

	this.setPlaybackShowMode = function(showMode) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgPlaybackSplit;

		var obj = {};
		obj.ID = gDevice.id;
		obj.ShowMode = showMode;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}

	this.getPlaybackTime = function(chn) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgGetPlaybackTime;

		var obj = {};
		obj.Channel = chn;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}

	this.setPlaybackTime = function(chn, date, time) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgSetPlaybackTime;

		var timeArr = time.split(':');
		var obj = {};
		obj = date;
		obj.chn = chn;
		obj.Hour = parseInt(timeArr[0]);
		obj.Minute = parseInt(timeArr[1]);
		obj.Second = parseInt(timeArr[2]);
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}

	this.SetPlaybackMode = function(chnArr, modeArr) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgPlaybackPlayMode;

		var obj = {};
		obj.chnArr = chnArr;
		obj.modeArr = modeArr;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}

	this.StartDownload = function(startArr) {
        console.log("StartDownload");
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgDownloadStart;
		var obj = {};
		obj.startArr = startArr;
		obj.ID = gDevice.id;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}

	this.StopDownload = function() {
        console.log("StopDownload");
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgDownloadStop;
		return this.SendMsgToPlugin(param);
	}
	
	this.ShowDownload = function(recordArr) {
		var param = {};
		param.MainType = methodEnum.MainMsgDownloadBox;
		param.SubType = methodEnum.SubMsgDownloadData;
		var obj = {};
		obj.recordArr = recordArr;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}
	
	this.InitDownload = function(data) {
        console.log("InitDownload");
		var param = {};
		param.MainType = methodEnum.MainMsgDownloadBox;
		param.SubType = methodEnum.SubMsgDownloadInit;
		param.Data = data;
		return this.SendMsgToPlugin(param);
	}
	
	this.SetDownloadBoxStatus = function(statusdata){
		var param = {};
		param.MainType = methodEnum.MainMsgDownloadBox;
		param.SubType = methodEnum.SubMsgDownloadStatus;
		param.Data = statusdata;
		return this.SendMsgToPlugin(param);
	}
	
	this.PlaybackSound = function(type) {
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgSound;
		var obj = {};
		obj.bOpen = type;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};
	
	this.PlaybackVolume = function(volume){
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgSetVolume;
		var obj = {};
		obj.Volume = volume;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}
	
	this.PlaybackDbclkFullscreen = function(bFullscreen){
		var param = {};
		param.MainType = methodEnum.MainMsgPlayback;
		param.SubType = methodEnum.SubMsgDbclkFullscreen;
		var obj = {};
		obj.bFullscreen = bFullscreen;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	}

	//parameter setting
	this.GetAndSetParameter = function(nPage, jsonData, type, nFlag) {
        console.log("GetAndSetParameter");
		var param = {};
		param.MainType = methodEnum.MainMsgGetAndSetParameter;
		param.SubType = methodEnum.MsgNoType;
		var obj = {};
		obj.Page = nPage;
		obj.Param = jsonData;
		obj.Type = type;
		obj.SubType = nFlag;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.FileUpdate = function(type, path,channelmask,filetype,data) {
		var param = {};
		param.MainType = methodEnum.MainMsgRemoteUpgrade; //36
		param.SubType = type;
		var obj = {};
		if (type == methodEnum.SubMsgStartUpgrade) {
			obj.ID = gDevice.id;
			obj.FilePath = path;
			if(channelmask == undefined){
				channelmask = 0;
			}
			obj.Channelmask = channelmask;
			if(filetype == undefined){
				filetype = 0;
			}
			obj.Filetype = filetype;
			if(-1==gVar.ip.indexOf(".") && -1==gVar.ip.indexOf(":")){//!=IPv4 && !=IPv6
				obj.time_sleep = 10;//ID Login Upgrade, Send File Need Sleep
			}else{
				obj.time_sleep = 0;//IP Login don't Need
			}
		}else if(type == methodEnum.SubMsgGetUpgradeFile){
			obj.FilePath = path;
		}else if(type == methodEnum.SubMsgGetActivateKey){
			obj.Filetype = path;
		}else if(type == methodEnum.SubMsgGetActivateFile){
			obj.FilePath = path;
			obj.Data = data;
		}else if(type == methodEnum.SubMsgSendActivateFile){
			obj.ID = gDevice.id;
			obj.Data = data;
		}
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.ParamPageVideoCtrl = function(cmdType) {
        console.log("ParamPageVideoCtrl");
		var param = {};
		param.MainType = methodEnum.MainMsgCtrlParamPageVideo;
		param.SubType = methodEnum.MsgNoType;
		var obj = {};
		obj.ID = gDevice.id;
		obj.CmdType = cmdType;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.RemoteTest = function(type, paramData) {
		var param = {};
		param.MainType = methodEnum.MainMsgRemoteTest; //41
		param.SubType = type; //329
		var obj = {};
		obj.ID = gDevice.id;
		obj.RemoteTestData = paramData;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.ParamvideoStart = function(chn, streamType) {
        console.log("ParamvideoStart");
		var param = {};
		param.MainType = methodEnum.MainMsgParamvideo;
		param.SubType = methodEnum.SubMsgPreviewStart;
		
		gVar.vdCurCh=chn;
		
		var obj = {};
		obj.ID = gDevice.id;
		obj.Channel = chn;
		obj.StreamType = streamType;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.ParamvideoStop = function(chn) {
        console.log("ParamvideoStop");
		var param = {};
		param.MainType = methodEnum.MainMsgParamvideo;
		param.SubType = methodEnum.SubMsgPreviewStop;
		
		gVar.vdCurCh=-1;
		
		var obj = {};
		obj.Channel = chn;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.ParamChangeChn = function(chn) {
        console.log("ParamChangeChn");
		var param = {};
		param.MainType = methodEnum.MainMsgParamvideo;
		param.SubType = methodEnum.SubMsgParamChangeChn;

		var obj = {};
		obj.Channel = chn;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.GetVideoParam = function(pageType) {
        console.log("GetVideoParam");
		var param = {};
		param.MainType = methodEnum.MainMsgParamvideo;
		param.SubType = methodEnum.SubMsgGetParameter;

		var obj = {};
		obj.PageType = pageType;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	this.SetVideoParam = function(pageType, data) {
        console.log("SetVideoParam");
		var param = {};
		param.MainType = methodEnum.MainMsgParamvideo;
		param.SubType = methodEnum.SubMsgSetParameter;

		var obj = {};
		obj = data;
		obj.PageType = pageType;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};
	
	this.paramImEx = function(type){
        console.log("paramImEx");
		var param = {};
		param.MainType = methodEnum.MainMsgRemoteParamBackup;
		param.SubType = type;
		var  obj = {};
		obj.ID = gDevice.id;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}
	
	this.paramExportEXCEL = function(path,filename,row,col,file){
		var param = {};
		param.MainType = methodEnum.MainMsgExportEXCEL;
		param.SubType = methodEnum.MsgNoType;
		var  obj = {};
		obj.ID = gDevice.id;
		obj.Path = path;
		obj.FileName = filename;
		obj.FileRow = row;
		obj.FileCol = col;
		obj.FileData = file;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}
	
	this.openSafariByUrl = function(url) {
		var param = {};
		param.MainType = methodEnum.MainMsgOpenSafariByUrl;
		param.SubType = methodEnum.MsgNoType;
		var obj = {};
		obj.url = url;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	};

	//The path configuration page
	this.GetSetInfo = function() {
        console.log("GetSetInfo");
		var param = {};
		param.MainType = methodEnum.MainMsgPathInfo;//18
		param.SubType = methodEnum.SubMsgGetPathInfo;//19
		return this.SendMsgToPlugin(param);
	};

	this.SetInfo = function(data) {
        console.log("SetInfo");
		var param = {};
		param.MainType = methodEnum.MainMsgPathInfo;//18
		param.SubType = methodEnum.SubMsgSetPathInfo;//21
		param.Data = data;
		return this.SendMsgToPlugin(param);
	};

	this.SetPath = function() {
		var param = {};
		param.MainType = methodEnum.MainMsgPathInfo;//18
		param.SubType = methodEnum.SubMsgGetSelPath;//20
		return this.SendMsgToPlugin(param);
	}

	this.AutoUpgrade = function(type) {
		var param = {};
		param.MainType = methodEnum.MainMsgAutoUpgrade; //105
		param.SubType = methodEnum.MsgNoType; //0
		var obj = {};
		obj.ID = gDevice.id;
		obj.type = type;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}
	
	this.ModifyPsw = function(pswVal) {
		var param = {};
		param.MainType = methodEnum.MainMsgModifyPsw; //106
		param.SubType = methodEnum.MsgNoType; //0
		var obj = {};
		obj.ID = gDevice.id;

		obj.nPage = paramPage.MsgParamUser;
		obj.pswVal = pswVal;
		obj.saveType = 800; //MODIFY_PSW
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}
	
	this.SimpleCmd = function(maintype,subtype) {
        console.log("SimpleCmd");
		var param = {};
		param.MainType = methodEnum.MainMsgSimpleCmd; //105
		param.SubType = methodEnum.MsgNoType; //0
		var obj = {};
		obj.ID = gDevice.id;
		obj.CmdMainType = maintype;
		obj.CmdSubType = subtype;
		param.Data = obj;
		return this.SendMsgToPlugin(param);
	}

	this.setFishEyeWheelScroll = function(maintype,subtype,data) {
		var param = {};
		param.Data = data; 
		param.MainType = maintype;
		param.SubType = subtype;
		return this.SendMsgToPlugin(param);
	}
	
	this.PreviewUpdateAutoConn = function(arr) {
        console.log("PreviewUpdateAutoConn");
		var param = {};
		param.MainType = methodEnum.MainMsgPreview;
		param.SubType = methodEnum.SubMsgUpdateAutoConn;//131

		var obj = {};
		obj.arrAutoConn = arr;
		param.Data = obj;

		return this.SendMsgToPlugin(param);
	};
}