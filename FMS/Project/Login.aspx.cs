using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void ValidateUser(object sender, EventArgs e)
    {
        //int userId = 0;
        string userId;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            try{
            using (SqlCommand cmd = new SqlCommand("Validate_User"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", Login1.UserName);
                cmd.Parameters.AddWithValue("@Password", Login1.Password);
                cmd.Connection = con;
                con.Open();
                userId = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
                //Response.Write(userId);
            }
            switch (userId)
            {
                case "-1":
                    Login1.FailureText = "Username and/or password is incorrect.";
                    //Session["data"] = null;
                    break;
                case "-2":
                    Login1.FailureText = "Account has not been activated.";
                    //Session["data"] = null;
                    break;
                
                default:

                    //Response.Write(Session["data"]);
                    //Session["validate"] = true;
                    //Session["data"] = true;
                    Session["role"] = userId;
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);

                    //Response.Write(Session["data"]);
                    break;
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