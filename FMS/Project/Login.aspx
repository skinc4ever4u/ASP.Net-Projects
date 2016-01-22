<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="shortcut icon"
       href="img/pix.png"/>
<style type="text/css"></style>
<link href="img/style.css" rel="stylesheet" type="text/css" />
<title>Login Page</title>
<!--
<script type="text/javascript">

    function getQueryStrings() {
        //Holds key:value pairs
        var queryStringColl = null;

        //Get querystring from url
        var requestUrl = window.location.search.toString();

        if (requestUrl != '') {
            //window.location.search returns the part of the URL 
            //that follows the ? symbol, including the ? symbol
            requestUrl = requestUrl.substring(1);

            queryStringColl = new Array();

            //Get key:value pairs from querystring
            var kvPairs = requestUrl.split('&');

            for (var i = 0; i < kvPairs.length; i++) {
                var kvPair = kvPairs[i].split('=');
                queryStringColl[kvPair[0]] = kvPair[1];
            }
        }

        return queryStringColl;
    }

    function myfunction() {
        var queryStringColl = getQueryStrings();

        if (queryStringColl != null) {
            //alert('no querystring found');
            disableBackButton();
            return;
        }

        //alert(queryStringColl['key1']);
    }

    function disableBackButton() {
        window.history.forward(-1);
    }
    //setTimeout("disableBackButton()", 0);
</script>
-->
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        input[type=text], input[type=password]
        {
            width: 200px;
        }
        table
        {
            border: 1px solid #ccc;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
    </style>
</head>

<!--
<script type="text/javascript" language="javascript">
    function disableBackButton() {
        window.history.forward()
    }
    disableBackButton();
    window.onload = disableBackButton();
    window.onpageshow = function (evt) { if (evt.persisted) disableBackButton() }
    window.onunload = function () { void (0) }  
</script>
-->
<!-- disabling right click on page
<body oncontextmenu="return false;">
-->
<script type="text/javascript" language="javascript">
    function DisableBackButton() {
        window.history.forward(-1)
    }
    DisableBackButton();
    window.onload = DisableBackButton;
    window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
    window.onunload = function () { void (0) }
</script>

<body>
<!--<body onload="myfunction()">-->
<!--<body onload="noBack();">-->
<!--<body onprerender="disableBackButton()" oninit="disableBackButton()" onload="disableBackButton()"> -->
    <form id="form1" runat="server">
    <div class="wrapper"> 
    <div class="top-shadow">
  <div class="top">
   <div class="logo"><img src="img/FMS.png" width="409" height="66" alt="FMS" /> </div>
   <div class="top_right"> <img src="img/clients_icon.png" width="75" height="66" alt="client" /></div>
  </div>
   
   <div class="menu_header">
   
   </div>
  </div>
  <div class="middle_Shadow">
  <div class="middle_body">   
    <div style="margin-top:100px;" align="center">
    <asp:Login ID="Login1" runat="server" OnAuthenticate="ValidateUser" 
            DisplayRememberMe="False">
    </asp:Login>
         </div>   
  </div> 
   </div>
   
   
   <div class="footer_shadow">
  <div class="footer">
    <div style="width:133px; float:left; padding-left:5px" align="center"><img src="img/pix.png" width="34" height="34" alt="Pixel Delta" />www.pixeldelta.com</div>
  <div style="width:159px; float:right; margin-top:22px">Powered By: <strong>Pixel delta</strong> </div> </div>
  
</div>
  </div>
    
 
    </form>
</body>
</html>
