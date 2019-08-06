/**
 * Created by yuan on 2019/5/20.
 */
// JavaScript Document
var gVar; //global variable
var gDevice; //Device information class object
var gOcx;
var UI; //UI class object
var lg; //Language object
var ISGetSysTime = 0; //If access to the system time
var lgCls;
var timeout;
var tabkey = 1;
var ColorSet = "#7EA264";
var gIELogin = true;
var gIDLogin = false; //IP control login id or login
var gHttp = "";
var NoDel = false;
var gStreamSet = 0;
var gReboot = 0;
var ratetype = 0; //Flashing type
var tTime; //Real time function
var gCloseFlag = 0;
var IPCRows = 0;
var g_bDefaultShow = false;
var g_downloadWin;
var g_loginTimeout = 15;
var g_intervalID = -1;
var g_ipcgup = false;
var g_pbNum; //Playback window number
var g_pbCkNum;//=AnalogChNum
var g_pbRowNum = 4;
var g_c2Wifi = false;
var alarm = {motionRec: 0, IORec: 0, pirRec: 0};
var g_noPermission = false;
var g_UiType = 40;//ie type:40

//ClassID Flag
var C23IEBaoNO265 = false;
var C152IEBao = false;
var C0IEBao = false;
var C0Netview = false;
var C23Netview = false;
var C23NetviewUI5 = false;
var C23IEBao265 = false;
var C23CH256 = false;
var C186IEBao = false;
var C186IEBaoNVR = false;
var C186IEBaoNO265 = false;
var C186IEBao265 = false;
var C142IEBao = false;
var C146IEBao = false;
var IPCIEBao = true;
var IPCC166IEBao = false;
var IPCC166CH256IEBao = false;
var IPCC186CH256IEBao = false;
var IPCC198IEBao = false;

//ClassID Flag,Add above here

var bSvgUsed;
var g_bLimitMainPreview = false;
var g_MainStreamNum;
var g_defaultStreamType = 1;
var g_recordStatus = [];
var g_pbIsSupportGt4WndPlay = false;//playback is support great than  4 channels play?
var g_ipcOldIntellCss = false; //gVar.CtArr->44,70,92,94,98,114,141,143,146,148- old intell style for shipment
var g_autoToConfig = false;
var g_bShowBSL = false;//bo shi li
var smartArr = [];
var g_videomovetime = -1;
var g_isTriggerAlarmOut = false;
var g_isFishEyeMode = {Preview: false, Playback: false};
var g_DevStateReportTime = -1;

function showMsg(msg){
    $("#msg").html($("#msg").html() + "</br>" + msg);
}


$(function () {

    var userAgent = navigator.userAgent.toLowerCase();
    if (!$.browser) {
        $.browser = {};
    }

    $.browser.version = (userAgent.match(/.+(?:rv|it|ra|ie)[\/: ]([\d.]+)/) || [0, '0'])[1];
    $.browser.msie = true;

    if (!CheckBrowser()) {
        LoadWebPlugins();
        return;
    }


    //Controls to write
    $("#liveOcx").html('<object id="ipcocx" name="ipcocx" style="width:0px; height:0px;" classid="clsid:5557FCC8-1048-4dfb-A76A-2973D550F1FF"></object>');
    //Controls to write end

    InitWeb();

    //AutoLogin();

});

