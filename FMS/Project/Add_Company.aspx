<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_Company.aspx.cs" Inherits="Add_Company" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="shortcut icon"
       href="img/pix.png"/>
<style type="text/css"></style>
<link href="img/style.css" rel="stylesheet" type="text/css" />
<title>Register Company</title>

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
    </style>

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
   
   <asp:Label ID="LSearch" runat="server" CssClass="line" Visible="true"></asp:Label>
   <div class="menu_left"> <asp:HyperLink ID="Search" runat="server" NavigateUrl="~/Search.aspx" Visible="true">File Search</asp:HyperLink></div>

   <asp:Label ID="LUpload" runat="server" CssClass="line" Visible="true"></asp:Label>
   <div class="menu_left"> <asp:HyperLink ID="Upload" runat="server" NavigateUrl="~/File_Upload.aspx" Visible="true">File Upload</asp:HyperLink></div>

   <asp:Label ID="LRegister" runat="server" CssClass="line" Visible="false"></asp:Label>
   <div class="menu_left"> <asp:HyperLink ID="Register" runat="server" NavigateUrl="~/Register.aspx" Visible="false"> Add User</asp:HyperLink></div>

   <asp:Label ID="LFDelete" runat="server" CssClass="line" Visible="false"></asp:Label>
   <div class="menu_left"> <asp:HyperLink ID="Delete" runat="server" NavigateUrl="~/File_Delete.aspx" Visible="false"> File Delete</asp:HyperLink></div>

   <div class="menu_right"><asp:Label ID="Label3" runat="server" Text="Welcome Head" Visible="false"></asp:Label><asp:Label ID="Label4" runat="server" Text="Welcome Admin" Visible="false"></asp:Label> <asp:LoginName ID="LoginName2" runat="server" Font-Bold="true" />&nbsp;&nbsp;&nbsp;<asp:LoginStatus ID="LoginStatus2" runat="server" onloggingout="LoginStatus1_LoggingOut" /></div>
   
   </div>
  </div>
  <div class="middle_Shadow">
  <div class="middle_body">   
  <center>
    <table>
    <tr>
    <td colspan="3" align="center">
    Add Company Details 
    </td>
    </tr>
    <tr>
    <td>
    Company name : 
    </td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
    </td>
    </tr>
     <tr>
    <td>
    Company Address : 
    </td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
    </td>
    </tr>
     <tr>
    <td>
    Company Description : 
    </td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td></td>
    <td align="center">
        <asp:Button ID="Button1" runat="server" Text="Register" 
            onclick="Button1_Click" /></td>
    <td></td>
    </tr>
    <tr>
    <td> Status :</td>
    <td colspan="2">
        <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Red" Visible="false"></asp:Label></td>
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
