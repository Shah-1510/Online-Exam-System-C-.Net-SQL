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
    public partial class AddQuestion : System.Web.UI.Page
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
                string qid = Request.QueryString["qid"];

                if (qid == null)
                {
                    Response.Redirect("/Teacher/TeacherQuiz.aspx");
                }
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
                                                                                    
        protected void addQues(object sender, EventArgs e)
        {
            string qid = Request.QueryString["qid"];

            if (IsValid)
            {
                using (SqlConnection con = new SqlConnection(c))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Questions(Ques, OptOne, OptTwo, OptThree, OptFour, QuesAns, QuizFID) VALUES(@ques, @optA, @optB, @optC, @optD, @ans, @quizID)", con);

                        cmd.Parameters.AddWithValue("@ques", question.Text);
                        cmd.Parameters.AddWithValue("@optA", optA.Text);
                        cmd.Parameters.AddWithValue("@optB", optB.Text);
                        cmd.Parameters.AddWithValue("@optC", optC.Text);
                        cmd.Parameters.AddWithValue("@optD", optD.Text);
                        cmd.Parameters.AddWithValue("@ans", correctAnswer.SelectedValue);
                        cmd.Parameters.AddWithValue("@quizID", Convert.ToInt32(qid));

                        con.Open();

                        cmd.ExecuteNonQuery();

                        Response.Write("<script> alert('Question Successfully Added') </script>");
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
    }
}