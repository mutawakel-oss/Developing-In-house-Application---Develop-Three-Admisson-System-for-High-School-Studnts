#region Copyright KSU-HS,COM. 2009
//
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
// Filename: Default2.cs
// File Version: 0.1
//
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
public partial class Default2 : System.Web.UI.Page
{
    GeneralClass.Program ProgramClass = new GeneralClass.Program();

    DataTable myDt;

    /// <summary>
    /// Populate College Names in CollegeNameDropDown from the database table college_preset
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
   {
        ///In this Page load event, populate the combobox with college data.
        ///Fields used from the college_preset database tables are:
        ///1-   id;             this will be the value identifier for the combobox.
        ///2-   college_name    this is the text identifier for the combobox.
        ///
        ///The default value for the combo box should be "اختر الكلية"
       if (Session["AdminId"] == null || Session["AdminId"].ToString().Equals(""))
       {
           Response.Redirect("adminlogin.aspx", false);
       }

        if (!IsPostBack)
        {   
            ProgramClass.strSql = "SELECT id,college_name FROM college_preset";
            ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);

            System.Web.UI.WebControls.ListItem Item = new System.Web.UI.WebControls.ListItem();
            Item.Text = "اختر الكلية";
            CollegeNameDropDown.Items.Add(Item);
            while (ProgramClass.drData.Read())
            {
                Item = new System.Web.UI.WebControls.ListItem();
                Item.Value  =ProgramClass.drData[0].ToString();
                Item.Text   =ProgramClass.drData[1].ToString();
                CollegeNameDropDown.Items.Add(Item);
            }
            ProgramClass.drData.Close();
            CollegeNameDropDown.SelectedIndex = -1;
        }

        myDt = new DataTable();
        ///CreateDataTable is a function to create the dataview structure which will be visible in the web page.        
        ///this function will return DataTable object which will be used for populating the registration records.
        myDt = CreateDataTable();
        Session["myDatatable"] = myDt;

