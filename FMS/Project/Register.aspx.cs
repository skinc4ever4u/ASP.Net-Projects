using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            Label1.Visible = false;
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

    protected string groupcheck()
    {
        if ( RadioButton1.Checked)
        {
            return RadioButton1.Text.Trim();
        }
        else
        {
            return RadioButton2.Text.Trim();
        }
    }
    protected void RegisterUser(object sender, EventArgs e)
    {
        int userId = 0;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            try{
            using (SqlCommand cmd = new SqlCommand("Insert_User"))
            {

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Roles", groupcheck());
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            string message = string.Empty;
            string message1 = string.Empty;
            switch (userId)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different username.";
                    message1 = "Username already exists.";
                    break;
                case -2:
                    message = "Supplied email address has already been used.";
                    message1 = "Supplied email address has already been used.";
                    break;
                default:
                    message = "Registration successful.\\nUser Id: " + userId.ToString();
                    message1 = "Registration successful.";
                    break;
            }
            Label1.Visible = true;
            Label1.Text = message1;
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
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
}