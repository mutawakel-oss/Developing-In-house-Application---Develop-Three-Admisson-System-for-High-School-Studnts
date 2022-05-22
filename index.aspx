<%@ Page Title="نظام التسجيل الإلكتروني - الصفحة الرئيسية" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_Default" %>
<%@ register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server"><asp:Button ID="btnHomePage" runat=server CssClass="mainMenuButton"  Text="الرئيسية" PostBackUrl="~/index.aspx"/><asp:Button ID="btnContactUs" runat=server CssClass="mainMenuButton"  Text="اتصل بنا" PostBackUrl="~/contact.aspx"/></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<%-- The following panel will contain the University welcome Letter--%>
<asp:Panel ID="pnlWelcomeLetter" runat="server" Width="830px">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" >
            <tr>
                <td valign="top">
                    <table class='msg' border='0' cellpadding='0' cellspacing='0'>
	                    <tr><td class='header' colspan='3'/></tr>
	                    <tr>
		                    <td class='rightBorder' />
		                    <td class='msgBody'>
		                        أعزاءنا الطلاب.
			                    <br />
			                    <br />
                                أخلص التهاني القلبية لكم جميعًا بالنجاح و التوفيق ، وأسعدنا اختياركم  لجامعة الملك سعود بن عبدالعزيز للعلوم الصحية بالحرس الوطني، هذه الجامعة التي تتولى زمام الريادة في التعليم الطبي الحديث محليًّا وإقليميًّا، وتتيح للطالب فرص التدريب المكثف والممارسة المهنية بمدينة الملك عبد العزيز الطبية بالشؤون الصحية منذ سنواته الدراسية الأولى وهي بيئة مهيأة ومحفزة على بناء خبرات الطالب وصقل مهاراته وتنمية قدراته العلمية في مجال تخصصه.
                                <br />
 ونود التنويه إلى أن القبول في الجامعة سيكون عبر هذه البوابة الإلكترونية ويستمر إلى نهاية المدة المعلنة، علمًا بأن فرز الطلبات محكوم بأفضلية المعدل والمقاعد المتاحة بعد إغلاق التسجيل.
 وسوف تتصل عمادة القبول و التسجيل بالطلاب الذين استكملوا متطلبات القبول المبدئي لترتيب إجراءات المقابلات الشخصية، متمنية لكل من لم يحالفهم التوفيق أن تتهيأ لهم فرص القبول في جامعات أخرى. 
 <br />
