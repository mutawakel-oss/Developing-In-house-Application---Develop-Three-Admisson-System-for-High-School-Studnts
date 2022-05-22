<%@ Page Title="صفحة المساعدة" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true"   CodeFile="contact.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" runat="Server">
    <asp:Button ID="btnHomePage" runat="server" CssClass="mainMenuButton" Text="الرئيسية"
        PostBackUrl="~/index.aspx" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <font color="red" size="4" style="font-family: Traditional Arabic"><b><span style="font-size: xx-large;
        text-align: center"></span>عزيزي المتقدم/المتقدمة، إذا كنت تواجه أي صعوبة أثناء
        استخدامك للنظام، الرجاء تعبئة نموذج طلب المساعدة التالي وستتصل بك عمادة القبول والتسجيل
        خلال الأربع والعشرين ساعة القادمة</b></font>
    <asp:Table ID="tblContactDetails" runat="server" align="rtl">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblApplicantName" runat="server" Text="اسم المتقدم/المتقدمة"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtApplicantName" Width="200px" runat="server" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameVlidator" runat="server" ControlToValidate="txtApplicantName"
                    ErrorMessage="*" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblID" runat="server" Text="رقم بطاقة الأحوال "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtStudID" Width="200px" runat="server" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="IDValidator" runat="server" ControlToValidate="txtStudID"
                    ErrorMessage="*" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="IDExpressionValidator" ControlToValidate="txtStudID"
                    ErrorMessage="رقم بطاقة الأحوال المدخل غير مقبول الرجاء التأكد من صحته" runat="server"
                    ValidationExpression="\d{10}" ValidationGroup="contactGroup"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblMobileNo" runat="server" Text="رقم الجوال"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtMobile" Width="159px" runat="server" MaxLength="8" ></asp:TextBox>
                <asp:DropDownList ID="ddlMobilePrefix" runat="server">
                    <asp:ListItem Text="05" Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="mobileValidator" runat="server" ControlToValidate="txtMobile"
                    ErrorMessage="*" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="mobileExpressionValidator" ControlToValidate="txtMobile"
                    ErrorMessage=" رقم الجوال المدخل غير مقبول الرجاء التأكد من صحته" runat="server"
                    ValidationExpression="\d{8}" ValidationGroup="contactGroup"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblHomePhone" runat="server" Text="رقم الهاتف"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtHomePhone" runat="server" MaxLength="7" Width="159px"></asp:TextBox>
                <asp:DropDownList ID="ddlCitZip" runat="server">
                    <asp:ListItem Text="01"></asp:ListItem>
                    <asp:ListItem Text="02"></asp:ListItem>
                    <asp:ListItem Text="03"></asp:ListItem>
                    <asp:ListItem Text="04"></asp:ListItem>
                    <asp:ListItem Text="05"></asp:ListItem>
                    <asp:ListItem Text="06"></asp:ListItem>
                    <asp:ListItem Text="07"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="phoneValidator" runat="server" ControlToValidate="txtHomePhone"
                    ErrorMessage="*" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="phoneValidator1" ControlToValidate="txtHomePhone"
                    ErrorMessage=" رقم الهاتف المدخل غير مقبول الرجاء التأكد من صحته" runat="server"
                    ValidationExpression="\d{7}" ValidationGroup="contactGroup"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="100px">
                <asp:Label ID="lblEmail" runat="server" Text="البريد الإلكتروني"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEmail" Width="200px" runat="server" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="emailValidator" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="*" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="emailExpressionValidator" ControlToValidate="txtEmail"
                    ErrorMessage="البريد الإلكتروني المدخل غير مقبول الرجاء التأكد من صحته" runat="server"
                    ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                    ValidationGroup="contactGroup"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCollegeName" runat="server" Text="الكلية المرغوبة"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList Width="450px" ID="ddlCollegeName" runat="server">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblProblemCategory" runat="server" Text="نوع المشكلة"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlProblemCateogry" Width="450px" runat="server">
                    <asp:ListItem Text="أواجه مشكلة في استخدام النظام"></asp:ListItem>
                    <asp:ListItem Text="لا أواجه مشكلة في استخدام النظام ولكني اواجة مشكلة أخرى"></asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell VerticalAlign=Top>
                <asp:Label ID="lblDescription"  runat="server" Text="تفاصيل المشكلة"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Height="150" Width="450px"
                    MaxLength="500"></asp:TextBox>
                <asp:RequiredFieldValidator ID="descriptionValidator" runat="server" ControlToValidate="txtDetail"
                    ErrorMessage="*" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnSave" runat="server" Text="ارسال" CausesValidation="true" ValidationGroup="contactGroup"
                    CssClass="button" OnClick="btnSave_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnCancel" runat="server" Text="الغاء" CssClass="button"
                    OnClick="btnCancel_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
