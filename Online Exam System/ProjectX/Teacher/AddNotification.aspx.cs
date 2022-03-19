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
    public partial class AddNotification : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }

            btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#343A40");

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Notifications SET Visited = 'Yes' WHERE Category = 'Teacher'", con);
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Notifications WHERE Category = 'Teacher' AND Visited = 'No'", con);
                cmd1.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd1;

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

        protected void save(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand AddNotification = new SqlCommand("INSERT INTO Notifications(Category, Sender, Type, Message) VALUES('Student', 'Teacher', '" + type.Text + "', '" + message.Text + "')", con);
                AddNotification.ExecuteNonQuery();

                Response.Write("<script> alert('Notification Successfully Send') </script>");

                type.Text = "";
                message.Text = "";

                con.Close();
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}