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
    public partial class EditQuestion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }

            string quesid = Request.QueryString["quesid"];

            if (!IsPostBack)
            {
                if (quesid == null)
                {
                    Response.Redirect("/Teacher/ViewQuestion.aspx");
                }

                editQuestion(Convert.ToInt32(quesid));
                getEditQuizdrp();
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

        protected void updateQues(object sender, EventArgs e)
        {
            string quesid = Request.QueryString["quesid"];

            if (IsValid)
            {
                string cs = ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Questions SET Ques = @questionname, OptOne = @optionone, OptTwo = @optiontwo, OptThree = @optionthree, OptFour = @optionfour, QuesAns = @questionanswer, QuizFID = @quizID WHERE Ques_ID = @questionid", con);
                        
                        cmd.Parameters.AddWithValue("@questionid", Convert.ToInt32(quesid));
                        cmd.Parameters.AddWithValue("@questionname", question.Text);
                        cmd.Parameters.AddWithValue("@optionone", optA.Text);
                        cmd.Parameters.AddWithValue("@optiontwo", optB.Text);
                        cmd.Parameters.AddWithValue("@optionthree", optC.Text);
                        cmd.Parameters.AddWithValue("@optionfour", optD.Text);
                        cmd.Parameters.AddWithValue("@questionanswer", correctAnswer.SelectedValue);
                        cmd.Parameters.AddWithValue("@quizID", selectQuiz.SelectedValue);

                        con.Open();

                        cmd.ExecuteNonQuery();

                        Response.Write("<script> alert('Question Successfully Updated') </script>");
                        Response.Redirect("/Teacher/ViewQuestion.aspx");

                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                } 
            } 
        }
        
        public void editQuestion(int id)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Questions LEFT JOIN Quiz ON Questions.QuizFID = Quiz.Q_ID WHERE Ques_ID = @questionid", con);
                cmd.Parameters.AddWithValue("@questionid", id);

                try
                {
                    con.Open();

                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        question.Text = rd["Ques"].ToString();
                        optA.Text = rd["OptOne"].ToString();
                        optB.Text = rd["OptTwo"].ToString();
                        optC.Text = rd["OptThree"].ToString();
                        optD.Text = rd["OptFour"].ToString();
                    }
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public void getEditQuizdrp()
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Quiz", con);

                try
                {
                    con.Open();

                    selectQuiz.DataSource = cmd.ExecuteReader();
                    selectQuiz.DataBind();

                    ListItem li = new ListItem("Select Quiz", "-1");
                    selectQuiz.Items.Insert(0, li);
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}