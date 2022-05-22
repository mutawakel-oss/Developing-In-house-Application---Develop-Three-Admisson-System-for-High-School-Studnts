<%@ Page Language="C#" UICulture="en-US" Culture="en-US" AutoEventWireup="true" CodeFile="email_popup.aspx.cs"
    Inherits="email_popup" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compose Email </title>
</head>
<body >
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <asp:Table  BorderWidth="1" CellPadding="0" CellSpacing="0" Font-Names="tahoma" Font-Size="10"
        Width="100%" runat="server">
        <asp:TableRow>
            <asp:TableCell BorderWidth="1" Text="البريد الإلكتروني" VerticalAlign="Top" Width="100px"></asp:TableCell>
            <asp:TableCell BorderWidth="1" BackColor="#EBF3FF" HorizontalAlign="Left">
                <asp:TextBox TextMode="MultiLine" ReadOnly="true" runat="server" ID="EmailTextBox"
                    Height="100px" Width="500px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ToolTip="Subject">
            <asp:TableCell BorderWidth="1" Text="الموضوع" VerticalAlign="Top" ></asp:TableCell>
            <asp:TableCell BorderWidth="1" BackColor="#EBF3FF" HorizontalAlign="Left">
            <asp:TextBox ID="SubjectText" runat=server Text="دعوة للمقابلة الشخصية"  Width=90%></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        
         <asp:TableRow ToolTip="Date">
            <asp:TableCell BorderWidth="1" Text="التاريخ" VerticalAlign="Top"></asp:TableCell>
            <asp:TableCell BorderWidth="1" BackColor="#EBF3FF" HorizontalAlign="Left">
            <telerik:RadDatePicker ID="RadDatePicker1"  runat=server></telerik:RadDatePicker>
            </asp:TableCell>
            
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell BorderWidth="1" Text="الزمن" VerticalAlign="Top" ></asp:TableCell>
            <asp:TableCell BorderWidth="1" BackColor="#EBF3FF" HorizontalAlign="Left">    
            <asp:TextBox ID="txtTime" runat=server></asp:TextBox>        
            </asp:TableCell>
        </asp:TableRow>
        
        
        
        <asp:TableRow>
            <asp:TableCell BorderWidth="1" Text="الموقع" VerticalAlign="Top" ></asp:TableCell>
            <asp:TableCell BorderWidth="1" BackColor="#EBF3FF" HorizontalAlign="Left" >  
            <asp:TextBox ID="Location" runat=server Width="300px"></asp:TextBox>                  
            </asp:TableCell>
        </asp:TableRow>
        
          <asp:TableRow>
            <asp:TableCell BorderWidth="1" ColumnSpan=2  VerticalAlign="Top" >
            <asp:LinkButton runat=server Text="Generate Template" ></asp:LinkButton>
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell BorderWidth="1"  ColumnSpan="2">
                <telerik:RadEditor runat=server Height="300px"  Width="100%" ID="email_text" ToolsFile="ToolsFileLimited.xml" >
                </telerik:RadEditor>
        
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table><div ></div>
    <br />
        <asp:Button runat=server Text="Send Invitation" OnClick="SendEmail" />
    </form>
</body>
</html>
