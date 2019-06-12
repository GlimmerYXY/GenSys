// JavaScript Document
var LanguageArray  = [["CHS", "简体中文"],["CHT","繁體中文"],["CSY","Čeština"],["DAN","Dansk"],["ENU", "English"],
					  ["FIN","Finnish"],["FRA","Français"],["DEU","Deutsch"],["ELL","Ελληνικα"],["HEB","Hebrew"],
					  ["HUN","Magyar"],["ITA","Italiano"],["JPN","日本語"],["PLK","Polski"],["PTG","Português"],
					  ["RUS", "Pусский"],["ESN","Español"],["THA","ไทย"],["SLV","Slovenija"],["ROM","România"],
					  ["BRG","Български"],["ARA","العربية"],["HIN","HINDI"],["VIE","VIETNAM"],["HOL","Nederlands"],
					  ["TUR","Türk"],["POS","فارسی"],["SVE","Svenska"],["KOR","한국어"],["IND","Bahasa Indonesia"],["PTB","Português do Brasil"]];	


var autoCloseTime = 10;
var tTime;  //Real time function

function AutoClose(title,flag)
{
	autoCloseTime--;
	if(autoCloseTime <= 0)
	{
		if($.browser.msie){
			if(C0Netview || C23Netview || C23NetviewUI5){//NetViewer
				window.location.reload(true);
			}else{
				window.opener=null;
				window.open('', '_self', ''); 
				window.close();
			}
		}else{
			window.location.reload(true);
		}
	}else{
		if($.browser.msie){
			if(C0Netview || C23Netview || C23NetviewUI5){//NetViewer
				ShowPaop(title, lg.get("IDS_DVR_REBOOT")+" "+autoCloseTime.toString()+" "+lg.get("IDS_LATER_RELOGIN"));
			}else{
				if(flag == 1){
					ShowPaop(title, lg.get("IDS_DVR_REBOOT")+" "+autoCloseTime.toString()+" "+lg.get("IDS_LATER_STARTEX"));
				}else if(flag == 0){
					ShowPaop(title, lg.get("IDS_DVR_REBOOT")+" "+autoCloseTime.toString()+" "+lg.get("IDS_LATER_START"));
				}else if(flag == 2){
					ShowPaop(title, lg.get("IDS_DEVICE_CHANGED")+" "+autoCloseTime.toString()+" "+lg.get("IDS_LATER_START"));
				}
			}
		}else{
			if(flag != 2){
				ShowPaop(title, lg.get("IDS_DVR_REBOOT")+" "+autoCloseTime.toString()+" "+lg.get("IDS_LATER_RELOGIN"));
			}else if(flag == 2){
				ShowPaop(title, lg.get("IDS_DEVICE_CHANGED")+" "+autoCloseTime.toString()+" "+lg.get("IDS_LATER_RELOGIN"));
			}
		}
		window.setTimeout(function(){AutoClose(title,flag);}, 1000);
	}
}


function closewnd() 
{
	try {
		if(g_downloadWin != null){
				gDevice.StopDownload();
				g_downloadWin.close();
				g_downloadWin = null;
			}

	} 
	catch(e) {
		//TODO handle the exception
	}
	if(typeof gDevice != "undefined"){
		if(gDevice.bInit){
			gDevice.Logout();
			gDevice.bInit = 0;
		}
	}
}

