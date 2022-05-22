using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    GeneralClass.Program objProgram = new GeneralClass.Program();
    GeneralClass.Student objStudent = new GeneralClass.Student();
    System.Data.Odbc.OdbcDataReader reader;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to populate the college drop down list "ddlColleges" and the adverstisments
        /// Author: mutawakelm
        /// Date :6/22/2009 10:47:03 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            
            string  strCollegesQuery = "";
            string strAdsQuery = "";//This 
            
            if (!IsPostBack)
            {
                Session.Abandon();
                ddlColleges.Items.Clear();
                ddlColleges.Items.Add("");
                ddlColleges.Items[0].Text = "";
                ddlColleges.Items[0].Value = "nothing";

                string SQLQuery = "select id,college_name from college_preset where status=0 and publish_start_date<=getdate() and publish_end_date>=getdate()";

                objProgram.gFillDropDownList(SQLQuery, ddlColleges);//"select id,college_name from college_preset where (status=0 and publish_start_date<='" + DateTime.Now + "' and publish_end_date>='"+DateTime.Now+"')", ddlColleges);
                
                
                strAdsQuery = "SELECT * FROM advertisement WHERE status=0 and start_date<=getdate() and end_date>=getdate()";                
                reader = objProgram.gRetrieveRecord(strAdsQuery);
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        literalAds.Text += reader["body_text"].ToString() + "<br><br><hr>";
                    }
                    reader.Close();
                }
                else reader.Close();
                
                             
            }

        }
        catch (Exception exp)
        {            
            if (reader != null)
                reader.Close();
            objProgram.gAddLog("Index", "Form_Load", exp.Message);
            Response.Redirect("~/error.aspx?error="+HttpUtility.UrlEncode("حدث خطأ، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."),false);
        }

    }
      protected void mContinueButtonClicked(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 90;
            Session["college_id"] = ddlColleges.SelectedItem.Value.ToString();
            Session["college_name"] = ddlColleges.SelectedItem.Text.ToString();            
            HttpContext.Current.Response.Redirect("terms_condition.aspx",false);
        }
        catch (Exception exp)
        {
            objProgram.gAddLog("Index", "mContinueButtonClicked", exp.Message);
            Response.Redirect("~/error.aspx?error=" + HttpUtility.UrlEncode("حدث خطأ، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."),false);
        }
    }
      protected void mShowCollegesExtender(object sender, EventArgs e)
      {

          //=====================================================//
          /// <summary>
          /// Description:This function will be used to show the colleges extender "CollegeChoiceExtnder"
          /// Author: mutawakelm
          /// Date :6/22/2009 12:00:07 PM
          /// Parameter:
          /// input:
          /// output:
          /// Example:
          /// <summary>
          //=====================================================//
          try
          {
              //The following code will be used to check if the registerer has chosen a college.
              Session["college_id"] = ddlColleges.SelectedItem.Value.ToString();
              Session["college_name"] = ddlColleges.SelectedItem.Text.ToString();
              Session["gender"] = ddlGender.SelectedItem.Value.ToString(); 
              HttpContext.Current.Response.Redirect("terms_condition.aspx",false);
          }
          catch (Exception exp)
          {
          }
      }
      protected void btnLogin_Click(object sender, EventArgs e)
      {

          //=====================================================//
          /// <summary>
          /// Description: This would be used to handle the Click Event of the btnLogin
          /// Author: hussaint
          /// Date :6/29/2009 10:55:35 AM
          /// Parameter:
          /// input:
          /// output:
          /// Example:
          /// <summary>
          //=====================================================//
          try
          {   
              Session["StudentId"] = null;
              
              objStudent.SignIn(txtUserName.Text.Trim(), txtPassword.Text.Trim(), "M", "S");


              if (!objStudent.strUserId.Equals(""))
              {
                  if (Session["StudentId"] == null || Session["StudentId"].ToString().Equals(""))
                  {

                      Session.Add("StudentId", objStudent.strUserId);
                      Session["college_id"] = objStudent.strColleges;

                      HttpContext.Current.Response.Redirect("~/register.aspx",false);
                  }


              }
              else
              {
                  mpeLoginFailure.Show();
              }
          }
          catch (Exception btnLogin_Click_Exp)
          {
              objProgram.gAddLog("Index", "btnLogin_Click", btnLogin_Click_Exp.Message);
              Response.Redirect("~/error.aspx?error=" + HttpUtility.UrlEncode("حدث خطأ اثناء محاولة الدخول، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."),false);
          }
          finally
          { 
          
          }
      }
      protected void mAssuranceCheckChanged(object sender, EventArgs e)
      {
          try
          {             

              if (chkAssurance.Checked == true)
              {
                  btnNext.Enabled = true;
                  btnNext.CssClass = "button";
              }
              else
              {
                  btnNext.Enabled = false;
                  btnNext.CssClass = "button buttondisabled";
              }
          }
          catch (Exception exp)
          {
          }
      }

}
