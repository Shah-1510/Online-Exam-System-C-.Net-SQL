using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectX.Student
{
    public partial class Settings2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Notifications WHERE Category = 'Student' AND Visited = 'No' ORDER BY N_ID DESC", con);
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                sda.Fill(dt);

                count = Convert.ToInt32(dt.Rows.Count.ToString());

                if (count >= 1)
                {
                    notificationIcon.Style.Add("display", "inline");
                }

                else
                {
                    notificationIcon.Style.Add("display", "none");
                }

                notification.Text = count.ToString();

                if (count == 1)
                {
                    notifylabel.InnerText = "alert!";
                }

                else if (count > 1)
                {
                    notifylabel.InnerText = "alerts!";
                }

                else
                {
                    topLabel.InnerText = "You are all clear!";
                    notificationHeading.InnerText = "No New Notifications";
                }

                r1.DataSource = dt;
                r1.DataBind();

                SqlCommand cmdUser1 = new SqlCommand("SELECT FirstName FROM Students WHERE Email = '" + Session["id"] + "' ", con);
                SqlCommand cmdUser2 = new SqlCommand("SELECT LastName FROM Students WHERE Email = '" + Session["id"] + "' ", con);

                var userName1 = cmdUser1.ExecuteScalar();
                var userName2 = cmdUser2.ExecuteScalar();

                string userName = userName1.ToString() + " " + userName2.ToString();
                nameLabel.Text = userName.ToString();     

                SqlCommand getEmail = new SqlCommand("SELECT Email FROM Students WHERE Email = '" + Session["id"] + "' ", con);
                string SQLemail = (String)getEmail.ExecuteScalar();

                SqlCommand getAge = new SqlCommand("SELECT Age FROM Students WHERE Email = '" + Session["id"] + "' ", con);
                int SQLage = (Int32)getAge.ExecuteScalar();

                con.Close();
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public string getTwentyCharacters(object myValues)
        {
            string a;
            a = Convert.ToString(myValues.ToString());

            string b = "";

            if (a.Length >= 20)
            {
                b = a.Substring(0, 20);
                return b.ToString() + "...";
            }

            else
            {
                b = a.ToString();
                return b.ToString();
            }
        }

        protected void ChangePassword(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    con.Open();

                    SqlCommand updatePassword = new SqlCommand("UPDATE Students SET Password = '" + newPassword.Text + "' WHERE Email = '" + Session["id"] + "'", con);
                    updatePassword.ExecuteNonQuery();
                    Response.Write("<script> alert('Password Successfully Changed') </script>");
                    Session.RemoveAll();
                    Response.Redirect("/Registration/Login.aspx");
                    
                    con.Close();
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }           
        }

        protected void PasswordCheck(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand getPassword = new SqlCommand("SELECT Password FROM Students WHERE Email = '" + Session["id"] + "'", con);
            string pass = (String)getPassword.ExecuteScalar();

            if (currentPassword.Text != pass)
            {
                errorMsg.Text = "* Invalid Password";
                changepassbtn.Enabled = false;
            }

            else
            {
                errorMsg.Text = "";
                changepassbtn.Enabled = true;
            }
         
            con.Close();
        }
    }
}