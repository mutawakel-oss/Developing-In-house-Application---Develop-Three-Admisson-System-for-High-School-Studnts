using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    System.Data.Odbc.OdbcDataReader reader;
    GeneralClass.Program objProgram = new GeneralClass.Program();
    protected void Page_Load(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to populate the data grid "ConfigurationGrid"
        /// Author: mutawakelm
        /// Date :6/24/2009 3:13:33 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (Session["ConfigAuthorized"] == null)
                Response.Redirect("~/adminLogin.aspx",false);
            if (!IsPostBack)
            {
                mFillConfigurationGrid();
                mFillAdsGrid();
            }
            

        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillConfigurationGrid()
    {
        try
        {
            string strCollegesQuery = "";
            DataTable tblSystemCollegesConfiguration = new DataTable();//This table will contain the information of the collegs
            tblSystemCollegesConfiguration.Columns.Add("id");
            tblSystemCollegesConfiguration.Columns.Add("college_name");
            tblSystemCollegesConfiguration.Columns.Add("status");
            tblSystemCollegesConfiguration.Columns.Add("start_date");
            tblSystemCollegesConfiguration.Columns.Add("end_date");
            //The following query will retrieve the information of the system colleges
            strCollegesQuery = "SELECT * FROM college_preset";
            reader = objProgram.gRetrieveRecord(strCollegesQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tblSystemCollegesConfiguration.Rows.Add(reader["id"].ToString(), reader["college_name"].ToString(), reader["status"].ToString(), reader["publish_start_date"].ToString(), reader["publish_end_date"].ToString());
                }
                reader.Close();
                ConfigurationGrid.DataSource = tblSystemCollegesConfiguration;
                ConfigurationGrid.DataBind();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillAdsGrid()
    {

        //=====================================================//
        /// <summary>
        /// Description:This functino will be used to fill the ads grid "adsGrid"
        /// Author: mutawakelm
        /// Date :6/28/2009 12:15:23 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            DataTable tblSystemAds = new DataTable();//This table will contain the advertisement configuration
            tblSystemAds.Columns.Add("id");
            tblSystemAds.Columns.Add("ads_text");
            tblSystemAds.Columns.Add("status2");
            tblSystemAds.Columns.Add("start_date");
            tblSystemAds.Columns.Add("end_date");
            //The following query will retrieve the advertisments of the system
            string strCollegesQuery = "SELECT * FROM advertisement";
            reader = objProgram.gRetrieveRecord(strCollegesQuery);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tblSystemAds.Rows.Add(reader["id"].ToString(), reader["body_text"].ToString(), reader["status"].ToString(), reader["start_date"].ToString(), reader["end_date"].ToString());
                }
                reader.Close();
                adsGrid.DataSource = tblSystemAds;
                adsGrid.DataBind();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mEditConfiguration(object source, DataGridCommandEventArgs e)
    {
        try
        {

            ConfigurationGrid.EditItemIndex = e.Item.ItemIndex;
            mFillConfigurationGrid();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mCacnelEdit(object sender, DataGridCommandEventArgs e)
    {
        try
        {
            ConfigurationGrid.EditItemIndex = -1;
            mFillConfigurationGrid();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mUpdateConfiguration(object sender, DataGridCommandEventArgs e)
    {
        try
        {

            
            System.Web.UI.WebControls.TextBox CollegeId = new System.Web.UI.WebControls.TextBox();
            CollegeId = (System.Web.UI.WebControls.TextBox)e.Item.Cells[1].Controls[0];
            DataGridItem dg = e.Item;
            CheckBox status = (CheckBox)dg.FindControl("chkStatus");
            System.Web.UI.WebControls.TextBox CollegeStartDate = new System.Web.UI.WebControls.TextBox();
            CollegeStartDate = (System.Web.UI.WebControls.TextBox)e.Item.Cells[4].Controls[0];
            System.Web.UI.WebControls.TextBox CollegeEndDate = new System.Web.UI.WebControls.TextBox();
            CollegeEndDate = (System.Web.UI.WebControls.TextBox)e.Item.Cells[5].Controls[0];
            //The following code will update the selected college
            objProgram.Add("status", status.Checked.ToString(), "S");
            objProgram.Add("publish_start_date", CollegeStartDate.Text.ToString(), "D");
            objProgram.Add("publish_end_date", CollegeEndDate.Text.ToString(), "D");
            int returnId = objProgram.UpdateRecordStatement("college_preset", "id", CollegeId.Text);
            ConfigurationGrid.EditItemIndex = -1;
            mFillConfigurationGrid();
            
            
        }
        catch (Exception exp)
        {
        }
    }
    protected void mAddCollege(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to add a new college to the table "college_preset"
        /// Author: mutawakelm
        /// Date :6/28/2009 12:06:11 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//   
        try
        {
            objProgram.Add("college_name", txtCollegeName.Text, "S");
            objProgram.InsertRecordStatement("college_preset");
            mFillConfigurationGrid();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mAddAds(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to add a new advertisement into the table "advertisement"
        /// Author: mutawakelm
        /// Date :6/28/2009 12:25:39 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            objProgram.Add("body_text", txtAdsText.Text, "S");
            int returnId = objProgram.InsertRecordStatement("advertisement");
            mFillAdsGrid();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mEditSystemAds(object sender, DataGridCommandEventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to open the advertisement grid in the editing mode
        /// Author: mutawakelm
        /// Date :6/28/2009 12:42:58 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {

            adsGrid.EditItemIndex = e.Item.ItemIndex;
            mFillAdsGrid();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mCancelEditingAds(object sender, DataGridCommandEventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to cancel editing the grid
        /// Author: mutawakelm
        /// Date :6/28/2009 12:44:15 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            adsGrid.EditItemIndex = -1;
            mFillAdsGrid();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mUpdateAds(object sender, DataGridCommandEventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to update the selected ad
        /// Author: mutawakelm
        /// Date :6/28/2009 12:45:34 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            System.Web.UI.WebControls.TextBox adsId = new System.Web.UI.WebControls.TextBox();
            adsId = (System.Web.UI.WebControls.TextBox)e.Item.Cells[1].Controls[0];
            DataGridItem dg = e.Item;
            CheckBox status = (CheckBox)dg.FindControl("chkAdsStatus");
            System.Web.UI.WebControls.TextBox adsStartDate = new System.Web.UI.WebControls.TextBox();
            adsStartDate = (System.Web.UI.WebControls.TextBox)e.Item.Cells[4].Controls[0];
            System.Web.UI.WebControls.TextBox adsEndDate = new System.Web.UI.WebControls.TextBox();
            adsEndDate = (System.Web.UI.WebControls.TextBox)e.Item.Cells[5].Controls[0];
            System.Web.UI.WebControls.TextBox adsText = new System.Web.UI.WebControls.TextBox();
            adsText = (System.Web.UI.WebControls.TextBox)e.Item.Cells[2].Controls[0];
            //The following code will update the selected college
            objProgram.Add("body_text", adsText.Text.ToString(), "S");
            objProgram.Add("status", status.Checked.ToString(), "S");
            objProgram.Add("start_date", adsStartDate.Text.ToString(), "D");
            objProgram.Add("end_date", adsEndDate.Text.ToString(), "D");
            int returnId = objProgram.UpdateRecordStatement("advertisement", "id", adsId.Text);
            adsGrid.EditItemIndex = -1;
            mFillAdsGrid();
        }
        catch (Exception exp)
        {
        }
    }
}
