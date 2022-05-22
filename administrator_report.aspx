<%@ Page Title="" Culture="ar-SA" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="administrator_report.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">

    <script type="text/javascript">
        function GetSelectedNames() {
            var grid = $find("<%=RadData.ClientID %>");
            var MasterTable = grid.get_masterTableView();
            var email_address;
            email_address = "";
            var selectedRows = MasterTable.get_selectedItems();
            for (var i = 0; i < selectedRows.length; i++) {
                var row = selectedRows[i];
                var cell = MasterTable.getCellByColumnUniqueName(row, "email_address")
                email_address = email_address + cell.innerHTML + ";";
            }
            if (email_address) {
                ShowEmailWindow(email_address);
            }
        }  

    </script>

    <script type="text/javascript">
        function ShowEmailWindow(email) {
            window.radopen("email_popup.aspx?email="+email, "StudentWindow");
            return false;
        }
    </script>

    <script type="text/javascript">
        function onRadWindowShow(sender, arg) {
            sender.maximize(true);
        }  
    </script>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow Skin="Outlook" ID="StudentWindow" Width="700px" Height="700px"  runat="server"
                 ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true" Behavior="Close">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <table width="100%">
        <tr >
            <td>
                <asp:RadioButton GroupName="TopGroup" Font-Size="11" Checked="true" ID="TopFromPoolRadioButton"
                    Text="قائمة الطلاب الفائقين" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton GroupName="TopGroup" Font-Size="11" ID="TopNewCandidatesRadioButton"
                    Text="قائمة الطلاب غير المدعوين للمقابلة الشخصية" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton GroupName="TopGroup" Font-Size="11" ID="TopInvitedCandidatesRadioButton"
                    Text="قائمة الطلاب المدعوين للمقابلة الشخصية" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList runat="server" Width="250px" ID="CollegeNameDropDown" Font-Size="Medium">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList runat="server" ID="CityList" Width="100px" Font-Size="Medium">
                </asp:DropDownList>
                <asp:Button runat="server" Text="Show Records" Font-Size="10" BackColor="LightGray"
                    BorderWidth="0" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Page Size :
                <asp:DropDownList AutoPostBack="true" runat="server" ID="cmbPage">
                    <asp:ListItem Text="100"></asp:ListItem>
                    <asp:ListItem Text="200"></asp:ListItem>
                    <asp:ListItem Text="300"></asp:ListItem>
                    <asp:ListItem Text="400"></asp:ListItem>
                    <asp:ListItem Text="500"></asp:ListItem>
                    <asp:ListItem Text="All"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;<asp:Button ID="PrintCommand" Text="Export to PDF" Enabled="true" runat="server"
                    OnClick="CreateReport" />
            </td>
        </tr>
        <tr>
            <td>
                <button onclick="return GetSelectedNames()" style="display:none">
                    Click</button>
                <asp:SqlDataSource ID="StudentSource" runat="server"></asp:SqlDataSource>
                <telerik:RadGrid StatusBarSettings-LoadingText="Please wait..." AllowMultiRowSelection="true"
                    ShowHeader="true" ShowFooter="true" ShowStatusBar="true" OnItemDataBound="RadGrid1_ItemCreated"
                    runat="server" Width="100%" ID="RadData" AutoGenerateColumns="false" AllowFilteringByColumn="false"
                    AllowPaging="true" AllowSorting="True">
                    <PagerStyle Mode="NextPrevAndNumeric" />
                    <GroupingSettings CaseSensitive="false" />
                    <ClientSettings EnableRowHoverStyle="true">
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView Font-Names="Tahoma" TableLayout="Auto" AllowCustomSorting="true">
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="Name" HeaderText="Full Name" DataField="Name"
                                HeaderTooltip="first name,father name,grand father name, lastname">
                                <ItemTemplate>
                                    <asp:HyperLink Target="_blank" ForeColor="Black" Font-Bold="false" Font-Size="10"
                                        ID="name_link" CausesValidation="false" ToolTip='<%# Eval("id") %>' Text='<%# Eval("Name") %>'
                                        runat="server"></asp:HyperLink>
                                    <asp:Label Visible="false" runat="server" ID="mod_y_n" Text='<%# Eval("marked_edited") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridNumericColumn AllowSorting="false" HeaderText="Local Id" DataField="local_id"
                                UniqueName="local_id" />
                            <telerik:GridTemplateColumn ItemStyle-BackColor="#EBF3FF" HeaderText="H.S Grade"
                                DataField="Name">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtGPApoint" runat="server" Text="35%" Width="50px" Visible="false"></asp:TextBox>
                                    <asp:Label ID="hschool_grade" Text='<%# Eval("highschool_grade") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn ItemStyle-BackColor="#EBF3FF" HeaderText="Godrat" DataField="Name">
                                <ItemTemplate>
                                    <asp:TextBox Visible="false" ID="txtGodaratPoint" Text="30%" runat="server" Width="50px"></asp:TextBox>
                                    <asp:Label ID="gudrat_grade" Text='<%# Eval("gudrat_grade") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn ItemStyle-BackColor="#EBF3FF" HeaderText="Tahseeli" DataField="Name">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtKnowPoint" runat="server" Visible="false" Width="50px" Text="35%"></asp:TextBox>
                                    <asp:Label ID="tahseeli_grade" Text='<%# Eval("tahseeli_grade") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridNumericColumn AllowSorting="true" HeaderText="Total" DataField="total_marks"
                                UniqueName="total_marks" SortExpression="total_marks" AutoPostBackOnFilter="true"
                                CurrentFilterFunction="equalto" ShowFilterIcon="false" />
                            <telerik:GridNumericColumn AllowSorting="false" HeaderText="Mobile" DataField="mobile"
                                UniqueName="mobile" SortExpression="mobile" AutoPostBackOnFilter="true" CurrentFilterFunction="equalto"
                                ShowFilterIcon="false" />
                            <telerik:GridNumericColumn AllowSorting="false" HeaderText="Home Phone" DataField="Home_phone"
                                UniqueName="Home_phone" SortExpression="Home_phone" AutoPostBackOnFilter="true"
                                CurrentFilterFunction="equalto" ShowFilterIcon="false" />
                            <telerik:GridNumericColumn AllowSorting="false" Aggregate="Count" HeaderText="Email Address"
                                DataField="email_address" UniqueName="email_address" SortExpression="email_address"
                                AutoPostBackOnFilter="true" CurrentFilterFunction="equalto" ShowFilterIcon="false" />
                            <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>
