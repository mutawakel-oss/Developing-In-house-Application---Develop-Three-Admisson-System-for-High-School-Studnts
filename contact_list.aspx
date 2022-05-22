<%@ Page Title="قائمة طلبات المساعدة" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contact_list.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
    <asp:Button ID="btnHomePage" runat=server CssClass="mainMenuButton"  Text="الرئيسية" PostBackUrl="~/admin_default_page.aspx"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:UpdatePanel ID="uptMain" runat="server">
        <ContentTemplate>
                <asp:Table ID="tblCollegeOptions" runat="server" align="rtl">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblCollegeName" runat="server" Text="حدد الكلية"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlColleges" runat="server" >
                            </asp:DropDownList>             
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblCategory" runat="server" Text="حدد نوع الإستفسار"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlColleges_Index_Changed">
                                <asp:ListItem Text="أواجه مشكلة في استخدام النظام" ></asp:ListItem>
                                <asp:ListItem Text="لا أواجه مشكلة في استخدام النظام ولكني اواجة مشكلة أخرى" ></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Label ID="lblListTitle" runat="server" Text="قائمة طلبات المساعدة" ForeColor="Red" Font-Size="X-Large"></asp:Label><br />
                
                <br />
                               
                
    <asp:Table ID="tblContactsList" runat="server" align="rtl">
        <asp:TableRow>
            <asp:TableCell>                
               <asp:DataGrid id="grdContacts" runat="server" Width="775px" BackColor="White" ForeColor="Black" HorizontalAlign="Center" GridLines="Vertical" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#DEDFDE" AutoGenerateColumns="False" PageSize="50"  AllowPaging="true" OnPageIndexChanged="grdContacts_PageIndexChaged"   PagerStyle-Position="TopAndBottom" PagerStyle-NextPageText="More" CssClass="conditionsTable">
                    <FooterStyle BackColor="#CCCC99" />
                    <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
                    <AlternatingItemStyle BackColor="White" />
                     <ItemStyle BackColor="#C9E1F4" Font-Size="Small"/>
                     <Columns>
                        <asp:BoundColumn HeaderText="م" DataField="id" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="وقت الإرسال" DataField="date"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="نوع الإستفسار" DataField="reason_for_contact"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="اسم الطالب" DataField="fullname"></asp:BoundColumn>                        
                        <asp:TemplateColumn HeaderStyle-VerticalAlign="Top"  headertext="عرض">
                        <ItemTemplate>                                
                                <asp:LinkButton id="lnkView" runat="server" Text="عرض" OnClick="lnkView_Clicked" CommandName='<%# DataBinder.Eval(Container.DataItem, "id") %>'></asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="الرد بواسطة" DataField="replied_by"></asp:BoundColumn>
                    </Columns>
                 <HeaderStyle CssClass="conditionsHeader" Font-Bold="true" />
                </asp:DataGrid>                
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