//Replication channel public methods
function copyTD(displayDiv,checkboxIds,joinDiv, num){
    if (typeof num == 'undefined')	num = gDevice.loginRsp.ChannelNum;
    $(displayDiv).css("display","block");

    var tempstr1 = "";
    var tempstr2 = "";
    var tempstr3 = "";
    var tempstr4 = "";
    var tempstr5 = "";
    var tempstr6 = "";
    var tempstr7 = "";
    var tempstr8 = "";

    var Rows = Math.ceil(num/8);
    for(var i = 0;i < Rows;i++){
        var RowsDiv = "";
        RowsDiv += '<div id="'+joinDiv+'_'+(i+1)+'_'+(i+1)+'" class="cfg_row"><div class="copy_R" id="'+joinDiv+'_'+(i+1)+'"></div></div>';
        $(displayDiv).append(RowsDiv);
    }

    var chnName = '';
    for(var i=0;i<num;i++)
    {
        var inner = "";
        if(i%8 == 0){
            cssStyle = 'float:left;';
        }else{
            cssStyle = 'float:left;margin-left:10px;';
        }

        if((i+1).toString().length==1){
            if(gDevice.devType==devTypeEnum.DEV_HDVR){
                if(i<gDevice.loginRsp.AnalogChNum){
                    //analog channel： CH01...
                    chnName = lg.get("IDS_CH")+'0'+(i+1);
                }else{
                    //IP channel： IP CH01...
                    chnName = "IP " + lg.get("IDS_CH")+'0'+(i+1-gDevice.loginRsp.AnalogChNum);
                }
            }else{
                chnName = lg.get("IDS_CH")+'0'+(i+1);
            }

        }else{
            if(gDevice.devType==devTypeEnum.DEV_HDVR){
                if(i<gDevice.loginRsp.AnalogChNum){
                    //analog channel： CH01...
                    chnName = lg.get("IDS_CH")+(i+1);
                }else{
                    //IP channel： IP CH01...
                    var n = i+1-gDevice.loginRsp.AnalogChNum;
                    if( n<10 ){ n = "0" + n;}
                    chnName = "IP " + lg.get("IDS_CH")+(n);
                }
            }else{
                chnName = lg.get("IDS_CH")+(i+1);
            }
        }
        if(gDevice.devType==devTypeEnum.DEV_HDVR){
            if(checkboxIds == 'io_ch'){
                chnName = 'IO-' + (i+1);
            }
		}
        inner += '<div id="div_'+checkboxIds+(i+1)+'" style="'+cssStyle+'"><input type="checkbox" id="'+checkboxIds+''+(i+1)+'" value="'+i+'"/>'+ chnName +'</div>';

        if(i<8){
            tempstr1 += inner;
            $("#"+joinDiv+"_1").html(tempstr1);
        }else if(i<16){
            tempstr2 += inner;
            $("#"+joinDiv+"_2").html(tempstr2);
        }else if(i<24){
            tempstr3 += inner;
            $("#"+joinDiv+"_3").html(tempstr3);
        }else if(i<32){
            tempstr4 += inner;
            $("#"+joinDiv+"_4").html(tempstr4);
        }else if(i<40){
            tempstr5 += inner;
            $("#"+joinDiv+"_5").html(tempstr5);
        }else if(i<48){
            tempstr6 += inner;
            $("#"+joinDiv+"_6").html(tempstr6);
        }else if(i<56){
            tempstr7 += inner;
            $("#"+joinDiv+"_7").html(tempstr7);
        }else if(i<64){
            tempstr8 += inner;
            $("#"+joinDiv+"_8").html(tempstr8);
        }

    }
}
function alarmOutCopy(displayDiv,checkboxIds,ipcArr){
	$("#"+displayDiv).empty();
	var html = "<div style='overflow-y:auto;overflow-x:hidden;'>";
	for (var i=0; i<gDevice.loginRsp.AlarmInNum; i++){
		html += '<div style="float:left;margin-right:10px;">'+
			'<input type="checkbox" id="' + checkboxIds + (i + 1) + '" value="' + i+ '" value="' + (i+1) + '" style="float:left;height:30px;">' + "Local<-"+(i+1) + '</input>'+
		'</div>';
	}
	html += "<br>";
	for(var i = 0;i < gDevice.loginRsp.ChannelNum;++i){
		if(gDevice.devState[i].CurChnState == 2){
			for(var j = 0;j < gDevice.devState[i].InputNum;++j){
				html += '<div style="float:left;margin-right:10px;">'+
					'<input type="checkbox" id="'+ checkboxIds + (i+1+gDevice.loginRsp.ChannelNum*(j+1)) + '" value="' + (i+gDevice.loginRsp.ChannelNum*(j+1)) + '" style="float:left;height:30px;">' + ipcArr[i]+'<-'+(j+1)+'</input>'+
				'</div>';
			}
		}
	}
	html += "</div>"
	$("#"+displayDiv).append(html);
}
//Trigger Alarm Out
function alarmOut(displayDiv,ipcArr){
	$("#"+displayDiv).empty();
	$("#"+displayDiv).append('<div class="cfg_row copytitle"><div>Trigger Alarm Out</div></div>');
	$("#"+displayDiv).append('<div class="cfg_row">'+
		'<div style="margin-left: 10px;width: 100px;">'+
			'<input type="checkbox" id="Alarmout_SelectAll_'+displayDiv+'" style="float: right;height:30px;background:transparent;">Select All</input>'+
			//'<font style="float: left;"></font>'+
		'</div>'+
	'</div>');
	var html = "<div style='height:150px;overflow-y:auto;overflow-x:hidden;margin-left:10px;right:10px;'>";
	for (var i=0; i<gDevice.loginRsp.AlarmOutNum; i++){
		html += '<div id="div_'+displayDiv+(i+1)+'" style="float:left;margin-left:5px;height:30px;">'+
			'<div style="float:left;margin-right: 5px;">' + 'Local->'+(i+1) + '</div>'+
			'<input type="checkbox" id="Alarmout_' + displayDiv + (i + 1) + '" value="' + i + '" style="float:right;"/>'+
		'</div>';
	}
	html += "<br style='line-height:30px;'>";
	for(var i = 0;i < gDevice.loginRsp.ChannelNum;++i){
		if(gDevice.devState[i].CurChnState == 2){
			for(var j = 0;j < gDevice.devState[i].OutputNum;++j){
				html += '<div id="div_'+displayDiv+(i+1+gDevice.loginRsp.ChannelNum*(j+1))+'" style="float:left;margin-left:5px;height:30px;">'+
					'<div style="float:left;margin-right: 5px;">' + ipcArr[i]+'->'+(j+1)+'</div>'+
					'<input type="checkbox" id="Alarmout_' + displayDiv + (i+1+gDevice.loginRsp.ChannelNum*(j+1)) + '" value="' + (i+gDevice.loginRsp.ChannelNum*(j+1)) + '" style="float:right;"/>'+
				'</div>';
			}
		}
	}
	html += "</div>"
	$("#"+displayDiv).append(html);
	$("#"+displayDiv).append('<div class="table" style="position: absolute;bottom: 0px;">'+
//			'<input class="ButtonToDiv" type="button" value="OK" id="ioOk" style="position: relative;left: 33%;bottom: 5px;"/>'+
			'<div class="btn" onclick="$(\'#'+displayDiv+'\').css(\'display\',\'none\');"style="position: relative;left: 250%;bottom: 5px;">'+lg.get("IDS_OK")+'</div>'+
		'</div>');
	$("input[id^='Alarmout_"+displayDiv+"']").change(function(){
		var length = $("input[id^='Alarmout_"+displayDiv+"']").length;
		$("input[id^='Alarmout_"+displayDiv+"']").each(function(){
			if($(this).val() == 1){
				--length;
			}
		});
		if(length > 0){
			$("input[id^='Alarmout_SelectAll_']").prop("checked",false);
		}else{
			$("input[id^='Alarmout_SelectAll_']").prop("checked",true);
		}
	});
	$("input[id^='Alarmout_SelectAll_']").click(function(){
		$("input[id^='Alarmout_']").prop("checked",$(this).prop("checked"));
	});
	$("input[id^='Alarmout_SelectAll_']").prop("checked",false);
}

function DivBox(objMain, obj){
	var $obj = $(obj);
	
	if (typeof objMain=="string" && ($(objMain).prop("checked")*1 != 1) ||(typeof objMain == "number" && objMain==0)){
		$obj.find("select").prop("disabled",true);
		$obj.find("div").prop("disabled",true);
		$obj.find("input").prop("disabled",true);
		$obj.children().prop("disabled",true);
		if($obj.css("display") != "none")$obj.stop().fadeTo("slow", 0.2);
		$obj.find('button').prop("disabled",true).addClass('btn-disable');
	}else{
		$obj.find("select").prop("disabled",false);
		$obj.find("div").prop("disabled",false);
		$obj.find("input").prop("disabled",false);
		if($obj.css("display") != "none"){
			$obj.stop().fadeTo("slow", 1,function(){
				//Compatible with safari processing
				if($.browser.safari){
					//$obj.css("filter","");
				}
			});
		}
		$obj.children().prop("disabled",false);
		$obj.find('button').prop("disabled",false).removeClass('btn-disable');
	}
	$obj = null;
}

function DivBox_Net(objMain, obj){
	var $obj = $(obj);
	if (typeof objMain=="string" && ($(objMain).attr("data")*1 != 1) ||(typeof objMain == "number" && objMain==0)){
		$obj.find("select").prop("disabled",true);
		$obj.find("input").prop("disabled",true);
		$obj.children().prop("disabled",true);
		$obj.find("div[data]").prop("disabled",true);
		if($obj.css("display") != "none")$obj.stop().fadeTo("slow", 0.7);
        $obj.find('button').prop("disabled",true).addClass('btn-disable');
    }else{
		$obj.find("select").prop("disabled",false);
		$obj.find("input").prop("disabled",false);
		if($obj.css("display") != "none"){
			$obj.stop().fadeTo("slow", 1,function(){
				//Compatible with safari processing
				if($.browser.safari){
					//$obj.css("filter","");
				}
			});
		}
		$obj.children().prop("disabled",false);
		$obj.find("div[data]").removeProp("disabled");
        $obj.find('button').prop("disabled",false).removeClass('btn-disable');
    }
	$obj = null;
}

