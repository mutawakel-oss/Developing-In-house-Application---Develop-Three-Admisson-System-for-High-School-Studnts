using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class statistics : System.Web.UI.Page
{
    protected int widestData;

    GeneralClass.Program ProgramClass = new GeneralClass.Program();
    protected void Page_Load(object sender, EventArgs e)
    {
        widestData = 0;

        if (Request.QueryString["col_id"] == null)
        {
            Button2.Enabled = false;
        }
    }

    protected void Export(object o, EventArgs e)
    {
        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than

        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite =
        new HtmlTextWriter(stringWrite);

        GridView1.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());

        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void RowDelete(object o, GridViewDeleteEventArgs e)
    {
        GridView1.Rows[e.RowIndex].Visible = false;
    }

    protected void Create(object o, EventArgs e)
    {
        GridView1.DataSource = null;
        
        ProgramClass.strSql = "SELECT     student_registration.id," +
                         "student_registration.first_name_ar + ' ' + student_registration.father_name_ar + ' ' + student_registration.last_name_ar + ' ' + student_registration.grand_father_ar AS Name," +
                         " student_registration.local_id [LocalID], student_registration.place_of_birth [POB], student_registration.mobile [Mobile], student_registration.home_phone [Tel], student_registration.email_address [Email], " +
                         " '05' + student_registration.ref_mobile AS [RefMob], student_registration.ref_name [RefName], student_registration.ref_home_phone [Tele], student_registration.ref_work_phone [WorkTel], " +
                         " student_registration.secondary_option [2ndOpt], student_academic_data.school_name [School], city_preset.city_name [City], " +
                         " imported_data_new.gudrat_grade [Kudrat],exam_period [Year], ROUND(imported_data_new.gudrat_grade * 0.30, 2) [Kudrat%], " +
                         " Tehseeli_results.tahsili_mark [Tahsili], ROUND(Tehseeli_results.tahsili_mark * 0.35, 2) AS [Tahsili%], High_School_Master.SecondYearPercentage [2ndyr%], " +
                         " High_School_Master.ThirdYearPercent [3rdyr%], CASE secondyearpercentage WHEN 0 THEN round(thirdyearpercent * 0.35, 2) " +
                         " ELSE round(((secondyearpercentage + thirdyearpercent) / 2) * 0.35, 2) END AS GPA, " +
                         " imported_data_new.gudrat_grade * 0.30 + ROUND(Tehseeli_results.tahsili_mark * 0.35, 2) + CASE secondyearpercentage WHEN 0 THEN round(thirdyearpercent * 0.35, 2)  " +
                         " ELSE round(((secondyearpercentage + thirdyearpercent) / 2) * 0.35, 2) END AS Total,program_options " +
                         " FROM         student_registration INNER JOIN " +
                         " student_academic_data ON student_registration.id = student_academic_data.student_id LEFT OUTER JOIN " +
                         " city_preset ON student_academic_data.city = city_preset.id LEFT OUTER JOIN " +
                         " High_School_Master ON CONVERT(varchar(10), student_registration.local_id) = High_School_Master.local_id LEFT OUTER JOIN " +
                         " Tehseeli_results ON student_registration.local_id = Tehseeli_results.local_id LEFT OUTER JOIN " +
                         " imported_data_new ON student_registration.local_id = imported_data_new.local_id " +
                         " WHERE     (student_registration.status_id = 1) AND (student_registration.college_id =" + Request.QueryString["col_id"].ToString() + ")" +
                         " ORDER BY Total DESC";
        ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);
     
        GridView1.DataSource = ProgramClass.drData;
        GridView1.DataBind();
        ProgramClass.drData.Close();



        for (int i = 1; i < GridView1.Rows.Count; i++)
        {
            Label lblLocalID = (Label)GridView1.Rows[i].Cells[1].FindControl("lblLocalID");
            string CurrentStr = lblLocalID.Text;// GridView1.Rows[i].Cells[1].FindControl("lblLocalID").Text;
            if (i < GridView1.Rows.Count - 1)
            {
                Label lblLocalID_1 = (Label)GridView1.Rows[i+1].Cells[1].FindControl("lblLocalID");
                string NextStr = lblLocalID_1.Text;// GridView1.Rows[i + 1].Cells[1].Text;
                if (CurrentStr.Trim() == NextStr.Trim())
                {
                    Label lblValue1 = (Label)GridView1.Rows[i].Cells[1].FindControl("lblKudrat");
                    Label lblValue2 = (Label)GridView1.Rows[i].Cells[1+1].FindControl("lblKudrat");
                    double Value1 = Convert.ToDouble(lblValue1.Text.Trim());
                    double Value2 = Convert.ToDouble(lblValue2.Text.Trim());
                    if (Value1 == Value2)
                    {
                        GridView1.DeleteRow(i);
                        GridView1.Rows[i].Visible = false;
                    }
                }
            }
        }
        
        //for (int i = 0; i < GridView1.Columns.Count; i++)
        //{
        //    GridView1.Columns[i].ItemStyle.Width = 150;
        //}
        //Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than

        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite =
        new HtmlTextWriter(stringWrite);

        GridView1.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());

        Response.End();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //System.Data.Common.DbDataRecord drv;
        //if (e.Row.DataItem != null)
        //{
        //    drv = (System.Data.Common.DbDataRecord)e.Row.DataItem;
            
        //    GridView1.Columns[1].ItemStyle.Width = widestData * 30;
        //    //if (e.Row.GetType().Name == "GridViewRow")
        //    //{
        //    //    drv = (System.Data.DataRowView)e.Row.DataItem;
        //    //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    //    {
        //    //        if (drv != null)
        //    //        {
        //    //            String catName = drv[1].ToString();
        //    //            Response.Write(catName + "/");

        //    //            int catNameLen = catName.Length;
        //    //            if (catNameLen > widestData)
        //    //            {
        //    //                widestData = catNameLen;
        //    //                GridView1.Columns[2].ItemStyle.Width =
        //    //                  widestData * 30;
        //    //                GridView1.Columns[2].ItemStyle.Wrap = false;
        //    //            }

        //    //        }
        //    //    }
        //    //}
        //}
    }


}
