#region Copyright KSU-HS,COM. 2009
//
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
// Filename: Contact.aspx.cs
// Versio  : 1.0
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    GeneralClass.Program objProgram = new GeneralClass.Program();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //=====================================================//
        /// <summary>
        /// Description:
        /// Author: hussaint
        /// Date :6/18/2009 1:07:53 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (!IsPostBack)
            {
                mFillColleges();
                
                
 
            }

        }
        catch (Exception Page_Load_Exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {

            Response.Redirect("~/index.aspx",false); 
        }
        catch (Exception exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: used for the event handler of the Save Button
        /// Author: hussaint
        /// Date :6/18/2009 1:09:38 PM
        /// Parameter:
        /// input: object sender, EventArgs e
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {

            objProgram.Add("local_id", txtStudID.Text.Trim(), "I");
            objProgram.Add("fullname", txtApplicantName.Text.Trim(), "S");
            objProgram.Add("email_address", txtEmail.Text.Trim(), "S");
            objProgram.Add("mobile", ddlMobilePrefix.SelectedItem.Text + txtMobile.Text.Trim(), "I");
            objProgram.Add("home_phone", ddlCitZip.SelectedItem.Text + txtHomePhone.Text.Trim(), "I");
            objProgram.Add("reason_for_contact", ddlProblemCateogry.SelectedItem.Text, "S");
            objProgram.Add("long_description", txtDetail.Text.Trim(), "S");
//            objProgram.Add("date", DateTime.Now.ToShortDateString(), "D");
            objProgram.Add("college_id", ddlCollegeName.SelectedValue.ToString(), "I");


            objProgram.intResult = objProgram.InsertRecordStatement("help_me");

            if (objProgram.intResult > 0)
            {
                mClearControls();
                
                Response.Redirect("~/index.aspx",false);
            }
 


        }
        catch (Exception btnSave_Click_Exp)
        {

        }
        finally
        { 
        
        }
    }
    private void mClearControls()
    {

        //=====================================================//
        /// <summary>
        /// Description:
        /// Author: hussaint
        /// Date :6/18/2009 2:15:10 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            txtApplicantName.Text = "";
            txtStudID.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtHomePhone.Text = "";
            txtDetail.Text = "";
            ddlProblemCateogry.SelectedIndex = 0;
            ddlCollegeName.SelectedIndex = 0;

        }
        catch (Exception mClearControls_Exp)
        {

        }
        finally
        { 
        
        }
    }
    private void mFillColleges()
    {

        //=====================================================//
        /// <summary>
        /// Description: Fill the Colleges Combo Box
        /// Author: hussaint
        /// Date :6/20/2009 11:57:18 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            objProgram.gFillDropDownList("select id,college_name from college_preset where status=0 and publish_start_date<=getdate() and publish_end_date>=getdate()", ddlCollegeName);          
            

        }
        catch (Exception mFillColleges_Exp)
        {

        }
        finally
        { 
        
        }
    }
}