        string ClientScript = "window.open('" +
                HttpContext.Current.Server.MapPath(System.Configuration.
                ConfigurationManager.AppSettings["ReportLocation"]) + "Report.pdf" + "')";
        PrintCommand.Attributes.Add("Onclick", ClientScript);
    }

    protected void GridView1_OnPageIndexChanged(object sender, GridViewPageEventArgs e )
    {
        try
        {            
            GridView1.PageIndex = e.NewPageIndex;
            SearchClick(SearchButton, new EventArgs());
        }
        catch (Exception exp)
        {

        }
        finally
        { 
        
        }
    }
    /// <summary>
    /// CreateDataTable function return a DataTable with fields to hold data.
    /// </summary>
    /// <returns></returns>
    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();
        DataColumn myDataColumn;

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Index";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "StudentID";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "LocalID";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "StudentName";
        myDataTable.Columns.Add(myDataColumn);
        //POB
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "POB";
        myDataTable.Columns.Add(myDataColumn);

        //Mobile
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Mobile";
        myDataTable.Columns.Add(myDataColumn);

        //Home Phone
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "HomePhone";
        myDataTable.Columns.Add(myDataColumn);
        //Email
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Email";
        myDataTable.Columns.Add(myDataColumn);
        //Ref Mobile
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "RefMobile";
        myDataTable.Columns.Add(myDataColumn);

        //Ref Name
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "RefName";
        myDataTable.Columns.Add(myDataColumn);

        //RefWorkPhone
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "RefWorkPhone";
        myDataTable.Columns.Add(myDataColumn);

        //SchoolName
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "SchoolName";
        myDataTable.Columns.Add(myDataColumn);

        //SchoolCity
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "SchoolCity";
        myDataTable.Columns.Add(myDataColumn);

        //Kudrat
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Kudrat";
        myDataTable.Columns.Add(myDataColumn);

        //Kudrat%
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "KudratPercentage";
        myDataTable.Columns.Add(myDataColumn);

        //Tahseeli
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Tahseeli";
        myDataTable.Columns.Add(myDataColumn);

        //Tahseeli%
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TahseeliPercentage";
        myDataTable.Columns.Add(myDataColumn);

        //2ndYear%
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "SecondYearPercentage";
        myDataTable.Columns.Add(myDataColumn);

        //3rdYear%
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ThirdYearPercentage";
        myDataTable.Columns.Add(myDataColumn);

        //HighSchool%
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "HighSchoolPercentage";
        myDataTable.Columns.Add(myDataColumn);

        //Total
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Total";
        myDataTable.Columns.Add(myDataColumn);
        

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.Boolean");
        myDataColumn.ColumnName = "visibility";
        myDataTable.Columns.Add(myDataColumn); 
        

        return myDataTable;
    }

    /// <summary>
    /// On selection changed event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CollegeChanged(object sender,EventArgs e)
    {
        ProgramNameDropDown.Items.Clear();
        if (CollegeNameDropDown.SelectedValue.ToString() == "-1")
            return;
        try
        {
            System.Web.UI.WebControls.ListItem Item = new System.Web.UI.WebControls.ListItem();
            Item.Value = "-1";
            Item.Text = " ";
            ProgramNameDropDown.Items.Add(Item);
            ProgramClass.strSql = "SELECT id,program_name FROM program_preset WHERE college_id=" + CollegeNameDropDown.SelectedValue.ToString();
            ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);
            while (ProgramClass.drData.Read())
            {
                if (ProgramClass.drData[1].ToString().Trim() != "اختر")
                {
                    Item = new System.Web.UI.WebControls.ListItem();
                    Item.Value = ProgramClass.drData[0].ToString();
                    Item.Text = ProgramClass.drData[1].ToString();
                    ProgramNameDropDown.Items.Add(Item);
                }
            }
            ProgramClass.drData.Close();

            ProgramNameDropDown.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            if( ProgramClass.drData!=null)
                ProgramClass.drData.Close();
            HttpContext.Current.Response.Redirect("app_exception.aspx?errorcode=" + ex.Message,false);
        }

    }

    /// <summary>
    /// Click the search button to retrieve the data from 
    /// student_registration and student_academic_data database table.
    /// Controls used to create the report;
    /// 1-  radio button to get data for "new registration" OR
    /// 2-  radio button to get data for "interview invited".
    /// 
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void SearchClick(object o, EventArgs e)
    {
        HyperLink1.NavigateUrl = "statistics.aspx?col_id=" + CollegeNameDropDown.SelectedValue.ToString();
        HyperLink1.Visible = true;
        return;
        try
        {
            //Add this session for graph
            Session.Add("graph_id", CollegeNameDropDown.SelectedValue.ToString());
            
            int intIndex = 0;
            string SQLWhereClause = "";
            SQLWhereClause = "SELECT ";
            
            
            string strStatus = "";
            //if New Registrations option radio button clicked.
            if (TopNewCandidatesRadioButton.Checked == true)
            {
                strStatus = " AND status_id=1 ";//1=new registration
            }
            //if Invited for Interview option radio button clicked.
            else if (TopInvitedCandidatesRadioButton.Checked == true)
            {
                strStatus = " AND status_id=2 ";//1=new registration
            }
            //Generate the SQL statment with the above mentioned parameters.

            //string strSQL = "SELECT     student_registration.id, " +
            //          "student_registration.first_name_ar + ' ' + student_registration.father_name_ar + ' ' + student_registration.last_name_ar + ' ' + student_registration.grand_father_ar AS StudentName," +
            //          "student_registration.local_id, student_registration.place_of_birth, student_registration.mobile, student_registration.home_phone, student_registration.email_address, " +
            //          "'05' + student_registration.ref_mobile AS ref_mobile, student_registration.ref_name, student_registration.ref_home_phone, student_registration.ref_work_phone, " +
            //          "student_registration.secondary_option, student_academic_data.school_name, city_preset.city_name, imported_data.gudrat_grade, ROUND(imported_data.gudrat_grade * 0.30, 2) AS Kudrat, " +
            //          "Tehseeli_results.tahsili_mark, ROUND(Tehseeli_results.tahsili_mark * 0.35, 2) AS Expr2, High_School_Master.SecondYearPercentage, " +
            //          "High_School_Master.ThirdYearPercent, CASE secondyearpercentage WHEN 0 THEN round(thirdyearpercent * 0.35, 2) " +
            //          " ELSE round(((secondyearpercentage + thirdyearpercent) / 2) * 0.35, 2) END AS High_School_Marks, " +
            //          " imported_data.gudrat_grade * 0.30 + ROUND(Tehseeli_results.tahsili_mark * 0.35, 2) + CASE secondyearpercentage WHEN 0 THEN round(thirdyearpercent * 0.35, 2) " +
            //          " ELSE round(((secondyearpercentage + thirdyearpercent) / 2) * 0.35, 2) END AS Total " +
            //          " FROM         student_registration INNER JOIN student_academic_data ON student_registration.id = student_academic_data.student_id LEFT OUTER JOIN " +
            //          " city_preset ON student_academic_data.city = city_preset.id LEFT OUTER JOIN " +
            //          " High_School_Master ON CONVERT(varchar(10), student_registration.local_id) = High_School_Master.local_id LEFT OUTER JOIN " +
            //          " Tehseeli_results ON student_registration.local_id = Tehseeli_results.local_id LEFT OUTER JOIN " +
            //          " imported_data ON student_registration.local_id = imported_data.local_id" +
            //          "  WHERE     (student_registration.status_id = 1)  AND High_School_Master.ThirdYearPercent>0 AND secondyearpercentage>0 AND tahsili_mark>0 AND imported_data.gudrat_grade>0 ";

            string strSQL = "SELECT     student_registration.id, " +
                     "student_registration.first_name_ar + ' ' + student_registration.father_name_ar + ' ' + student_registration.last_name_ar + ' ' + student_registration.grand_father_ar AS StudentName," +
                     "student_registration.local_id, student_registration.place_of_birth, student_registration.mobile, student_registration.home_phone, student_registration.email_address, " +
                     "'05' + student_registration.ref_mobile AS ref_mobile, student_registration.ref_name, student_registration.ref_home_phone, student_registration.ref_work_phone, " +
                     "student_registration.secondary_option, student_academic_data.school_name, city_preset.city_name, imported_data.gudrat_grade, ROUND(imported_data.gudrat_grade * 0.30, 2) AS Kudrat, " +
                     "Tehseeli_results.tahsili_mark, ROUND(Tehseeli_results.tahsili_mark * 0.35, 2) AS Expr2, High_School_Master.SecondYearPercentage, " +
                     "High_School_Master.ThirdYearPercent, CASE secondyearpercentage WHEN 0 THEN round(thirdyearpercent * 0.35, 2) " +
                     " ELSE round(((secondyearpercentage + thirdyearpercent) / 2) * 0.35, 2) END AS High_School_Marks, " +
                     " imported_data.gudrat_grade * 0.30 + ROUND(Tehseeli_results.tahsili_mark * 0.35, 2) + CASE secondyearpercentage WHEN 0 THEN round(thirdyearpercent * 0.35, 2) " +
                     " ELSE round(((secondyearpercentage + thirdyearpercent) / 2) * 0.35, 2) END AS Total " +
                     " FROM         student_registration INNER JOIN student_academic_data ON student_registration.id = student_academic_data.student_id LEFT OUTER JOIN " +
                     " city_preset ON student_academic_data.city = city_preset.id LEFT OUTER JOIN " +
                     " High_School_Master ON CONVERT(varchar(10), student_registration.local_id) = High_School_Master.local_id LEFT OUTER JOIN " +
                     " Tehseeli_results ON student_registration.local_id = Tehseeli_results.local_id LEFT OUTER JOIN " +
                     " imported_data ON student_registration.local_id = imported_data.local_id" +
                     "  WHERE     (student_registration.status_id = 1)  AND High_School_Master.ThirdYearPercent>0 AND secondyearpercentage>0 AND tahsili_mark>0 AND imported_data.gudrat_grade>0 ";
                      
           
            //for the selected College Name.
            if (CollegeNameDropDown.SelectedIndex != 0)
            {
                ProgramClass.strSql +=strSQL+ " AND college_id=" + CollegeNameDropDown.SelectedValue.ToString();
            }
            //with Total Marks arranged in DESC
            ProgramClass.strSql += "  ORDER BY Total DESC"; 
            //finally retrieve the records.
            ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);
            
            while (ProgramClass.drData.Read())
            {
                intIndex++;
                DataRow row         = myDt.NewRow();
                row["Index"]        = intIndex.ToString();
                row["LocalID"]      = ProgramClass.drData[2].ToString();
                row["StudentName"]  = ProgramClass.drData[1].ToString();
                row["POB"] = ProgramClass.drData[3].ToString();
                row["mobile"] ="05"+ ProgramClass.drData[4].ToString();
                row["HomePhone"] = ProgramClass.drData[5].ToString();
                row["Email"] = ProgramClass.drData[6].ToString();
                row["RefMobile"] = ProgramClass.drData[7].ToString();
                row["RefName"] = ProgramClass.drData[8].ToString();
                row["RefWorkPhone"] = ProgramClass.drData[9].ToString();
                row["SchoolName"] = ProgramClass.drData[12].ToString();
                row["SchoolCity"] = ProgramClass.drData[13].ToString();

                //row["Kudrat"] = ProgramClass.drData[14].ToString();
                //row["KudratPercentage"] = ProgramClass.drData[15].ToString();
                row["Tahseeli"] = ProgramClass.drData[16].ToString();
                row["TahseeliPercentage"] = ProgramClass.drData[17].ToString();
                row["SecondYearPercentage"] = ProgramClass.drData[18].ToString();
                row["ThirdYearPercentage"] = ProgramClass.drData[19].ToString();
                row["HighSchoolPercentage"] = ProgramClass.drData[20].ToString();
                row["Total"] = ProgramClass.drData[21].ToString();
                //if (ProgramClass.drData["highschool_grade"].ToString() != "")
                //{
                //    double dml1 = double.Parse(ProgramClass.drData["highschool_grade"].ToString());
                //    double dml2 = (dml1 * 35) / 100;
                //    row["highschool_grade"]=dml2.ToString();

                //    dblTotal += dml2;
                //}
                //else
                //{
                //    row["highschool_grade"] = ProgramClass.drData[3].ToString();
                //}
                //if (ProgramClass.drData[4].ToString() != "")
                //{
                //    double dblGod = double.Parse(ProgramClass.drData[4].ToString());
                //    double dblGod2 = dblGod * 0.30;
                //    row["gudrat_grade"] = dblGod2.ToString();

                //    dblTotal += dblGod2;
                //}
                //else
                //{
                //    row["gudrat_grade"] = ProgramClass.drData[4].ToString();
                //}
                //if (ProgramClass.drData[5].ToString() != "")
                //{
                //    double dblKnow = double.Parse(ProgramClass.drData[5].ToString());
                //    double dblKnow2 = dblKnow * 0.35;
                //    row["tahseeli_grade"] = dblKnow2.ToString();

                //    dblTotal += dblKnow2;
                //}
                //else
                //{
                //    row["tahseeli_grade"] = ProgramClass.drData[5].ToString();
                //}

                //row["total_marks"]  = dblTotal.ToString();
                ////Session.Add("StudentId", ProgramClass.drData[0].ToString());
                //row["link_url"]     = "Report_admin.aspx?student_id=" + ProgramClass.drData[0].ToString();
                //row["email_address"] = ProgramClass.drData[7].ToString();

                //if(ProgramClass.drData[8].ToString()=="1")
                //    row["visibility"] = true;
                //else if (ProgramClass.drData[8].ToString() == "2")
                //    row["visibility"] = false;
                //string[] p_options=ProgramClass.drData[9].ToString().Split(',');
                //string Programs = "";
                //for (int x = 0; x < p_options.Length; x++)
                //{
                //    Programs +=p_options[x]+ "<br>";
                //}
                //row["program_options"] = Programs;

                myDt.Rows.Add(row);
            }
            ProgramClass.drData.Close();

            this.GridView1.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
            this.GridView1.DataBind();
            TotalCell.Text = intIndex + " records found";
            InviteButton_1.Enabled = true; InviteButton_2.Enabled = true;
            if (this.GridView1.Rows.Count > 1)
                PrintCommand.Enabled = true;
            else
                PrintCommand.Enabled = false;

            //ShowGraph.Enabled = true;
        }
        catch (Exception ex)
        {
            if (ProgramClass.drData != null)
                ProgramClass.drData.Close();
            HttpContext.Current.Response.Redirect("app_exception.aspx?errorcode=" + ex.Message,false);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void InviteSelectedStudents(object o, EventArgs e)
    {
        string strSQLStatement = "";
        try
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ChkRowCheck = (CheckBox)GridView1.Rows[i].FindControl("SelectStudentCheckBox");
                if (ChkRowCheck != null)
                {
                    if (ChkRowCheck.Checked == true)//means current row selected.
                    {
                        strSQLStatement += "UPDATE student_registration SET status_id=2,interview_location='" +
                            VenueTextBox.Text + "',interview_date='" + InterviewDateTextBox.Text + "',interview_time='" + 
                            InterviewTime.Text + "' WHERE id=" + ChkRowCheck.ToolTip.Trim() + "|";
                    }
                }
            }
            if (strSQLStatement != "")
            {
                ProgramClass.BulkInsert(strSQLStatement);
            }

        }
        catch (Exception ex)
        {
            if (ProgramClass.drData != null)
                ProgramClass.drData.Close();
            HttpContext.Current.Response.Redirect("app_exception.aspx?errorcode=" + ex.Message,false);
        }
        finally
        {
            VenueTextBox.Text = "";
            InterviewDateTextBox.Text = "";
            InterviewTime.Text = "";
            SearchClick(o, e);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void ShowHideParam(object o, EventArgs e)
    {
        LinkButton ShowHideParam = (LinkButton)o;
        if (ShowHideParam.Text == "Hide Options")
        {
            Row_1.Visible = false;
            Row_2.Visible = false;
            Row_3.Visible = false;
            Row_4.Visible = false;
            Row_5.Visible = false;
            Row_6.Visible = false;

            ShowHideParam.Text = "Show Options";
        }
        else
        {
            Row_1.Visible = true;
            Row_2.Visible = true;
            Row_3.Visible = true;
            Row_4.Visible = true;
            Row_5.Visible = true;
            Row_6.Visible = true;
            ShowHideParam.Text = "Hide Options";
        }
    }
    /// <summary>
    /// use ItextSharp To generate PDF document
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void PdfPrint(object o, EventArgs e)
    {
        float[] Widths = { 10, 10, 10, 10,25, 25, 15 };
        string strOpt = "";            
        string SQLWhereClause = "";
        SQLWhereClause = "SELECT ";
        if (TopFromPoolRadioButton.Checked == true)
        {
            SQLWhereClause += "TOP " + TopTextBox.Text;
        }
        string strStatus = "";
        if (TopNewCandidatesRadioButton.Checked == true)
        {
            strStatus = " AND status_id=1 ";//1=new registration
            strOpt = "New Registrations";
        }
        else if (TopInvitedCandidatesRadioButton.Checked == true)
        {
            strStatus = " AND status_id=2 ";//1=new registration
            strOpt = "Invted Applications";
        }

        iTextSharp.text.Document document = new iTextSharp.text.Document();
        try
        {
            int intIndex = 0;
            BaseFont bf = BaseFont.CreateFont("C:\\windows\\fonts\\times.ttf", iTextSharp.text.pdf.BaseFont.IDENTITY_H, true);
            Font f1 = new Font(bf, 10);
            Font f3 = new Font(bf, 12);

            PdfWriter pdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new System.IO.FileStream(
                HttpContext.Current.Server.MapPath(System.Configuration.
                    ConfigurationManager.AppSettings["ReportLocation"]) + "Report.pdf", System.IO.FileMode.Create));

            PdfPTable HeaderTable = new PdfPTable(2);
            HeaderTable.RunDirection = iTextSharp.text.pdf.PdfWriter.RUN_DIRECTION_RTL;
            HeaderTable.WidthPercentage = 100;

            PdfPCell HeaderCell1 = new PdfPCell(new Phrase("King Saud bin Abdulaziz University\nfor Health Sciences\n\n"
               + CollegeNameDropDown.SelectedItem.Text + "\n\n", f3));

            Phrase footPhraseImg = new Phrase("", iTextSharp.text.FontFactory.GetFont("Verdana", 10));
            HeaderCell1.Column.Alignment = Element.ALIGN_LEFT;
            HeaderCell1.BorderWidth = 0;
            HeaderTable.AddCell(HeaderCell1);
            footPhraseImg.Add(HeaderTable);


            PdfPCell HeaderCell2 = new PdfPCell(new Phrase("جامعة الملك سعود بن عبدالعزيز للعلوم الصحية\n نظام التسجيل الإلكتروني\n\n"
               + CollegeNameDropDown.SelectedItem.Text + "\n\n", f3));
            HeaderCell2.Column.Alignment = Element.ALIGN_RIGHT;
            HeaderCell2.BorderWidth = 0;
            HeaderTable.AddCell(HeaderCell2);

            HeaderCell1 = new PdfPCell(new Phrase("Top " + TopTextBox.Text + " " + strOpt, FontFactory.GetFont("Tahoma", 8)));
            HeaderCell1.BorderWidth = 0;
            HeaderTable.AddCell(HeaderCell1);
            HeaderCell1 = new PdfPCell(new Phrase("\n\n\n"));
            HeaderCell1.BorderWidth = 0;

            HeaderTable.AddCell(HeaderCell1);
            HeaderCell1.BorderWidth = 0;
            HeaderFooter header = new HeaderFooter(footPhraseImg, false);
            header.Alignment = Element.ALIGN_RIGHT;
            HeaderCell1.BorderWidth = 0;

            document.Header = header;


            HeaderFooter footer = new HeaderFooter(new Phrase("Date : " +
                DateTime.Today.Date.ToShortDateString() + ": Generated By: " + User.Identity.Name, FontFactory.GetFont("Tahoma", 6)), false);
            footer.Alignment = Element.ALIGN_RIGHT;
            document.Footer = footer;
            footer.BorderWidth = 0;
            document.Open();

            MyHandler MyEvents = new MyHandler();
            pdfWriter.PageEvent = MyEvents;
            MyEvents.OnStartPage(pdfWriter, document);

            iTextSharp.text.pdf.PdfPTable DataTable = new iTextSharp.text.pdf.PdfPTable(7);

            DataTable.RunDirection = iTextSharp.text.pdf.PdfWriter.RUN_DIRECTION_RTL;
            DataTable.WidthPercentage = 100;
            DataTable.SetWidths(Widths);

            PdfPCell HeaderCell = new PdfPCell(new Phrase("رقم بطاقة الأحوال", f1));//local id
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);
            HeaderCell = new PdfPCell(new Phrase("اسم الطالب", f1));///name
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);

            HeaderCell = new PdfPCell(new Phrase("Program", f1));///name
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);

            HeaderCell = new PdfPCell(new Phrase("درجة الثانوية", f1));//high school grade
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);
            HeaderCell = new PdfPCell(new Phrase("نتيجة امتحان القدرات", f1));//gudrat grade
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);
            HeaderCell = new PdfPCell(new Phrase("نتيجة الإمتحان التحصيلي", f1));//tahsili
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);
            HeaderCell = new PdfPCell(new Phrase("المجموع", f1));//total marks
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);


            //Data Fetch Mechanism

            #region

            ProgramClass.strSql = SQLWhereClause + " student_registration.id,local_id,first_name_ar + ' '+ father_name_ar +' '+ " +
                " last_name_ar +' '+grand_father_ar [name],highschool_grade,gudrat_grade,tahseeli_grade,total_marks,email_address,status_id,program_options " +
                " FROM student_registration,student_academic_data WHERE student_academic_data.student_id=student_registration.id " +
                strStatus;
            if (CollegeNameDropDown.SelectedIndex != 0)
            {
                ProgramClass.strSql += " AND college_id=" + CollegeNameDropDown.SelectedValue.ToString();
            }
            ProgramClass.strSql += " ORDER BY total_marks DESC ";
            ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);

            while (ProgramClass.drData.Read())
            {
                double dblTotal = 0;
                PdfPCell DataCell = new PdfPCell(new Phrase(ProgramClass.drData["local_id"].ToString(), f1));
                DataCell.BackgroundColor = new Color(229, 225, 196);
                DataTable.AddCell(DataCell);
                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["name"].ToString(), f1));
                DataTable.AddCell(DataCell);
                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["program_options"].ToString(), f1));
                DataTable.AddCell(DataCell);
                if (ProgramClass.drData["highschool_grade"].ToString() != "")
                {
                    double dml1 = double.Parse(ProgramClass.drData["highschool_grade"].ToString());
                    double dml2 = (dml1 * 35) / 100;
                    DataCell = new PdfPCell(new Phrase(dml2.ToString(), f1));
                    DataTable.AddCell(DataCell);
                    dblTotal += dml2;
                }
                else
                {

                    DataCell = new PdfPCell(new Phrase(ProgramClass.drData["highschool_grade"].ToString(), f1));
                    DataTable.AddCell(DataCell);
                }
                if (ProgramClass.drData["gudrat_grade"].ToString() != "")
                {
                    double dblGod = double.Parse(ProgramClass.drData[4].ToString());
                    double dblGod2 = dblGod * 0.30;
                    DataCell = new PdfPCell(new Phrase(dblGod2.ToString(), f1));
                    DataTable.AddCell(DataCell);
                    dblTotal += dblGod2;
                }
                else
                {
                    DataCell = new PdfPCell(new Phrase(ProgramClass.drData["gudrat_grade"].ToString(), f1));
                    DataTable.AddCell(DataCell);
                }

                if (ProgramClass.drData["tahseeli_grade"].ToString() != "")
                {
                    double dblKnow = double.Parse(ProgramClass.drData["tahseeli_grade"].ToString());
                    double dblKnow2 = dblKnow * 0.35;
                    DataCell = new PdfPCell(new Phrase(dblKnow2.ToString(), f1));
                    DataTable.AddCell(DataCell);
                    dblTotal += dblKnow2;
                }
                else
                {
                    DataCell = new PdfPCell(new Phrase(ProgramClass.drData["tahseeli_grade"].ToString(), f1));
                    DataTable.AddCell(DataCell);
                }

                DataCell = new PdfPCell(new Phrase(dblTotal.ToString(), f1));
                DataTable.AddCell(DataCell);
                intIndex++;

            }
            ProgramClass.drData.Close();
            #endregion


            document.Add(DataTable);
            Phrase TotalPh = new Phrase("\n\n\nTotal Records Found: " + intIndex, FontFactory.GetFont("Tahoma", 8, Font.BOLD));

            document.Add(TotalPh);
            document.Close();


        }
        catch (Exception ex)
        {
            if (document.IsOpen())
            {
                document.Close();
            } 
                if (ProgramClass.drData != null) ProgramClass.drData.Close();

            
        }

        finally
        {
            Server.Transfer(HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ReportLocation"]) + "Report.pdf");

            //ScriptManager.RegisterStartupScript(this, typeof(string), "openNewWindow", "window.open('" +
             //   HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ReportLocation"]) + "Report.pdf" + "')", true);

        }
        
    }
}
public class MyHandler : iTextSharp.text.pdf.PdfPageEventHelper
{
    
    public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
    {
        iTextSharp.text.Image imghead = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(System.Configuration.
                    ConfigurationManager.AppSettings["ReportLocation"]) + "univ.png");
        
        imghead.SetAbsolutePosition(0, 0);

        PdfContentByte cbhead = writer.DirectContent;
        PdfTemplate tp = cbhead.CreateTemplate(100, 150);
        tp.AddImage(imghead);

        cbhead.AddTemplate(tp, 270, 760);

        Phrase headPhraseImg = new Phrase(cbhead + "", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 7, iTextSharp.text.Font.NORMAL));
        
        HeaderFooter header = new HeaderFooter(headPhraseImg, false);
        header.Alignment = Element.ALIGN_CENTER;
                
        PdfContentByte cb1 = writer.DirectContent;
        BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        
        base.OnStartPage(writer, document);
    }

}
