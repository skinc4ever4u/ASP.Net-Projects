<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="shortcut icon"
       href="img/pix.png"/>
<style type="text/css"></style>
<link href="img/style.css" rel="stylesheet" type="text/css" />
<title>Search Files</title>

<!--
<script type="text/javascript">
    function disableBackButton() {
        window.history.forward(-1);
    }
    setTimeout("disableBackButton()", 0);
</script> 
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

   
   <asp:Label ID="LUpload" runat="server" CssClass="line" Visible="false"></asp:Label>
   <div class="menu_left"> <asp:HyperLink ID="Upload" runat="server" NavigateUrl="~/File_Upload.aspx" Visible="false">File Upload</asp:HyperLink></div>

   <asp:Label ID="LCompany" runat="server" CssClass="line" Visible="false"></asp:Label>
   <div class="menu_left"> <asp:HyperLink ID="Company" runat="server" NavigateUrl="~/Add_Company.aspx" Visible="false">Add Company</asp:HyperLink></div>

   <asp:Label ID="LRegister" runat="server" CssClass="line" Visible="false"></asp:Label>
   <div class="menu_left"> <asp:HyperLink ID="Register" runat="server" NavigateUrl="~/Register.aspx" Visible="false"> Add User</asp:HyperLink></div>

   <asp:Label ID="LFDelete" runat="server" CssClass="line" Visible="false"></asp:Label>
   <div class="menu_left"> <asp:HyperLink ID="Delete" runat="server" NavigateUrl="~/File_Delete.aspx" Visible="false"> File Delete</asp:HyperLink></div>
   
   <div class="menu_right"><asp:Label ID="Label2" runat="server" Text="Welcome User" Visible="false"></asp:Label><asp:Label ID="Label3" runat="server" Text="Welcome Head" Visible="false"></asp:Label><asp:Label ID="Label4" runat="server" Text="Welcome Admin" Visible="false"></asp:Label> <asp:LoginName ID="LoginName2" runat="server" Font-Bold="true" />&nbsp;&nbsp;&nbsp;<asp:LoginStatus ID="LoginStatus2" runat="server" onloggingout="LoginStatus1_LoggingOut" /></div>
   
   </div>
   </div>
  <div class="middle_Shadow">
  <div class="middle_body">   
    <div class="menu_left">
    <table>
    <tr>
    <td colspan="2">
    <u><b>Search By User</b></u>
    </td>
    </tr>
    <tr>
    <td>
    User Name :
    </td>
    <td>
    <asp:DropDownList ID="DropDownList1" runat="server" Width="123px" Height="16px">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    Module :
    </td>
    <td>
        <asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
            <asp:ListItem>D</asp:ListItem>
            <asp:ListItem>E</asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    </td>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Search" onclick="Button1_Click" />
    </td>
    </tr>
    </table>
    </div>
    <div class="menu_left">
    <table>
    <tr>
    <td colspan="2">
    <u><b>Search By Company</b></u>
    </td>
    </tr>
    <tr>
    <td>
    Company Name :
    </td>
    <td>
    <asp:DropDownList ID="DropDownList2" runat="server" Width="123px" Height="16px">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    Module :
    </td>
    <td>
        <asp:DropDownList ID="DropDownList4" runat="server">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
            <asp:ListItem>D</asp:ListItem>
            <asp:ListItem>E</asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    </td>
    <td>
        <asp:Button ID="Button2" runat="server" Text="Search" onclick="Button2_Click" />
    </td>
    </tr>
    </table>

    </div>
    <div class="menu_left">
    <table>
    <tr>
    <td colspan="2">
    <u><b>Search by year</b></u>
    </td>
    </tr>
    <tr>
    <td>
    Year
    </td>
    <td>
        <asp:DropDownList ID="DropDownList5" runat="server">
        </asp:DropDownList>    
    </td>
    </tr>
    <tr>
    <td>
    </td>
    <td>
        <asp:Button ID="Button3" runat="server" Text="Search" onclick="Button3_Click" />
    </td>
    </tr>
    </table>
    </div>
    <br/>
    <div>
    
    <center> Uploaded Files </center> 
    <br />
    <center>
            <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="FileId">
    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
    <Columns>
    <asp:BoundField DataField="FileId" HeaderText="File ID" />
    <asp:BoundField DataField="Username" HeaderText="User Name" />
    <asp:BoundField DataField="Company_Name" HeaderText="Company Name" />
    <asp:BoundField DataField="Module" HeaderText="Module" />
    <asp:BoundField DataField="CreatedDate" HeaderText="Date YYYY-MM-DD" />
    <asp:BoundField DataField="File_Description" HeaderText="Description" />
    <asp:BoundField DataField="File_Type" HeaderText="File Type" />
    <asp:TemplateField HeaderText="File Download">
    <ItemTemplate><asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click">
    </asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    
            </center>
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
