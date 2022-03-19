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
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Closed)
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

                SqlCommand cmdSemester = new SqlCommand("SELECT Semester FROM Students WHERE Email = '" + Session["id"] + "' ", con);
                int Semester = (Int32)cmdSemester.ExecuteScalar();

                if (Semester == 1)
                {
                    SqlCommand countCourses = new SqlCommand("SELECT C_ID FROM Courses WHERE Semester = '1'", con);
                    countCourses.ExecuteNonQuery();

                    DataTable dt2 = new DataTable();
                    SqlDataAdapter sda2 = new SqlDataAdapter();
                    sda2.SelectCommand = countCourses;

                    sda2.Fill(dt2);

                    int courses1 = Convert.ToInt32(dt2.Rows.Count.ToString());

                    if (courses1 == 0)
                    {
                        noCourse.Text = "No Courses Registered Yet!";
                    }

                    else if (courses1 >= 1)
                    {
                        errorLabel.Style.Add("display", "none");
                        noCourse.Text = "";

                        SqlCommand getCourses = new SqlCommand("SELECT C_ID, CourseName, CourseLabel FROM Courses WHERE Semester = '1'", con);
                        getCourses.ExecuteNonQuery();

                        DataTable dt1 = new DataTable();
                        SqlDataAdapter sda1 = new SqlDataAdapter();
                        sda1.SelectCommand = getCourses;

                        sda1.Fill(dt1);

                        r2.DataSource = dt1;
                        r2.DataBind();
                    }  
                }

                else if (Semester == 2)
                {
                    SqlCommand countCourses = new SqlCommand("SELECT C_ID FROM Courses WHERE Semester = '2'", con);
                    countCourses.ExecuteNonQuery();

                    DataTable dt2 = new DataTable();
                    SqlDataAdapter sda2 = new SqlDataAdapter();
                    sda2.SelectCommand = countCourses;

                    sda2.Fill(dt2);

                    int courses2 = Convert.ToInt32(dt2.Rows.Count.ToString());

                    if (courses2 == 0)
                    {
                        noCourse.Text = "No Courses Registered Yet!";
                    }

                    else if (courses2 >= 1)
                    {
                        errorLabel.Style.Add("display", "none");
                        noCourse.Text = "";

                        SqlCommand getCourses = new SqlCommand("SELECT C_ID, CourseName, CourseLabel FROM Courses WHERE Semester = '2'", con);
                        getCourses.ExecuteNonQuery();

                        DataTable dt1 = new DataTable();
                        SqlDataAdapter sda1 = new SqlDataAdapter();
                        sda1.SelectCommand = getCourses;

                        sda1.Fill(dt1);

                        r2.DataSource = dt1;
                        r2.DataBind();
                    }  
                }

                else if (Semester == 3)
                {
                    SqlCommand countCourses = new SqlCommand("SELECT C_ID FROM Courses WHERE Semester = '3'", con);
                    countCourses.ExecuteNonQuery();

                    DataTable dt2 = new DataTable();
                    SqlDataAdapter sda2 = new SqlDataAdapter();
                    sda2.SelectCommand = countCourses;

                    sda2.Fill(dt2);

                    int courses3 = Convert.ToInt32(dt2.Rows.Count.ToString());

                    if (courses3 == 0)
                    {
                        noCourse.Text = "No Courses Registered Yet!";
                    }

                    else if (courses3 >= 1)
                    {
                        errorLabel.Style.Add("display", "none");
                        noCourse.Text = "";

                        SqlCommand getCourses = new SqlCommand("SELECT C_ID, CourseName, CourseLabel FROM Courses WHERE Semester = '3'", con);
                        getCourses.ExecuteNonQuery();

                        DataTable dt1 = new DataTable();
                        SqlDataAdapter sda1 = new SqlDataAdapter();
                        sda1.SelectCommand = getCourses;

                        sda1.Fill(dt1);

                        r2.DataSource = dt1;
                        r2.DataBind();
                    }
                }

                else if (Semester == 4)
                {
                    SqlCommand countCourses = new SqlCommand("SELECT C_ID FROM Courses WHERE Semester = '4'", con);
                    countCourses.ExecuteNonQuery();

                    DataTable dt2 = new DataTable();
                    SqlDataAdapter sda2 = new SqlDataAdapter();
                    sda2.SelectCommand = countCourses;

                    sda2.Fill(dt2);

                    int courses4 = Convert.ToInt32(dt2.Rows.Count.ToString());

                    if (courses4 == 0)
                    {
                        noCourse.Text = "No Courses Registered Yet!";
                    }

                    else if (courses4 >= 1)
                    {
                        errorLabel.Style.Add("display", "none");
                        noCourse.Text = "";

                        SqlCommand getCourses = new SqlCommand("SELECT C_ID, CourseName, CourseLabel FROM Courses WHERE Semester = '4'", con);
                        getCourses.ExecuteNonQuery();

                        DataTable dt1 = new DataTable();
                        SqlDataAdapter sda1 = new SqlDataAdapter();
                        sda1.SelectCommand = getCourses;

                        sda1.Fill(dt1);

                        r2.DataSource = dt1;
                        r2.DataBind();
                    } 
                }

                else if (Semester == 5)
                {
                    SqlCommand countCourses = new SqlCommand("SELECT C_ID FROM Courses WHERE Semester = '5'", con);
                    countCourses.ExecuteNonQuery();

                    DataTable dt2 = new DataTable();
                    SqlDataAdapter sda2 = new SqlDataAdapter();
                    sda2.SelectCommand = countCourses;

                    sda2.Fill(dt2);

                    int courses5 = Convert.ToInt32(dt2.Rows.Count.ToString());

                    if (courses5 == 0)
                    {                       
                        noCourse.Text = "No Courses Registered Yet!";
                    }

                    else if (courses5 >= 1)
                    {
                        errorLabel.Style.Add("display", "none");
                        noCourse.Text = "";

                        SqlCommand getCourses = new SqlCommand("SELECT C_ID, CourseName, CourseLabel FROM Courses WHERE Semester = '5'", con);
                        getCourses.ExecuteNonQuery();

                        DataTable dt1 = new DataTable();
                        SqlDataAdapter sda1 = new SqlDataAdapter();
                        sda1.SelectCommand = getCourses;

                        sda1.Fill(dt1);

                        r2.DataSource = dt1;
                        r2.DataBind();
                    }
                }

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

            if(a.Length >= 20)
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
    }
}