function showDiv(objMain, obj){//0 show，1 hide
	var $obj = $(obj);
	if (objMain == 1){
		$obj.find("select").prop("disabled",true);
		$obj.find("input").prop("disabled",true);
		$obj.children().prop("disabled",true);
		$obj.find(":text").each(function(){
			$(this).attr("disabled", true);
		});
		$obj.find(":password").each(function(){
			$(this).attr("disabled", true);
		});
		if($obj.css("display") != "none")$obj.fadeTo("slow", 0.2);
	}else{
		$obj.find("select").prop("disabled",false);
		$obj.find("input").prop("disabled",false);
		if($obj.css("display") != "none"){
			$obj.fadeTo("slow", 1,function(){
				//Compatible with safari processing
				//$obj.css("filter","");
			});
		}
		$obj.children().prop("disabled",false);
		$obj.find(":text").each(function(){
			$(this).attr("disabled", false);
		});
		$obj.find(":password").each(function(){
			$(this).attr("disabled", false);
		});
	}
}

Date.prototype.Format = function(fmt)   
{  
  var o = {   
    "M+" : this.getMonth()+1,                 //month   
    "d+" : this.getDate(),                    //   
    "h+" : this.getHours(),                   //   
    "m+" : this.getMinutes(),                 //  
    "s+" : this.getSeconds(),                 //   
    "q+" : Math.floor((this.getMonth()+3)/3), //quarter   
    "S"  : this.getMilliseconds()             //   
  };   
  if(/(y+)/.test(fmt))   
    fmt=fmt.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length));   
  for(var k in o)   
    if(new RegExp("("+ k +")").test(fmt))   
  fmt = fmt.replace(RegExp.$1, (RegExp.$1.length==1) ? (o[k]) : (("00"+ o[k]).substr((""+ o[k]).length)));   
  return fmt;   
}

//Initialize the button state
function InitButton(){
	$("input[data],div[data]").each(function () {
		if ($(this).attr("data")*1 == 1) {
			$(this).removeClass("switch").addClass("selectEnable");
		} else {
			$(this).addClass("switch");
		}
	});
}

//Button switch function
function ChangeBtnState(){
	$("input[data],div[data]").click(function () {
		if ($(this).attr("data") == "0") {
			$(this).removeClass("switch").addClass("selectEnable").attr("data","1");
		} else {
			$(this).removeClass("selectEnable").addClass("switch").attr("data","0");
		}
	});
}

//Display mask layer
function MasklayerShow() 
{
	var bgObj=document.getElementById("MaskLayout");
	bgObj.style.width = document.body.offsetWidth + "px";
	bgObj.style.height = document.body.offsetHeight + "px";
	bgObj.style.display = "block";
//	if($.browser.firefox){
//		var bgObjfirefox=document.getElementById("MaskLayoutFirefox");
//		bgObjfirefox.contentWindow.ShowMask();
//		bgObjfirefox.style.display = "block";
//		$(bgObjfirefox).slideDown("fast");
//		bgObjfirefox.style.left = $("#ipcocx").offset().left+"px";
//		bgObjfirefox.style.top = $("#ipcocx").offset().top+"px";
//		bgObjfirefox.style.width = $("#ipcocx").css("width");
//		bgObjfirefox.style.height = $("#ipcocx").css("height");
//	}
}

//Hide the mask layer
function MasklayerHide()
{
	var bgObj=document.getElementById("MaskLayout");
	bgObj.style.display = "none";
//	if($.browser.firefox){
//		var bgObjfirefox=document.getElementById("MaskLayoutFirefox");
//		bgObjfirefox.style.display = "none";
//	}
}

function ShowPaop(title, contant){
	if(gCloseFlag == 1){
		MasklayerShow();
		$("#MsgPaop_box").css("left","40%");
		$("#MsgPaop_box").css("top","35%");
		$("#MsgPaop_box").css("z-index","10003");
	}
	if($.browser.msie || $.browser.safari){
		MsgPaop_box.window.ShowPaop(title, contant, gVar.sPage);
	}else if($.browser.chrome){
		MsgPaop_box.contentWindow.ShowPaopChrome(title, contant, gVar.sPage);
	}else{
		MsgPaop_box.contentWindow.ShowPaop(title, contant, gVar.sPage);
	}
}

function ShowSetCam(){
	if($.browser.msie || $.browser.safari){
		SetCam_box.window.ShowSetCam();
	}else{
		SetCam_box.contentWindow.ShowSetCam();
	}
}

function setShutterCon(type,val,bAdd){
	if($.browser.msie || $.browser.safari){
		SetCam_box.window.setShutterCon(type,val,bAdd);
	}else{
		SetCam_box.contentWindow.setShutterCon(type,val,bAdd);
	}
}

var g_webPromptTimmer = -1;
function Web_prompt(str,delayHide){
	if(g_autoToConfig){
		alert(str);
		return ;
	}
  	MasklayerHide();
	if(str == "" || str == null || str=="undefined") { str="";/*str = "can't find the language !";*/}
	//$("#loginBtn").get(0).onclick = Login;
	$("#Web_false").text(str).css("color","red");
	if(g_webPromptTimmer != -1) {
			clearTimeout(g_webPromptTimmer);
	}
	if(delayHide) {
		$("#Web_false").fadeIn("slow");	
		g_webPromptTimmer = setTimeout('$("#Web_false").fadeOut("slow")',5000);
	} else {
		$("#Web_false").fadeIn("fast");
	}
}

function Web_promptEx(str){
  	MasklayerHide();
	if(str == "" || str == null) { str = "can't find the language !";}
	//$("#loginBtn").get(0).onclick = Login;
	$("#Web_false").text(str).css("color","red");
	setTimeout('$("#Web_false").fadeIn("slow")',500);
	setTimeout('$("#Web_false").fadeOut("slow")',5000);
}

//IE 
function findNode(name, xml){
	xml = '<a>' + xml + '</a>';
	xml = xml.split(name).join("p");
	xml = $(xml).find("p").html();
	return xml == null? -1: xml;
}

function findChildNode(name, child, xml){
	var s = xml.indexOf(name);
	if (s == -1) {alert(lg.get("IDS_REFRESH_NONODE"));return;}
	s = s + name.length + 1;
	xml = xml.substring(s, xml.length);
	var e = xml.indexOf(name);
	if (e == -1)	{alert(lg.get("IDS_REFRESH_NONODE"));return;}
	e = e - 2;
	xml = xml.substring(0, e);
	xml = '<a>' + xml + '</a>';
//	xml = xml.split(child).join("p");
	xml = xml.split("<"+child+">")[1].split("</"+child+">")[0];
//	xml.replace(/(^\s*)|(\s*$)/g, "&nbsp"); 
//	xml = $(xml).find("p").html();
	return xml == null? "": xml;
}

