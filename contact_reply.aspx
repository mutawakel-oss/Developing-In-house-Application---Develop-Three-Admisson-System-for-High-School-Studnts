<%@ Page Title="صفحة الرد على طلبات المساعدة" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contact_reply.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
    <asp:Button ID="btnHomePage" runat=server CssClass="mainMenuButton"  Text="الرئيسية" PostBackUrl="~/admin_default_page.aspx"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">

<asp:Table ID="tblContactDetails" runat="server" align="rtl">
                                    
  
    <asp:TableRow>
        <asp:TableCell>
                  <asp:Label ID="lblApplicantName" runat="server" Text="اسم المتقدم"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
                   <asp:TextBox ID="txtApplicantName" runat="server" MaxLength="100" Enabled = "false" Width="200px"></asp:TextBox>                                                                         
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell>
                      <asp:Label ID="lblID" runat="server" Text="رقم بطاقة الأحوال " ></asp:Label>                      
                      </asp:TableCell>
                      <asp:TableCell>
                      <asp:TextBox ID="txtStudID" runat="server" MaxLength="10" Enabled = "false" Width="200px"></asp:TextBox>                                                                                                                                                                                                    
                      
          </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell>
                   <asp:Label ID="lblMobileNo" runat="server" Text="رقم الجوال"></asp:Label>
         </asp:TableCell>
         <asp:TableCell>
                     <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" Width="159px" Enabled = "false"></asp:TextBox>                                                                                                                                                                                                    
                      <asp:DropDownList ID="ddlMobilePrefix" runat="server" Enabled="false">
                     <asp:ListItem Text="05" Selected="True"></asp:ListItem>
                     </asp:DropDownList>                     
         </asp:TableCell>
   </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell>
                   <asp:Label ID="lblHomePhone" runat="server" Text="رقم الهاتف"></asp:Label>
         </asp:TableCell>
         <asp:TableCell>
                     <asp:TextBox ID="txtHomePhone" runat="server" MaxLength="10" Width="159px" Enabled = "false" ></asp:TextBox>                                                                                                                                                                                                    
                      <asp:DropDownList ID="ddlCitZip" runat="server" Enabled="false">
                     <asp:ListItem Text="01"></asp:ListItem>
                     <asp:ListItem Text="02"></asp:ListItem>
                     <asp:ListItem Text="03"></asp:ListItem>
                     <asp:ListItem Text="04"></asp:ListItem>
                     <asp:ListItem Text="05"></asp:ListItem>
                     <asp:ListItem Text="06"></asp:ListItem>
                     <asp:ListItem Text="07"></asp:ListItem>
                     </asp:DropDownList>                     
         </asp:TableCell>
   </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell Width="100px">                                                                                           
                         <asp:Label ID="lblEmail" runat="server" Text="البريد الإلكتروني"></asp:Label>                                                                        
         </asp:TableCell>              
         <asp:TableCell>
                         <asp:TextBox ID="txtEmail" runat="server" MaxLength="30" Enabled = "false" Width="200px"></asp:TextBox>                                                                           
         </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell>
                         <asp:Label ID="lblProblemCategory" runat="server" Text="نوع المشكلة"></asp:Label>                      
         </asp:TableCell>
          <asp:TableCell>
                         <asp:DropDownList ID="ddlProblemCateogry" runat="server"  Enabled="false" Width="450px">
                         <asp:ListItem Text="النظام لا يسمح لي بالدخول لعدم قبول رقم بطاقة الأحوال" ></asp:ListItem>
                         <asp:ListItem Text="النظام يسمح لي بالدخول ولكني اواجة مشكلة أخرى" ></asp:ListItem>
                         
                         </asp:DropDownList>
           </asp:TableCell>
      </asp:TableRow>
    <asp:TableRow>
          <asp:TableCell VerticalAlign=Top>
          <asp:Label ID="lblDescription" runat="server" Text="تفاصيل المشكلة"></asp:Label>
          </asp:TableCell>
          <asp:TableCell ColumnSpan=2>
                        <asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Height="150" Width="450px" MaxLength="500" ></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="descriptionValidator" runat=server ControlToValidate="txtDetail" ErrorMessage="*" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>--%>
          </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
        <asp:TableCell VerticalAlign=Top>
            <asp:Label ID="lblReply" runat="server" Text="الرد"></asp:Label>
        </asp:TableCell>
        <asp:TableCell  >
            <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Height="150" Width="450px" MaxLength="500"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReplyValidator" runat="server" ControlToValidate="txtReply" ErrorMessage="*" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
        </asp:TableCell>
      </asp:TableRow>
    <asp:TableRow>
           <asp:TableCell>                        
                <asp:Button ID="btnSave" runat="server" Text="ارسل" CausesValidation="true"  ValidationGroup="contactGroup" CssClass="button" OnClick="btnSave_Clicked" />                             
           </asp:TableCell>
           <asp:TableCell>
                        <asp:Button ID="btnCancel" runat="server" Text="الغي"  CssClass="button" OnClick="CancelClick" />  
           </asp:TableCell>
           
      </asp:TableRow>
                          
</asp:Table>
 
</asp:Content>

