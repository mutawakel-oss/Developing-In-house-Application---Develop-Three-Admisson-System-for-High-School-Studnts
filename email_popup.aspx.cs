using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mail;
public partial class email_popup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        email_text.Content = "";
        if (Request.QueryString["email"] != null)
        {
            EmailTextBox.Text = Request.QueryString["email"].ToString();

            email_text.Content += "<div style=font-size:medium dir=rtl><b>";
            email_text.Content += "الموضوع";
            email_text.Content += "&nbsp;&nbsp;</b>";
            email_text.Content += "دعوة للمقابلة الشخصية";
            email_text.Content += "<br><b>";
            email_text.Content += "التاريخ";
            email_text.Content += "&nbsp;&nbsp;</b>";

            if (RadDatePicker1.SelectedDate != null)
            {
                email_text.Content += RadDatePicker1.SelectedDate.Value.Date.ToLongDateString();
            }
            else
            {
                email_text.Content += "--";
            }

            email_text.Content += "<br><b>";
            email_text.Content += "التاريخ";
            email_text.Content += "&nbsp;&nbsp;</b>";
            email_text.Content += txtTime.Text;
            email_text.Content += "<br><b>";
            email_text.Content += "الموقع";
            email_text.Content += "&nbsp;&nbsp;</b>";
            email_text.Content += Location.Text;
            email_text.Content += "<br><br><hr/>";
            email_text.Content += "أخي المتقدم";
            email_text.Content += "<br>";
            email_text.Content += "الرجاء الحضور للمقابلة الشخصية  في المكان والزمان المحدد أعلاه.";
            email_text.Content += "<br>";
            email_text.Content += "<br>";
            email_text.Content += "مع تمنياتنا للجميع بالتوفيق المستمر.";
            email_text.Content += "</div>";


        }

    }

    protected void SendEmail(object o, EventArgs e)
    {
        SendMail("no-reply@ksau-hs.edu.sa", EmailTextBox.Text, SubjectText.Text, email_text.Content);
    }
    public void SendMail(string FROM, string TO, string SUBJECT, string BODY)
    {
        //================FROM and TO==================//
        MailMessage mail = new MailMessage();
        mail.Bcc = TO;
        mail.From = FROM;
        mail.Subject = SUBJECT;
        mail.Body = "<div dir='rtl'>" + BODY + "</div>";
        mail.Body = BODY;
        mail.BodyFormat = MailFormat.Html;

        mail.BodyEncoding = System.Text.Encoding.UTF8;


        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "med/wtest");
        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "test123");

        //=============SMTP Server==================/
        SmtpMail.SmtpServer = "mail1.ksuhs.edu.sa";
        //==========================================/
        //====Sending email to the email address====/
        try
        {
            SmtpMail.Send(mail);
            string[] EmailAddress=TO.Split(';');
            for(int i=0;i<EmailAddress.Length;i++)
            {
                if (EmailAddress[i].ToString() != "")
                {
                    GeneralClass.Program ProgramClass = new GeneralClass.Program();
                    ProgramClass.Add("status_id", "2", "I");
                    ProgramClass.UpdateRecordStatement("student_registration", "email_address","'"+ EmailAddress[i].ToString()+"'");
                }
            }

        }
        catch (Exception exp)
        {
            Response.Write(exp.Message);   
        }
    }
}
