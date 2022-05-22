<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="getpassword.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" runat="Server">
    <asp:Button ID="btnHomePage" runat=server CssClass="mainMenuButton"  Text="الرئيسية" PostBackUrl="~/index.aspx"/>
                <asp:Button ID="btnContactUs" runat=server CssClass="mainMenuButton"  Text="اتصل بنا" PostBackUrl="~/contact.aspx"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">

    <script type="text/javascript">
        function ReqField1Validator() {
                document.getElementById('<%=UserNameTextBox.ClientID%>').value = '';
                document.getElementById('<%=EmailTextBox.ClientID%>').value = '';
                document.getElementById('<%=UserNameTextBox.ClientID%>').disabled = false
                document.getElementById('<%=EmailTextBox.ClientID%>').disabled = true
            }
            function ReqField2Validator() {
                document.getElementById('<%=UserNameTextBox.ClientID%>').value = '';
                document.getElementById('<%=EmailTextBox.ClientID%>').value = '';
                document.getElementById('<%=UserNameTextBox.ClientID%>').disabled = true
                document.getElementById('<%=EmailTextBox.ClientID%>').disabled = false
            }

            function ReqField3Validator() {
                if (document.getElementById('<%=UserNameTextBox.ClientID%>').value == '' && document.getElementById('<%=EmailTextBox.ClientID%>').value == '')
                {
                    alert('.الرجاء ادخال اسم المستخدم أو كلمة المرور')
                    return false;
                }

            } 
            
            
    </script>

    <asp:Table ID="Table1" runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell Font-Size="Medium">
            <b>لا استطيع استخدام حسابي</b>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Font-Size="10">
        اذا كنت تواجه مشكلة في الدخول الى حسابك في نظام التسجيل، الرجاء اتباع التعليمات الآتية:

            <br /><br />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            <hr />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Font-Size="10">
                <asp:RadioButton ID="ForgotMyPWD" GroupName="g1" Font-Size="10" Text="لقد نسيت كلمة المرور الخاصة بي "
                    runat="server" />
                <br />
                <br />
                لإسترجاع كلمة المرور الخاص بحسابك اتبع الخطوات الآتية:<br />
                <br />
                1- ادخل اسم المستخدم الخاص بك.<br />
                2- اضغط على زر "اعتمد".<br />
                <br />
                <asp:Label ID="lblUserName" Width="100" Text="اسم المستخدم:" runat="server"></asp:Label>
                <asp:TextBox ID="UserNameTextBox" Enabled="false" runat="server" Width="150"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            <hr />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Font-Size="10">
                <asp:RadioButton ID="ForgotUID" GroupName="g1" Font-Size="10" Text="لقد نسيت اسم المستخدم الخاص بي"
                    runat="server" />
                <br />
                <br />
                اذا كنت قد نسيت اسم المستخدم الخاص بك فاتبع الخطوات الآتية:
                <br />
                <br />
                1- ادخل البريد الإلكتروني الخاص بك .<br />
                2- اضغط على زر "اعتمد".<br />
                <br />
                سيتم ارسال اسم المستخدم الخاص بك إلى البريد الإلكتروني الذي حددته
                <br />
                <br />
                <asp:Label Width="100" Text="البريد الإلكتروني:" runat="server"></asp:Label>
                <asp:TextBox ID="EmailTextBox" runat="server" Width="150"  Enabled="false"></asp:TextBox>
                <asp:RegularExpressionValidator ID="EmailExpressionValidator" Font-Bold="true" Font-Size="12"
                    ControlToValidate="EmailTextBox" ErrorMessage="البريد الإلكتروني المدخل غير مقبول الرجاء التأكد من صحته"
                    runat="server" Font-Names="Simplified Arabic" ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$">
                </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            <hr />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button Text="أرسل" ID="SubmitButton" runat="server" OnClick="GetPassUID" CssClass="button" />
                <asp:Label runat="server" ID="InfoLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
