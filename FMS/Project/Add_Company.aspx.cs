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

public partial class Add_Company : System.Web.UI.Page
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
        else if (Session["role"] == null)
        {
            FormsAuthentication.SignOut();
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
                
                LRegister.Visible = true;
                Register.Visible = true;
                Label4.Visible = true;
                LFDelete.Visible = true;
                Delete.Visible = true;
            }
            else if (Session["role"].ToString() == "Head")
            {
                
                Label3.Visible = true;
            }
        }


    }
    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        
            //HttpResponse.RemoveOutputCacheItem("/caching/Home.aspx");

            FormsAuthentication.SignOut();
            Session["data"] = null;
            Response.Redirect("Login.aspx");
            //ClearApplicationCache();
            //LoginStatus1.Dispose();
            //FormsAuthentication.RedirectToLoginPage();       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert Company values(@name,@address,@description)", con);

            SqlParameter sql1 = cmd.Parameters.Add("@name", SqlDbType.VarChar, 80);
            sql1.Value = TextBox1.Text;

            SqlParameter sql2 = cmd.Parameters.Add("@address", SqlDbType.VarChar, 80);
            sql2.Value = TextBox2.Text;

            SqlParameter sql3 = cmd.Parameters.Add("@description", SqlDbType.VarChar, 80);
            sql3.Value = TextBox3.Text;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                //Response.Redirect("Default2.aspx");
                Label1.Text = "Added Succesfully ";
                Label1.Visible = true;
            }
            con.Close();
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