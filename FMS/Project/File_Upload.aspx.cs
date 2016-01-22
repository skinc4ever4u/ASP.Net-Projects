using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class File_Upload : System.Web.UI.Page
{
    static String dbstring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    static SqlConnection con = new SqlConnection(dbstring);

    protected void Page_Init(object sender, EventArgs e)
    {
        /*if (PreviousPage.Session["data"]==null)
        {
            Response.AppendHeader("Refresh", "0");
        } */
        //string check = Session["role"].ToString();

        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.SignOut();
            Session["data"] = null;
            Session["role"] = "-1";
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            if (Session["role"].ToString() != "Admin" && Session["role"].ToString() != "Head")
            {
                FormsAuthentication.SignOut();
                Session["data"] = null;
                Session["role"] = "-1";
                FormsAuthentication.RedirectToLoginPage();
            }
            else if (Session["role"].ToString() == "Admin")
            {
                LCompany.Visible = true;
                Company.Visible = true;
                LRegister.Visible = true;
                Register.Visible = true;
                Label4.Visible = true;
                LFDelete.Visible = true;
                Delete.Visible = true;
            }
            else if (Session["role"].ToString() == "Head")
            {
                Label3.Visible = true;
                LCompany.Visible = true;
                Company.Visible = true;
            }
        }
    }
    int year, month;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime tnow = DateTime.Now;
            ArrayList AlYear = new ArrayList();
            int i;
            for (i = 1960; i <= 2040; i++)
                AlYear.Add(i);
            ArrayList AlMonth = new ArrayList();
            for (i = 1; i <= 12; i++)
                AlMonth.Add(i);
            if (!this.IsPostBack)
            {
                DropDownList6.DataSource = AlYear;
                DropDownList6.DataBind();
                DropDownList6.SelectedValue = tnow.Year.ToString();


                DropDownList5.DataSource = AlMonth;
                DropDownList5.DataBind();
                DropDownList5.SelectedValue = tnow.Month.ToString();


                year = Int32.Parse(DropDownList6.SelectedValue);
                month = Int32.Parse(DropDownList5.SelectedValue);


                BindDays(year, month);

                DropDownList4.SelectedValue = tnow.Day.ToString();

            }

            DropDownList6.SelectedItem.Text = System.DateTime.Now.Year.ToString();
            try
            {
                //ListItem li = new ListItem();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select UserId,Username from Users", con);
                SqlCommand cmd = new SqlCommand("select Company_id,Name from Company", con);



                SqlDataReader ddlValues1;
                ddlValues1 = cmd1.ExecuteReader();

                DropDownList1.DataSource = ddlValues1;
                DropDownList1.DataValueField = "UserId";
                DropDownList1.DataTextField = "Username";
                DropDownList1.DataBind();
                ddlValues1.Close();

                SqlDataReader ddlValues;
                ddlValues = cmd.ExecuteReader();

                DropDownList2.DataSource = ddlValues;
                DropDownList2.DataValueField = "Company_id";
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataBind();
                ddlValues.Close();

                /*SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    li.Value = dr[0].ToString();
                    li.Text = dr[1].ToString();

                    DropDownList1.Items.Add(li);
                }
                 */

                con.Close();
            }
            catch (Exception z)
            {
                Response.Write(z.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private bool CheckLeap(int year)
    {
        if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
            return true;
        else return false;
    }
    //binding every month day
    private void BindDays(int year, int month)
    {
        int i;
        ArrayList AlDay = new ArrayList();

        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                for (i = 1; i <= 31; i++)
                    AlDay.Add(i);
                break;
            case 2:
                if (CheckLeap(year))
                {
                    for (i = 1; i <= 29; i++)
                        AlDay.Add(i);
                }
                else
                {
                    for (i = 1; i <= 28; i++)
                        AlDay.Add(i);
                }
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                for (i = 1; i <= 30; i++)
                    AlDay.Add(i);
                break;
        }

        DropDownList4.DataSource = AlDay;
        DropDownList4.DataBind();

    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = Int32.Parse(DropDownList6.SelectedValue);
        month = Int32.Parse(DropDownList5.SelectedValue);
        BindDays(year, month);
        SetFocus(DropDownList6);
        DropDownList5.Enabled = true;
    }

    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = Int32.Parse(DropDownList6.SelectedValue);
        month = Int32.Parse(DropDownList5.SelectedValue);
        BindDays(year, month);
        SetFocus(DropDownList5);
        DropDownList4.Enabled = true;
    }


    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {

        //HttpResponse.RemoveOutputCacheItem("/caching/Home.aspx");

        FormsAuthentication.SignOut();
        Session["data"] = null;
        //ClearApplicationCache();
        //LoginStatus1.Dispose();
        Response.Redirect("Login.aspx");
        //FormsAuthentication.RedirectToLoginPage();
    }
    protected bool check()
    {

        Label2.Visible = true;
        if (DropDownList1.Text == "")
        {
            Label2.Text = "please select the User Name ";
            return false;
        }
        else if (DropDownList2.Text == "")
        {
            Label2.Text = "please select the Company Name ";
            return false;
        }
        else if (DropDownList3.Text == "")
        {
            Label2.Text = "please select the Module ";
            return false;
        }
        else if (DropDownList4.Text == "" || DropDownList5.Text == "" || DropDownList6.Text == "" || DropDownList5.Enabled == false || DropDownList4.Enabled == false)
        {
            Label2.Text = "please select the Date ";
            return false;
        }
        else if (TextBox1.Text == "")
        {
            Label2.Text = "please Enter the Description ";
            return false;
        }
        else if (!FileUpload1.HasFile)
        {
            Label1.Text = "*";
            Label1.Visible = true;
            Label2.Text = "please select the file first";
            return false;
        }
        else
        {
            Label1.Visible = false;
            Label2.Visible = false;
            return true;
        }

    }
    protected string filetype(string extension)
    {
        if (extension == ".pdf")
            return "Acrobat Reader";
        else if (extension == ".doc" || extension == ".docx")
            return "Word";
        else if (extension == ".xls" || extension == ".xlsx")
            return "Excel";
        else if (extension == ".ppt" || extension == ".pptx")
            return "Power Point";

        else
        {
            return "ERROR";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (check())
        {
            int FileId = 0, res = 0;
            string Ftype, Fname;
            string uploadFolder = Request.PhysicalApplicationPath + "Files_DATA\\";
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            Ftype = filetype(extension);
            if (Ftype != "ERROR")
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("Insert_File_Data"))
                        {

                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@UserId", DropDownList1.SelectedItem.Value);
                                cmd.Parameters.AddWithValue("@Username", DropDownList1.SelectedItem.Text);
                                cmd.Parameters.AddWithValue("@Company_id", DropDownList2.SelectedItem.Value);
                                cmd.Parameters.AddWithValue("@Company_Name", DropDownList2.SelectedItem.Text);
                                cmd.Parameters.AddWithValue("@Module", DropDownList3.SelectedItem.Value);
                                cmd.Parameters.AddWithValue("@CreatedDate", DropDownList5.SelectedItem.Text + "/" + DropDownList4.SelectedItem.Text + "/" + DropDownList6.SelectedItem.Text);
                                cmd.Parameters.AddWithValue("@file_year", DropDownList6.SelectedItem.Text);

                                cmd.Connection = con;
                                con.Open();
                                FileId = Convert.ToInt32(cmd.ExecuteScalar());
                                con.Close();
                                sda.Dispose();
                            }
                        }
                        using (SqlCommand cmd = new SqlCommand("Insert_File_Uploaded"))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                Fname = FileId.ToString() + extension;

                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@FileId", FileId);
                                cmd.Parameters.AddWithValue("@File_Description", TextBox1.Text);
                                cmd.Parameters.AddWithValue("@File_Type", Ftype);
                                cmd.Parameters.AddWithValue("@File_Path", uploadFolder);
                                cmd.Parameters.AddWithValue("@F_Name", Fname);

                                cmd.Connection = con;
                                con.Open();
                                res = Convert.ToInt32(cmd.ExecuteScalar());

                                //Label1.Text = "File uploaded successfully as: " + "Test" + extension;

                                con.Close();
                                sda.Dispose();

                                FileUpload1.SaveAs(uploadFolder + FileId.ToString() + extension);

                                Label2.Text = "File uploaded successfully as: " + Fname;
                                Label2.Visible = true;

                                //Label1.Text = "File uploaded successfully as: " + "Test" + extension;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Label1.Text = ex.ToString();
                    Label1.Visible = true;
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Label2.Text = "Unsupported file selected";
                Label2.Visible = true;
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert(Error!);", true);
        }
    }
}