function InitWeb() { //Site initialization
    ////Body attachEvent
    var bodyobj = document.getElementsByTagName("body")[0];
    bodyobj.setAttribute("onunload", "closewnd()");

    //////////////////////////////////////Initializes the global data////////////////////////////////////////////////////
    lgCls = new LgClass();
    gDevice = new DeviceInfo(); //Create the device object
    gVar = new GlobalVar(); //Initializes the global class object
    lg = new HashmapCom(); //To create a language pack a hash table

    gIELogin = false;//Pack Flag

    gVar.CtArr = getCtmArr();//Array(300);

    if (gIELogin == false) {
        gVar.mediaport = "";
        lgCls.version = gVar.CtArr[201];
        lgCls.logo = gVar.CtArr[201];
        lgCls.langues = "ENU CHS"; //ENU CHS DEU ITA ESN FRA HOL PTG PTB RUS TUR BRG
        //lgCls.langues = "ENU RUS PLK HUN";
        lgCls.defaultLg = "ENU";
        //lgCls.sdcardshow = "1";
        gVar.synchr = 0;
        gOcx = new OcxClass();
        //if (!gOcx.bInit) {
        //    alert("Plugin is not loaded!");
        //    return;
        //}
        InitOcx();

    } else {

    }

}

function InitOcx() {
    var ret = gDevice.OcxInit(lgCls.version); //The initial control
    if (ret == 0) {
        //alert("Ocx initialization failed!");
        return;
    }
    //The console output plug-in printed information
    //gDevice.SetDebugFlag(0);
    /*gVar.nWeekStart = gDevice.getDayOfWeek();
     if (gVar.nWeekStart < 0 || gVar.nWeekStart > 6) {
     gVar.nWeekStart = 0;
     }
     gVar.SysLangType = gDevice.GetSysLangType();*/
}

function AutoLogin() {
    gVar.ip = "yuanxxn.vicp.net";   //"192.168.1.192"  "yuanxxn.vicp.net"
    gVar.mediaport = 18915;  //9200;
    gVar.user = "admin";
    gVar.passwd = "admin";

    gDevice.id = gDevice.UserLogin().Data.DeviceID;
}

function GensysLogin(ip, mediaport, user, passwd) {
    gVar.ip = ip;   
    gVar.mediaport = mediaport;
    gVar.user = user;
    gVar.passwd = passwd;

    gDevice.id = gDevice.UserLogin().Data.DeviceID;
}

function logout() {
    closewnd();
    window.location.reload(true);
}

function SendMsgToWeb(strMsg) {
    console.log("[MsgToWeb]:"+strMsg);
    GetMsgCallBack(strMsg);
}

function GetMsgCallBack(strMsg) { //event handling
    var data = JSON.parse(strMsg);
    var mainType = data["MainType"];
    var subType = data["SubType"];
    switch (mainType) {
        case eventEnum.MsgUserLoginEvent://0
        {
            if (subType == retEnum.RSNetMsgLoginSuccess) {
                gDevice.setLoginRsp(data["Data"]["LoginRsp"]);
                InitMainStreamNum();
                loginSuccess();

            } else if (subType == retEnum.RSNetMsgSendInfoSuccess) {// ipc set pwd suc
                gDevice.Disconnection();

            } else if (subType == retEnum.RSNetMsgSendInfoFailed) {// ipc set pwd failed
                gDevice.Disconnection();

            } else {
                if (subType == retEnum.RSNetMsgConnectFail) {
                    if (++gVar.errCount == 3) {
                        gDevice.Disconnection();
                        showMsg("网络连接失败");
                        console.log("网络连接失败");
                    }
                } else {
                    gDevice.Disconnection();
                    showMsg("网络连接失败");
                    console.log("网络连接失败");
                }
            }

            break;
        }
        case eventEnum.MsgPreviewEvent:
        {
            break;
        }

    }
}

function InitMainStreamNum() {//Limit number of main stream
    if ((lgCls.version == gVar.CtArr[0]) &&
        ((gDevice.loginRsp.HighType == 0x52530609 && gDevice.loginRsp.LowType == 0x140500) ||
        (gDevice.loginRsp.HighType == 0x52530306 && gDevice.loginRsp.LowType == 0xE0301))
    ) {//The equipment model
        g_MainStreamNum = 8;
        g_bLimitMainPreview = true;
    }
    else if (gDevice.loginRsp.PreviewNum * 1) {//See the value
        g_MainStreamNum = gDevice.loginRsp.PreviewNum * 1;
        g_bLimitMainPreview = true;
    }
    else {
        g_MainStreamNum = gDevice.loginRsp.ChannelNum;
    }
}