//Let the text box, text fields, and the password box to choose from
function fbd()
{
	var the = event.srcElement ;
 	//Through the body of the onselectstart properties, control the content of leaf optional state
 	//Tags are input text and text fields textarea, are all can choose project.
 	if( !( ( the.tagName== "INPUT" && the.type.toLowerCase() == "password" ) ||( the.tagName== "INPUT" && the.type.toLowerCase() == "text" ) || the.tagName== "TEXTAREA" )){
 		return false;
 	}
 	return true;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////
function cfgXmlParsing(obj, array, xml){
	if ($.browser.msie && $.browser.version*1 > 9){
		$('<?xml version="1.0" encoding="utf-8"?><xml>"+xml+"</xml>').find("xml").children().each(function(){
			obj.set($(this).get(0).nodeName, $(this).text());
		});
	}else{
		$("<xml><item>" + xml + "</item></xml>").find("item").children().each(function(){
			obj.set($(this).get(0).nodeName, $(this).text());
		})
	}
	//Populate the data elements
	var length = array.length;
	for (var i=0; i<length; i++){
		$("#"+array[i][0]).attr(array[i][2], obj.get(array[i][1]));
	}
}

function cfgXmlPack(obj, length){
	var xml = "";
	var node = "";
	for (var i=0; i<length; i++){
		node = obj.get(i);
		xml += ("<" + node + ">" + obj.get(node) + "</" + node + ">")
	}
	return xml;
}

function cfgXmlSing(node, value){
	return("<"+node+">"+value+"</"+node+">");
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////////////////////////////
function LanguageCall(){}	//Load the language callback function

	
//Filtering the direction key 
function keyboardFilter(e){
	e = e || window.event;
	if(!e.srcElement)
		e.srcElement = e.target;
	if ((e.keyCode >= 37 && e.keyCode <= 40) || (e.keyCode == 8) || (e.keyCode == 9)){
		return false;
	}
	return true; 
}
//To limit the port
function NumberRangeLimt(ctrId,minVal,maxVal){
//var str =$("#"+ctrId.id).get(0).value.replace(/\D/g,'');
	var str = ($("#"+ctrId.id).val()).replace(/\D/g,'')*1;
	if(minVal != maxVal)
	{
	  if(str < minVal) {return minVal;}
	  if(str > maxVal) {return maxVal;}
	}
	return str;
}
		 
function Reset(){
	$("#username").val("");
	$("#passwd").val("");
	$("#login_language").val(gVar.lg);
	$("#login_language").change();
	$("#username").focus();
}

//Check the string
function CheckStringValue(str,bpswd){
	
	if(bpswd != 1)
	{
	if(str == "" || str == null) 
	   return 1;
	}
	
	 ss = str.split(" ");  
	 if(ss.length != 1)
	    return 2;
		
	return 0;	
}

//Dealing with traditional Chinese special characters
function CheckBig5(str){
	return str.replace(/許/g,"許\\").replace(/功/g,"功\\").replace(/么/g,"么\\").replace(/蓋/g,"蓋\\").replace(/閱/g,"閱\\");
}

//The version number, the new version of the return true
function compareVersion(oldversion,newversion){
	var oldArr = oldversion.split(".");
	var newArr = newversion.split(".");
	if(oldArr.length != newArr.length)
		return true;
	for(var i = 0;i < oldArr.length; ++i)
	{
		if(oldArr[i]*1 < newArr[i]*1){
			return true;
		}else if(oldArr[i]*1 > newArr[i]*1){
			return false;
		}
	}
	return false;
}

function GetPluginVersion(ext){
	var plugins = navigator.plugins;
	var plugin;
	for (var pi = 0; pi  < plugins.length; pi++)
	{
		plugin = plugins[pi];
		if (plugin[0].type == ext)
		{
			return plugin.description;
		}
	}
	return "";
}


function CheckBrowser(){
	if(C0Netview || C23Netview){
		return true;//netview has no download
	}
	
	if ($.browser.firefox) {
		if( $.browser.version*1 < 52){
			return true;
		}
	} else if ($.browser.chrome) {
        if( $.browser.chromeversion.split(".")[0]*1 < 45){
			return true;
		}
	} else if ($.browser.msie) {
		if( $.browser.version*1 > 7){
			return true;
		}
	} else if ($.browser.safari) {
		if($.browser.macos){
			return true;
		}
	} else {

	}
	
	return false;
}

function  CheckVersion(bIpcSafari){
	var bDown = false;
	bIpcSafari = typeof bIpcSafari != "undefined"?bIpcSafari:false;
	if($.browser.msie) {
		var control = null;
		try {
			var param = {};
			param.MainType = methodEnum.MainMsgGetOcxVersion;
			param.SubType = methodEnum.MsgNoType;
			var retData = document.getElementById("ipcocx").SendMsgToPlugin(JSON.stringify(param));

			var ocxVersion = "1.0.0.0";
			if(JSON.parse(retData).Code == errCodeEnum.Code_Success){
				ocxVersion = JSON.parse(retData)["version"];
			}else{
				bDown = true;
			}
			ocxVersion = ocxVersion.replace(' ','').split(',').join('.');//2.0.0.168
			if($.browser.msie){
				if(compareVersion(ocxVersion,version_msie)){
					bDown = true;
				}
			}else{
				if(compareVersion(ocxVersion,version_safari)){
					bDown = true;
				}
			}
			
		} catch (e) {
			bDown = true;
		}
		if(bDown) {
			LoadWebPlugins();
		}else{
			InitWeb();
		}
	}
}


/*//write in cookie
function setCookieLan(kindOfLan){
	var expdate=new Date();  
    var outms=7*24*60*60*1000;//Expiration time, expressed as a day '1' for the unit a day, 7 days
    expdate.setTime(expdate.getTime()+outms);  
    var cookieStr="RS_Language="+encodeURIComponent(kindOfLan)+";expires="+expdate.toGMTString();  
    document.cookie=cookieStr;
}
//read cookie
function getCookieLan(){
	var CookieVaule = document.cookie,CookieLength = CookieVaule.length,RSlanVaue="";
	if(CookieLength > 0){
		var RSlan = CookieVaule.indexOf("RS_Language=");
		if(RSlan != -1){
			RSlan +="RS_Language=".length;
			var RSlanEnd = document.cookie.indexOf(";", RSlan);
			if (RSlanEnd == -1) RSlanEnd = CookieLength;
			RSlanVaue = decodeURIComponent(document.cookie.substring(RSlan, RSlanEnd));
		}
		return RSlanVaue;
	}else{
		return "";
	}
}*/

function MiladiIsLeap(miladiYear)
{
	if(((miladiYear % 100)!= 0 && (miladiYear % 4) == 0) || ((miladiYear % 100)== 0 && (miladiYear % 400) == 0))
	{
		return true;
	}
	else
	{
		return false;
	}
}

/**********************************************************
function name：MiladiToShamsi
function declaration：Convert the Gregorian calendar to Persian calendar
Incoming parameters：miladiDate:Need to convert the Gregorian calendar date value
return：Calendar value after conversion
***********************************************************/ 
function MiladiToShamsi(Month,Day,Year)//The Gregorian calendar to the Gregorian one conversion
{
	var iMiladiMonth = Month;
	var iMiladiDay   = Day;
	var iMiladiYear  = Year;

	var shamsiDay, shamsiMonth, shamsiYear; 
	var dayCount,farvardinDayDiff,deyDayDiff ; 
	var sumDayMiladiMonth = [0,31,59,90,120,151,181,212,243,273,304,334];
	var sumDayMiladiMonthLeap= [0,31,60,91,121,152,182,213,244,274,305,335];
	//SHAMSIDATE shamsidate;
	farvardinDayDiff=79;
	if (MiladiIsLeap(iMiladiYear))	{
		dayCount = sumDayMiladiMonthLeap[iMiladiMonth-1] + iMiladiDay;
	}else{ 
		dayCount = sumDayMiladiMonth[iMiladiMonth-1] + iMiladiDay;
	}

	if((MiladiIsLeap(iMiladiYear - 1))){
		deyDayDiff = 11;
	}else{
		deyDayDiff = 10;
	}
	if (dayCount > farvardinDayDiff) { 
		dayCount = dayCount - farvardinDayDiff; 
		if (dayCount <= 186){ 
			switch (dayCount%31) { 
			case 0: 
				shamsiMonth = dayCount / 31;
				shamsiDay = 31;
				break;
			default:
				shamsiMonth = (dayCount / 31) + 1; 
				shamsiDay = (dayCount%31);
				break;
			}
			shamsiYear = iMiladiYear - 621;
		}else{
			dayCount = dayCount - 186;   
			switch (dayCount%30){
				case 0:    
					shamsiMonth = (dayCount / 30) + 6;
					shamsiDay = 30;
					break;
				default:            
					shamsiMonth = (dayCount / 30) + 7;
					shamsiDay = (dayCount%30);    
					break;
			}
			shamsiYear = iMiladiYear - 621;
		}    
	}else {            
		dayCount = dayCount + deyDayDiff;
		switch (dayCount%30){
		   case 0 :
			   shamsiMonth = (dayCount / 30) + 9; 
			   shamsiDay = 30;
			   break;
		   default:
			   shamsiMonth = (dayCount / 30) + 10;           
			   shamsiDay = (dayCount%30);
			   break;
		}
		shamsiYear = iMiladiYear - 622;            
	}
	shamsiYear = parseInt(shamsiYear);
	shamsiMonth = parseInt(shamsiMonth);
	shamsiDay = parseInt(shamsiDay);
	var date={};
	date.year = shamsiYear;
	date.month = shamsiMonth;
	date.day = shamsiDay;
	return date;
	//GLtoHLyear = shamsiYear;
	//GLtoHLmonth = shamsiMonth;
	//GLtoHLday = shamsiDay;
	//return 1 ;
}

function getWindowNumByChannelNum(channelNum)
{
	if(gDevice.loginRsp.ZeroChFlag)
		channelNum+= 1;
	//if(!$.browser.safari){
		return channelNum;
	/*}
	if(channelNum == 1) return 1;
	else if(channelNum>1 && channelNum<=4) return 4;
	else if(channelNum>4 && channelNum<=6) return 6;
	else if(channelNum>6 && channelNum<=8) return 9;
	else if(channelNum>8 && channelNum<=16) return 16;
	else if(channelNum>16 && channelNum<=25) return 25;
	else if(channelNum>25 && channelNum<=36) return 36;
	else if(channelNum>36 && channelNum<=64) return 64;
	else if(channelNum>64 && channelNum<=80) return 80;*/
}

function getSplitModeByChannelNum(channelNum)
{
	if(gDevice.loginRsp.ZeroChFlag)
		channelNum += 1;
	if(channelNum == 1) return SplitModeEnum.WINDOW_MODE_1;
	else if(channelNum>1 && channelNum<=4) return SplitModeEnum.WINDOW_MODE_4;
	else if(channelNum>4 && channelNum<=6) return SplitModeEnum.WINDOW_MODE_6;
	else if(channelNum>6 && channelNum<=9) return SplitModeEnum.WINDOW_MODE_9;
	else if(channelNum>9 && channelNum<=12) return SplitModeEnum.WINDOW_MODE_12;
	else if(channelNum>12 && channelNum<=16) return SplitModeEnum.WINDOW_MODE_16;
	else if(channelNum>16 && channelNum<=25) return SplitModeEnum.WINDOW_MODE_25;
	else  return SplitModeEnum.WINDOW_MODE_36;
}

function getTotalPageByMode(mode, channelNum) {
	var wndNum = getWindowNumByChannelNum(channelNum);
	var nPerPage = numPerPage(mode);
	var page = parseInt((wndNum + (nPerPage-1))/nPerPage);
	return page;
}

function findPageIndexByChannel(channel, mode, views) {
	var channelPerPage = numPerPage(mode);
	var viewIndex = 0;
	for(var i=0; i<views.length; i++) {
		if(channel == views[i]) {
			viewIndex = i;
			break;
		}
	}
	return parseInt(viewIndex / channelPerPage);
}

function numPerPage(mode) {
	switch(mode) {
		case SplitModeEnum.WINDOW_MODE_1:
		return 1;
		case SplitModeEnum.WINDOW_MODE_4:
		return 4;
		case SplitModeEnum.WINDOW_MODE_6:
		return 6;
		case SplitModeEnum.WINDOW_MODE_8:
		return 8;
		case SplitModeEnum.WINDOW_MODE_9:
		return 9;
		case SplitModeEnum.WINDOW_MODE_10:
		return 10;
		case SplitModeEnum.WINDOW_MODE_10_1:
		return 10;
		case SplitModeEnum.WINDOW_MODE_12:
		return 12;
		case SplitModeEnum.WINDOW_MODE_13:
		return 13;
		case SplitModeEnum.WINDOW_MODE_13_1:
		return 13;
		case SplitModeEnum.WINDOW_MODE_14:
		return 14;
		case SplitModeEnum.WINDOW_MODE_16:
		return 16;
		case SplitModeEnum.WINDOW_MODE_20:
		return 20;
		case SplitModeEnum.WINDOW_MODE_25:
		return 25;
		case SplitModeEnum.WINDOW_MODE_36:
		return 36;
		default:
		return 1;
	}
}

function tick() {   //Call real-time loading page only can use the time functions
        var years,months,days,hours, minutes, seconds,yearsHuili,monthsHuili,daysHuili;
        var intYears,intMonths,intDays,intHours, intMinutes, intSeconds,intYearsHuili,intMonthsHuili,intDaysHuili;
        var today;
        today = new Date(); //The current system time
        intYears = today.getFullYear(); //
        intMonths = today.getMonth() + 1; //
        intDays = today.getDate(); //
        intHours = today.getHours(); // 
        intMinutes = today.getMinutes(); //
        intSeconds = today.getSeconds(); //

		if(lgCls.version == gVar.CtArr[44]){
			var date = MiladiToShamsi(intMonths, intDays, intYears);
			intMonthsHuili = date.month;
			intDaysHuili = date.day;
			intYearsHuili = date.year;
		}
        years = intYears + "-"; 
		yearsHuili = intYearsHuili + "-"; 

        if(intMonths < 10 ){
            months = "0" + intMonths +"-";
            } else {
            months = intMonths +"-";
        }
		if(intMonthsHuili < 10 ){
            monthsHuili = "0" + intMonthsHuili +"-";
            } else {
            monthsHuili = intMonthsHuili +"-";
        }
		
        if(intDays < 10 ){
            days = "0" + intDays +" ";
            } else {
            days = intDays + " ";
        }
		if(intDaysHuili < 10 ){
            daysHuili = "0" + intDaysHuili +" ";
            } else {
            daysHuili = intDaysHuili + " ";
        }

	if (intHours == 0) {
		hours = "00:";
		} else if (intHours < 10) {
		hours = "0" + intHours+":";
		} else {
		hours = intHours + ":";
	}

	if (intMinutes < 10) {
		minutes = "0"+intMinutes+":";
		} else {
		minutes = intMinutes+":";
	}

        if (intSeconds < 10) {
            seconds = "0"+intSeconds+" ";
            } else {
            seconds = intSeconds+" ";
        }
     
        var timeDate = years+months+days;
		var timeDateHuili = yearsHuili+monthsHuili+daysHuili;
        var timeClock = hours+minutes+seconds;
		if(lgCls.version == gVar.CtArr[44]){
	        $("#dst_date").val(timeDateHuili) ;
		}else{
			$("#dst_date").val(timeDate);
		}
		$("#dst_date").attr("grecal",timeDate);
        $("#clock").val(timeClock);
        tTime = window.setTimeout("tick()", 500);
}

function fnDDNSTest_TimeOut()
{
	gVar.var_DDNSTest_isTimeOut = false;
	var time = 1*60*1000;//2 minute
	try{
		gVar.timer_DDNSTest = window.setTimeout(function(){
			gVar.var_DDNSTest_isTimeOut = true;
	
			ShowPaop($("#ddns_config").text(),lg.get("IDS_DDNSTEST_RECEIVE_TIMEOUT"));
			$("#DDNSTest").prop("disabled",false);
			$("#DDNSSave").prop("disabled",false);
            if($("#DDNSServerAddr").val()*1 == 52){
                DDNSTest.innerHTML = "Update";
            }else{
                DDNSTest.innerHTML = lg.get("IDS_DDNSTEST");
            }
		}, time);
	}catch(e){
		//TODO handle the exception
	}
}

function SetAllCheckFun(allId,selId,addEvent){
	var bAll=true;
	if(addEvent){
		$(allId).click(function() {
			$(selId).each(function() {
				$(this).prop("checked", $(allId).prop("checked"));
			});
		});
		$(selId).click(function() {
			var bAll = true;
			$(selId).each(function() {
				if(!$(this).prop("checked")){
					bAll = false;
				}
			});
			_result(allId,selId);
			bAll = null;
		});
	}
	
	_result(allId,selId);
	
	function _result(allId,selId){
		$(selId).each(function(){
			if(!$(this).prop("checked")){
				bAll = false;
			}
		});
		if(bAll){
			$(allId).prop("checked",true);
		}else{
			$(allId).prop("checked",false);
		}
		bAll = true;
	}
}

//Digital supplement the digits
function prefixInteger(num,len){//
    return (Array(len).join('0') + num).slice(-len);
}

//delete ligerGrid invalid data
function deleteUselessList(xml,ifdata){//ifdata->Judge condition of data
	var arr=[],len=xml.length,i;
	for(i=0;i<len;i++){
		if(typeof xml[i][ifdata] !='undefined'){
			arr.push(xml[i]);
		}
	}
	return arr;
}

//Add video channel
function recChannel(idDiv,chAllId,clr,bcr){//id,checkAllid
	var i,Datahtml='',cnNum=gDevice.loginRsp.ChannelNum,hasAnal=false,color = clr;
	var idDiv=idDiv,chAllId=chAllId;
	var $obj=$("#"+idDiv);
	
	if(gDevice.loginRsp.AnalogChNum>0){
		Datahtml+='<div class="cfg_row_left" id="'+idDiv+'_check">'
							    +'<div class="cfg_row"><span id="'+idDiv+'_lg1">'+lg.get("IDS_ANALOG")+' '+lg.get("IDS_CFG_ALL")+'</span><input id="'+idDiv+'_AnaALL" type="checkbox" style="margin-left:5px;">'+'</div>'
								+'<div class="cfg_row"><span id="'+idDiv+'_lg2">IP '+lg.get("IDS_CFG_ALL")+'</span><input id="'+idDiv+'_IPALL" type="checkbox" style="margin-left:5px;">'+'</div>'
						+'</div><div class="cfg_row_right">'
								+'<div class="rightEx" id="'+idDiv+'_Box"></div></div>';
		hasAnal = true;
	}else{
		Datahtml = '<div class="rightEx" id="'+idDiv+'_Box"></div>';
	}
	$obj.css("height",(i/14+1)*30+"px");
	$obj.prop("innerHTML",Datahtml);
	
	$("#"+idDiv+"_Box").divBox({number:cnNum,bkColor:color,parentLev:2,borderColor:bcr});
	$("#"+idDiv+"_Box").css("height",(i/14+1)*30+"px");
	
	if(hasAnal){
		$("#"+idDiv+"_AnaALL").click(function(){
			$("#"+idDiv+"_Box > div").each(function(i){
                if(i<(gDevice.loginRsp.AnalogChNum)){
					if($("#"+idDiv+"_AnaALL").prop("checked")){
						$(this).css("background-color",color);
					}else{
						$(this).css("background-color","transparent");
					}
				}
            });
			$("#"+chAllId).prop("checked",$(this).prop("checked")&&$("#"+idDiv+"_IPALL").prop("checked"));
		});
		
		$("#"+idDiv+"_IPALL").click(function(){
			$("#"+idDiv+"_Box > div").each(function(i){
                if(i>=gDevice.loginRsp.AnalogChNum){
					if($("#"+idDiv+"_IPALL").prop("checked")){
						$(this).css("background-color",color);
					}else{
						$(this).css("background-color","transparent");
					}
				}
            });
			$("#"+chAllId).prop("checked",$(this).prop("checked")&&$("#"+idDiv+"_AnaALL").prop("checked"));
		});
	}
	
	$("#"+idDiv+"_Box > div").mousedown(function(){
		bCkAll(hasAnal);
	}).mouseover(function(){
		bCkAll(hasAnal);
	});
	
	$("#"+chAllId).click(function(){
	    $("#"+idDiv+"_Box > div").each(function(i){
			  if($("#"+chAllId).prop("checked")){
				  $(this).css("background-color",color);
			  }else{
				  $(this).css("background-color", "transparent");
			  }
		 });
		$("#"+idDiv+"_AnaALL").prop("checked",$(this).prop("checked"));
		$("#"+idDiv+"_IPALL").prop("checked",$(this).prop("checked"));
	});
	
	function bCkAll(b){
		if(b){
			var mnCk = true;
			var ipCk = true;
		    $("#"+idDiv+"_Box > div").each(function(i){
				if(i<gDevice.loginRsp.AnalogChNum){
					if($(this).css("background-color").replace(/\s/g, "")!=color.replace(/\s/g, "")){
						mnCk = false;
					}
				}else if(i>=gDevice.loginRsp.AnalogChNum && i<cnNum){
					if($(this).css("background-color").replace(/\s/g, "")!=color.replace(/\s/g, "")){
						ipCk = false;
					}
				}
			});

			$("#"+idDiv+"_AnaALL").prop("checked",mnCk);
			$("#"+idDiv+"_IPALL").prop("checked",ipCk);
			$("#"+chAllId).prop("checked",mnCk && ipCk);
		}else{
			var bAll=true;
			$("#"+idDiv+"_Box > div").each(function(i) {
				if(i<cnNum){
					if($(this).css("background-color").replace(/\s/g, "")!=color.replace(/\s/g, "")){
						bAll = false;
					}
				}
            });
			$("#"+chAllId).prop("checked",bAll);
		}
	}
}

//Is there a device support into the page
function IsShowPage(name){
	if(gDevice.devType == devTypeEnum.DEV_IPC){
		return 1;
	}
	
	if(name == "chn_live"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i))	
				if(((gDevice.devState[i].Abilities>>AbilityTypeEnum.OSD) & 1) == 1){
					return 1;
				}
		}
		return 0;
	}else if(name == "chn_sp"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i))	
				if(((gDevice.devState[i].Abilities>>AbilityTypeEnum.COVER) & 1) == 1){
					return 1;
				}
		}
		return 0;
	}else if(name == "main_stream_set"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i) || (gVar.bC0_0305_3120101 && gDevice.isSleep(i))){	
				if((((gDevice.devState[i].Abilities>>AbilityTypeEnum.MAINSTREAM) & 1) == 1 &&gDevice.devState[i].NewDevAbilityModeFlag != 1) ||(gDevice.devState[i].NewDevAbilityModeFlag == 1&&((gDevice.devState[i].Abilities>>AbilityTypeEnum.NOSUPMAINSTREAMPARAM) & 1) == 0)){
					return 1;
				}
			}
		}
		return 0;
	}else if(name == "substream" || name == "sub_stream_set"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i))	
				if((((gDevice.devState[i].Abilities>>AbilityTypeEnum.SUBSTREAM) & 1) == 1&&gDevice.devState[i].NewDevAbilityModeFlag != 1) || (gDevice.devState[i].NewDevAbilityModeFlag == 1&&((gDevice.devState[i].Abilities>>AbilityTypeEnum.NOSUPSUBSTREAMPARAM) & 1) == 0)){
					return 1;
				}
		}
		return 0;
	}else if(name == "mobistream" || name == "mobile_stream_set"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i))	
				if((((gDevice.devState[i].Abilities>>AbilityTypeEnum.SNAPSTREAM) & 1) == 1&&gDevice.devState[i].NewDevAbilityModeFlag != 1) || (gDevice.devState[i].NewDevAbilityModeFlag == 1&&((gDevice.devState[i].Abilities>>AbilityTypeEnum.NOSUPMOBILESTREAMPARAM) & 1) == 0)){
					return 1;
				}
		}
		return 0;
	}else if(name == "chn_yt"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(/*gDevice.isOnline(i)*/1)	
				if(/*((gDevice.devState[i].Abilities>>10) & 1) == 1*/1){
					return 1;
				}
		}
		return 0;
	}else if(name == "alarm_mv"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i) || gDevice.isSleep(i))	
				if((gDevice.devState[i].Abilities>>AbilityTypeEnum.MOTIONSET) & 1){
					return 1;
				}
		}
		return 0;
	}else if(name == "Img_Ctrl"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i))	
				if(gDevice.devState[i].Abilities>>AbilityTypeEnum.IMAGE&1){
					return 1;
				}
		}
		return 0;
	}else if(name == "Capture_Set"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i)){
				return 1;
			}
		}
		return 0;
	}else if(name == "GoodsLost_Legacy"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i)){
				if(gDevice.devType == devTypeEnum.DEV_HDVR){
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT)){//switch
						return 1;
					}
				}else{
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT) && gDevice.hasIntelligentAbilities(i,PageIntelligentEnum.SOD)){
						return 1;
					}
				}
			}
		}
		return 0;
	}else if(name == "Perimeter_Line"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i)){
				if(gDevice.devType == devTypeEnum.DEV_HDVR){
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT)){//switch
						return 1;
					}
				}else{
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT) && gDevice.hasIntelligentAbilities(i,PageIntelligentEnum.LCD)){
						return 1;
					}
				}
			}
		}
		return 0;
	}else if(name == "Perimeter_Zone"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i)){
				if(gDevice.devType == devTypeEnum.DEV_HDVR){
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT)){//switch
						return 1;
					}
				}else{
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT) && gDevice.hasIntelligentAbilities(i,PageIntelligentEnum.PID)){
						return 1;
					}
				}
			}
		}
		return 0;
	}else if(name == "Human_Detection"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i)){
				if(gDevice.devType == devTypeEnum.DEV_HDVR){
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT)){//switch
						return 1;
					}
				}else{
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT) && gDevice.hasIntelligentAbilities(i,PageIntelligentEnum.PD)){
						return 1;
					}
				}
			}
		}
		return 0;
	}else if(name == "Face_Detection"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i)){
				if(gDevice.devType == devTypeEnum.DEV_HDVR){
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT)){//switch
						return 1;
					}
				}else{
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT) && gDevice.hasIntelligentAbilities(i,PageIntelligentEnum.FD)){
						return 1;
					}
				}
			}
		}
		return 0;
	}else if(name == "People_Cross_Counting"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i)){
				if(gDevice.devType == devTypeEnum.DEV_HDVR){
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT)){//switch
						return 1;
					}
				}else{
					if(gDevice.hasAbility(i,AbilityTypeEnum.INTELLIGENT) && gDevice.hasIntelligentAbilities(i,PageIntelligentEnum.CC)){
						return 1;
					}
				}
			}
		}
		return 0;
	}else if(name == "sysinf_smart"){//HDVR
        for (var i = gDevice.loginRsp.AnalogChNum; i<gDevice.loginRsp.ChannelNum; i++){
            if(gDevice.isOnline(i)){
                return 1;
            }
        }
        return 0;
    }else if(name == "alarm_pir"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i))	
				if((gDevice.devState[i].Abilities>>AbilityTypeEnum.PIR) & 1){
					return 1;
				}
		}
		return 0;
	}else if(name == "flood_lightmulchn"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i))	
				if((gDevice.devState[i].Abilities>>AbilityTypeEnum.WHITE_LIGHT) & 1){
					return 1;
				}
		}
		return 0;
	}else if(name == "AF_controls"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i))	
				if((gDevice.devState[i].Abilities>>AbilityTypeEnum.AFOCUS) & 1){
					return 1;
				}
		}
		return 0;
	}else if(name == "Alarm_ODSwitch"){
		for (var i=0; i<gDevice.loginRsp.ChannelNum; i++){
			if(gDevice.isOnline(i))	
				return 1;
		}
		return 0;
	}
	return 1; 

}

