using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.IO;

public partial class File_Delete : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            //Label1.Visible = false;
        }
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
            if (Session["role"].ToString() != "Admin")
            {
                FormsAuthentication.SignOut();
                Session["data"] = null;
                Session["role"] = "-1";
                FormsAuthentication.RedirectToLoginPage();
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
        //FormsAuthentication.RedirectToLoginPage();
        Response.Redirect("Login.aspx");
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
                try
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
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        
    }

    private void BindGridviewFile()
    {
        try
        {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            try{
            using (SqlCommand cmd = new SqlCommand())
            {
                //cmd.CommandText = "select fu.FileId, fd.Username, fd.Company_Name, fd.Module, fd.CreatedDate, fu.File_Description, fu.File_Type, fu.File_Path ,fu.F_Name from file_data fd join file_uploaded fu on fd.FileId=fu.FileId where fd.FileId=@ID";
                cmd.CommandText = "select fu.FileId, fd.Username, fd.Company_Name, fd.Module, fd.CreatedDate, fu.File_Description, fu.File_Type, fu.File_Path ,fu.F_Name ,fu.F_Name from file_data fd join file_uploaded fu on fd.FileId=fu.FileId where fd.FileId=@ID";
                cmd.Parameters.AddWithValue("@ID", TextBox1.Text);
                //cmd.Parameters.AddWithValue("@Module", DropDownList4.SelectedItem.Value);
                cmd.Connection = con;
                con.Open();
                gvDetails.DataSource = cmd.ExecuteReader();
                
                    //Button2.Visible = true;
                    gvDetails.DataBind();
                    //Label1.Text = "File Found";
                   //Label1.Visible = true;
                

                
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
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
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
                 cmd.CommandText = "select F_Name from file_uploaded where FileId=@id";
                cmd.Parameters.AddWithValue("@id", fileid);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    string fname = dr[0].ToString();
                    con.Close();
                    con.Open();
                    SqlCommand del = new SqlCommand("delete file_uploaded where FileId=@dae; delete file_data where FileId=@dae;", con);
                    SqlParameter sql2 = del.Parameters.Add("@dae", SqlDbType.Int);
                    sql2.Value = fileid;
                    int result = del.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Label1.Text = "data deleted succefully";
                        Label1.Visible = true;

                        string completePath = Server.MapPath("~/Files_DATA/" + fname); if (System.IO.File.Exists(completePath))
                        {
                            System.IO.File.Delete(completePath);
                        }
                        dr.Close();
                        con.Close();
                    }
                    else
                    {
                        Label1.Text = "there is no data for this date";
                        Label1.Visible = true;
                    }
                    con.Close();
                }
                else {
                    con.Close();
                    
                }

            }
            //gvDetails.DeleteRow(0);
            BindGridviewFile();
            gvDetails.EmptyDataText = "File Not Found";
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGridviewFile();
        
    }
}