للاستفسار و طلب المساعدة؛ يرجى استخدام نظام المساعدة المدمج في النظام، وسيبادر منسوبوا القبول والتسجيل للاتصال بكم لمساعدتكم والرد على استفساراتكم.
<br />
<br />
<font color="red">ملاحظات هامة:</font><br />
* التسجيل في كلية الطب وكلية طب الأسنان والصيدلة والعلوم الطبية التطبيقية خاص بالطلاب فقط .
<br />
* التسجيل في كليتي التمريض بجدة والاحساء خاص بالطالبات فقط .
<br />
* التسجيل في كليتي الطب والتمريض (الرياض - طالبات) سيكون عن طريق موقع القبول الإلكتروني الموحد للطالبات في الجامعات الحكومية بالرياض عن طريق الرابط التالي: <asp:LinkButton ID="rguLink" runat="server" PostBackUrl="http://www.rgu-admit.net" Font-Underline="true"> ( موقع القبول الإلكتروني الموحد للطالبات في الجامعات الحكومية بالرياض)</asp:LinkButton>

                                <div align=right>
                                </div>
		                    </td>
		                    <td class='leftBorder' />
	                    </tr>
	                    <tr>
		                    <td class='rightBottomCorner' />
		                    <td class='bottomCorner' />
		                    <td class='leftBottomCorner' />
	                    </tr>
                    </table>
      <asp:UpdatePanel ID="UpdatePanel15" runat="server" RenderMode="Inline">
            <ContentTemplate>
                    
                    <div class="collegeChoicesTable" >
                        <asp:Table ID="tblCollegeChoice" runat="server" align="rtl">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblGender" runat="server" Text="الجنس"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="ddlGender" runat="server">
                                    <asp:ListItem Text="ذكر" Value="male"></asp:ListItem>
                                    <asp:ListItem Text="أنثى" Value="female"></asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                الكلية المرغوب التقدم لها
                                </asp:TableCell>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:DropDownList ID="ddlColleges" runat="server" /><br />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell >                                        
                                        <asp:CheckBox ID="chkAssurance" CssClass="fontFamilyClass"  runat="server" Font-Size="12pt" TextAlign="Right" Text="تأكيد الإختيار" ForeColor=Red AutoPostBack="true" OnCheckedChanged="mAssuranceCheckChanged"  />
                                </asp:TableCell>
                                <asp:TableCell >
                                  <asp:Button ID="btnNext" runat="server" Text="الصفحة التالية" CssClass="button buttondisabled" OnClick="mShowCollegesExtender" Enabled="false" />
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
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
                </td>
                <td valign="top" class='leftPane'>
                    <table cellpadding="0" cellspacing="0"    align=center >
                        <tr >
                        <td valign="top" >
                            <%-- The following table will contain the login control --%>
                            <div id='blueLoginPanel'>
                            <asp:Table ID="tblLogin" runat="server" align="rtl" GridLines="None" CssClass="loginTable" >
                                  <asp:TableRow>
                                      <asp:TableCell CssClass='loginLabel'>
                                         <asp:Label ID="lblUserNAME" runat=server Text="اسم المستخدم" ></asp:Label>
                                      </asp:TableCell>
                                      <asp:TableCell CssClass='loginInput'>
                                          <asp:TextBox ID="txtUserName" runat="server"  MaxLength="20" CssClass='username'></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="userNameVlidator" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" ValidationGroup="loginGroup"></asp:RequiredFieldValidator>
                                     </asp:TableCell>
                                    </asp:TableRow>
                                  <asp:TableRow>
                                       <asp:TableCell CssClass='loginLabel'>
                                            <asp:Label ID="lblPassword" runat="server" Text="كلمة المرور" ></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass='loginInput'>
                                            <asp:TextBox ID="txtPassword" runat="server" MaxLength="15" TextMode="Password" CssClass='password'></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ValidationGroup="loginGroup"></asp:RequiredFieldValidator>
                                         </asp:TableCell>
                                 </asp:TableRow>
                                  <asp:TableRow  HorizontalAlign="Center">
                                      <asp:TableCell >
                                         <asp:Button ID="btnLogin" runat="server" CausesValidation="true" ValidationGroup="loginGroup"  CssClass='loginButton' OnClick="btnLogin_Click" />
                                     </asp:TableCell>
                                     <asp:TableCell Width="100px">
                                        <asp:LinkButton ID="lnkForgotePassword" runat="server" Text="نسيت كلمة المرور" PostBackUrl="~/getpassword.aspx"></asp:LinkButton>
                                     </asp:TableCell>
                                </asp:TableRow>
                               
                            </asp:Table>
                            </div>
                        </td>
                        </tr>
                        <tr height="200" >
                            <td valign="top">
                                <asp:Panel ID="pnlAdvertiseMent" runat="server"  Direction="RightToLeft" CssClass="advTable">
                                     <marquee id="mrqAds" direction ="up" scrollamount="2" scrolldelay ="3" > <p> <A><asp:Literal ID="literalAds" runat="server"></asp:Literal></A> </p> </marquee></asp:Panel>
                            </td>
                        </tr>
                    </table>
                 </td>
            </tr>
        </table>
        
        
        
    </div>
   
    
        
</asp:Panel>
<div style='height:15px;'/>
<%-- Failure of login Modal Popup Extender Control --%>
                <asp:Button ID="btnOptionsExptender" Style="display: none;" runat="server" Text="Fake" />
			    
                <ajaxToolkit:ModalPopupExtender ID="mpeLoginFailure" runat="server" 
                    TargetControlID="btnOptionsExptender"  PopupControlID="pnlLoginFailure" 
                    BackgroundCssClass="modalBackground" 
                    DropShadow="false"  CancelControlID="btnLoginFailure">
                </ajaxToolkit:ModalPopupExtender>
                
                <asp:Panel ID="pnlLoginFailure" runat="server" Direction="RightToLeft" CssClass="modalPopup" Style="display:none" Width="300" Height="200">
                <center>
                    <asp:Label ID="lblStudyOptionsHeading" runat="server" Text="جامعة الملك سعود بن عبدالعزيز للعلوم الصحية" Font-Bold="true"></asp:Label>                    
                </center>
                <hr />
                <br />
                    <div align="justify">
                    <asp:Label ID="lblLoginFaliureInfo" runat="server" Text="اسم المستخدم او كلمة المرور غير صحيحة الرجاء التأكد من صحتهم.">                    
                    </asp:Label>
                    </div>
                    <br /><br /><br /><br /><br /><br />
                    <center>
                        <asp:Button ID="btnLoginFailure" runat="server" Text="اغلاق"/>                    
                    </center>
                </asp:Panel>                
                
                
<%-- Failure of login Modal Popup Extender Control --%>
         
</asp:Content>
