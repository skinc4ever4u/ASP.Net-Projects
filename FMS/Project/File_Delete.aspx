<%@ Page Language="C#" AutoEventWireup="true" CodeFile="File_Delete.aspx.cs" Inherits="File_Delete" %>

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
        input
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
   <div class="menu_left"> <asp:HyperLink ID="Register" runat="server" NavigateUrl="~/Register.aspx"> Add User</asp:HyperLink></div>
   
   <div class="menu_right">Welcome Admin <asp:LoginName ID="LoginName2" runat="server" Font-Bold="true" />&nbsp;&nbsp;&nbsp;<asp:LoginStatus ID="LoginStatus2" runat="server" onloggingout="LoginStatus1_LoggingOut" /></div>
   
   </div>
   </div>
  <div class="middle_Shadow">
  <div class="middle_body">   

  <table>
  <tr>
  <td>
  File Id:
  </td>
  <td>
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      </td>
  </tr>
  <tr>
  <td colspan="2">
  <asp:Button ID="Button1" runat="server" Text="File Search" onclick="Button1_Click" />
  </td>
  </tr>
  <tr>
  <td>
  Status :
  </td>
  <td>
      <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
  </td>
  </tr>
  
  </table>
  <br />
  <br />

  <center>
  <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="FileId">
    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
    <Columns>
    <asp:BoundField DataField="FileId" HeaderText="File ID" />
    <asp:BoundField DataField="Username" HeaderText="User Name" />
    <asp:BoundField DataField="Company_Name" HeaderText="Company Name" />
    <asp:BoundField DataField="Module" HeaderText="Module" />
    <asp:BoundField DataField="CreatedDate" HeaderText="Date" />
    <asp:BoundField DataField="File_Description" HeaderText="Description" />
    <asp:BoundField DataField="File_Type" HeaderText="File Type" />
    <asp:TemplateField HeaderText="File Download">
    <ItemTemplate><asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click">
    </asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="File Delete">
    <ItemTemplate><asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClick="lnkDelete_Click">
    </asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
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

