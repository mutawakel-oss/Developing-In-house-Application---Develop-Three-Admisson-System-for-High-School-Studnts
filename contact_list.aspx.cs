#region Copyright KSU-HS,COM. 2009
//
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
// Filename: Contact_list.aspx.cs
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
    System.Data.DataTable dtContactSource = new System.Data.DataTable("dtContactSource");
    GeneralClass.Administrator objAdmin = new GeneralClass.Administrator();
    GeneralClass.Program objProgram = new GeneralClass.Program();
    protected void Page_Load(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This is the Load event of the Page
        /// Author: hussaint
        /// Date :6/20/2009 12:51:52 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (Session["AdminId"] == null ||Session["AdminId"].ToString().Equals(""))
            {
                Response.Redirect("adminlogin.aspx",false);
            }
            else
            {
                objAdmin.strUserId = Session["AdminId"].ToString();
                objAdmin.strRole = Session["AdminRole"].ToString();
                objAdmin.strColleges = Session["AdminColleges"].ToString();
            }
            
            if (!IsPostBack)
            {                
                objProgram.gFillDropDownList("SELECT id,college_name FROM college_preset WHERE id IN (" + objAdmin.strColleges + ")", ddlColleges);

                mFillGrid();                
            }

        }
        catch (Exception Page_Load_Exp)
        {

        }
        finally
        { 
        
        }
    }   
    
    protected void ddlColleges_Index_Changed(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to handle the Index Changed Event of the ddlColleges
        /// Author: hussaint
        /// Date :6/20/2009 2:24:26 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            mFillGrid();
            
        }
        catch (Exception ddlColleges_Index_Changed_Exp)
        {

        }
        finally
        { 
        
        }
    }
    private void mFillGrid()
    {

        //=====================================================//
        /// <summary>
        /// Description: will be used to Fill the Grid with contacts for Specific Institue.
        /// Author: hussaint
        /// Date :6/20/2009 5:15:17 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (ddlColleges.Items.Count == 0) return;

            dtContactSource = objProgram.gSqlDataTable("SELECT * FROM help_me WHERE college_id  = " + ddlColleges.SelectedValue + " and reason_for_contact='"+ddlCategory.SelectedItem.Text+"'  Order By date");
            grdContacts.DataSource = dtContactSource;
            grdContacts.DataBind();

        }
        catch (Exception mFillGrid_Exp)
        {

        }
        finally
        { 
        
        }
        
    }

    protected void lnkView_Clicked(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: It will handle the Clicked Event of the lnkView
        /// Author: hussaint
        /// Date :6/20/2009 3:18:48 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strAddress = "";

            LinkButton objTemp = (LinkButton)sender;
            strAddress = "contact_reply.aspx?Id=" + objTemp.CommandName;
            Response.Redirect(strAddress,false);

        }
        catch (Exception lnkView_Clicked_Exp)
        {

        }
        finally
        { 
        
        }
    }


    protected void grdContacts_PageIndexChaged(object sender, DataGridPageChangedEventArgs  e)
    {

        //=====================================================//
        /// <summary>
        /// Description: will be used to hanlde the PageIndexChanged Event of the Grid
        /// Author: hussaint
        /// Date :6/20/2009 5:03:08 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            grdContacts.CurrentPageIndex = e.NewPageIndex;
            mFillGrid();

        }
        catch (Exception grdContacts_PageIndexChaged_Exp)
        {

        }
        finally
        { 
        
        }
    }

}
