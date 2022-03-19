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
    public partial class Result : System.Web.UI.Page
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
                    getemail.Text = usercookie["id"];
                }

                else
                {
                    getemail.Text = Session["id"].ToString();
                }
            }

            else
            {
                Response.Redirect("/Registration/Login.aspx");
            }

            if (!IsPostBack)
            {
                CheckResult(getemail.Text);
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

        public void CheckResult(string email)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                try
                {
                    SqlCommand getResult = new SqlCommand("SELECT * FROM Result JOIN Quiz ON Result.QuizFID = Quiz.Q_ID JOIN Courses ON Courses.C_ID = Quiz.CourseFID WHERE Email = @email", con);
                    getResult.Parameters.AddWithValue("@email", email);

                    con.Open();

                    SqlDataReader rd = getResult.ExecuteReader();

                    if (rd.HasRows)
                    {
                        GetResult(email);
                    }

                    else
                    {
                        card.Style.Add("display", "none");
                        noResult.Text = "No Results to Show!";
                    }
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public void GetResult(string email)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                try
                {
                    SqlCommand getResult = new SqlCommand("SELECT * FROM Result JOIN Quiz ON Result.QuizFID = Quiz.Q_ID JOIN Courses ON Courses.C_ID = Quiz.CourseFID WHERE Email = @email", con);
                    getResult.Parameters.AddWithValue("@email", email);

                    con.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sda.SelectCommand = getResult;

                        using (DataTable tb = new DataTable())
                        {
                            sda.Fill(tb);

                            if (tb != null)
                            {
                                errorLabel.Style.Add("display", "none");

                                myResult.DataSource = tb;
                                myResult.DataBind();
                            } 
                        }
                    }

                    con.Close();
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void myResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            myResult.PageIndex = e.NewPageIndex;
            GetResult(getemail.Text);
        }
    }
}