<%@ Page Title="صفحة التقارير" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="reportsection.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" runat="Server">
    <asp:Button ID="btnHomePage" runat="server" CssClass="mainMenuButton" Text="الرئيسية"
        PostBackUrl="~/admin_default_page.aspx" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    
    <asp:UpdatePanel ID="upd_main" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Table ID="OuterTable" runat="server" Width="100%">
                <asp:TableRow>
                    <asp:TableCell Font-Bold="true" Text="معايير البحث">
                    
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:LinkButton OnClick="ShowHideParam" Text="Hide Options" runat="server" ID="LinkParam"></asp:LinkButton>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                <hr />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="Row_1" runat="server">
                    <asp:TableCell ColumnSpan="2">
                        <asp:RadioButton GroupName="TopGroup" Checked="true" ID="TopFromPoolRadioButton"
                            Text="قائمة الطلاب الفائقين" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="Row_2" runat="server">
                    <asp:TableCell ColumnSpan="2">
                <hr />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="Row_3" runat="server">
                    <asp:TableCell ColumnSpan="2">
                        <asp:RadioButton GroupName="StatusGroup" ID="TopNewCandidatesRadioButton" Text="قائمة الطلاب غير المدعوين للمقابلة الشخصية"
                            Checked="true" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="Row_4" runat="server">
                    <asp:TableCell ColumnSpan="2">
                        <asp:RadioButton GroupName="StatusGroup" ID="TopInvitedCandidatesRadioButton" Text="قائمة الطلاب المدعوين للمقابلة الشخصية"
                            runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="Row_5" runat="server">
                    <asp:TableCell ColumnSpan="2">
                <hr />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="Row_6" runat="server">
                    <asp:TableCell Font-Bold="true" Text="عدد الطلاب">                
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Table ID="Table2" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:TextBox Text="*" Enabled="false" ID="TopTextBox" Width="50" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Req_TopTextBox" runat="server" ErrorMessage="*" ControlToValidate="TopTextBox"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                                <asp:TableCell Font-Bold="true" Text="&nbsp;&nbsp;اسم الكلية"></asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="CollegeNameDropDown" runat="server" Width="150">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Req_CollegeNameDropDown" runat="server" ErrorMessage="*"
                                        ControlToValidate="CollegeNameDropDown" InitialValue="اختر الكلية"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                                <asp:TableCell Visible="false" Font-Bold="true" Text="&nbsp;&nbsp;Program Name&nbsp;&nbsp;">
                                    <asp:DropDownList ID="ProgramNameDropDown" runat="server" Width="150">
                                    </asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell>
                                    
                                        
                                    <asp:Button ID="SearchButton" Text="..." runat="server" OnClick="SearchClick" />
                                    &nbsp;&nbsp;
                                    <asp:HyperLink   Visible=false Font-Bold="true" ID="HyperLink1" Text="Show Report"
                                        runat="server" Target="_blank"  />
                                 <%--   <asp:HyperLink Enabled="false" Font-Bold="true" ID="ShowGraph" Text="Show Graph"
                                        runat="server" Target="_blank" NavigateUrl="~/ShowGraph.aspx" />--%>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                <hr />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="datagrid" runat="server" Width="100%">
                <asp:TableRow>
                    <asp:TableCell>
                        Interview Details
                        <asp:TextBox ToolTip="Enter a venue " ID="VenueTextBox" runat="server" Width="150"></asp:TextBox>
                        &nbsp;
                        <asp:TextBox ToolTip="Enter a date " ID="InterviewDateTextBox" runat="server" Width="150"></asp:TextBox>
                        &nbsp;
                        <asp:TextBox ToolTip="Enter Interview Time" ID="InterviewTime" runat="server" Width="60"></asp:TextBox>
                        &nbsp;
                        <asp:Button OnClick="InviteSelectedStudents" runat="server" Enabled="false" ID="InviteButton_1"
                            Text="Invite" />
                        &nbsp;
                        <asp:Button ID="PrintCommand" Text="Export to PDF" Enabled="false" runat="server"
                            OnClick="PdfPrint" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" Font-Bold="true" ID="TotalCell" runat="server">
                        <asp:UpdateProgress ID="p1" runat="server">
                            <ProgressTemplate>
                                <asp:Label ID="Label1" BackColor="Green" runat="server" ForeColor="White" Text="Please wait..."></asp:Label>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                      <%--  <div style="overflow-y: scroll; ">
