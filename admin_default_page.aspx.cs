using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mAuthenticate();
        }

    }
    protected void mAuthenticate()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to check the authority for the logged user
        /// If the user has a role of "system configuration controller" then he will be allowed to access
        /// the page.
        /// Author: mutawakelm
        /// Date :6/28/2009 2:20:05 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string[] userRoles = Session["AdminRole"].ToString().Split(',');
            for (int i = 0; i < userRoles.Length; i++)
            {
                if (userRoles[i] == "4")
                {
                    lnkSysConfig.Visible = true;
                    tdSystemConfig.Visible = true;
                }
                else
                    if (userRoles[i] == "1")
                    {
                        lnkReport.Visible = true;
                        tdReport.Visible = true;
                    }

                    else
                        if (userRoles[i] == "3")
                        {
                            lnkContacts.Visible = true;
                            tdContacts.Visible = true;
                        }
                        else
                            if (userRoles[i] == "2")
                            {
                                lnkUserPrivileges.Visible = true;
                                tdSystemUsers.Visible = true;
                            }
            }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mViweConfig(object sender, EventArgs e)
    {
        try
        {
            Session["ConfigAuthorized"] = "true";
            Response.Redirect("~/system_configuration.aspx",false);
        }
        catch (Exception exp)
        {
        }
    }
    protected void mViwerReports(object sender, EventArgs e)
    {
        try
        {
            Session["ReportAuthorized"] = "true";
            Response.Redirect("~/administrator_report.aspx", false);
        }
        catch (Exception exp)
        {
        }
    }
    protected void mViweContact(object sender, EventArgs e)
    {
        try
        {
            Session["contactAuthorized"] = "true";
            Response.Redirect("~/contact_list.aspx",false);
        }
        catch (Exception exp)
        {
        }
    }
    protected void mViweUsersControl(object sender, EventArgs e)
    {
        try
        {
            Session["mangeUserAuthorized"] = "true";
            Response.Redirect("~/usermanager.aspx",false);
        }
        catch (Exception exp)
        {
        }
    }
    
    

}
