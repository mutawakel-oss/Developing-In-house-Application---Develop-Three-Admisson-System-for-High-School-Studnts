
#region Copyright KSU-HS,COM. 2009
//
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
// Filename: StudentAdministration.cs
// File Version: 0.1
//
#endregion


#region "namespaces"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.DirectoryServices;
    using System.Data;
#endregion


public partial class UserManagerClass : System.Web.UI.Page
{
    //Set LDAP properties, user name and password to authenticate
    string strLDAPDomainPath = "LDAP://10.8.128.100";
    string strLDAPAuthUID = "karadas";
    string strLDAPAuthPWD = "hosamane^";
    DataTable myDt;
    GeneralClass.Program objProgram = new GeneralClass.Program();
    GeneralClass.Program ProgramClass = new GeneralClass.Program();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mangeUserAuthorized"] == null)
            Response.Redirect("~/adminLogin.aspx",false);
        if (!IsPostBack)
        {
            InformationLabel1.Text = "لإدخال مستخدم جديد للنظام الرجاء اتباع الطريقة الآتية:\n"+
            "\n"+
            "1- ادخل اسم المستخدم للمستخدم المراد البحث عنه ثم اظغط زر 'ابحث'"+
            "\n"+
            "2- اختر المستخدم المراد ادراجة ثم اظغط زر 'ادراج'"+
            "\n"+
            "3- اختر الإمتيازات اللازمة للمستخدم بالظغط على زر 'تحرير'";
        }
        myDt = new DataTable();
        myDt = CreateDataTable();
        Session["myDatatable"] = myDt;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private DataTable CreateDataTable()
    {   
        DataTable myDataTable = new DataTable();
        DataColumn myDataColumn;

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "LoginName";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "UserName";
        myDataTable.Columns.Add(myDataColumn);

        
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CurrentRoles";
        myDataTable.Columns.Add(myDataColumn);
        
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.Boolean");
        myDataColumn.ColumnName = "Exist";
        myDataTable.Columns.Add(myDataColumn);
        
        return myDataTable;
    }