$.fn.extend({
	BtnDisable:function(){
		//disable status
		$(this).mouseover(function(){
			$(this).css({
				"cursor":"auto",
				"background-color": "#252525",
				"color":"#353535"
			});
		}).mouseout(function(){
			$(this).css({
				"cursor":"auto",
				"background-color": "#252525",
				"color":"#353535"
			});
		});
		$(this).mouseout();
	},
	
	BtnEnable:function(){
		//enable status
		$(this).mouseover(function(){
			$(this).css({
				"cursor":"pointer",
				"background-color": "#32A0E1",
				"color":"#353535"
			});
		}).mouseout(function(){
			$(this).css({
				"background-color": "#1e3b56",
				"color":"#e6ebf0"
			});
		});
		$(this).mouseout();
	}
});

function CheckPageControl(bit,val){
	return (((gDevice.loginRsp.PageControl>>bit) & 1) ==val);
}
function funPlaceholder(element) {

	var placeholder = '';

	if(element && !('placeholder' in document.createElement('input')) && (placeholder = element.getAttribute('placeholder'))) {

		var  idLabel = element.id;
		if(!idLabel) {
			idLabel = 'placeholder' + new Date().getTime();
			element.id = idLabel;
		}

		var eleLabel = document.createElement('label');
		eleLabel.htmlFor = idLabel;
		eleLabel.style.position = "absolute";
		//According to the actual text box size modify the margin value here

		eleLabel.style.margin = "2px 0 0 3px";
		eleLabel.style.top = "0";
		eleLabel.style.left = "35px";
		eleLabel.style.color = "graytext";
		eleLabel.style.cursor = "text";
		eleLabel.style.zIndex = 1000;

		element.parentNode.insertBefore(eleLabel, element);

		element.onfocus = function() {
			eleLabel.innerHTML = '';
		};

		element.onblur = function () {
			if(this.value === '') {
				eleLabel.innerHTML = placeholder;
			}
		};

		//Style initialization

		if (element.value === "") {
			eleLabel.innerHTML = placeholder;
		}
	}
}

