<%@ Page Title="صفحة شروط القبول والتسجيل" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="terms_condition.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server"><asp:Button ID="btnHomePage" runat=server CssClass="mainMenuButton"  Text="الرئيسية" PostBackUrl="~/index.aspx"/><asp:Button ID="btnContactUs" runat=server CssClass="mainMenuButton"  Text="اتصل بنا" PostBackUrl="~/contact.aspx"/></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">

      <div align="center">
        <asp:Label ID="lblTitle" runat="server" ForeColor="Red"  CssClass="fontFamilyClass" Font-Size="14pt"></asp:Label>
        <br />
      </div>
      <asp:DataGrid id="termsAndConditionGrid" runat="server" Width="100%" GridLines="Vertical" CellPadding="4" AutoGenerateColumns="False"  CssClass="conditionsTable">
      <%-- <asp:BoundColumn HeaderText="" DataField="id"></asp:BoundColumn> --%>
           <FooterStyle BackColor="#CCCC99" />
           <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
           <AlternatingItemStyle BackColor="White" />
           <ItemStyle  Font-Size=small />
           <Columns>
               
               <asp:BoundColumn  HeaderText="» الشـــروط" DataField="condition"></asp:BoundColumn>
           </Columns>
           <HeaderStyle CssClass="conditionsHeader" Font-Bold="true" />
       </asp:DataGrid>
      <asp:DataGrid id="RulesGrid" runat="server" Width="100%" GridLines="Vertical" CellPadding="4" AutoGenerateColumns="False"  CssClass="conditionsTable">
           <FooterStyle BackColor="#CCCC99" />
           <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
           <AlternatingItemStyle BackColor="White" />
           <ItemStyle  Font-Size=small />
           <Columns>
               <asp:BoundColumn HeaderText="» الأنظمة المتعلقة بالقبول" DataField="condition"></asp:BoundColumn>
           </Columns>
           <HeaderStyle CssClass="conditionsHeader" Font-Bold="true" />
       </asp:DataGrid>
       
       <asp:DataGrid id="formulaGrid" runat="server" Width="100%" GridLines="Vertical" CellPadding="4" AutoGenerateColumns="False"  CssClass="conditionsTable">
           <FooterStyle BackColor="#CCCC99" />
           <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
           <AlternatingItemStyle BackColor="White" />
           <ItemStyle  Font-Size=small />
           <Columns>
               <asp:BoundColumn HeaderText="» سيكون التنافس على المقاعد المتوفرة وفق المعايير التالية" DataField="condition"></asp:BoundColumn>
           </Columns>
           <HeaderStyle CssClass="conditionsHeader" Font-Bold="true" />
       </asp:DataGrid>
        <%-- Verify Student Modal Popup Extender Control This will check if School Grade more then 90 or less--%>
    <asp:Button ID="btnCheckSchoolGrade" Style="display: none;" runat="server" Text="Fake" />
    <ajaxToolkit:ModalPopupExtender ID="mpeSchoolGrades" runat="server" TargetControlID="btnCheckSchoolGrade"
        PopupControlID="pnlCheckSchoolGrades" BackgroundCssClass="modalBackground"
        DropShadow="false" CancelControlID="btnCloseSchoolGrades">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlCheckSchoolGrades" runat="server" Direction="RightToLeft" CssClass="modalPopup"
        Style="display: none" Width="300" Height="200">
        <center>
            <asp:Label ID="lblCollegeChoiceTitle" runat="server" Text="جامعة الملك سعود بن عبدالعزيز للعلوم الصحية"
                Font-Bold="true"></asp:Label>
        </center>
        <hr />
        <br />
        <div align="justify">
            <asp:Label ID="lblCollegeChoice" runat="server" >                    
                    
            </asp:Label>
        </div>
        <br />
        <br />
        <center>
            <asp:Button ID="btnCloseSchoolGrades" runat="server" Text="نعم" CssClass="mainMenuButton" />
            <asp:Button ID="btnSchoolGradeContactUs" runat="server" Text="لا" PostBackUrl="~/index.aspx" CssClass="mainMenuButton"/>
            
        </center>
    </asp:Panel>
       <asp:UpdatePanel ID="agreementUpdatePanel" runat="server" RenderMode="Inline">
            <ContentTemplate>
               <br />
               <asp:Table ID="tblAgreement" runat="server"  CssClass="tblAgreementStyle">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:CheckBox ID="chkAgreement" runat="server" AutoPostBack="true" Text="قرأت الشروط اعلاه وأوافق عليها" OnCheckedChanged="mAgreementCheckChanged"  CssClass="agreementStyle" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnContinue" runat="server" CssClass="button buttondisabled" Text="تابع التسجيل" Enabled="false" OnClick="mGoToRegister"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:UpdateProgress ID="upprg15" runat="server">
                        <ProgressTemplate>
                            <asp:Label ID="lblProgress" runat="server" Text="الرجاء الإنتظار..."></asp:Label>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    
                </asp:TableCell>
            </asp:TableRow>
       </asp:Table>
            </ContentTemplate>
       </asp:UpdatePanel>
    
</asp:Content>

