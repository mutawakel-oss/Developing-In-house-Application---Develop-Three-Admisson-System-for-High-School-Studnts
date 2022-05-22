using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
public partial class Default2 : System.Web.UI.Page
{
    //*     Class level variable for database activities    *//
    GeneralClass.Program ProgramClass = new GeneralClass.Program();
    GeneralClass.Program objProgram = new GeneralClass.Program();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ForgotMyPWD.Attributes.Add("onclick", "return ReqField1Validator()");
        this.ForgotUID.Attributes.Add("onclick", "return ReqField2Validator()");
        this.SubmitButton.Attributes.Add("onclick", "return ReqField3Validator()");
    }
    /// <summary>
    /// Click this button to get the data corresponding to the option selected
    /// Option 1: If user forgot password get the password from the database
    ///             against the user name entered and send this password in the email of that applicant.
    /// Option 2: If user forgot username get the user name from the database 
    ///             against the email address entered and send this password to the email address.
    ///             
    /// Email sending will be through stored procedure in database.
    ///         
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetPassUID(object sender, EventArgs e)
    {
        InfoLabel.Text = "";
        //get the email address and password. Password is encrypted. 
        //So decrypt first and send the password.
       
        //if I forgot my password option is selected, then...
        if (ForgotMyPWD.Checked == true && UserNameTextBox.Text.Trim() != "")
        {
            try
            {

                ProgramClass.strSql = "SELECT password,email_address FROM student_registration WHERE user_name='" + UserNameTextBox.Text + "'";
                ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);
                while (ProgramClass.drData.Read())
                {

                    ProgramClass.SendMail("noreply@ksau-hs.edu.sa", ProgramClass.drData[1].ToString(), "استرجاع اسم المستخدم",
                      "<div dir=rtl>كلمة المرور الخاصة بحسابك في نظام التسجيل الإلكتروني بجامعة الملك سعود بن عبدالعزيز للعلوم الصحية هي:" +
                       "<br><br><b>"+ ProgramClass.Decrypt(ProgramClass.drData[0].ToString()) + "</b><br>"+
                        "انسخ الرابط التالي والصقه في متصفح الإنترنت للدخول للنظام." +
                       "<br><br>http://" + Request.ServerVariables["HTTP_HOST"].ToString() + "/index.aspx<br><br>" +
                       " تم ارسال هذه الرسالة بغرض الرد على طلب الحصول على كلمة المرور وليس عليك الرد على هذه الرسالة.</div>");

                    //OdbcCommand p_Command = new OdbcCommand("{ call sp_SQLNotify (?,?,?,?)}", ProgramClass.REG_CONN);
                    //OdbcParameter Param1 = p_Command.Parameters.Add("@From", OdbcType.NVarChar);
                    //Param1.Direction = System.Data.ParameterDirection.Input;
                    //Param1.Value = "dar@ksau-hs.edu.sa";


                    //OdbcParameter Param2 = p_Command.Parameters.Add("@To", OdbcType.NVarChar);
                    //Param2.Direction = System.Data.ParameterDirection.Input;
                    //Param2.Value = ProgramClass.drData[1].ToString();

                    //OdbcParameter Param3 = p_Command.Parameters.Add("@Subject", OdbcType.NVarChar);
                    //Param3.Direction = System.Data.ParameterDirection.Input;
                    //Param3.Value = "استرجاع كلمة المرور";


                    //OdbcParameter Param4 = p_Command.Parameters.Add("@Body", OdbcType.NVarChar);
                    //Param4.Direction = System.Data.ParameterDirection.Input;
                    //Param4.Value = "<div dir=rtl>كلمة المرور الخاصة بحسابك في نظام التسجيل الإلكتروني بجامعة الملك سعود بن عبدالعزيز للعلوم الصحية هي:" +
                    //   "<br><br><b>"+ ProgramClass.Decrypt(ProgramClass.drData[0].ToString()) + "</b><br>"+
                    //    "انسخ الرابط التالي والصقه في متصفح الإنترنت للدخول للنظام." +
                    //    "<br><br>http://" + Request.ServerVariables["HTTP_HOST"].ToString() + "/index.aspx<br><br>" +
                    //    " تم ارسال هذه الرسالة بغرض الرد على طلب الحصول على كلمة المرور وليس عليك الرد على هذه الرسالة.</div>";

                    ////close the reader before execiting the sp :)
                    //if (ProgramClass.drData != null)
                    //{
                    //    if (ProgramClass.drData.IsClosed == false)
                    //        ProgramClass.drData.Close();
                    //}

                    //p_Command.CommandType = System.Data.CommandType.StoredProcedure;
                    //OdbcDataReader sp_Reader = p_Command.ExecuteReader();
                    InfoLabel.Text = "";
                    UserNameTextBox.Text = "";
                    break;
                }
                if (ProgramClass.drData != null)
                {
                    if (ProgramClass.drData.IsClosed == false)
                        ProgramClass.drData.Close();
                }
            }
            catch (Exception exp)
            {
                InfoLabel.Text = "Error!" + exp.Message;
            }
            finally
            {
                if (ProgramClass.drData.IsClosed == false)
                    ProgramClass.drData.Close();
            }
        }
        else if (ForgotUID.Checked==true && EmailTextBox.Text.Trim() != "")
        {
            try
            {
                ProgramClass.strSql = "SELECT user_name,email_address FROM student_registration WHERE email_address='" + EmailTextBox.Text + "'";
                ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);

                while (ProgramClass.drData.Read())
                {
                    ProgramClass.SendMail("noreply@ksau-hs.edu.sa",ProgramClass.drData[1].ToString(),"استرجاع اسم المستخدم",
                        "<div dir=rtl align=right>اسم المستخدم الخاص بحسابك في نظام التسجيل الإلكتروني بجامعة الملك سعود بن عبدالعزيز للعلوم الصحية هو:" +
                        ProgramClass.drData[0].ToString() +
                        "انسخ الرابط التالي والصقه في متصفح الإنترنت للدخول للنظام." +
                        "<br><br>http://" + Request.ServerVariables["HTTP_HOST"].ToString() + "/index.aspx<br><br>" +
                        "تم ارسال هذه الرسالة بغرض الرد على طلب الحصول على اسم المستخدم الخاص بك، وليس عليك الرد على هذه الرسالة.</div>");

                    //OdbcCommand p_Command = new OdbcCommand("{ call sp_SQLNotify (?,?,?,?)}", ProgramClass.REG_CONN);
                    //OdbcParameter Param1 = p_Command.Parameters.Add("@From", OdbcType.NVarChar);
                    //Param1.Direction = System.Data.ParameterDirection.Input;
                    //Param1.Value = "dar@ksau-hs.edu.sa";


                    //OdbcParameter Param2 = p_Command.Parameters.Add("@To", OdbcType.NVarChar);
                    //Param2.Direction = System.Data.ParameterDirection.Input;
                    //Param2.Value = ProgramClass.drData[1].ToString();

                    //OdbcParameter Param3 = p_Command.Parameters.Add("@Subject", OdbcType.NVarChar);
                    //Param3.Direction = System.Data.ParameterDirection.Input;
                    //Param3.Value = "استرجاع اسم المستخدم";

                    //OdbcParameter Param4 = p_Command.Parameters.Add("@Body", OdbcType.NVarChar);
                    //Param4.Direction = System.Data.ParameterDirection.Input;
                    //Param4.Value = "";
                    ////close the reader before execiting the sp :)
                    //if (ProgramClass.drData != null)
                    //{
                    //    if (ProgramClass.drData.IsClosed == false)
                    //        ProgramClass.drData.Close();
                    //}

                    //p_Command.CommandType = System.Data.CommandType.StoredProcedure;
                    //OdbcDataReader sp_Reader = p_Command.ExecuteReader();
                    InfoLabel.Text = "";
                    UserNameTextBox.Text = "";
                    break;
                }
                ProgramClass.drData.Close();
            }
            catch (Exception exp)
            {
                InfoLabel.Text = "Error!" + exp.Message;
                objProgram.gAddLog("getpassword.aspx", "GetPassUID", exp.Message);
                Response.Redirect("~/error.aspx?error=" + HttpUtility.UrlEncode("حدث خطأ اثناء محاولة إرسال اسم المستخدم/كلمة المرور ، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."),false);
            }
            finally
            {
                if(ProgramClass.drData!=null)
                    if (ProgramClass.drData.IsClosed == false)
                        ProgramClass.drData.Close();
            }
        }
    }
}
