<%@ Page Language="C#" AutoEventWireup="true" CodeFile="statistics.aspx.cs" Inherits="statistics"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/xhtml; charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label1" Font-Names="Garamond" Text="Step1:1-Please click on Prepare Data button to generate the data first."
        runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label12" Font-Names="Garamond" Text="Step1:2-Once data is ready, you will see the following message."
        runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label21" Font-Names="Garamond" Text="Step1:3-Click Save button and provide a valid filename.Please note that this may take few minutes based of the size of the data from server."
        runat="server"></asp:Label>
    
    <asp:Image runat="server" ImageUrl="~/FileSaveAs.jpg" />
   
    <asp:Image ID="Image1" runat="server" ImageUrl="~/FileName.jpg" />
    <br />
    <asp:Button ID="Button2" Text="Prepare Data" runat="server" OnClick="Create" />
    <asp:UpdatePanel ID="upd_main" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="upd1">
                <ProgressTemplate>
                    <asp:Label BackColor="Green" ForeColor="White" runat="server" ID="stat" Text="Please wait..."></asp:Label>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:GridView Width="220%" RowStyle-Font-Names="Garamond" RowStyle-Font-Size="Medium"
                HeaderStyle-BackColor="ActiveBorder" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="WhiteSmoke"
                HeaderStyle-Height="25" ID="GridView1" OnRowDeleting="RowDelete" runat="server"
                PageSize="50" PagerSettings-Position="TopAndBottom">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="200" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="StName" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Name") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Local ID">
                        <ItemTemplate>
                            <asp:Label ID="lblLocalID" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("LocalID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Programs">
                        <ItemTemplate>
                            <asp:Label ID="lblProgram" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("program_options") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="POB">
                        <ItemTemplate>
                            <asp:Label ID="POB" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("POB") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Mobile">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Mobile") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Tel">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Tel") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Email") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="RefMob">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("RefMob") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="150" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="RefName">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("RefName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Tel">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Tele") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="WorkTel">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("WorkTel") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="2ndOpt">
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("2ndOpt") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="School">
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("School") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("City") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Kudrat">
                        <ItemTemplate>
                            <asp:Label ID="lblKudrat" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Kudrat") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="200" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Year">
                        <ItemTemplate>
                            <asp:Label ID="Label13" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Year") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Kudrat%">
                        <ItemTemplate>
                            <asp:Label ID="Label14" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Kudrat%") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Tahsili">
                        <ItemTemplate>
                            <asp:Label ID="Label15" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Tahsili") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Tahsili%">
                        <ItemTemplate>
                            <asp:Label ID="Label16" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Tahsili%") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="2ndyr%">
                        <ItemTemplate>
                            <asp:Label ID="Label17" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("2ndyr%") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="3rdyr%">
                        <ItemTemplate>
                            <asp:Label ID="Label18" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("3rdyr%") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="GPA">
                        <ItemTemplate>
                            <asp:Label ID="Label19" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("GPA") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="100" HeaderStyle-Font-Names="Simplified Arabic"
                        HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="Label20" runat="server" Font-Size="11" Font-Names="Simplified Arabic"
                                Text='<%# Eval("Total") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
