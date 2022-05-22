<%@ Page Title="صفحة اعدادات النظام" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="system_configuration.aspx.cs" Inherits="_Default" %>
<%@ register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
    <asp:Button ID="btnHomePage" runat=server CssClass="mainMenuButton"  Text="الرئيسية" PostBackUrl="~/admin_default_page.aspx"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<ajaxToolkit:CollapsiblePanelExtender ID="PeronalInformationCollaspedPanel" runat="Server"
        TargetControlID="CollegeInfoPanel1"
        ExpandControlID="collegeInfoPanel2"
        CollapseControlID="collegeInfoPanel2" 
        Collapsed="False"
        TextLabelID="lblPersonalInf"
        ImageControlID="personalInfPanelImage"    
        ExpandedImage="~/assets/ajax_images/collapse_blue.jpg"
        CollapsedImage="~/assets/ajax_images/expand_blue.jpg"
        SuppressPostBack="true"
        SkinID="CollapsiblePanelDemo" />
                <asp:Panel ID="collegeInfoPanel2" runat="server" CssClass="collapsePanelHeader" Height="30px"  BackImageUrl="~/assets/ajax_images/1.png" >
                    <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                        cursor: pointer; padding-top: 5px">
                        
                        <div style="float:right" >
                        <asp:ImageButton ID="personalInfPanelImage" runat="server" AlternateText="(Show Details...)" ImageUrl="~/assets/ajax_images/expand_blue.jpg" />
                           اعدادات الكليات المتاحة</div>
                        
                        <div style="float: left; margin-left: 20px; width: 1px; height: 14px;">
                            &nbsp;</div>
                        <br />
                        <div style="float: right; vertical-align: middle">
                            &nbsp;</div>
                            </div>
                </asp:Panel>
                <asp:Panel ID="CollegeInfoPanel1" runat="server" CssClass="collapsePanel" Height="1px"   >
            <asp:Table ID="tblCollegeAdd" runat="server" align="rtl>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblCollegeName" runat="server" Text="اسم الكلية"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtCollegeName" runat="server" Width="250px" Height="80px" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="collegeValidator" runat="server" ControlToValidate="txtCollegeName" ErrorMessage="*" ValidationGroup="CollegeGroup" ></asp:RequiredFieldValidator>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="btnAddCollege" runat="server" CssClass="button" Text="أظف الكلية"  CausesValidation="true" ValidationGroup="CollegeGroup" OnClick="mAddCollege"/>
        </asp:TableCell>
    </asp:TableRow>
   </asp:Table>
   <br />
    <asp:DataGrid id="ConfigurationGrid" runat="server" Width="775px" BackColor="White" ForeColor="Black" HorizontalAlign="Center" GridLines="Vertical" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#DEDFDE" AutoGenerateColumns="False" OnEditCommand="mEditConfiguration" OnCancelCommand="mCacnelEdit"  OnUpdateCommand="mUpdateConfiguration"  CssClass="conditionsTable">
           <FooterStyle BackColor="#CCCC99" />
           <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
           <AlternatingItemStyle BackColor="White" />
           <ItemStyle BackColor="#C9E1F4" Font-Size=small />
           <Columns>
               <asp:EditCommandColumn CancelText="الغاء" EditText="تحرير" UpdateText="تحديث"  ItemStyle-ForeColor=blue></asp:EditCommandColumn>
               <asp:BoundColumn HeaderText="رقم" DataField="id"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="اسم الكلية" DataField="college_name"></asp:BoundColumn>
               <asp:TemplateColumn HeaderStyle-VerticalAlign="Top"  headertext="متوقف"      >
                            <ItemTemplate>
                              <asp:CheckBox ID="chkStatus" runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "status")) %>' />
                            </ItemTemplate>
                 </asp:TemplateColumn>  
                 <asp:BoundColumn HeaderText="تاريخ البدء" DataField="start_date"></asp:BoundColumn>
                 <asp:BoundColumn HeaderText="تاريخ الإنتهاء" DataField="end_date"></asp:BoundColumn>
           </Columns>
           <HeaderStyle CssClass="conditionsHeader" Font-Bold="true" />
       </asp:DataGrid>
     <br />
           
               </asp:Panel>  
               <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"
        TargetControlID="adsInfoPanel1"
        ExpandControlID="adsInfoPanel2"
        CollapseControlID="adsInfoPanel2" 
        Collapsed="False"
        TextLabelID="lblPersonalInf"
        ImageControlID="personalInfPanelImage"    
        ExpandedImage="~/assets/ajax_images/collapse_blue.jpg"
        CollapsedImage="~/assets/ajax_images/expand_blue.jpg"
        SuppressPostBack="true"
        SkinID="CollapsiblePanelDemo" />
                <asp:Panel ID="adsInfoPanel2" runat="server" CssClass="collapsePanelHeader" Height="30px"  BackImageUrl="~/assets/ajax_images/1.png" >
                    <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                        cursor: pointer; padding-top: 5px">
                        
                        <div style="float:right" >
                        <asp:ImageButton ID="adsImage" runat="server" AlternateText="(Show Details...)" ImageUrl="~/assets/ajax_images/expand_blue.jpg" />
                           اعدادات إعلانات النظام</div>
                        
                        <div style="float: left; margin-left: 20px; width: 1px; height: 14px;">
                            &nbsp;</div>
                        <br />
                        <div style="float: right; vertical-align: middle">
                            &nbsp;</div>
                            </div>
                </asp:Panel>
                <asp:Panel ID="adsInfoPanel1" runat="server" CssClass="collapsePanel" Height="1px"  >
         
            <asp:Table ID="tblAdsAdd" runat="server" align="rtl">
          <asp:TableRow>
                <asp:TableCell>
                        <asp:Label ID="lblAdsText" runat="server" Text="نص الإعلان"></asp:Label>
                 </asp:TableCell>
                 <asp:TableCell>
                        <asp:TextBox ID="txtAdsText" runat="server"  TextMode="MultiLine" Height="80px" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="adsValidator" runat="server" ControlToValidate="txtAdsText" ErrorMessage="*" ValidationGroup="adsGroup" ></asp:RequiredFieldValidator>
                </asp:TableCell>
                <asp:TableCell>
                        <asp:Button ID="Button1" runat="server" CssClass="button" Text="أظف الإعلان"  CausesValidation="true" ValidationGroup="adsGroup" OnClick="mAddAds"/>
                </asp:TableCell>
            </asp:TableRow>
    </asp:Table>
  <asp:DataGrid id="adsGrid" runat="server" Width="775px" BackColor="White" ForeColor="Black" HorizontalAlign="Center" GridLines="Vertical" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#DEDFDE" AutoGenerateColumns="False" OnEditCommand="mEditSystemAds" OnCancelCommand="mCancelEditingAds" OnUpdateCommand="mUpdateAds"  CssClass="conditionsTable">
           <FooterStyle BackColor="#CCCC99" />
           <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
           <AlternatingItemStyle BackColor="White" />
           <ItemStyle BackColor="#C9E1F4" Font-Size=small />
           <Columns>
               <asp:EditCommandColumn CancelText="الغاء" EditText="تحرير" UpdateText="تحديث"  ItemStyle-ForeColor=blue></asp:EditCommandColumn>
               <asp:BoundColumn HeaderText="رقم" DataField="id"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="نص الإعلان" DataField="ads_text"></asp:BoundColumn>
               <asp:TemplateColumn HeaderStyle-VerticalAlign="Top"  headertext="متوقف"      >
                            <ItemTemplate>
                              <asp:CheckBox ID="chkAdsStatus" runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "status2")) %>' />
                            </ItemTemplate>
                 </asp:TemplateColumn>  
                 <asp:BoundColumn HeaderText="تاريخ البدء" DataField="start_date"></asp:BoundColumn>
                 <asp:BoundColumn HeaderText="تاريخ الإنتهاء" DataField="end_date"></asp:BoundColumn>
           </Columns>
           <HeaderStyle CssClass="conditionsHeader" Font-Bold="true" />
       </asp:DataGrid>
               </asp:Panel>  
  
   
   
</asp:Content>

