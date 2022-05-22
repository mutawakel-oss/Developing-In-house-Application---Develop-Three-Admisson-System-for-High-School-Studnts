using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    System.Data.Odbc.OdbcDataReader reader ;
    GeneralClass.Program objProgram = new GeneralClass.Program();
    protected void Page_Load(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to populate the terms and conditions of the selected college.
        /// Author: mutawakelm
        /// Date :6/22/2009 12:29:07 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (Session["college_id"] != null)
            {
                string strTermsQuery = "";
                DataTable tblTermsAndConditions = new DataTable();
                tblTermsAndConditions.Columns.Add("id");
                tblTermsAndConditions.Columns.Add("condition");
                DataTable tblRules = new DataTable();
                tblRules.Columns.Add("id");
                tblRules.Columns.Add("condition");
                DataTable tblFormula = new DataTable();
                tblFormula.Columns.Add("id");
                tblFormula.Columns.Add("condition");
                strTermsQuery = "SELECT terms_and_conditions,category FROM terms_and_conditions WHERE college_id=" + Session["college_id"].ToString();
                reader = objProgram.gRetrieveRecord(strTermsQuery);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["category"].ToString() == "1")
                            tblTermsAndConditions.Rows.Add("*", reader["terms_and_conditions"].ToString());
                        else
                            if (reader["category"].ToString() == "2")
                                tblRules.Rows.Add("*", reader["terms_and_conditions"].ToString());
                            else
                                if (reader["category"].ToString() == "3")
                                    tblFormula.Rows.Add("*", reader["terms_and_conditions"].ToString());
                        
                    }
                    reader.Close();
                    termsAndConditionGrid.DataSource = tblTermsAndConditions;
                    termsAndConditionGrid.DataBind();
                    RulesGrid.DataSource = tblRules;
                    RulesGrid.DataBind();
                    formulaGrid.DataSource = tblFormula;
                    formulaGrid.DataBind();
                }
                else
                    reader.Close();
                if (!IsPostBack)
                {
                    lblCollegeChoice.Text = "لقد قمت باختيار  " + Session["college_name"].ToString() + "،هل ترغب في المتابعة؟";
                    mpeSchoolGrades.Show();
                }
            }
            else
                Response.Redirect("~/index.aspx",false);
            //The following code will display the title of the page
            if (Session["college_name"] != null)
            {
                lblTitle.Text ="شروط وأنظمة القبول ب"+ Session["college_name"].ToString();
            }

          

        }
        catch (Exception exp)
        {
            objProgram.gAddLog("terms_condition.aspx", "Page_Load", exp.Message);
            Response.Redirect("~/error.aspx?error=" + HttpUtility.UrlEncode("حدث خطأ اثناء محاولة عرض شروط القبول، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."),false);
        }

    }
    protected void mAgreementCheckChanged(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be fired when the checking status changed for the check box "chkAgreement"
        /// Author: mutawakelm
        /// Date :6/22/2009 1:38:14 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {

            if (chkAgreement.Checked == true)
            {
                btnContinue.Enabled = true;
                btnContinue.CssClass = "button";
            }
            else
            {
                btnContinue.Enabled = false;
                btnContinue.CssClass = "button buttondisabled";
            }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mGoToRegister(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to redirect the user to the registration page "register.aspx"
        /// Author: mutawakelm
        /// Date :6/22/2009 2:01:15 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {           

            Session["college_id"] = Session["college_id"].ToString();
            Session["college_name"] = Session["college_name"].ToString();
            Session["gender"] = Session["gender"].ToString();
            Response.Redirect("~/register.aspx",false);
        }
        catch (Exception exp)
        {
            //objProgram.gAddLog("terms_condition.aspx", "mGoToRegister", exp.Message);
            //Response.Redirect("~/error.aspx?error=" + HttpUtility.UrlEncode("حدث خطأ اثناء محاولة عرض صفحة التسجيل، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."));
        }
    }
   
}