function rmLabelPlaceholder() {
	if(!('placeholder' in document.createElement('input'))) {
		$('.login_box').each(function () {
			$(this).find('label').remove();
		})
	}
}

//To determine whether a browser supports SVG
function hasSVG(){  
    if(typeof bSvgUsed == "undefined"){
		var SVG_NS = 'http://www.w3.org/2000/svg'; 
		bSvgUsed =  !!document.createElementNS && !!document.createElementNS(SVG_NS, 'svg').createSVGRect;
        return bSvgUsed;
	}else{
		return bSvgUsed;
	}
}  

//What channel according to the transfer, the ipc to get the channel
function getIpcCh(chValue){
	var i=0,chnNum=gDevice.loginRsp.ChannelNum, result=0;
	for(i=0;i<chnNum;i++){
		if(chValue & (1<<i)){
			result = i;
			break;
		}
	}
	return result;
}

function getFishEyeHardChNumByMode(fishMode)
{
	switch(fishMode){
		case fishEyeDisplayMode_hard.FishEye_1:
		case fishEyeDisplayMode_hard.Panoramic_180:
		    return 1;
			
		case fishEyeDisplayMode_hard.Partition_PTZ4:	
		case fishEyeDisplayMode_hard.FishEye_PTZ3:
		    return 4;
			
		default:
		    return 1;
	}
}

