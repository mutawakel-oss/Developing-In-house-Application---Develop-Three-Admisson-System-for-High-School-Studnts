using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
public partial class _Default : System.Web.UI.Page
{
    GeneralClass.Administrator objAdmin = new GeneralClass.Administrator();
    GeneralClass.Program objProgram = new GeneralClass.Program();
    GeneralClass.Program ProgramClass = new GeneralClass.Program();
    DataTable myDt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminId"] == null || Session["AdminId"].ToString().Equals(""))
        {
            Response.Redirect("adminlogin.aspx", false);
        }


        if (!IsPostBack)
        {
            if (Session["AdminId"] == null || Session["AdminId"].ToString().Equals(""))
            {
                Response.Redirect("adminlogin.aspx", false);
            }
            else
            {
                objAdmin.strUserId = Session["AdminId"].ToString();
                objAdmin.strRole = Session["AdminRole"].ToString();
                objAdmin.strColleges = Session["AdminColleges"].ToString();
            }

            if (!IsPostBack)
            {
                objProgram.gFillDropDownList("SELECT id,college_name FROM college_preset WHERE id IN (" + objAdmin.strColleges + ")", CollegeNameDropDown);

            
            }

            //ProgramClass.strSql = "SELECT id,college_name FROM college_preset";
            //ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);

            System.Web.UI.WebControls.ListItem Item = new System.Web.UI.WebControls.ListItem();
            //Item.Text = "اختر الكلية";
            //Item.Value = "";
            //CollegeNameDropDown.Items.Add(Item);
            //while (ProgramClass.drData.Read())
            //{
            //    Item = new System.Web.UI.WebControls.ListItem();
            //    Item.Value = ProgramClass.drData[0].ToString();
            //    Item.Text = ProgramClass.drData[1].ToString();
            //    CollegeNameDropDown.Items.Add(Item);
            //}
            //ProgramClass.drData.Close();
            CollegeNameDropDown.SelectedIndex = -1;

            ProgramClass.strSql = "SELECT * FROM city_preset";
            ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);

