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

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to get the error message text from the "queryString" then assign it 
        /// to the label "lblErrorText"
        /// Author: mutawakelm
        /// Date :7/9/2009 11:28:47 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (Request.QueryString["error"] != null)
                lblErrorText.Text =HttpUtility.UrlDecode(Request.QueryString["error"].ToString());
        }
        catch (Exception exp)
        {
        }

    }
}