--%>
                        <asp:GridView HeaderStyle-BackColor="ActiveBorder" AlternatingRowStyle-BackColor="WhiteSmoke"
                            HeaderStyle-Height="25" ID="GridView1" AutoGenerateColumns="false" runat="server"
                            OnPageIndexChanging="GridView1_OnPageIndexChanged" PageSize="50"
                            PagerSettings-Position="TopAndBottom" AllowPaging="true" PagerSettings-PageButtonCount="50">
                            <Columns>
                                <%--<asp:TemplateField ItemStyle-BackColor="ActiveBorder" HeaderText="#" HeaderStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Index" Text='<%# Eval("Index") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderStyle-Width="200" HeaderStyle-Font-Names="Simplified Arabic"
                                    HeaderText="رقم بطاقة الأحوال">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="LocalID" Text='<%# Eval("LocalID") %>' />
                                        <br />
                                          <asp:Label runat="server" Font-Size="11" Font-Names="Simplified Arabic" ID="StudentName"
                                            Text='<%# Eval("StudentName") %>' />
                                             
                                        <%--<br />
                                        <asp:Label runat="server" ID="program_options" Text='<%# Eval("program_options") %>' />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                               
                                <asp:TemplateField  HeaderText="Contact" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="mob" Text='<%# Eval("mobile") %>' />
                                        <br />
                                        <asp:Label runat="server" ID="Label4" Text='<%# Eval("HomePhone") %>' />
                                        <br />
                                         <asp:Label runat="server" ID="Label5" Text='<%# Eval("Email") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                               
                                <asp:TemplateField HeaderText="Reference" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="mob" Text='<%# Eval("RefMobile") %>' />
                                        <br />
                                         <asp:Label runat="server" ID="Label2" Text='<%# Eval("RefName") %>' />
                                         <br />
                                          <asp:Label runat="server"  ID="Label3" Text='<%# Eval("RefWorkPhone") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField  HeaderText="School" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="SchoolName" Text='<%# Eval("SchoolName") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="City" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Schoolciyt" Text='<%# Eval("SchoolCity") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderStyle-Width="80" HeaderText="Kudrat" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Kudrat" Text='<%# Eval("Kudrat") %>' /><br />
                                         <asp:Label Font-Bold=true runat="server" ID="KudratPercentage" Text='<%# Eval("KudratPercentage") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderStyle-Width="80" HeaderText="Tahseeli" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="KudratPercentage" Text='<%# Eval("Tahseeli") %>' />
                                        <br />
                                        <asp:Label Font-Bold=true runat="server" ID="TahseeliPercentage" Text='<%# Eval("TahseeliPercentage") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderStyle-Width="80" HeaderText="2ndYear%" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="SecondYearPercentage" Text='<%# Eval("SecondYearPercentage") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="80" HeaderText="3rdYear%" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="ThirdYearPercentage" Text='<%# Eval("ThirdYearPercentage") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderStyle-Width="80" HeaderText="GPA" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label Font-Bold=true runat="server" ID="HighSchoolPercentage" Text='<%# Eval("HighSchoolPercentage") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField  HeaderText="Total" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label Font-Bold=true runat="server" ID="Total" Text='<%# Eval("Total") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--
                                
                                <asp:TemplateField HeaderStyle-Width="100" HeaderText="نتيجة امتحان القدرات" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="gudrat_grade" Text='<%# Eval("gudrat_grade") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="100" HeaderText="نتيجة الإمتحان التحصيلي" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="tahseeli_grade" Text='<%# Eval("tahseeli_grade") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="60" HeaderText="المجموع" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="total_marks" Text='<%# Eval("total_marks") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="50" HeaderText="رابط" HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:HyperLink Target="_blank" runat="server" Text="..." ID="RegisterPageLink" NavigateUrl='<%# Eval("link_url") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-BackColor="ActiveBorder" HeaderStyle-Width="50" HeaderText="اختر"
                                    HeaderStyle-Font-Names="Simplified Arabic">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="SelectStudentCheckBox" Enabled='<%# Eval("visibility") %>' runat="server"
                                            ToolTip='<%# Eval("StudentID") %>' />
                                        <asp:Label ID="StudentEmailAddress" Visible="false" runat="server" Text='<%# Eval("StudentID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                       <%-- </div>--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow Visible="false">
                    <asp:TableCell>
                        <asp:Button OnClick="InviteSelectedStudents" runat="server" Enabled="false" ID="InviteButton_2"
                            Text="Invite" />
                    </asp:TableCell>
                    <asp:TableCell>
                    
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