function getFpsZone(fps){
	var fpsZone = 0;
	if(fps>23){
		fpsZone = 7;
	}else if(fps>19){
		fpsZone = 6;
	}else if(fps>15){
		fpsZone = 5;
	}else if(fps>11){
		fpsZone = 4;
	}else if(fps>8){
		fpsZone = 3;
	}else if(fps>5){
		fpsZone = 2;
	}else if(fps>3){
		fpsZone = 1;
	}
	return fpsZone;
}

function checkPsdLUNS(valStr){//Lowercase,Uppercase,Number,Sequen------more than 2 kinds
    var str = valStr;
	var numberRegEx = /[0-9]+/g;
	var lowerCaseRegEx = /[a-z]+/g;
	var upperCaseRegEx = /[A-Z]+/g;
	var sequenRegEx = /[`~!@#$%^&*()_+<>?:"{},.\/;'[\]]/g;
	var Lkinds = 0;
	
	if(numberRegEx.test(str)){
		Lkinds +=1;
	}
	
	if(lowerCaseRegEx.test(str)){
		Lkinds +=1;
	}
	
	if(upperCaseRegEx.test(str)){
		Lkinds +=1;
	}
	
	if(sequenRegEx.test(str)){
		Lkinds +=1;
	}
	
	if(Lkinds > 1){
		return true;
	}
	
	return false;
}

function supportCSS3(style){  
	var prefix = ['webkit','ms','o','moz'];  
	var i;  
	var htmlStyle = document.documentElement.style;  
	var testStyle = [];  
	var upper = function (string){  
		return string.replace(/-(\w)/g,function($0,$1)  
		{  
			return $1.toUpperCase();  
		});  
	};  
	var str;  
	for(i in prefix){  
		str = upper(prefix[i]+'-'+style);  
		testStyle.push(str);  
	}  
	str = upper(style);  
	testStyle.push(str);  
	for(i in testStyle){  
		if(testStyle[i] in htmlStyle)  
			return true;  
	}  
	return false;  
} 

function setLigerGridSize(objId,parentDivV){
	var objWidth = 0;
	var parentDivW = 0;
	var result = {};
	var borderNum = 0;
	
	if($.browser.safari || $.browser.chrome) { borderNum = 1; }
	
	$("#"+objId+" .l-grid2 .l-grid-header-table .l-grid-hd-cell").each(function(){
		var $temp = $(this);
		if($temp.css("display") != "none"){
			objWidth = objWidth+parseInt($temp.css("width"));
		}
		borderNum++;
		$temp = null;
	});
	
	objWidth = objWidth+borderNum;//border
	
	parentDivW = $(parentDivV).width()*1;
	
	if(objWidth > parentDivW-50){
		objWidth = parentDivW-50;		
	}
	result = objWidth;
	return result;
}

function isIPv4(ip) {
	var reExp = /^0*(\d+\.)0*(\d+\.)0*(\d+\.)0*(\d+)$/;
  var reg = /^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$/
	ip = ip.replace(reExp, '$1$2$3$4');
  return reg.test(ip);
}

function canvasSupport() {
	try {
		document.createElement("canvas").getContext("2d");
		return true;
	} catch (e) {
		return false;
	} 
}

function getCtmArr(){
	var customersArr = new Array(300);
	for (var i = 0; i < customersArr.length; i++) {
		customersArr[i] = i;
	}
    return customersArr;
}

function getDDNSArr(n){
	var ddnsArr = [];
	ddnsArr = gDevice.GetDDNSArr(n);
	if(ddnsArr["Code"] == errCodeEnum.Code_Success){
		return ddnsArr["retData"];
	}else{
		return [];
	}
	
}

function getC_info(n){
	var arr = [];
	arr = gDevice.GetCInfoArr();
	if(arr["Code"] == errCodeEnum.Code_Success){
		return arr["retData"][n];
	}else{
		return "";
	}
}