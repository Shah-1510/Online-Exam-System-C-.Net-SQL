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
    public partial class Settings : System.Web.UI.Page
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

                updateFirstName.Attributes.Add("Placeholder", userName1.ToString());
                updateLastName.Attributes.Add("Placeholder", userName2.ToString());
                updateEmail.Attributes.Add("Placeholder", SQLemail.ToString());
                updateAge.Attributes.Add("Placeholder", SQLage.ToString());

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

        protected void Save(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                if (updateFirstName.Text == "" && updateLastName.Text == "" && updateEmail.Text == "" && updateAge.Text == "")
                {
                    Response.Redirect("/Student/Settings1.aspx");
                }

                if (updateFirstName.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("UPDATE Students SET FirstName = '" + updateFirstName.Text + "' WHERE Email = '" + Session["id"] + "' ", con);
                    cmd1.ExecuteNonQuery();
                }

                if (updateLastName.Text != "")
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE Students SET LastName = '" + updateLastName.Text + "' WHERE Email = '" + Session["id"] + "' ", con);
                    cmd2.ExecuteNonQuery();
                }

                if (updateEmail.Text != "")
                {
                    SqlCommand cmd3 = new SqlCommand("UPDATE Students SET Email = '" + updateEmail.Text + "' WHERE Email = '" + Session["id"] + "' ", con);
                    cmd3.ExecuteNonQuery();
                    Response.Write("<script> alert('Email Address Successfully Changed') </script>");
                    Session.RemoveAll();
                    Response.Redirect("/Registration/Login.aspx");
                }

                if (updateAge.Text != "")
                {
                    SqlCommand cmd4 = new SqlCommand("UPDATE Students SET Age = '" + updateAge.Text + "' WHERE Email = '" + Session["id"] + "' ", con);
                    cmd4.ExecuteNonQuery();
                }

                Response.Redirect("/Student/Profile.aspx");

                con.Close();
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void EmailCheck(object sender, EventArgs e)
        {
            string EmailID = updateEmail.Text;

            SqlCommand cmd = new SqlCommand("SELECT Email FROM Students WHERE Email ='" + EmailID + "'", con);

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {     
                errorMsg.Text = "* Email Address already exists";
                savebtn.Enabled = false;
            }

            else
            {
                errorMsg.Text = "";
                savebtn.Enabled = true;
            }

            con.Close();
        }
    }
}