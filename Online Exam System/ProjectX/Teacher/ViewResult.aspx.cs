﻿using System;
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
    public partial class ViewResult : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                string emailID = Request.QueryString["sid"];

                if (emailID == null)
                {
                    Response.Redirect("/Teacher/TeacherResult.aspx");
                }

                getResults(emailID);
            }

            else
            {
                Response.Redirect("/Registration/Login.aspx");
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

        public void getResults(string email)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Result JOIN Quiz ON Result.QuizFID = Quiz.Q_ID WHERE Email = @email", con);
                cmd.Parameters.AddWithValue("@email", email);

                try
                {
                    con.Open();

                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;

                        using (DataTable tb = new DataTable())
                        {
                            ad.Fill(tb);

                            if (tb != null)
                            {
                                myResult.DataSource = tb;
                                myResult.DataBind();
                            } 
                        }
                    }

                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void gridmyresult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            myResult.PageIndex = e.NewPageIndex;
            getResults(getemail.Text);
        }
    }
}