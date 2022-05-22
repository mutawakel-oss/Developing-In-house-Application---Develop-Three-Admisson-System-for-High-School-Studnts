<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Report_admin.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
    <asp:Button ID="btnHomePage" runat=server CssClass="mainMenuButton"  Text="الرئيسية" PostBackUrl="~/index.aspx"/>
                
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    
    <center><h3>مبروك تمت عملية التسجيل بنجاح</h3></center>
    <asp:Table ID="tblMain" runat="server" Width="100%" BorderColor="Black" BorderWidth="1" BorderStyle="Inset" GridLines="Both">
    
    </asp:Table>
    <br /><br />
    <center>
        <input type="button" value="اغلاق" onclick="javascript:window.close()"> 
        <input type="button" value="طباعة" onclick="javascript:window.print()"/>
    </center>
</asp:Content>