    /// <summary>
    /// The button click event serach the user names in LDAP and populate the table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void SearchLdapUsers(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        //Try to get the Entry point in ldap by providing the parameter:
        //1- LDAP main path
        //2-User name
        //3-Password
        //variables in this event is prefixed with 'p_'. For eg: p_SearchResult
        if (IsPostBack)
        {
            System.DirectoryServices.DirectoryEntry p_DirectoryEntry = new DirectoryEntry(strLDAPDomainPath, strLDAPAuthUID, strLDAPAuthPWD);
            Object obj = p_DirectoryEntry.NativeObject;
            DirectorySearcher p_DirectorySearch = new DirectorySearcher(p_DirectoryEntry);
            SearchResultCollection p_SearchResult = p_DirectorySearch.FindAll();

            //if we got the entry point,
            int i = 0;
            if (p_SearchResult != null)
            {
                #region "For MED domain"
                foreach (SearchResult search_result in p_DirectorySearch.FindAll())
                {
                    string p_UserName = GetProperty(search_result, "sAMAccountName");
                    string p_DisplayName = GetProperty(search_result, "displayName");
                        if (p_UserName != "")
                        {
                            if (p_DisplayName.Trim().ToLower().IndexOf(UserSearchTextBox.Text.ToLower()) >= 0)
                            {
                                DataRow row = myDt.NewRow();
                                row["LoginName"] = p_UserName.ToLower();
                                row["UserName"] = p_DisplayName;
                                //if this user has any predefined roles in role database table,
                                //populate this in a columns
                                row["Exist"] = true;
                                ProgramClass.strSql = "SELECT role FROM authentication WHERE username='" + p_UserName + "'";
                                ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);
                                if (ProgramClass.drData != null)
                                {
                                    ProgramClass.drData.Read();
                                    //if there is a row in authentication for this user, 
                                    //then get his role from role database table
                                    if (ProgramClass.drData.HasRows)
                                    {
                                        row["Exist"] = false;
                                        string RoleValue = ProgramClass.drData[0].ToString();
                                        ProgramClass.drData.Close();
                                        if (RoleValue != "")//if role column in authentication table has value
                                        {
                                            ProgramClass.strSql = "SELECT role_name FROM role WHERE id IN(" + RoleValue + ")";
                                            ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);
                                            if (ProgramClass.drData != null)
                                            {
                                                string Role = "";
                                                while (ProgramClass.drData.Read())
                                                {
                                                    Role += ProgramClass.drData[0] + ",";
                                                }
                                                if (Role != "") Role = Role.Remove(Role.Length - 1);
                                                ProgramClass.drData.Close();
                                                row["CurrentRoles"] = Role;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        row["Exist"] = true;
                                    }
                                }
                                myDt.Rows.Add(row);
                            }
                            i++;
                        }
                }

                #endregion

                #region "For KSUHS domain"
                    p_DirectoryEntry = new DirectoryEntry("LDAP://KSUHS", strLDAPAuthUID, strLDAPAuthPWD);
                    p_DirectorySearch = new DirectorySearcher(p_DirectoryEntry);
                    p_SearchResult = p_DirectorySearch.FindAll();
                    if (p_SearchResult != null)
                    {
                        foreach (SearchResult search_result in p_DirectorySearch.FindAll())
                        {
                            string p_UserName = GetProperty(search_result, "sAMAccountName");
                            string p_DisplayName = GetProperty(search_result, "displayName");
                            if (p_UserName != "")
                            {
                                if (p_DisplayName.Trim().ToLower().IndexOf(UserSearchTextBox.Text.ToLower()) >= 0)
                                {
                                    DataRow row = myDt.NewRow();
                                    row["LoginName"] = p_UserName.ToLower();
                                    row["UserName"] = p_DisplayName;
                                    //if this user has any predefined roles in role database table,
                                    //populate this in a columns
                                    row["Exist"] = true;
                                    ProgramClass.strSql = "SELECT role FROM authentication WHERE username='" + p_UserName + "'";
                                    ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);
                                    if (ProgramClass.drData != null)
                                    {
                                        ProgramClass.drData.Read();
                                        //if there is a row in authentication for this user, 
                                        //then get his role from role database table
                                        if (ProgramClass.drData.HasRows)
                                        {
                                            row["Exist"] = false;
                                            string RoleValue = ProgramClass.drData[0].ToString();
                                            ProgramClass.drData.Close();
                                            if (RoleValue != "")//if role column in authentication table has value
                                            {
                                                ProgramClass.strSql = "SELECT role_name FROM role WHERE id IN(" + RoleValue + ")";
                                                ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);
                                                if (ProgramClass.drData != null)
                                                {
                                                    string Role = "";
                                                    while (ProgramClass.drData.Read())
                                                    {
                                                        Role += ProgramClass.drData[0] + ",";
                                                    }
                                                    if (Role != "") Role = Role.Remove(Role.Length - 1);
                                                    ProgramClass.drData.Close();
                                                    row["CurrentRoles"] = Role;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            row["Exist"] = true;
                                        }
                                    }
                                    myDt.Rows.Add(row);
                                }
                                i++;
                            }
                        }
                    }
                #endregion
            }
            this.GridView1.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
            this.GridView1.DataBind();

            GridView1.Visible = true;
        }
    }
    /// <summary>
    /// Use this function to get some properties like first name , last name etc
    /// </summary>
    /// <param name="searchResult"></param>
    /// <param name="PropertyName"></param>
    /// <returns></returns>
    public string GetProperty(SearchResult searchResult, string PropertyName)
    {
        try
        {
            if (searchResult.Properties.Contains(PropertyName))
                return searchResult.Properties[PropertyName][0].ToString();
            else
                return string.Empty;
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Redirect("app_exception.aspx?errorcode=" + ex.Message,false);
            return string.Empty;
        }
    }

    protected void SaveClick(object sender, EventArgs e)
    {
        string BulkInsertStatement = "";
        try
        {
            int i = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox SelectedCheckBox = (CheckBox)row.FindControl("chkReportViewer");
                if (SelectedCheckBox != null)
                {
                    if (SelectedCheckBox.Enabled == true && SelectedCheckBox.Checked == true)
                    {
                        Label HIDDEN_USER_NAME = (Label)row.FindControl("HIDDEN_USER_NAME");
                        BulkInsertStatement += "INSERT INTO authentication(username) VALUES('" + HIDDEN_USER_NAME.Text + "')" + "|";
                    }
                }
                i++;
            }
        }
        catch (Exception ex)
        {
            objProgram.gAddLog("usermanager.aspx", "SaveClick", ex.Message);
            Response.Redirect("~/error.aspx?error=" + HttpUtility.UrlEncode("حدث خطأ اثناء محاولة حفظ البيانات ، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."),false);
            //HttpContext.Current.Response.Redirect("app_exception.aspx?errorcode=" + ex.Message);
        }
        finally
        {
            if(BulkInsertStatement!="")
            ProgramClass.BulkInsert(BulkInsertStatement);

            SearchLdapUsers(sender, new EventArgs());
        }
    }

    protected void ClickLink(object sender, EventArgs e)
    {        
        CollegeNameCheckList.Items.Clear();
        RoleNameCheckList.Items.Clear();

        try
        {
            LinkButton LinkObject = (LinkButton)sender;
            UserNameLabel.Text = LinkObject.ToolTip.ToString();
            
            //get the college data from the server
            #region "Create check box items from college_preset"
                ProgramClass.strSql = "SELECT id,college_name FROM college_preset";
                ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);
                while (ProgramClass.drData.Read())
                {
                    ListItem CollegeNameListItem = new ListItem();
                    CollegeNameListItem.Text = ProgramClass.drData[1].ToString();
                    CollegeNameListItem.Value = ProgramClass.drData[0].ToString();
                    CollegeNameCheckList.Items.Add(CollegeNameListItem);
                }
                ProgramClass.drData.Close();
            #endregion

            #region "Create check box items from role"
                ProgramClass.strSql = "SELECT id,role_name FROM role";
                ProgramClass.drData = ProgramClass.gRetrieveRecord(ProgramClass.strSql);
                while (ProgramClass.drData.Read())
                {
                    ListItem RoleNameListItem = new ListItem();
                    RoleNameListItem.Text = ProgramClass.drData[1].ToString();
                    RoleNameListItem.Value = ProgramClass.drData[0].ToString();
                    RoleNameCheckList.Items.Add(RoleNameListItem);
                }
                ProgramClass.drData.Close();
            #endregion
            
            mdlPopup.Show();         
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Redirect("app_exception.aspx?errorcode=" + ex.Message,false);
        }
        
    }

    protected void SaveRights(object sender, EventArgs e)
    {
        try
        {
            string[] Splitted=UserNameLabel.Text.Split('-');
            string role_selected        = "";
            string college_selected     = "";
            for (int i = 0; i < RoleNameCheckList.Items.Count; i++)
            {
                if(RoleNameCheckList.Items[i].Selected==true)
                    role_selected += RoleNameCheckList.Items[i].Value + ",";
            }

            for (int i = 0; i < CollegeNameCheckList.Items.Count; i++)
            {
                if (CollegeNameCheckList.Items[i].Selected == true)
                    college_selected += CollegeNameCheckList.Items[i].Value + ",";
            }
            if (role_selected != "")
            {
                role_selected = role_selected.Remove(role_selected.Length - 1);
            }
            if (college_selected != "")
            {
                college_selected = college_selected.Remove(college_selected.Length - 1);
            }
            if (college_selected != "" && role_selected != "")
            {
                ProgramClass.gRetrieveRecord("UPDATE authentication SET role='" + role_selected + "',college_id='" + college_selected + "' WHERE username=" +
                    "'" + Splitted[0] + "'");
                SearchLdapUsers(sender, new EventArgs());
            }
        }
        catch (Exception ex)
        {
            objProgram.gAddLog("usermanager.aspx", "SaveRights", ex.Message);
            Response.Redirect("~/error.aspx?error=" + HttpUtility.UrlEncode("حدث خطأ اثناء محاولة حفظ البيانات ، الرجاء الظغط عل زر 'اتصل بنا' لإرسال طلب مساعدة من المسؤولين عن النظام."),false);
            //HttpContext.Current.Response.Redirect("app_exception.aspx?errorcode=" + ex.Message);            
        }
    }

}
