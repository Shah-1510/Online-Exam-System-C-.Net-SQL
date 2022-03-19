using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProjectX.Registration
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void Signin(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);

                    SqlCommand cmd = new SqlCommand("StudentLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", floatingInput.Text);
                    cmd.Parameters.AddWithValue("@password", floatingPassword.Text);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if(sdr.HasRows)
                    {
                        sdr.Read();
                        Session["id"] = floatingInput.Text;
                        Response.Write("<script> alert('Login Successful') </script>");

                        if (check.Checked)
                        {
                            HttpCookie user = new HttpCookie("UserCookies");
                            user["Email"] = floatingInput.Text;
                            user.Expires = DateTime.Now.AddYears(2);
                            Response.Cookies.Add(user);
                        }

                        else
                        {
                            Session["Email"] = floatingInput.Text;
                        }

                        Response.Redirect("/Student/Dashboard.aspx");

                        errorMsg.Text = "";
                        floatingInput.Text = "";
                        floatingPassword.Text = "";
                    }

                    else
                    {
                        errorMsg.Text = "* Invalid email or password";
                    }

                    con.Close();
                }
                
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }         
            }
        }
    }
}