<%@ Page Title="صفحة ادارة النظام" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminLogin.aspx.cs" Inherits="_Default" %>
<%@ register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
    <asp:Button ID="btnHomePage" runat=server CssClass="mainMenuButton"  Text="الرئيسية" PostBackUrl="~/index.aspx"/><asp:Button ID="btnContactUs" runat=server CssClass="mainMenuButton"  Text="اتصل بنا" PostBackUrl="~/contact.aspx"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<br /><br /><br />
<div align="center">
<div  id="blueLoginPanel" >
    <asp:Table ID="tblAdminLoginControls" runat="server" align="rtl"   Width="250px"  >
      <asp:TableRow>
        <asp:TableCell>
            <asp:Login ID="Login" runat="server"    OnAuthenticate="btnLogin_Click" RememberMeText="تذكرني في المرة القادمة" UserNameLabelText="اسم المستخدم" PasswordLabelText="كلمة المرور" TitleText="  ">
            </asp:Login>
        </asp:TableCell>
    </asp:TableRow>
    </asp:Table>
</div>
</div>
</asp:Content>

