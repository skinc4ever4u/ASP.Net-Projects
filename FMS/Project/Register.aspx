<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="shortcut icon"
       href="img/pix.png"/>
<style type="text/css"></style>
<link href="img/style.css" rel="stylesheet" type="text/css" />
<title>Register User</title>

<!--
<script runat="server">
void OnLoginError(object sender, EventArgs e)
{
    FormsAuthentication.RedirectToLoginPage();
}
</script> -->
<!--
<script type="text/javascript">
    function disableBackButton() {
        window.history.forward(-1);
    }
    setTimeout("disableBackButton()", 0);
</script> -->


 <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
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
        <!--
        input
        {
            width: 200px;
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
        .style1
        {
            height: 30px;
        }
        
        .style2
        {
            width: 255px;
        }
        
        .style3
        {
            height: 36px;
        }
        .style4
        {
            width: 255px;
            height: 36px;
        }
        .style5
        {
            height: 26px;
        }
        
    </style>
     -->

   
</head>

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
    <form id="form1" runat="server">

    
<div class="wrapper"> 
<div class="top-shadow">
  <div class="top">
   <div class="logo"><img src="img/FMS.png" width="409" height="66" alt="FMS" /> </div>
   <div class="top_right"> <img src="img/clients_icon.png" width="75" height="66" alt="client" /></div>
  </div>
   
   <div class="menu_header">
   
   <div class="menu_left"> <asp:HyperLink ID="Home" runat="server" NavigateUrl="~/Default.aspx" Visible="true">Home</asp:HyperLink></div>
   
   <div class="line"></div>
   <div class="menu_left"> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Search.aspx">File Search</asp:HyperLink></div>

   <div class="line"></div>
   <div class="menu_left"> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/File_Upload.aspx">File Upload</asp:HyperLink></div>

   <div class="line"></div>
   <div class="menu_left"> <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Add_Company.aspx">Add Company</asp:HyperLink></div>   

   <div class="line"></div>
   <div class="menu_left"> <asp:HyperLink ID="Delete" runat="server" NavigateUrl="~/File_Delete.aspx" > File Delete</asp:HyperLink></div>
   
   
   <div class="menu_right">Welcome Admin <asp:LoginName ID="LoginName2" runat="server" Font-Bold="true" />&nbsp;&nbsp;&nbsp;<asp:LoginStatus ID="LoginStatus2" runat="server" onloggingout="LoginStatus1_LoggingOut" /></div>
   
   </div>
   </div>
  <div class="middle_Shadow">
  <div class="middle_body">   
    <center> Register User </center> 
    <br />
    <center>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th colspan="3" class="style5">
                Registration
            </th>
        </tr>
        <tr>
            <td>
                Username
            </td>
            <td class="style2">
                <asp:TextBox ID="txtUsername" runat="server" style="margin-right: 53px" 
                    Width="222px" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td class="style2">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" 
                    style="margin-right: 53px" 
                    Width="222px" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Confirm Password
            </td>
            <td class="style2">
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" 
                    style="margin-right: 53px" 
                    Width="222px" />
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td class="style2">
                <asp:TextBox ID="txtEmail" runat="server" style="margin-right: 53px" 
                    Width="222px" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
            </td>
        </tr>
        <tr>
        <td>
                Role :
            </td>
            <td>
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="name"  Text="User"  Checked="true" /> &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="name" style="vertical-align:middle" Text="Head"/>
                
            </td>
            <td class="style1">
            
            </td>
        </tr>
        <tr>
            <td class="style3">
            </td>
            <td class="style4">
                <asp:Button ID="Button1" Text="Submit" runat="server" OnClick="RegisterUser" />
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
        <td>
        Status :
        </td>
        <td colspan="2">
        
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
        </td>
        </tr>
    </table>
    
            </center>
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
