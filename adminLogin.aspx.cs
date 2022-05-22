    #region Copyright KSU-HS,COM. 2009
//
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
// Filename: AdminLogin.cs
//
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;

public partial class _Default : System.Web.UI.Page
{
    GeneralClass.Administrator objAdmin = new GeneralClass.Administrator();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                
            }
        }
        catch (Exception exp)
        {

        }
        finally
        { 
        
        }
    }    
    protected void btnLogin_Click(object sender, AuthenticateEventArgs e)
    {
        try
        {            
            if (!objAdmin.SignIn(Login.UserName, Login.Password.Trim(), "M", "A"))
            {                
                return;
            }
            else
            {
                Session.Timeout = 90;
                Session.Add("AdminId", objAdmin.strUserId);
                Session.Add("AdminRole", objAdmin.strRole);
                Session.Add("AdminColleges", objAdmin.strColleges);
                Response.Redirect("~/admin_default_page.aspx",false);
            }
        }
        catch (Exception exp)
        {

        }
        finally
        {

        }

    }
}