            Item = new System.Web.UI.WebControls.ListItem();
            Item.Text = "اختر الكلية";
            Item.Value = "";
            CityList.Items.Add(Item);
            while (ProgramClass.drData.Read())
            {
                Item = new System.Web.UI.WebControls.ListItem();
                Item.Value = ProgramClass.drData[0].ToString();
                Item.Text = ProgramClass.drData[2].ToString();
                CityList.Items.Add(Item);
            }
            ProgramClass.drData.Close();
            CityList.SelectedIndex = -1;
        }

        if (cmbPage.SelectedIndex != 5)
            RadData.PageSize = int.Parse(cmbPage.Text);
        else
            RadData.PageSize = 100000;

        string CityId = "";
        if (CityList.SelectedIndex > 0)
        {
            CityId = " AND student_registration.city=" + CityList.SelectedItem.Value.ToString();

        }
        if (CollegeNameDropDown.SelectedItem != null)
        {
            if (CollegeNameDropDown.SelectedItem.Value != "")
            {
                string strStatus = "";
                if (TopNewCandidatesRadioButton.Checked == true)
                    strStatus = " AND status_id=1 ";//1=new registration                    
                else if (TopInvitedCandidatesRadioButton.Checked == true)
                    strStatus = " AND status_id=2 ";//1=new registration                    
                else if (TopFromPoolRadioButton.Checked == true)
                    strStatus = " ";//All records


                StudentSource.ConnectionString = "Server=uswa; Database=Registration_2010; UID=" + "sa;PWD=Admin123";
                StudentSource.SelectCommand = "SELECT student_registration.id, first_name_ar +'' +father_name_ar + last_name_ar +' '+grand_father_ar [name], " +
                    "local_id,date_of_birth,mobile, Home_phone,email_address,marked_edited," +
                    "highschool_grade *35/100 [highschool_grade], " +
                    "gudrat_grade *30/100 [gudrat_grade], " +
                    "tahseeli_grade * 35/100 [tahseeli_grade], " +
                    "(highschool_grade *35/100) + (gudrat_grade *30/100) + (tahseeli_grade * 35/100) total_marks" +
                    " FROM student_registration,student_academic_data WHERE student_academic_data.student_id=student_registration.id AND college_id=" +
                    CollegeNameDropDown.SelectedItem.Value + CityId + strStatus + " ORDER BY 12 DESC";

                RadData.DataSourceID = "StudentSource";
                StudentSource.DataBind();
            }
            else
            {
                RadData.DataSourceID = null;
                StudentSource.DataBind();
            }
        }


    }
    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        //double hs_grade = 0;
        //double gudrat = 0;
        //double tahseeli = 0;

        Telerik.Web.UI.GridItem item = e.Item;
        Label mod_y_n = (Label)item.FindControl("mod_y_n");
        HyperLink name_link = (HyperLink)item.FindControl("name_link");
        if (name_link != null)
            if (mod_y_n != null)
            {
                name_link.NavigateUrl = "Report_admin.aspx?student_id=" + name_link.ToolTip;
                if (mod_y_n.Text == "Y")
                    name_link.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                name_link.NavigateUrl = "Report_admin.aspx?student_id=" + name_link.ToolTip;
            }
    }
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
    protected void CreateReport(object o, EventArgs e)
    {
        SendOutPDF(PdfPrint());
    }
    protected MemoryStream PdfPrint()
    {
        string CityId = "";
        if (CityList.SelectedIndex > 0)
        {
            CityId = CityList.SelectedItem.Text;
        }
        else
        {
            CityId = " All City";
        }
        MemoryStream PDFData = new MemoryStream();

        float[] Widths = { 5, 10, 5, 5, 6, 5, 5, 5, 5, 5, 10, 15, 6 };
        string strOpt = "";
        string SQLWhereClause = "";
        SQLWhereClause = "SELECT ";

        string strStatus = "";
        if (TopNewCandidatesRadioButton.Checked == true)
        {
            strStatus = " AND status_id=1 ";//1=new registration
        }
        else if (TopInvitedCandidatesRadioButton.Checked == true)
        {
            strStatus = " AND status_id=2 ";//1=new registration
            
        }
        else if (TopFromPoolRadioButton.Checked == true)
        {
            strStatus = "  ";//1=new registration
        }
        Rectangle rect = new iTextSharp.text.Rectangle(PageSize.A4.Rotate());
        iTextSharp.text.Document document = new iTextSharp.text.Document(rect, 5, 5, 10, 5);
        try
        {
            int intIndex = 0;
            BaseFont bf = BaseFont.CreateFont("C:\\windows\\fonts\\times.ttf", iTextSharp.text.pdf.BaseFont.IDENTITY_H, true);
            Font f1 = new Font(bf, 10);
            Font f3 = new Font(bf, 12);

            PdfWriter pdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(document, PDFData);

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

            HeaderCell1 = new PdfPCell(new Phrase(" " + CityId, f3));
            HeaderCell2.Column.Alignment = Element.ALIGN_RIGHT;
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

            pdf_reg MyEvents = new pdf_reg();
            pdfWriter.PageEvent = MyEvents;
            MyEvents.OnStartPage(pdfWriter, document);

            iTextSharp.text.pdf.PdfPTable DataTable = new iTextSharp.text.pdf.PdfPTable(13);

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

            HeaderCell = new PdfPCell(new Phrase("Mobile", f1));//Mobile
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);

            HeaderCell = new PdfPCell(new Phrase("HomePhone", f1));//HomePhone
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);

            HeaderCell = new PdfPCell(new Phrase("Email", f1));//Email
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);

            HeaderCell = new PdfPCell(new Phrase("POB", f1));//Email
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);


            HeaderCell = new PdfPCell(new Phrase("RefName", f1));//Email
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);

            HeaderCell = new PdfPCell(new Phrase("RefMobile", f1));//Email
            HeaderCell.BackgroundColor = new Color(212, 208, 200);
            DataTable.AddCell(HeaderCell);
            //Data Fetch Mechanism

            #region
            string City_Id = "";
            if (CityList.SelectedIndex > 0)
            {
                City_Id = " AND student_registration.city=" + CityList.SelectedItem.Value.ToString();

            }

            ProgramClass.strSql = SQLWhereClause + " student_registration.id,local_id,first_name_ar + ' '+ father_name_ar +' '+ " +
                " last_name_ar +' '+grand_father_ar [name],highschool_grade *35/100 [highschool_grade],gudrat_grade *30/100 [gudrat_grade],tahseeli_grade * 35/100 [tahseeli_grade],(highschool_grade *35/100) + (gudrat_grade *30/100) + (tahseeli_grade * 35/100) total_marks,email_address,status_id, " +
                "program_options " +
                ",date_of_birth,place_of_birth,address,mobile,home_phone,email_address,ref_mobile, " +
                "ref_home_phone,ref_name,ref_work_phone,email_address FROM student_registration,student_academic_data  " +
                "WHERE college_id="+this.CollegeNameDropDown.SelectedItem.Value + City_Id +
                " AND student_academic_data.student_id=student_registration.id " +
                strStatus + " order by total_marks DESC";
            
            
            ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);

            while (ProgramClass.drData.Read())
            {
                double dblTotal = 0;
                PdfPCell DataCell = new PdfPCell(new Phrase(ProgramClass.drData["local_id"].ToString(), f1));
                DataTable.AddCell(DataCell);
                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["name"].ToString(), f1));
                DataTable.AddCell(DataCell);
                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["program_options"].ToString(), f1));
                DataTable.AddCell(DataCell);
                   
                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["highschool_grade"].ToString(), f1));
                DataTable.AddCell(DataCell);
                
               
                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["gudrat_grade"].ToString(), f1));
                DataTable.AddCell(DataCell);
               
                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["tahseeli_grade"].ToString(), f1));
                DataTable.AddCell(DataCell);


                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["total_marks"].ToString(), f1));
                DataTable.AddCell(DataCell);

                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["mobile"].ToString(), f1));
                DataTable.AddCell(DataCell);

                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["home_phone"].ToString(), f1));
                DataTable.AddCell(DataCell);

                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["email_address"].ToString(), f1));
                DataTable.AddCell(DataCell);

                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["place_of_birth"].ToString(), f1));
                DataTable.AddCell(DataCell);

                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["ref_name"].ToString(), f1));
                DataTable.AddCell(DataCell);

                DataCell = new PdfPCell(new Phrase(ProgramClass.drData["ref_mobile"].ToString(), f1));
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
            return null;
        }
        return PDFData;


    }
    protected void SendOutPDF(System.IO.MemoryStream PDFData)
    {
        if (PDFData == null) return;
        Random rnd = new Random();
        int intNextValue = rnd.Next();
        // Clear response content & headers
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.Charset = string.Empty;
        Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
        Response.AddHeader("Content-Disposition",
            "attachment; filename=" + intNextValue.ToString() + ".pdf");

        Response.OutputStream.Write(PDFData.GetBuffer(), 0, PDFData.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        Response.End();
    }
}
public class pdf_reg : iTextSharp.text.pdf.PdfPageEventHelper
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
