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
    public partial class Quiz : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }

            HttpCookie usercookie = Request.Cookies["user_cookies"];

            if (Session["id"] != null || usercookie != null)
            {
                if (Session["id"] == null)
                {
                    getstringuser.Text = usercookie["id"];
                }

                else
                {
                    getstringuser.Text = Session["id"].ToString();
                }
            }

            else
            {
                Response.Redirect("/Registration/Login.aspx");
            }

            string qid = Request.QueryString["qid"];

            if (qid == null)
            {
                Response.Redirect("/Student/Dashboard.aspx");
            }

            QuizName(Convert.ToInt32(qid));
            QuizCheck(Convert.ToInt32(qid));

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

        public void QuizName(int id)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Quiz WHERE Q_ID = @quizid", con);
                cmd.Parameters.AddWithValue("@quizid", id);

                try
                {
                    con.Open();

                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        QuizLabel.Text = rd["Name"].ToString();
                    }

                    con.Close();
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public void QuizCheck(int id)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                try
                {
                    con.Open();

                    SqlCommand checkQuiz = new SqlCommand("SELECT * FROM Quiz JOIN Result ON Quiz.Q_ID = Result.QuizFID WHERE Email = '" + Session["id"] + "' AND Given = 'Yes' AND QuizFID = @quizid", con);
                    checkQuiz.Parameters.AddWithValue("@quizid", id);

                    SqlDataReader rd = checkQuiz.ExecuteReader();

                    if (!rd.HasRows)
                    {
                        QuestionList(id);
                    }

                    else
                    {
                        card.Style.Add("display", "none");
                        noQuestions.Text = "Quiz Already Submitted!";
                    }
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            } 
        }

        public void QuestionList(int id)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                try
                {
                    con.Open();

                    SqlCommand getQuestions = new SqlCommand("SELECT * FROM Questions JOIN Quiz ON Quiz.Q_ID = Questions.QuizFID WHERE QuizFID = @quizid", con);
                    getQuestions.Parameters.AddWithValue("@quizid", id);

                    SqlDataReader rd = getQuestions.ExecuteReader();

                    if (rd.HasRows)
                    {
                        errorLabel.Style.Add("display", "none");
                        noQuestions.Text = "";

                        Questions.DataSource = rd;
                        Questions.DataBind();
                    }

                    else
                    {
                        card.Style.Add("display", "none");
                        noQuestions.Text = "No Questions Added Yet!";
                    }

                    con.Close();
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        string result = string.Empty;
        int select_number = 0;
        int correct_number = 0; 
        int wrong_number = 0;
        int counter = 0;

        public static Random _random = new Random();
        int random;

        public void checkAnswer(int quesid)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT * FROM Questions WHERE Ques_ID = @questionID" + counter;
                cmd.Parameters.AddWithValue("@questionID" + counter, quesid);
                cmd.Connection = con;

                try
                {
                    con.Open();

                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        if (select_number == Convert.ToInt32(rd["QuesAns"]))
                        {
                            correct_number = correct_number + 1;
                            break;
                        }

                        else
                        {
                            wrong_number = wrong_number + 1;
                            break;
                        }
                    }

                    con.Close();

                    counter++;
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public string CheckStatus()
        {
            string qid = Request.QueryString["qid"];

            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT PassingMarks FROM Quiz WHERE Q_ID = @quizid", con);
                cmd.Parameters.AddWithValue("@quizid", qid);

                con.Open();

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    if (random >= Convert.ToInt32(rd["PassingMarks"]))
                    {
                        result = result + "Pass";
                        break;
                    }

                    else
                    {
                        result = result + "Fail";
                        break;
                    }
                }
            }

            return result;
        }

        public void SaveInResult(string status, int score, int tquestion)
        {
            string qid = Request.QueryString["qid"];

            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Result(QuizFID, Status, Score, TotalQuestions, Email, Date, Given) VALUES(@quizfid, @resultstatus, @resultscore, @totalquestion, @username, @examdate, 'Yes')", con);
                
                cmd.Parameters.AddWithValue("@quizfid", qid);
                cmd.Parameters.AddWithValue("@resultstatus", status);
                cmd.Parameters.AddWithValue("@resultscore", score);
                cmd.Parameters.AddWithValue("@totalquestion", tquestion);
                cmd.Parameters.AddWithValue("@username", getstringuser.Text);
                cmd.Parameters.AddWithValue("@examdate", DateTime.Now.ToString());

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    Response.Redirect("/Student/Dashboard.aspx");
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void saveQuiz(object sender, EventArgs e)
        {
            foreach (GridViewRow row in Questions.Rows)
            {
                Label li = row.FindControl("lblid") as Label;
                RadioButton rb1 = row.FindControl("optionOne") as RadioButton;
                RadioButton rb2 = row.FindControl("optionTwo") as RadioButton;
                RadioButton rb3 = row.FindControl("optionThree") as RadioButton;
                RadioButton rb4 = row.FindControl("optionFour") as RadioButton;

                if (rb1.Checked == true)
                {
                    select_number = 1;
                }

                else if (rb2.Checked == true)
                {
                    select_number = 2;
                }

                else if (rb3.Checked == true)
                {
                    select_number = 3;
                }

                else if (rb4.Checked == true)
                {
                    select_number = 4;
                }

                if (rb1.Checked != true && rb2.Checked != true && rb3.Checked != true && rb4.Checked != true)
                {
                    random = 0;
                }

                else
                {
                    random = _random.Next(1, 6);
                }

                int quesid = Convert.ToInt32(li.Text);

                checkAnswer(quesid);
            }

            SaveInResult(CheckStatus(), random, Questions.Rows.Count);
        }
    }
}