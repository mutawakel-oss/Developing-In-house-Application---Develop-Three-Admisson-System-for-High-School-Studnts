using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class _Default : System.Web.UI.Page
{
    GeneralClass.Program objProgram = new GeneralClass.Program();
    GeneralClass.Student objStudent = new GeneralClass.Student();
    GeneralClass.Dates objDate = new GeneralClass.Dates();    
    int intCollegeId = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        

        //=====================================================//
        /// <summary>
        /// Description: It will handle the Page Load Event
        /// Author: hussaint
        /// Date :6/23/2009 12:33:40 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {            
            if (Session["college_id"] != null)
            {
                intCollegeId = int.Parse(Session["college_id"].ToString());
                HIDDEN_COLLEGE_ID.Text = intCollegeId.ToString();

                if (intCollegeId == 1 || intCollegeId == 2)
                {
                    txtGraduationYear.Visible = true;
                    ddlGraduationYear.Visible = false;
                }               

            }
            else
            {
                Response.Redirect("~/index.aspx",false);
            }
            

            //Will have to remove this line
            //intCollegeId = 2;             

            if (!IsPostBack)
            {   
                mManageEducationalList(intCollegeId.ToString());                

                //Here we are gonna check if this is a new user or an existing one came by providing login and password information
                //If the StudentId Session variable is empty.. then its a new user... otherwise an existing one
                if (Session["StudentId"] == null || Session["StudentId"].ToString().Equals(""))
                {
                    mFillDropDownLists();
                    mConvertDates();

                    if (intCollegeId == 14 || intCollegeId == 15)
                    {
                        btnVerify.Visible = false;
                        mEnableDisableControls(true);
                        txtLocalId.Enabled = true;
                        txtGraduationYear.Visible = false;
                        ddlGraduationYear.Visible = true;
                    }
                    else
                    {
                        btnVerify.Visible = true;
                        mEnableDisableControls(false);                        
                    }                    
                    
                }
                else
                {
                    if (intCollegeId == 14 || intCollegeId == 15)
                    {
                        btnVerify.Visible = false;
                        txtGraduationYear.Visible = false;
                        ddlGraduationYear.Visible = true;
                    }
                    else
                    {
                        btnVerify.Visible = true;
                        txtGraduationYear.Visible = true;
                        ddlGraduationYear.Visible = false;
                    }


                    objStudent = objStudent.GetStudentByID(Session["StudentId"].ToString());                    

                    txtLocalId.Enabled = false;
                    btnVerify.Enabled = false;

                    mFillDropDownLists();
                    mConvertDates();

                    mFillStudentDetailsInForm(objStudent);

                    btnSubmit.Text = "احفظ التغييرات";
                }               
                
            }
        }
        catch (Exception Page_Load_Exp)
        {
            objProgram.gAddLog("register.aspx", "Page_Load", Page_Load_Exp.Message);
            Response.Redirect("~/error.aspx?error=" + HttpUtility.UrlEncode("حدث خطأ اثناء محاولة عرض صفحة التسجيل، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."),false);

        }
        finally
        { 
        
        }       

    }
    private void mManageEducationalList(string strCollegeId)
    {

        //=====================================================//
        /// <summary>
        /// Description: This method will manage the Educational List according to the College Selection
        /// Author: hussaint
        /// Date :7/6/2009 3:41:33 PM
        /// Parameter:
        /// input: strCollegeId is the ID of the college
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            objProgram.strSql = "SELECT * FROM program_preset WHERE college_id  = " + strCollegeId;

            if (strCollegeId.Equals("14") || strCollegeId.Equals("15") )
            {

                //For any other College we dont need to show anything...              
                studyOptionsInfoPanel1.Visible = false;
                studyOptionslInfoPanel2.Visible = false;               

                ////If this is 1 then.. this is college of medicine..
                //lblOption1.Visible = false;
                //lblOption2.Visible = false;
                //lblOption3.Visible = false;
                //ddlOption1.Visible = false;
                //ddlOption2.Visible = false;
                //ddlOption3.Visible = false;
                ////To be Eliminated ...
                //lblCollegePreferences.Visible = false; 
                //rdPrefrences.Visible = false;             
            }
            else if (strCollegeId.Equals("1") || strCollegeId.Equals("2") || strCollegeId.Equals("3") || strCollegeId.Equals("4") || strCollegeId.Equals("13"))
            {
                //If this is 2 then.. this is college of applied medical sciences..
                lblOption1.Visible = true;
                lblOption2.Visible = true;
                lblOption3.Visible = true;
                ddlOption1.Visible = true;
                ddlOption2.Visible = true;
                ddlOption3.Visible = true;

                //To be Eliminated ...
                //lblCollegePreferences.Visible = false;
                //rdPrefrences.Visible = false;

                objProgram.objListItem = new ListItem("اختر الكلية", "-1");
                ddlOption1.Items.Add(objProgram.objListItem);
                objProgram.objListItem = new ListItem("اختر الكلية", "-2");
                ddlOption2.Items.Add(objProgram.objListItem);
                objProgram.objListItem = new ListItem("اختر الكلية", "-3");
                ddlOption3.Items.Add(objProgram.objListItem);

                objProgram.strSql = "SELECT * FROM program_preset WHERE college_id = " + strCollegeId;
                objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                while (objProgram.drData.Read())
                {
                    objProgram.objListItem = new ListItem(objProgram.drData["program_name"].ToString(), objProgram.drData["id"].ToString());

                    ddlOption1.Items.Add(objProgram.objListItem);
                    objProgram.objListItem = new ListItem(objProgram.drData["program_name"].ToString(), objProgram.drData["id"].ToString());
                    ddlOption2.Items.Add(objProgram.objListItem);
                    objProgram.objListItem = new ListItem(objProgram.drData["program_name"].ToString(), objProgram.drData["id"].ToString());
                    ddlOption3.Items.Add(objProgram.objListItem);
                }
                objProgram.drData.Close();
            }
            else
            {
                //For any other College we dont need to show anything...              
                studyOptionsInfoPanel1.Visible = false;
                studyOptionslInfoPanel2.Visible = false;               
                
            }

        }
        catch (Exception mManageEducationalList_Exp)
        {
            //if (objProgram.drData != null) objProgram.drData.Close();
            objProgram.gDisposeDataBaseObjects();
        }
        finally
        {
            //if (objProgram.drData != null) objProgram.drData.Close();
            objProgram.gDisposeDataBaseObjects();
        }
        
    }
    protected void mFillStudentDetailsInForm(GeneralClass.Student objStudent)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to Fill the student details in the Registration form using his Student ID
        /// Author: hussaint
        /// Date :6/29/2009 11:35:29 AM
        /// Parameter:
        /// input: strStudentId is the Database ID of the Student
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            
            
            txtLocalId.Text = objStudent.strLocalId;

            txtFirstNameAr.Text = objStudent.strFirstNameAr;
            txtFirstNameEn.Text = objStudent.strFirstNameEn;
            txtMiddleNameAr.Text = objStudent.strMiddleNameAr;
            txtMiddleNameEn.Text = objStudent.strMiddleNameEn;
            txtGrandFatherAr.Text = objStudent.strGrandFatherNameAr;
            txtGrandFatherEn.Text = objStudent.strGrandFatherNameEn;
            txtFamilyNameAr.Text = objStudent.strFamilyNameAr;
            txtFamilyNameEn.Text = objStudent.strFamilyNameEn;
            txtPlaceOfBirth.Text = objStudent.strPlaceOfBirth;
            objProgram.strData = objStudent.strDateOfBirth.Split('/');                             
            ddlHirjiDay.Text = objProgram.strData[0];
            mSetListIndex(ddlHirjriMonth, objProgram.strData[1]);            
            ddlHirjiYear.Text = objProgram.strData[2];  
            
            txtStudentAddress.Text = objStudent.strAddress;
            mSetListIndex(ddlStudentCountry,objStudent.strStudentCountry);                                
            mSetListIndex(ddlStudentCity, objStudent.strStudentCity);              
            txtStudentMobile.Text = objStudent.strStudentMobile;


            if (objStudent.strStudentPhone.Length > 7)
            {

                mSetListIndex(ddlStudentPhonePrefix,objStudent.strStudentPhone.Substring(0,2));                
                txtStudentHomePhone.Text = objStudent.strStudentPhone.Substring(2);
            }
            else
            {
                txtStudentHomePhone.Text = objStudent.strStudentPhone;
            }

            txtEmail.Text= objStudent.strEmail;
            txtEmail2.Text = objStudent.strEmail;     
            mSetListIndex(ddlRleationShip,objStudent.strRefRelationId);
            txtReferenceName.Text = objStudent.strRefName;
            txtReferenceMobile.Text = objStudent.strRefMobile;

            if (objStudent.strRefHomePhone.Length > 7)
            {

                mSetListIndex(ddlRefPhonePrefix,objStudent.strRefHomePhone.Substring(0,2)); 
                txtRefHomePhone.Text = objStudent.strRefHomePhone.Substring(2);

            }
            else
            {
                txtRefHomePhone.Text = objStudent.strRefHomePhone;
            }

            if (objStudent.strRefWorkPhone.Length > 7)
            {

                mSetListIndex(ddlRefWorkPhone, objStudent.strRefWorkPhone.Substring(0, 2));                 
                txtRefWorkPhone.Text = objStudent.strRefWorkPhone.Substring(2);
            }
            else
            {
                txtRefWorkPhone.Text = objStudent.strRefWorkPhone;
            }


            txtSchoolName.Text = objStudent.strSchoolName;
            mSetListIndex(ddlSchoolCountry, objStudent.strShcoolCountry);
            mSetListIndex(ddlSchoolCity,objStudent.strSchoolCity);
            //new changes. 
            if (intCollegeId == 1 || intCollegeId == 2)
            {
                txtGraduationYear.Text = objStudent.strGraduationyear;
            }
            else if (intCollegeId == 14 || intCollegeId == 15)
            {
                //ddlGraduationYear.Text = objStudent.strGraduationyear;
                mSetListIndex(ddlGraduationYear, objStudent.strGraduationyear);
            }

            
            txtUserName.Text = objStudent.strUserName;
            txtPassword.Attributes.Add("value", objStudent.strPassword);
            txtRetypedPassword.Attributes.Add("value", objStudent.strPassword);

            txtGeneralPercentage.Text = objStudent.strHighSchoolMarks;
            txtGodarat.Text = objStudent.strGodarat;
            txtKnowExam.Text = objStudent.strKnowExam;

            //Here it will keep the Mark in the Global Variables to make a comparison while saving.
            txtGeneralPercentage.CssClass = txtGeneralPercentage.Text.Trim();
            txtGodarat.CssClass = txtGodarat.Text.Trim();
            txtKnowExam.CssClass = txtKnowExam.Text.Trim();

            if (!objStudent.strStudyOptions.Equals(""))
            {
                objProgram.strData = objStudent.strStudyOptions.Split(',');
            }

            if (objProgram.strData.Length > 0)
            {
                mSetListIndex(ddlOption1, objProgram.strData[0]);
            }
            if (objProgram.strData.Length > 1)
            {
                mSetListIndex(ddlOption2, objProgram.strData[1]);
            }
            if (objProgram.strData.Length > 2)
            {
                mSetListIndex(ddlOption3, objProgram.strData[2]);
            }

            //if (!objStudent.strAlternateCollege.Equals(""))
            //{
            //    rdPrefrences.SelectedIndex = int.Parse(objStudent.strAlternateCollege);
            //}

            mCalculateMarks();
            mConvertDates();

        }
        catch (Exception mFillStudentDetailsInForm_Exp)
        {
            objProgram.gAddLog("register.aspx", "mFillStudentDetailsInForm", mFillStudentDetailsInForm_Exp.Message);
            Response.Redirect("~/error.aspx?error=" + HttpUtility.UrlEncode("حدث خطأ اثناء محاولة عرض صفحة التسجيل، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."),false);
        }
        finally
        { 
        
        }
    
    }
    private void mSetListIndex(DropDownList ddlTemp, string strCaption)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to Set the Index of a particular item in Drop Down List
        /// Author: hussaint
        /// Date :6/29/2009 1:33:55 PM
        /// Parameter:
        /// input: ddlTemp is the DropDownList, strCaption is text of the Item tht we are searching for.
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            for (objProgram.intLoopCounter = 0; objProgram.intLoopCounter < ddlTemp.Items.Count; objProgram.intLoopCounter++)
            {
                if (ddlTemp.Items[objProgram.intLoopCounter].Text.Equals(strCaption))
                {
                    ddlTemp.SelectedIndex = objProgram.intLoopCounter;
                    return;
                }
            }

        }
        catch (Exception mGetListIndex_Exp)
        {

        }
        finally
        { 
        
        }
    
    }
    protected void HijriDayChanged(object sender,EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to handle the Index Changed Event of the Hijri Day Drop Down List
        /// Author: hussaint
        /// Date :6/24/2009 10:24:53 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {           

            mConvertDates();

        }
        catch (Exception HijriDayChanged_Exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void HijriMonthChanged(object sender,EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to handle the Index Changed Event of the Hijri Month Drop Down List
        /// Author: hussaint
        /// Date :6/24/2009 10:24:53 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            mConvertDates();

        }
        catch (Exception HijriDayChanged_Exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void HijriYearChanged(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to handle the Index Changed Event of the Hijri Year Drop Down List
        /// Author: hussaint
        /// Date :6/24/2009 10:24:53 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            mConvertDates();

        }
        catch (Exception HijriDayChanged_Exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void AddressCountyChanged(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: will be used to handle the Selected Index Changed Event of Address Country
        /// Author: hussaint
        /// Date :6/24/2009 10:51:28 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {            

            objProgram.strSql = "SELECT id,city_name FROM city_preset WHERE country_id = " + ddlStudentCountry.SelectedValue.ToString();
            objProgram.gFillDropDownList(objProgram.strSql, ddlStudentCity); 

        }
        catch (Exception AddressCountyChanged_Exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void SchoolCountryChanged(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to handle the selected index changed event of the School country Drop Drown List
        /// Author: hussaint
        /// Date :6/24/2009 11:01:17 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {           

            objProgram.strSql = "SELECT id,city_name FROM city_preset WHERE country_id = " + ddlSchoolCountry.SelectedValue.ToString();
            objProgram.gFillDropDownList(objProgram.strSql, ddlSchoolCity); 

        }
        catch (Exception SchoolCountryChanged_Exp)
        {

        }
        finally
        { 
        
        }
    }
    private void mConvertDates()
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to convert the Hijri date used by user to English Date
        /// Author: hussaint
        /// Date :6/24/2009 10:20:59 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            objProgram.strSql = ddlHirjiDay.SelectedItem.Text + "/" + Convert.ToString(ddlHirjriMonth.SelectedIndex + 1) + "/" + ddlHirjiYear.SelectedItem.Text;
            objProgram.strSql = objDate.HijriToGreg(objProgram.strSql, "dd-MM-yyyy");
            txtEnglishDay.Text = objProgram.strSql.Substring(0, 2);
            txtEnglishMonth.Text = objProgram.strSql.Substring(3, 2);
            txtEnglishYear.Text = objProgram.strSql.Substring(6);
        }
        catch (Exception mConvertDates_Exp)
        {

        }
        finally
        { 
        
        }
    }

    protected void mShowStatusExtender(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to show the registratino status extender "registratinoStatusExtender"
        /// Author: mutawakelm
        /// Date :6/20/2009 12:38:27 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            registratinoStatusExtender.Show();
        }
        catch (Exception exp)
        {
        }
    }
    private void mFillDropDownLists()
    {

        //=====================================================//
        /// <summary>
        /// Description: This will populate all the drop down list at the page.. Like Birth Date, City and Country..
        /// Author: hussaint
        /// Date :6/23/2009 12:27:55 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            for (objProgram.intLoopCounter = 1; objProgram.intLoopCounter <= 30; objProgram.intLoopCounter++)
            { 
                ddlHirjiDay.Items.Add(objProgram.intLoopCounter.ToString());
            }
            objProgram.strSql = "SELECT birth_start_date,birth_end_date FROM college_preset WHERE id = " + intCollegeId.ToString();

            objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);

            if (objProgram.drData.Read())
            {
                for (objProgram.intLoopCounter = int.Parse(objProgram.drData["birth_start_date"].ToString()); objProgram.intLoopCounter <= int.Parse(objProgram.drData["birth_end_date"].ToString()); objProgram.intLoopCounter++)
                {
                    ddlHirjiYear.Items.Add(objProgram.intLoopCounter.ToString()); 
                }
            }

            objProgram.drData.Close();

            objProgram.gFillDropDownList("SELECT id,relation_name FROM relationship_preset", ddlRleationShip);
            objProgram.gFillDropDownList("SELECT id,country_name FROM country_preset", ddlSchoolCountry);
            objProgram.gFillDropDownList("SELECT id,country_name FROM country_preset",ddlStudentCountry);

            //If this is a new student.. then fill the city with the cities of Saudi Arabia.. otherwise.. dont fill and leave it to 
            //process of index changed event of ddlCountry..
            if (Session["StudentId"] == null || Session["StudentId"].ToString().Equals(""))
            {
                objProgram.gFillDropDownList("SELECT id,city_name FROM city_preset WHERE country_id = 1", ddlStudentCity);
                objProgram.gFillDropDownList("SELECT id,city_name FROM city_preset WHERE country_id = 1", ddlSchoolCity);
            }
            else
            {
                objProgram.gFillDropDownList("SELECT id,city_name FROM city_preset WHERE country_id = (SELECT id FROM country_preset WHERE country_name ='" + objStudent.strStudentCountry + "')", ddlStudentCity);
                objProgram.gFillDropDownList("SELECT id,city_name FROM city_preset WHERE country_id = (SELECT id FROM country_preset WHERE country_name ='" + objStudent.strShcoolCountry + "')", ddlSchoolCity);
            }

            //objProgram.gFillDropDownList("SELECT id,program_name FROM program_preset WHERE college_id = " + intCollegeId.ToString(), ddlOption1); //Session["College_id"]
            //if (ddlOption1.Items.Count == 0)
            //{
            //    //studyOptionsInfoPanel1.Visible = false;
            //    //studyOptionslInfoPanel2.Visible = false;               

            //}
            //else
            //{
            //    //studyOptionsInfoPanel1.Visible = true;
            //    //studyOptionslInfoPanel2.Visible = true; 
            //    objProgram.gFillDropDownList("SELECT id,program_name FROM program_preset WHERE college_id =" + intCollegeId.ToString(), ddlOption2); //Session["College_id"]
            //    objProgram.gFillDropDownList("SELECT id,program_name FROM program_preset WHERE college_id =" + intCollegeId.ToString(), ddlOption3); //Session["College_id"]
            //}            

        }
        catch (Exception mFillDropDownLists_Exp)
        {
            objProgram.gDisposeDataBaseObjects();                        
        }
        finally
        {
            objProgram.gDisposeDataBaseObjects();        
        }
    }    
    protected void ddlOption1_Changed(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to handle the Selected Index changed events of option drop down lists.
        /// Author: hussaint
        /// Date :6/24/2009 4:54:44 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            mCheckOptions("1");
        }
        catch (Exception ddlOption1_Changed_Exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void ddlOption2_Changed(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to handle the Selected Index changed events of option drop down lists.
        /// Author: hussaint
        /// Date :6/24/2009 4:54:44 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            mCheckOptions("2");
        }
        catch (Exception ddlOption1_Changed_Exp)
        {

        }
        finally
        {

        }
    }
    protected void ddlOption3_Changed(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to handle the Selected Index changed events of option drop down lists.
        /// Author: hussaint
        /// Date :6/24/2009 4:54:44 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            mCheckOptions("3");
        }
        catch (Exception ddlOption1_Changed_Exp)
        {

        }
        finally
        {

        }
    }
    private void mCheckOptions(string strOption)
    {

        //=====================================================//
        /// <summary>
        /// Description: This procedure will be used to check the Options chosen by the applicant.
        /// Author: hussaint
        /// Date :6/24/2009 5:02:24 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (strOption.Equals("1"))
            {
                if (ddlOption1.SelectedIndex != 0)
                {
                    if (ddlOption1.SelectedIndex == ddlOption2.SelectedIndex || ddlOption1.SelectedIndex == ddlOption3.SelectedIndex)
                    {                        
                        mpeStudyOptions.Show();
                        ddlOption1.SelectedIndex = 0;
                        
                    }
                }
            }
            else if (strOption.Equals("2"))
            {

                if (ddlOption2.SelectedIndex != 0)
                {
                    if (ddlOption2.SelectedIndex == ddlOption1.SelectedIndex || ddlOption2.SelectedIndex == ddlOption3.SelectedIndex)
                    {                        
                        mpeStudyOptions.Show();
                        ddlOption2.SelectedIndex = 0;
                    }
                }
            }
            else if (strOption.Equals("3"))
            {

                if (ddlOption3.SelectedIndex != 0)
                {
                    if (ddlOption3.SelectedIndex == ddlOption2.SelectedIndex || ddlOption3.SelectedIndex == ddlOption1.SelectedIndex)
                    {                        
                        mpeStudyOptions.Show();
                        ddlOption3.SelectedIndex = 0;
                    }
                }
            }
        }
        catch (Exception mCheckOptions_Exp)
        {

        }
        finally
        { 
        
        }
        

    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: will be used to handle the click event of btnVerify.
        /// Author: hussaint
        /// Date :6/24/2009 1:09:53 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {

            string strStudentFullName = "";
            string strSchoolGrade = "";
            
            if (!txtLocalId.Text.Trim().Equals(""))
            {


                if (objProgram.gCheckRecordExistence("student_registration", "local_id", txtLocalId.Text.Trim(), "S"))
                {
                    mpeCheckStudentExistence.Show();
                    return;
                }                

                //objProgram.strSql = "SELECT * FROM imported_data_new WHERE local_id = " + txtLocalId.Text;
                //objProgram.strSql = "SELECT A.local_id,A.studentnamearabic,A.SchoolNameArabic,A.secondyearpercentage AS sec_year,A.thirdyearpercent AS third_year,B.birth_place,B.mobile,B.home_phone,B.gudrat_grade,C.tahsili_mark As tahseeli_marks FROM high_school_master A left outer join imported_data_new B ON A.local_id = B.local_id " +
                //                    " LEFT OUTER JOIN Tehseeli_results C ON A.local_id = C.local_id WHERE A.local_id = '" + txtLocalId.Text.Trim() + "' order by B.gudrat_grade DESC";

                objProgram.strSql = "SELECT A.local_id,first_name,father_name,grand_father,family_name,A.full_name As 'studentnamearabic',B.SchoolName AS 'SchoolNameArabic',A.high_school_mark AS 'sec_year','0' AS third_year,' ' AS 'birth_place',RIGHT(RTRIM(LTRIM(A.mobile_no)),8) As 'mobile',RIGHT(RTRIM(LTRIM(A.phone_no)),7) As 'home_phone',A.qudrat_mark,A.tehseeli_mark FROM t_qudarat_2010 A LEFT OUTER JOIN t_school_2010 B ON A.school_id = B.school_id " +
                                    " WHERE A.local_id = '" + txtLocalId.Text.Trim() + "'";

                objProgram.drData = objProgram.gRetrieveRecord(objProgram.strSql);
                if (objProgram.drData.HasRows)
                {
                    if (objProgram.drData.Read())
                    {


                        //if (objProgram.drData["third_year"].ToString().Equals(""))
                        //{
                        //    strSchoolGrade = "0";
                        //}
                        //else
                        //{
                        //    strSchoolGrade = objProgram.drData["sec_year"].ToString() == "0" ? objProgram.drData["third_year"].ToString() : Convert.ToString((double.Parse(objProgram.drData["sec_year"].ToString()) + double.Parse(objProgram.drData["third_year"].ToString())) / 2);
                        //}

                        strSchoolGrade = objProgram.drData["sec_year"].ToString();

                        strStudentFullName  = objProgram.drData["studentnamearabic"].ToString().Trim();

                        while (strStudentFullName.IndexOf("  ") > 0)
                        {
                            strStudentFullName = strStudentFullName.Replace("  ", " ");
                        }

                        lblFullNameValue.Text = strStudentFullName;
                        objProgram.strData = strStudentFullName.Split(' ');
                        if (objProgram.strData.Length > 0)
                        {
                            txtFirstNameAr.Text = objProgram.strData[0];
                        }

                        if (objProgram.strData.Length > 1)
                        {
                            txtMiddleNameAr.Text = objProgram.strData[1];
                        }

                        if (objProgram.strData.Length > 2)
                        {
                            txtGrandFatherAr.Text = objProgram.strData[2];
                        }

                        if (objProgram.strData.Length > 3)
                        {
                            txtFamilyNameAr.Text = objProgram.strData[3];
                        }

                        //txtFirstNameAr.Text = objProgram.drData["first_name"].ToString().Trim();
                        //txtMiddleNameAr.Text = objProgram.drData["father_name"].ToString().Trim();
                        //txtGrandFatherAr.Text = objProgram.drData["grand_father"].ToString().Trim();
                        //txtFamilyNameAr.Text = objProgram.drData["family_name"].ToString().Trim();


                        txtPlaceOfBirth.Text = objProgram.drData["birth_place"].ToString();


                        txtGeneralPercentage.Text = strSchoolGrade.Trim() == "" ? "0" : strSchoolGrade.Trim(); 
                        txtGodarat.Text = objProgram.drData["qudrat_mark"].ToString() == "" ? "0" : objProgram.drData["qudrat_mark"].ToString();
                        txtKnowExam.Text = objProgram.drData["tehseeli_mark"].ToString() == "" ? "0" : objProgram.drData["tehseeli_mark"].ToString();


                        //Here it will keep the Mark in the Global Variables to make a comparison while saving.
                        txtGeneralPercentage.CssClass = txtGeneralPercentage.Text.Trim();
                        txtGodarat.CssClass = txtGodarat.Text.Trim();
                        txtKnowExam.CssClass = txtKnowExam.Text.Trim();

                        txtStudentMobile.Text = objProgram.drData["mobile"].ToString();
                        txtStudentHomePhone.Text = objProgram.drData["home_phone"].ToString();
                        txtSchoolName.Text = objProgram.drData["SchoolNameArabic"].ToString();


                        if (strSchoolGrade.Trim().Length > 0 && double.Parse(strSchoolGrade) < 90)
                        {
                            mpeSchoolGrades.Show();                            
                        }
                        else
                        {
                            mEnableDisableControls(true);                          

                        }

                        mCalculateMarks();
                    }
                }
                else
                {                    
                    mpeVerifyStudent.Show();
                    intCollegeId = int.Parse(Session["college_id"].ToString());
                    if (intCollegeId == 1 || intCollegeId == 2)
                    {
                        mEnableDisableControls(false);                           
                    }
                    else if (intCollegeId == 3 || intCollegeId == 4)
                    {
                        mEnableDisableControls(true);                           
                    }
                }
            }
            
            objProgram.drData.Close();


        }
        catch (Exception btnVerify_Click_Exp)
        {
            objProgram.gDisposeDataBaseObjects();
        }
        finally
        {
            objProgram.gDisposeDataBaseObjects();
        }
    }
    private void mEnableDisableControls(bool blnFlag)
    {

        //=====================================================//
        /// <summary>
        /// Description: This procedure would be used to Enable Disable Controls
        /// Author: hussaint
        /// Date :6/27/2009 2:03:48 PM
        /// Parameter:
        /// input: blnFlag would be used to determine that whether to keep the controls Enable or Disable
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {

            txtLocalId.Enabled = !blnFlag;

            txtFirstNameAr.Enabled = blnFlag;
            txtFirstNameEn.Enabled = blnFlag;

            txtMiddleNameAr.Enabled = blnFlag;
            txtMiddleNameEn.Enabled = blnFlag;

            txtGrandFatherAr.Enabled = blnFlag;
            txtGrandFatherEn.Enabled = blnFlag;

            txtFamilyNameAr.Enabled = blnFlag;
            txtFamilyNameEn.Enabled = blnFlag;

            txtPlaceOfBirth.Enabled = blnFlag;       
            ddlHirjiDay.Enabled = blnFlag;
            ddlHirjriMonth.Enabled = blnFlag;
            ddlHirjiYear.Enabled = blnFlag;

            txtEnglishDay.Enabled = blnFlag;
            txtEnglishMonth.Enabled = blnFlag;
            txtEnglishYear.Enabled = blnFlag;

            txtStudentAddress.Enabled = blnFlag;
            ddlStudentCountry.Enabled = blnFlag;
            ddlStudentCity.Enabled = blnFlag;
            txtStudentMobile.Enabled = blnFlag;
            txtStudentHomePhone.Enabled = blnFlag;
            txtEmail.Enabled = blnFlag;
            txtEmail2.Enabled = blnFlag;
            txtReferenceName.Enabled = blnFlag;
            txtReferenceMobile.Enabled = blnFlag;
            txtRefHomePhone.Enabled = blnFlag;
            txtRefWorkPhone.Enabled = blnFlag;
            txtSchoolName.Enabled = blnFlag;
            ddlSchoolCountry.Enabled = blnFlag;
            ddlSchoolCity.Enabled = blnFlag;
            txtGraduationYear.Enabled = blnFlag;
            lnkSchoolGPA.Enabled = blnFlag;
            btnCalculate.Enabled = blnFlag;
            txtUserName.Enabled = blnFlag;
            txtPassword.Enabled = blnFlag;
            txtRetypedPassword.Enabled = blnFlag; 


        }
        catch (Exception mEnableDisableControls_Exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void mCalculateMarks()
    {

        //=====================================================//
        /// <summary>
        /// Description: This will be used to calculate the marks based upon the total marks and percentage.. 
        /// Author: hussaint
        /// Date :6/27/2009 11:30:52 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            double dblVerifyTemp = 0;

            if (!double.TryParse(txtGeneralPercentage.Text.Trim(), out dblVerifyTemp)) txtGeneralPercentage.Text = "0";
            if (!double.TryParse(txtGodarat.Text.Trim(), out dblVerifyTemp)) txtGodarat.Text = "0";
            if (!double.TryParse(txtKnowExam.Text.Trim(), out dblVerifyTemp)) txtKnowExam.Text = "0";


            //This is the Calculation Part of the Marks section
            if (!txtGeneralPercentage.Text.Trim().Equals(""))
            {
                txtGPAFinal.Text = Convert.ToString(Math.Round(double.Parse(txtGeneralPercentage.Text.Trim()) * (double.Parse(txtGPApoint.Text.Trim().Substring(0, 2)) / 100),2));
            }

            if (!txtGodarat.Text.Trim().Equals(""))
            {
                txtGodaratFinal.Text = Convert.ToString(Math.Round(double.Parse(txtGodarat.Text.Trim()) * (double.Parse(txtGodaratPoint.Text.Trim().Substring(0, 2)) / 100),2));
            }

            if (!txtKnowExam.Text.Trim().Equals(""))
            {
                txtKnowFinal.Text = Convert.ToString(Math.Round(double.Parse(txtKnowExam.Text.Trim()) * (double.Parse(txtKnowPoint.Text.Trim().Substring(0, 2)) / 100),2));
            }

            txtTotalConvertedMarks.Text = Convert.ToString(double.Parse(txtGPAFinal.Text.Trim()) + double.Parse(txtGodaratFinal.Text.Trim()) + double.Parse(txtKnowFinal.Text.Trim()));

        }
        catch (Exception mCalculateMarks_Exp)
        {

        }
        finally
        { 
        
        }
        
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This will be used to handle the click event of btnCalculate
        /// Author: hussaint
        /// Date :6/27/2009 11:33:30 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {           

            txtGeneralPercentage.Enabled = false;           
            txtGodarat.Enabled = false;           
            txtKnowExam.Enabled = false;

            mCalculateMarks();
        }
        catch (Exception btnCalculate_Click_Exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void lnkSchoolGpa_Click(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description: This will handle the Click event of the lnkSchoolGpa
        /// Author: hussaint
        /// Date :6/27/2009 11:28:09 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {           

            txtGeneralPercentage.Enabled = true;           
            txtGodarat.Enabled = true;           
            txtKnowExam.Enabled = true;            

        }
        catch (Exception lnkSchoolGpa_Click_Exp)
        {

        }
        finally
        { 
        
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:
        /// Author: hussaint
        /// Date :6/27/2009 3:40:01 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//        
        int intStudentId = 0;
        try
        {
            if (!mValidate()) return;


            if (Session["StudentId"] == null || Session["StudentId"].ToString().Equals(""))
            {
                objStudent.strStudent_Registration_Id = "";
            }
            else
            {
                objStudent.strStudent_Registration_Id = Session["StudentId"].ToString();
            }
            
            objStudent.strLocalId = txtLocalId.Text.Trim();
            objStudent.strCollegeId = HIDDEN_COLLEGE_ID.Text;

            objStudent.strFirstNameAr = txtFirstNameAr.Text.Trim();
            objStudent.strFirstNameEn = txtFirstNameEn.Text.Trim();
            objStudent.strMiddleNameAr = txtMiddleNameAr.Text.Trim();
            objStudent.strMiddleNameEn = txtMiddleNameEn.Text.Trim();
            objStudent.strGrandFatherNameAr = txtGrandFatherAr.Text.Trim();
            objStudent.strGrandFatherNameEn = txtGrandFatherEn.Text.Trim();
            objStudent.strFamilyNameAr = txtFamilyNameAr.Text.Trim();
            objStudent.strFamilyNameEn = txtFamilyNameEn.Text.Trim();
            objStudent.strPlaceOfBirth = txtPlaceOfBirth.Text.Trim();
            
            objStudent.strDateOfBirth = ddlHirjiDay.SelectedItem.Text + "/" + ddlHirjriMonth.SelectedItem.Text + "/" + ddlHirjiYear.SelectedItem.Text;
            objStudent.strAddress = txtStudentAddress.Text.Trim();
            objStudent.strStudentCountry = ddlStudentCountry.SelectedValue.ToString();

            if (!ddlStudentCity.SelectedValue.Equals(""))
            {
                objStudent.strStudentCity = ddlStudentCity.SelectedValue.ToString();
            }
            else
            {
                objStudent.strStudentCity = "";
            }

            objStudent.strStudentMobile = txtStudentMobile.Text.Trim();
            objStudent.strStudentPhone = ddlStudentPhonePrefix.SelectedItem.Text  + txtStudentHomePhone.Text.Trim();
            objStudent.strEmail = txtEmail.Text.Trim();
            objStudent.strRefRelationId = ddlRleationShip.SelectedValue.ToString();  
            objStudent.strRefName = txtReferenceName.Text.Trim();
            objStudent.strRefMobile = txtReferenceMobile.Text.Trim();
            objStudent.strRefHomePhone = ddlRefPhonePrefix.SelectedItem.Text + txtRefHomePhone.Text.Trim();
            objStudent.strRefWorkPhone = ddlRefWorkPhone.SelectedItem.Text + txtRefWorkPhone.Text.Trim();
            objStudent.strSchoolName = txtSchoolName.Text.Trim();
            objStudent.strShcoolCountry = ddlSchoolCountry.SelectedValue.ToString();

            if (!ddlSchoolCity.SelectedValue.Equals(""))
            {
                objStudent.strSchoolCity = ddlSchoolCity.SelectedValue.ToString();
            }
            else
            {
                objStudent.strSchoolCity = "";
            }
            if (intCollegeId == 1 || intCollegeId == 2)
            {
                objStudent.strGraduationyear = txtGraduationYear.Text.Trim();
            }
            else if (intCollegeId == 14 || intCollegeId == 15)
            {
                objStudent.strGraduationyear = ddlGraduationYear.SelectedValue.ToString();
            }

            
            objStudent.strUserName = txtUserName.Text.Trim();
            objStudent.strPassword = objProgram.Encrypt(txtPassword.Text.Trim());

            objStudent.strHighSchoolMarks = txtGeneralPercentage.Text.Trim();
            objStudent.strGodarat = txtGodarat.Text.Trim();
            objStudent.strKnowExam = txtKnowExam.Text.Trim();

            //objStudent.strAlternateCollege = rdPrefrences.SelectedIndex.ToString();             

            objStudent.strStudyOptions = "";

            if (ddlOption1.SelectedIndex > 0)
            {
                objStudent.strStudyOptions += objStudent.strStudyOptions.Trim().Length == 0 ? ddlOption1.SelectedItem.Text : "," + ddlOption1.SelectedItem.Text; 
            }

            if (ddlOption2.SelectedIndex > 0)
            {
                objStudent.strStudyOptions += objStudent.strStudyOptions.Trim().Length == 0 ? ddlOption2.SelectedItem.Text : "," + ddlOption2.SelectedItem.Text;
            }

            if (ddlOption3.SelectedIndex > 0)
            {
                objStudent.strStudyOptions += objStudent.strStudyOptions.Trim().Length == 0 ? ddlOption3.SelectedItem.Text : "," + ddlOption3.SelectedItem.Text;
            }
            
            //if (ddlOption1.SelectedIndex > 0 || ddlOption2.SelectedIndex > 0 || ddlOption3.SelectedIndex > 0)
            //{
            //    objStudent.strStudyOptions = ddlOption1.SelectedItem.Text + "," + ddlOption2.SelectedItem.Text + "," + ddlOption3.SelectedItem.Text;
            //}
            //else
            //{
            //    objStudent.strStudyOptions = "";
            //}



            if (!txtGeneralPercentage.Text.Trim().Equals(txtGeneralPercentage.CssClass.Trim()) || !txtGodarat.Text.Trim().Equals(txtGodarat.CssClass.Trim()) || !txtKnowExam.Text.Trim().Equals(txtKnowExam.CssClass.Trim()))
            {
                objStudent.strMarkEdit = "Y";
            }
            else
            {
                objStudent.strMarkEdit = "N";
            }
            
            intStudentId =  objStudent.SaveStudent();

            //After Getting the StudentId It will create the Session Variable to pass this ID to Report Part.
            if (intStudentId > 0)
            {
                if (Session["StudentId"] == null || Session["StudentId"].ToString().Equals(""))
                {

                    Session.Add("StudentId", intStudentId.ToString());
                }               

                Response.Redirect("Report.aspx",false);                
            }

        }
        catch (Exception btnSave_Click_Exp)
        {
            objProgram.gAddLog("register.aspx", "btnSave_Click", btnSave_Click_Exp.Message);
            Response.Redirect("~/error.aspx?error=" + HttpUtility.UrlEncode("حدث خطأ اثناء محاولة حفظ بياناتك ، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."),false);
        }
        finally
        {
            objStudent = null;
        }
    }
    protected bool mValidate()
    {

        //=====================================================//
        /// <summary>
        /// Description: This would be used to perform the validation before saving the Information
        /// Author: hussaint
        /// Date :6/27/2009 12:13:10 PM
        /// Parameter:
        /// input:
        /// output: Bool suggesting that whether this operations succeeded or failed
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            
            bool blnResult = true;

            //if (ddlOption1.Items.Count > 0)
            //{
            //   if (ddlOption1.SelectedIndex == 0 && ddlOption2.SelectedIndex == 0 && ddlOption3.SelectedIndex == 0)
            //    {
            //        blnResult = false;
            //        mpeStudyOptions.Show(); 
            //        
            //    }
            //}

            //if (!txtPassword.Text.ToString().Trim().Equals(txtRetypedPassword.Text.ToString().Trim()))
            //{
            //    blnResult = false;
            //    mpeStudentPassword.Show(); 
            //}

            //if (!txtEmail.Text.ToString().Trim().Equals(txtEmail2.Text.ToString().Trim()))
            //{
            //    blnResult = false;
            //    mpeCheckEmailExistence.Show();
            //}

            if (double.Parse(txtGeneralPercentage.Text.Trim()) > 100 || double.Parse(txtGodarat.Text.Trim()) > 100 || double.Parse(txtKnowExam.Text.Trim()) > 100)
            {
               
                mpeCheckMarks.Show(); 
                blnResult = false;
                return blnResult;
            }

            if (Session["StudentId"] == null || Session["StudentId"].ToString().Equals(""))
            {
                if (objProgram.gCheckRecordExistence("student_registration", "local_id", txtLocalId.Text.Trim(), "S"))
                {
                    mpeCheckStudentExistence.Show();
                    blnResult = false;
                    return blnResult;
                }

                if (objProgram.gCheckRecordExistence("student_registration", "user_name", txtUserName.Text.Trim(), "S"))
                {
                    mpeCheckUserName.Show();
                    blnResult = false;
                    return blnResult;
                }

                if (objProgram.gCheckRecordExistence("student_registration", "email_address", txtEmail.Text.Trim(), "S"))
                {
                    mpeCheckEmailExistence.Show();
                    blnResult = false;
                    return blnResult;
                }

            }
            
            return blnResult;
        }
        catch (Exception mValidate_Exp)
        {
            return false;
        }
        finally
        { 
        
        }
    }
   
    
}
