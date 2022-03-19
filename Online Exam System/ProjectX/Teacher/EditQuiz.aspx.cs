using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectX.Teacher
{
    public partial class EditQuiz : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }

            string qid = Request.QueryString["qid"];

            if (!IsPostBack)
            {
                if (qid == null)
                {
                    Response.Redirect("/Teacher/TeacherQuiz.aspx");
                }

                get_editquizfill(Convert.ToInt32(qid));
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

        string c = ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString;

        protected void editQuiz(object sender, EventArgs e)
        {
            string qid = Request.QueryString["qid"];

            if (IsValid)
            {
                string cs = ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Quiz SET Name = @quizname, Description = @quizDes, Date = @quizDate, Duration = @quizDuration, Marks = @totalMarks, PassingMarks = @passMarks WHERE Q_ID = @quizID", con);

                        cmd.Parameters.AddWithValue("@quizID", Convert.ToInt32(qid));
                        cmd.Parameters.AddWithValue("@quizname", quizName.Text);
                        cmd.Parameters.AddWithValue("@quizDes", quizDes.Text);
                        cmd.Parameters.AddWithValue("@quizDate", quizDate.Text);
                        cmd.Parameters.AddWithValue("@quizDuration", quizDuration.Text);
                        cmd.Parameters.AddWithValue("@totalMarks", quizTotalMarks.Text);
                        cmd.Parameters.AddWithValue("@passMarks", quizPassMarks.Text);

                        con.Open();

                        cmd.ExecuteNonQuery();

                        Response.Write("<script> alert('Quiz Successfully Updated') </script>");
                        Response.Redirect("/Teacher/TeacherQuiz.aspx");
                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                } 
            }
        }

        public void get_editquizfill(int id)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Quiz WHERE Q_ID = @quizID", con);
                cmd.Parameters.AddWithValue("@quizID", id);

                try
                {
                    con.Open();

                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        quizName.Text = rd["Name"].ToString();
                        quizDes.Text = rd["Description"].ToString();
                        quizDuration.Text = rd["Duration"].ToString();
                        quizTotalMarks.Text = rd["Marks"].ToString();
                        quizPassMarks.Text = rd["PassingMarks"].ToString();
                    }
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}