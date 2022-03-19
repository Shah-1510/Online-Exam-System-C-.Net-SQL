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
    public partial class Course : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }

            string cid = Request.QueryString["cid"];

            if (cid == null)
            {
                Response.Redirect("/Student/Dashboard.aspx");
            }

            CourseName(Convert.ToInt32(cid));
            CourseList(Convert.ToInt32(cid));

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

        string c = ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString;

        public void CourseName(int id)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Courses WHERE C_ID = @courseid", con);
                cmd.Parameters.AddWithValue("@courseid", id);

                try
                {
                    con.Open();

                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        CourseLabel.Text = rd["CourseName"].ToString();
                    }

                    con.Close();
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public void CourseList(int id)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                try
                {
                    con.Open();

                    SqlCommand getQuiz = new SqlCommand("SELECT * FROM Courses JOIN Quiz ON Courses.C_ID = Quiz.CourseFID WHERE C_ID = @courseid", con);
                    getQuiz.Parameters.AddWithValue("@courseid", id);

                    SqlDataReader rd = getQuiz.ExecuteReader();

                    if (rd.HasRows)
                    {
                        errorLabel.Style.Add("display", "none");
                        noQuiz.Text = "";

                        r2.DataSource = rd;
                        r2.DataBind();
                    }

                    else
                    {
                        noQuiz.Text = "No Quiz Added Yet!";
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