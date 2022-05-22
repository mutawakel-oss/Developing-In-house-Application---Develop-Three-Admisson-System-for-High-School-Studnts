using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //GeneralClass.Program objProgram = new GeneralClass.Program();
    GeneralClass.Student objStudent = new GeneralClass.Student();
    
    protected void Page_Load(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:
        /// Author: hussaint
        /// Date :6/28/2009 11:10:07 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {          


            if (Session["StudentId"] != null && !Session["StudentId"].ToString().Equals(""))
            {
                mCreateReport(Session["StudentId"].ToString());
            }
            else
            {
                Response.Redirect("index.aspx", false);
            }
            
            //objStudent = objStudent.GetStudentByID("28");

            


        }
        catch (Exception Page_Load_Exp)
        {

        }
        finally
        {
		Session.Abandon();
        }
    }
    private void mCreateReport(string strID)
    {
        try
        {
            objStudent = objStudent.GetStudentByID(strID);
            mCreateRow("رقم بطاقة الأحوال", objStudent.strLocalId);
            mCreateRow("الإسم (بالإنجليزية)", objStudent.strFirstNameEn + " " + objStudent.strMiddleNameEn + " " + objStudent.strGrandFatherNameEn + " " + objStudent.strFamilyNameEn);
            mCreateRow("الإسم (بالعربية)", objStudent.strFirstNameAr + " " + objStudent.strMiddleNameAr + " " + objStudent.strGrandFatherNameAr + " " + objStudent.strFamilyNameAr);
            mCreateRow("الكلية", objStudent.strCollegeName);
            mCreateRow("تاريخ الميلاد", objStudent.strDateOfBirth);
            mCreateRow("مكان الميلاد", objStudent.strPlaceOfBirth);
            mCreateRow("العنوان", objStudent.strAddress);
            mCreateRow("البلد", objStudent.strStudentCountry);
            mCreateRow("المدينة", objStudent.strStudentCity);
            mCreateRow("رقم الجوال", objStudent.strStudentMobile);
            mCreateRow("رقم الهاتف", objStudent.strStudentPhone);
            mCreateRow("البريد الإلكتروني", objStudent.strEmail);
            mCreateRow("شخص للإتصال به عند الحاجة", objStudent.strRefName);
            mCreateRow("صلة القرابة", objStudent.strRefRelationId);
            mCreateRow("رقم الجوال", objStudent.strRefMobile);
            mCreateRow("رقم هاتف المنزل", objStudent.strRefHomePhone);
            mCreateRow("رقم هاتف العمل", objStudent.strRefWorkPhone);
            mCreateRow("اسم المستخدم", objStudent.strUserName);
            mCreateRow("اسم المدرسة", objStudent.strSchoolName);
            mCreateRow("البلد", objStudent.strShcoolCountry);
            mCreateRow("المدينة", objStudent.strSchoolCity);
            mCreateRow("سنة التخرج", objStudent.strGraduationyear);
            mCreateRow("معدل الثانوية العامة", Convert.ToString(double.Parse(objStudent.strHighSchoolMarks)*0.35));
            mCreateRow("درجة امتحان القدرات",  Convert.ToString(double.Parse(objStudent.strGodarat)*0.30));
            mCreateRow("درجة الإمتحان التحصيلي", Convert.ToString(double.Parse(objStudent.strKnowExam)*0.35));
            if (objStudent.strCollegeId == "2")
            {
                mCreateRow("خيارات الدراسة", objStudent.strStudyOptions.Replace(",", "-"));
            }            

        }
        catch (Exception exp)
        {

        }
        finally
        { 
        
        }
    }
    private void mCreateRow(string strCaption,string strValue)
    {

        //=====================================================//
        /// <summary>
        /// Description: This will create the Table using all the Details from the object of student Class
        /// Author: hussaint
        /// Date :6/28/2009 12:53:31 PM
        /// Parameter:
        /// input: strCaption is the caption of the Attribute, strValue is the value of Attribute
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            TableRow objRow = new TableRow();
            TableCell objCell = new TableCell();

            objCell.Text = strCaption;
            objRow.Cells.Add(objCell);

            objCell = new TableCell();
            objCell.Text = strValue ;
            objRow.Cells.Add(objCell);

            tblMain.Rows.Add(objRow);

        }
        catch (Exception mAddRowInTable_Exp)
        {

        }
        finally
        { 
        
        }
    }
}