function loginSuccess() {

    var data = {};
    var preview = {};
    preview.padding = 2;
    preview.margin = 2;
    preview.wndBgColor = {
        "r": 29,
        "g": 28,
        "b": 33,
        "a": 255
    };
    preview.videoColor = {
        "r": 0,
        "g": 0,
        "b": 0,
        "a": 255
    };
    preview.bShowLogo = 0;
    if(lgCls.version==gVar.CtArr[0] || lgCls.version==gVar.CtArr[104] || lgCls.version==gVar.CtArr[159] || lgCls.version==gVar.CtArr[165] || lgCls.version==gVar.CtArr[167] || lgCls.version==gVar.CtArr[169] || lgCls.version==gVar.CtArr[171] || lgCls.version==gVar.CtArr[185]) {
        preview.bShowLogo = 1; //Show Background Picture
    }

    preview.videoNums = 1;
    preview.bShowLoading = 0;
    preview.bC003053120101 = 0;
    if (gVar.bC0_0305_3120101) {
        preview.bShowLoading = 1;
        preview.bC003053120101 = 0;
    }
    if(lgCls.version == gVar.CtArr[0]){
        preview.nOsdPos = 1;//0:left_bottom(default), 1:right_bottom
    }

    preview.arrBWirelessCh = [];
    for (var i = 0; i < gDevice.loginRsp.ChannelNum; i++) {
        if ((gDevice.devState[i].Abilities >> AbilityTypeEnum.SUPPROT_WIREFREE) & 1) {
            preview.arrBWirelessCh.push(1);
        } else {
            preview.arrBWirelessCh.push(0);//default
        }
    }

    preview.selColor = {
        "r": 125,
        "g": 125,
        "b": 0,
        "a": 255
    };

    if (lgCls.version == gVar.CtArr[142] && gDevice.devType == devTypeEnum.DEV_HDVR) {
        preview.selColor = {
            "r": 251,
            "g": 4,
            "b": 4,
            "a": 255
        };
    }
    if(gDevice.loginRsp.ZeroChFlag)
        preview.ChannelNum =gDevice.loginRsp.ChannelNum + 1;
    else
        preview.ChannelNum =gDevice.loginRsp.ChannelNum;
    //preview.showMode = getSplitModeByChannelNum(gDevice.loginRsp.ChannelNum);
    preview.showMode = SplitModeEnum.WINDOW_MODE_1;
    preview.zeroChannel = gDevice.loginRsp.ZeroChFlag;
    preview.StreamType = streamTypeEnum.SubStreamType;
    preview.RatioType = videoDisplayMode.Original;
    preview.bOpenSound = 0;
    preview.soundVolume = 25;
    if (gDevice.devType == devTypeEnum.DEV_IPC && gDevice.loginRsp.FishEye.isFishEye) {
        preview.bDragable = false;
        preview.isFishEye = true;
    } else {
        preview.bDragable = true;
        preview.isFishEye = false;
    }

    if (gDevice.devType == devTypeEnum.DEV_IPC) {
        if (gDevice.loginRsp.DefualtStream * 1 == 1) {//
            preview.StreamType = streamTypeEnum.SubStreamType;
        } else if (gDevice.loginRsp.DefualtStream * 1 == 2) {//
            preview.StreamType = streamTypeEnum.MobileStreamType;
        } else {//
            preview.StreamType = streamTypeEnum.MainStreamType;
        }
    }

    //Initializes the warning mark
    for (var n = 0; n < preview.ChannelNum; n++) {
        g_recordStatus[n] = new RecordStatusLog();
    }

    var playback = {};
    playback.padding = 2;
    playback.margin = 2;
    playback.wndBgColor = {
        "r": 29,
        "g": 28,
        "b": 33,
        "a": 255
    };
    playback.videoColor = {
        "r": 0,
        "g": 0,
        "b": 0,
        "a": 255
    };
    playback.selColor = {
        "r": 125,
        "g": 125,
        "b": 0,
        "a": 255
    };

    if (lgCls.version == gVar.CtArr[142] && gDevice.devType == devTypeEnum.DEV_HDVR) {
        playback.selColor = {
            "r": 251,
            "g": 4,
            "b": 4,
            "a": 255
        };
    }

    g_pbNum = g_pbCkNum = 4;
    var pbTmpMode = SplitModeEnum.WINDOW_MODE_4;

    if (g_pbIsSupportGt4WndPlay) {
        if (gDevice.devType == devTypeEnum.DEV_HDVR) {
            if (gDevice.loginRsp.AnalogChNum > 4 && gDevice.loginRsp.AnalogChNum <= 9) {
                g_pbNum = 9; //8 road playback, to create a window
                pbTmpMode = SplitModeEnum.WINDOW_MODE_9;
                g_pbCkNum = gDevice.loginRsp.AnalogChNum;
            } else if (gDevice.loginRsp.AnalogChNum > 9) {
                g_pbNum = 16;
                pbTmpMode = SplitModeEnum.WINDOW_MODE_16;
                g_pbCkNum = gDevice.loginRsp.AnalogChNum > 16 ? 16 : gDevice.loginRsp.AnalogChNum;
            }
        } else if (gDevice.devType == devTypeEnum.DEV_NVR) {
            if (gDevice.loginRsp.ChannelNum > 4 && gDevice.loginRsp.ChannelNum <= 9) {
                g_pbNum = 9; //8 road playback, to create a window
                pbTmpMode = SplitModeEnum.WINDOW_MODE_9;
                g_pbCkNum = gDevice.loginRsp.ChannelNum;
            } else if (gDevice.loginRsp.ChannelNum > 9) {
                g_pbNum = 16;
                pbTmpMode = SplitModeEnum.WINDOW_MODE_16;
                g_pbCkNum = gDevice.loginRsp.ChannelNum > 16 ? 16 : gDevice.loginRsp.ChannelNum;
            }
        }
    }

    playback.videoNums = (gDevice.loginRsp.ChannelNum) == 1 ? 1 : g_pbNum;
    playback.showMode = (gDevice.loginRsp.ChannelNum == 1 ? SplitModeEnum.WINDOW_MODE_1 : pbTmpMode);
    playback.bOpenSound = 0;
    playback.soundVolume = 25;

    if (gDevice.devType == devTypeEnum.DEV_IPC && gDevice.loginRsp.FishEye.isFishEye) {
        g_pbNum = 1;
        playback.videoNums = 1;
        playback.showMode = 0;
    }

    playback.ChannelNum = gDevice.loginRsp.ChannelNum;
    playback.arrBWirelessCh = [];
    for (var i = 0; i < gDevice.loginRsp.ChannelNum; i++) {
        if ((gDevice.devState[i].Abilities >> AbilityTypeEnum.SUPPROT_WIREFREE) & 1) {
            playback.arrBWirelessCh.push(1);
        } else {
            playback.arrBWirelessCh.push(0);//default
        }
    }

    var paramvideo = {};
    paramvideo.videoColor = {
        "r": 30,
        "g": 30,
        "b": 30,
        "a": 255
    };
    paramvideo.videoNums = gDevice.loginRsp.ChannelNum;

    data.Preview = preview;
    data.Playback = playback;
    data.Paramvideo = paramvideo;

    gDevice.initWindow(methodEnum.SubMsgInitWindowAll, data);
    gDevice.setPageIndex(0);

    gVar.logined = true;

    $("#ipcocx").css({width:"500px", height:"300px"});
    gDevice.OcxChangePage(pageEnum.TypePreviewPage);
    gDevice.PreviewPlay([0]);
}

