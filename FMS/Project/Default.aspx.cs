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

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.SignOut();
            Session["data"] = null;
            Session["role"] = "-1";
            FormsAuthentication.RedirectToLoginPage();

        }
        else if (Session["role"] == null)
        {
            FormsAuthentication.SignOut();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridviewData();
        }
    }
    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        FormsAuthentication.SignOut();
        Session["role"] = null;
        Response.Redirect("Login.aspx");
        //FormsAuthentication.RedirectToLoginPage();
    }

    private void BindGridviewData()
    {
       
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            try
            {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select top 5 fu.FileId, fd.Username, fd.Company_Name, fd.Module, fd.CreatedDate, fu.File_Description, fu.File_Type, fu.File_Path ,fu.F_Name from file_data fd join file_uploaded fu on fd.FileId=fu.FileId order by fd.FileId desc";
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
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}