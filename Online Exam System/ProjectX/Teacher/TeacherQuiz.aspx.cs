using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace ProjectX.Teacher
{
    public partial class TeacherQuiz : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }

            if (!IsPostBack)
            {
                panel_examlist.Visible = true;
                panel_addexam.Visible = false;
                btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#343A40");
                btn_paneladdexam.BackColor = ColorTranslator.FromHtml("#DC3545");

                getQuizList();
            }

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Notifications WHERE Category = 'Teacher' AND Visited = 'No' ORDER BY N_ID DESC", con);
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

                SqlCommand cmdTeacher = new SqlCommand("SELECT TeacherName FROM Teachers WHERE Email = '" + Session["email"] + "' ", con);
                var user = cmdTeacher.ExecuteScalar();

                string userName = user.ToString();
                nameLabel.Text = userName.ToString();
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

        protected void btn_panelexamlist_Click(object sender, EventArgs e)
        {
            panel_examlist.Visible = true;
            panel_addexam.Visible = false;

            btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_paneladdexam.BackColor = ColorTranslator.FromHtml("#DC3545");

            getQuizList();
        }

        protected void btn_paneladdexam_Click(object sender, EventArgs e)
        {
            panel_examlist.Visible = false;
            panel_addexam.Visible = true;

            btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdexam.BackColor = ColorTranslator.FromHtml("#343A40");
        }

        string c = ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString;

        protected void AddQuiz(object sender, EventArgs e)
        {
            if (IsValid)
            {
                using (SqlConnection con = new SqlConnection(c))
                {
                    try
                    {
                        con.Open();

                        SqlCommand getCourse = new SqlCommand("SELECT Course FROM Teachers WHERE Email = '" + Session["id"] + "'", con);
                        string TeacherCourse = Convert.ToString(getCourse.ExecuteScalar());

                        SqlCommand getCourseID = new SqlCommand("SELECT C_ID FROM Courses WHERE CourseName = '" + TeacherCourse + "'", con);
                        int TeacherCourseID = Convert.ToInt32(getCourseID.ExecuteScalar());

                        SqlCommand addQuiz = new SqlCommand("INSERT INTO Quiz(Name, Description, Date, Duration, Marks, PassingMarks, CourseFID) VALUES(@name, @des, @date, @duration, @marks, @passmarks, @coursefid)", con);

                        addQuiz.Parameters.AddWithValue("@name", quizName.Text);
                        addQuiz.Parameters.AddWithValue("@des", quizDes.Text);
                        addQuiz.Parameters.AddWithValue("@date", quizDate.Text);
                        addQuiz.Parameters.AddWithValue("@duration", quizDuration.Text);
                        addQuiz.Parameters.AddWithValue("@marks", quizTotalMarks.Text);
                        addQuiz.Parameters.AddWithValue("@passmarks", quizPassMarks.Text);
                        addQuiz.Parameters.AddWithValue("@coursefid", TeacherCourseID);

                        addQuiz.ExecuteNonQuery();

                        Response.Write("<script> alert('Quiz Added Successfully') </script>");
                        Response.Redirect("/Teacher/TeacherQuiz.aspx");

                        con.Close();
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                } 
            }
        }

        protected void grdview_examlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delQuiz")
            {
                DeleteQuiz(Convert.ToInt32(e.CommandArgument));
                getQuizList();
            }
        }

        protected void grdview_examlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdview_examlist.PageIndex = e.NewPageIndex;
            getQuizList();
        }

        public void getQuizList()
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Quiz LEFT JOIN Courses ON Quiz.CourseFID = Courses.C_ID ", con);

                try
                {
                    con.Open();

                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;

                        using (DataTable dtatble = new DataTable())
                        {
                            ad.Fill(dtatble);
                            grdview_examlist.DataSource = dtatble;
                            grdview_examlist.DataBind();
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public void DeleteQuiz(int id)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                try
                {
                    con.Open();

                    SqlCommand delQuiz = new SqlCommand("DELETE Quiz WHERE Q_ID = @quizid", con);
                    delQuiz.Parameters.AddWithValue("@quizid", id);

                    delQuiz.ExecuteNonQuery();

                    Response.Write("<script> alert('Quiz Deleted Successfully') </script>");
                    Response.Redirect("/Teacher/TeacherQuiz.aspx");
                    
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}