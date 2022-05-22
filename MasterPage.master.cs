public partial class MasterPage_master : System.Web.UI.MasterPage
{


    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Session["college_name"] != null)
            {
                GlobalCollegeName.Text = Session["college_name"].ToString();
            }
        if (Session["StudentId"] != null || Session["AdminId"] !=null)
        {
            LinkButton1.Visible = true;
        }

    }
    protected void Logout(object o, System.EventArgs e)
    {
        try
        {
            if (Session["StudentId"] != null)
            {
                Session.Abandon();
                Response.Redirect("~/index.aspx", false);
            }
            else if (Session["AdminId"] != null)
            {
                Session.Abandon();
                Response.Redirect("~/adminlogin.aspx", false);
            }
        }
        catch
        {
        }
    }
}
