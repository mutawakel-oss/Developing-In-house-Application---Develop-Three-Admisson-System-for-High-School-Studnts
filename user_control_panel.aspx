<%@ Page Title="صفحة اسناد المهمات الإدارية" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_control_panel.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div align=center >
        <asp:Label ID="lblTitle" runat="server" Text="قائمة المهام الإدارية" ForeColor=Red Font-Size=X-Large></asp:Label>
    </div>
      <asp:DataGrid id="usersPermissionGrid" runat="server" Width="775px" BackColor="White" ForeColor="Black" HorizontalAlign="Center" GridLines="Vertical" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#DEDFDE" AutoGenerateColumns="False"  >
           <FooterStyle BackColor="#CCCC99" />
           <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
           <AlternatingItemStyle BackColor="White" />
           <ItemStyle BackColor="#F7F7DE" Font-Size=small />
           <Columns>

               <asp:BoundColumn HeaderText="المستخدم" DataField="item"></asp:BoundColumn>
                 <asp:TemplateColumn HeaderStyle-VerticalAlign="Top"  headertext="الكليات"     >
                            <ItemTemplate>
                                <asp:ListBox ID="lstBoxColleges" runat="server" SelectionMode="Multiple">
                                    <asp:ListItem Text="كلية الطب"></asp:ListItem>
                                    <asp:ListItem Text="كلية العلوم الطبية التطبيقية"></asp:ListItem>
                                    <asp:ListItem Text="كلية التمريض - جدة"></asp:ListItem>
                                    <asp:ListItem Text="كلية التمريض - الأحساء"></asp:ListItem>
                                </asp:ListBox>
                            </ItemTemplate>
                 </asp:TemplateColumn>
                 <asp:TemplateColumn HeaderStyle-VerticalAlign="Top"  headertext="عرض التقارير"     >
                            <ItemTemplate>
                              <asp:CheckBox ID="chkReportViewer" runat=server  />
                            </ItemTemplate>
                 </asp:TemplateColumn>
                   <asp:TemplateColumn HeaderStyle-VerticalAlign="Top"  headertext="عرض الإستعلامات"     >
                            <ItemTemplate>
                              <asp:CheckBox ID="chkContractViewer" runat=server  />
                            </ItemTemplate>
                 </asp:TemplateColumn>
                   <asp:TemplateColumn HeaderStyle-VerticalAlign="Top"  headertext="دعوة الطلاب"     >
                            <ItemTemplate>
                              <asp:CheckBox ID="chkStudentInvitor" runat=server />
                            </ItemTemplate>
                 </asp:TemplateColumn>
                   <asp:TemplateColumn HeaderStyle-VerticalAlign="Top"  headertext="تغيير اعدادات النظام"     >
                            <ItemTemplate>
                              <asp:CheckBox ID="chkSystemController" runat=server  />
                            </ItemTemplate>
                 </asp:TemplateColumn>
           </Columns>
           <HeaderStyle BackColor="#6B696B" Font-Size=small  ForeColor="White" />
       </asp:DataGrid>
</asp:Content>

