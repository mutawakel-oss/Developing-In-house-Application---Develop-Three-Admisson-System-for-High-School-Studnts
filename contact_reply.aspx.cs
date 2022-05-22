#region Copyright KSU-HS,COM. 2009
//
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
// Filename: Contact_Reply.aspx.cs
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
    GeneralClass.Administrator objAdmin = new GeneralClass.Administrator();
    GeneralClass.Program objProgram = new GeneralClass.Program();
    string strRequestId;

    protected void Page_Load(object sender, EventArgs e)
    {
        

        //=====================================================//
        /// <summary>
        /// Description: This will handle the Page Load Event of the Page
        /// Author: hussaint
        /// Date :6/21/2009 9:30:28 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            strRequestId = "";

            if (Session["AdminId"] == null || Session["AdminId"].ToString().Equals(""))
            {
                Response.Redirect("adminlogin.aspx",false);
            }
            else
            {
                objAdmin.strUserId = Session["AdminId"].ToString();
                objAdmin.strRole = Session["AdminRole"].ToString();
            }

            if (!IsPostBack)
            {

                if (Request.QueryString.Count > 0)
                {
                    strRequestId = Request.QueryString[0];
                    btnSave.CommandName = strRequestId;
                    mFillContactRequest(strRequestId);

                }
                else
                {
                    Response.Redirect("contact_list.apx",false);
                }
            }

        }
        catch (Exception Page_Load_Exp)
        {

        }
        finally
        { 
        
        }
    }
    private void mFillContactRequest(string strRequestID)
    {

        //=====================================================//
        /// <summary>
        /// Description:This would be used to fill the details for the Contact Request
        /// Author: hussaint
        /// Date :6/21/2009 9:54:51 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            objProgram.strSql = "SELECT * FROM help_me WHERE id = " + strRequestID;
            objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
            if (objProgram.drData.Read())
            {
                txtApplicantName.Text = objProgram.drData["fullname"].ToString();
                txtStudID.Text = objProgram.drData["local_id"].ToString();
                txtEmail.Text = objProgram.drData["email_address"].ToString();
                txtMobile.Text = objProgram.drData["mobile"].ToString();
                txtHomePhone.Text = objProgram.drData["home_phone"].ToString();
                txtDetail.Text = objProgram.drData["long_description"].ToString();
                txtReply.Text = objProgram.drData["reply_text"].ToString();
                ddlProblemCateogry.SelectedItem.Text = objProgram.drData["reason_for_contact"].ToString();

            }

            objProgram.drData.Close();

        }
        catch (Exception mFillContactRequest_Exp)
        {
            if (objProgram.drData != null) objProgram.drData.Close();
        }
        finally
        {
            if (objProgram.drData != null) objProgram.drData.Close();
        }
    }

    protected void btnSave_Clicked(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to handle the Clicked event of Save Button
        /// Author: hussaint
        /// Date :6/21/2009 10:09:12 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            objProgram.SendMail("Help@ksau-hs.edu.sa", txtEmail.Text, "بخصوص طلب المساعدة المرسل إلى نظام التسجيل الإلكتروني بجامعة الملك سعود بن عبدالعزيز للعلوم الصحية", txtReply.Text);
            objProgram.strSql = "Update help_me SET reply_text = '" + txtReply.Text.Trim() + "',replied_by = '" + objAdmin.strUserId + "' WHERE id = " + btnSave.CommandName;
            objProgram.gDeleteRecord(objProgram.strSql);
            Response.Redirect("~/contact_list.aspx",false);
        }
        catch (Exception btnSave_Clicked_Exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void CancelClick(object sender, EventArgs e)
    {
        Response.Redirect("~/contact_list.aspx",false);
    }
}
