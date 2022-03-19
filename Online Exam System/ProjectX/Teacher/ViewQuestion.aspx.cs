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
    public partial class ViewQuestion : System.Web.UI.Page
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

                getquizquestion(Convert.ToInt32(qid));
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

        protected void gridview_examquestion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delQuestion")
            {
                deleteQuestion(Convert.ToInt32(e.CommandArgument));
            }
        }
      
        protected void gridview_examquestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string qid = Request.QueryString["qid"];

            quizQuestions.PageIndex = e.NewPageIndex;
            getquizquestion(Convert.ToInt32(qid));
        }

        string c = ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString;
  
        public void getquizquestion(int id)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Questions LEFT JOIN Quiz ON Questions.QuizFID = Quiz.Q_ID WHERE QuizFID = @quizID", con);
                cmd.Parameters.AddWithValue("@quizID", id);

                try
                {
                    con.Open();

                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;

                        using (DataTable tb = new DataTable())
                        {
                            ad.Fill(tb);
                            quizQuestions.DataSource = tb;
                            quizQuestions.DataBind();
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public void deleteQuestion(int id)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE Questions WHERE Ques_ID = @questionid", con);
                    cmd.Parameters.AddWithValue("@questionid", id);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    Response.Write("<script> alert('Question Successfully Deleted') </script>");
                    Response.Redirect("/Teacher/ViewQuestion.aspx");
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}