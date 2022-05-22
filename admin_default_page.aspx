<%@ Page Title="صفحة ادارة النظام" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin_default_page.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
    <asp:button ID="lnkReport" runat="server" ToolTip="لعرض التقارير" CssClass="mainMenuButton" Text="عرض التقارير" Visible="false"  OnClick="mViwerReports"/><asp:button ID="lnkContacts" runat="server" ToolTip="لعرض استفسارات المتقدمين" CssClass="mainMenuButton" Text="عرض الإستفسارات" Visible="false" OnClick="mViweContact"/><asp:button ID="lnkUserPrivileges" runat="server" ToolTip="لتغيير امتيازات المستخدمين" CssClass="mainMenuButton" Text="اعدادات المستخدمين" Visible="false" OnClick="mViweUsersControl" Font-Size="9pt"/><asp:button ID="lnkSysConfig" runat="server" ToolTip="لتغيير اعدادات النظام" CssClass="mainMenuButton" Text="اعدادات النظام" Visible="false" OnClick="mViweConfig"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">

    <asp:Table ID="tblAdminPrivileges" runat="server" align="rtl" Width="100%"  Font-Size="Medium" >
        <asp:TableRow>
            <asp:TableCell>
            <div align="center">
                <asp:Label ID="lblSystemConfiguration" runat="server" Text="مرحباً بك في صفحة ادارة النظام." ForeColor="Red" Font-Size="Large"></asp:Label>
            <div align="center">                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell >
                <b>
                باستخدامك الأزرار الموجودة في القائمة العلوية تستطيع الآتي:
                </b>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell runat="server" ID="tdReport" Visible="false">
                <asp:Label ID="lblReportsViwer" runat="server" Text=" - زر 'عرض التقارير'يعطي امكانية عرض تقارير الطلاب المتقدمين."></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell runat="server" ID="tdContacts" Visible="false">
                <asp:Label ID="lblCcontactViwer" runat="server" Text=" - زر 'عرض الإستفسارات'يعطي امكانية عرض استفسارات الطلاب المتقدمين حول النظام."></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
             <asp:TableRow>
            <asp:TableCell runat="server" ID="tdSystemUsers" Visible="false">
                <asp:Label ID="Label1" runat="server" Text="- زر 'اعدادات المستخدمين' يعطي امكانية اظافة الإمتيازات لمدراء النظام."></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell runat="server" ID="tdSystemConfig" Visible="false">
                <asp:Label ID="lblSystemConfig" runat="server" Text=" - زر 'اعدادات النظام'يعطي امكانية التحكم في اعدادات النظام."></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
   
    </asp:Table>
</asp:Content>


    