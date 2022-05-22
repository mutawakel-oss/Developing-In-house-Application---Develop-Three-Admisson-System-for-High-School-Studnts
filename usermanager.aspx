<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="usermanager.aspx.cs" Inherits="UserManagerClass" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" runat="Server">
    <asp:Button ID="btnHomePage" runat=server CssClass="mainMenuButton"  Text="الرئيسية" PostBackUrl="~/admin_default_page.aspx" CausesValidation="false"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Table runat="server" ID="InformationTable" Width="90%">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server" ID="InformationLabel1" >                            
                        </asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table runat="server" ID="ldapTable" Width="400px">
                <asp:TableRow>
                    <asp:TableCell ID="TableCell1" runat="server" Text="اسم المستخدم:"></asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="UserSearchTextBox" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="SearchButton" runat="server" Text="ابحث" OnClick="SearchLdapUsers" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3">
                        <asp:RequiredFieldValidator runat="server" ID="SearchTextRequired" ControlToValidate="UserSearchTextBox"
                            ErrorMessage="Specify the search criteria">
                        </asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
               
            </asp:Table>
            <div id="Layer1" style="position:relative ; width: 100%; height: 250px; overflow: scroll;">
                <asp:UpdateProgress runat="server" ID="Progress1">
                            <ProgressTemplate>
                                <asp:Label ID="Label1" BackColor="Green" runat="server" ForeColor="White" Text="Please wait..."></asp:Label>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                <asp:GridView HeaderStyle-Height="25" ID="GridView1" AutoGenerateColumns="false"
                    runat="server" Width="90%">
                    <Columns>
                        <asp:TemplateField HeaderText="الإسم">
                            <ItemTemplate>
                                <asp:CheckBox Enabled='<%#Eval("Exist") %>' runat="server" ID="chkReportViewer" Text='<%# Eval("UserName") %>' />
                                <asp:Label ID="HIDDEN_USER_NAME" Text='<%# Eval("LoginName") %>' runat="server" Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم الدخول">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="LoginName" Text='<%# Eval("LoginName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الإمتيازات">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="CurrentRole" Text='<%# Eval("CurrentRoles") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ادرج">
                            <ItemTemplate>
                                <asp:LinkButton  ToolTip='<%#Eval("LoginName") + "-"+ Eval("UserName")%>'
                                   OnClick="ClickLink" ID="btnViewDetails"
                                    runat="server" Text="تحرير" CommandName="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Panel ID="pnlPopup" runat="server" Height="300px" Width="500px" Style="display: none;
                background-color: White" CssClass="modalPopup">              
                        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                        <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
                            PopupControlID="pnlPopup" DropShadow="true" CancelControlID="btnClose" BackgroundCssClass="modalBackground" />
                        <%-- some checkbox for setting the roles--%>
                        <asp:Table ID="UserDataTable" runat="server" Width="500px" CellPadding="0" CellSpacing="0">
                            <asp:TableRow BackColor="LightGray" Height="20">
                                <asp:TableCell>اسم المستخدم</asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="UserNameLabel" Font-Bold="true" runat="Server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                        <hr />
                                </asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                اختر الكليات المرغوب ادراج امتيازاتها للمستخدم، يمكنك اختيار اكثر من كلية
                                </asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:CheckBoxList ID="CollegeNameCheckList" runat="Server" RepeatDirection="Vertical">
                                    </asp:CheckBoxList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                        <hr />
                                </asp:TableCell>
                            </asp:TableRow>
                            
                             <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                اختر الإمتيازات المرغوب ادراجها للمستخدم
                                </asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:CheckBoxList ID="RoleNameCheckList" runat="Server" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <div>
                           
                            <asp:LinkButton ID="btnSave" OnClick="SaveRights" runat="server" Text="ادرج" CausesValidation="true" />
                            <asp:LinkButton ID="btnClose" runat="server" Text="الغي" CausesValidation="false" />
                        </div>
                 
            </asp:Panel>
            <br />
            <asp:Button ID="SaveButton" OnClick="SaveClick" Text="ادرج" runat="server" />
            &nbsp;&nbsp;
            <asp:Button ID="CancelButton" Text="الغي" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
