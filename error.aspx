<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
    <asp:Button ID="btnHomePage" runat=server CssClass="mainMenuButton"  Text="الرئيسية" PostBackUrl="~/index.aspx"/>
    <asp:Button ID="btnContactUs" runat=server CssClass="mainMenuButton"  Text="اتصل بنا" PostBackUrl="~/contact.aspx"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div align="center" dir="rtl" style="font-family:Traditional Arabic;font-size:14pt;font-weight:bold" >
        <asp:Label ID="lblErrorText" runat="server" ></asp:Label> 
    </div>
</asp:Content>

