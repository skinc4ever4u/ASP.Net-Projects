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


public partial class Search : System.Web.UI.Page
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
            if (Session["role"].ToString() != "Admin" && Session["role"].ToString() != "User" && Session["role"].ToString() != "Head")
            {
                FormsAuthentication.SignOut();
                Session["data"] = null;
                Session["role"] = "-1";
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                if (Session["role"].ToString() == "User")
                {
                    Label2.Visible = true;
                    
                }
                else if (Session["role"].ToString() == "Head")
                {
                    Label3.Visible = true;
                    
                    LUpload.Visible = true;
                    Upload.Visible = true;
                    LCompany.Visible = true;
                    Company.Visible = true;
                }
                else if (Session["role"].ToString() == "Admin")
                {
                    Label4.Visible = true;
                    LUpload.Visible = true;
                    Upload.Visible = true;
                    LCompany.Visible = true;
                    Company.Visible = true;
                    LRegister.Visible = true;
                    Register.Visible = true;
                    LFDelete.Visible = true;
                    Delete.Visible = true;
                }
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ArrayList al= new ArrayList();
            for (int i = 1950; i < 2051; i++)
                al.Add(i);
            DropDownList5.DataSource = al;
            DropDownList5.DataBind();
            try
            {
                ListItem li = new ListItem();
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGridviewData();
    }

    private void BindGridviewData()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            try{
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select fu.FileId, fd.Username, fd.Company_Name, fd.Module, fd.CreatedDate, fu.File_Description, fu.File_Type, fu.File_Path ,fu.F_Name from file_data fd join file_uploaded fu on fd.FileId=fu.FileId where fd.Module=@Module and fd.UserId=@UserId order by fd.FileId desc";
                cmd.Parameters.AddWithValue("@UserId", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Module", DropDownList3.SelectedItem.Value);
                cmd.Connection = con;
                con.Open();
                gvDetails.DataSource = cmd.ExecuteReader();
                gvDetails.DataBind();
                con.Close();
            }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        try{
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        int fileid = Convert.ToInt32(gvDetails.DataKeys[gvrow.RowIndex].Value.ToString());
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            try{
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select File_Path, F_Name from file_uploaded where FileId=@id";
                cmd.Parameters.AddWithValue("@id", fileid);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    FileInfo fileInfo = new FileInfo(dr[0].ToString() + dr[1].ToString());
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
                    Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.Flush();
                    Response.WriteFile(fileInfo.FullName);
                    Response.End();
                    /*
                    Response.ContentType = dr["FileType"].ToString();
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + dr["FileName"] + "\"");
                    Response.BinaryWrite((byte[])dr["FileData"]);
                    Response.End();
                     */
                }
                con.Close();
                dr.Close();
            }
            }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
        }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        BindGridviewDatacom();
    }
    private void BindGridviewDatacom()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            try{
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select fu.FileId, fd.Username, fd.Company_Name, fd.Module, fd.CreatedDate, fu.File_Description, fu.File_Type, fu.File_Path ,fu.F_Name from file_data fd join file_uploaded fu on fd.FileId=fu.FileId where fd.Module=@Module and fd.Company_id=@comId order by fd.FileId desc";
                cmd.Parameters.AddWithValue("@comid", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Module", DropDownList4.SelectedItem.Value);
                cmd.Connection = con;
                con.Open();
                gvDetails.DataSource = cmd.ExecuteReader();
                gvDetails.DataBind();
                con.Close();
            }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        BindGridviewDatayear();
    }
    private void BindGridviewDatayear()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            try{
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select fu.FileId, fd.Username, fd.Company_Name, fd.Module, fd.CreatedDate, fu.File_Description, fu.File_Type, fu.File_Path ,fu.F_Name from file_data fd join file_uploaded fu on fd.FileId=fu.FileId where fd.file_year=@year";
                cmd.Parameters.AddWithValue("@year", DropDownList5.SelectedItem.Value);
                //cmd.Parameters.AddWithValue("@Module", DropDownList4.SelectedItem.Value);
                cmd.Connection = con;
                con.Open();
                gvDetails.DataSource = cmd.ExecuteReader();
                gvDetails.DataBind();
                con.Close();
            }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}