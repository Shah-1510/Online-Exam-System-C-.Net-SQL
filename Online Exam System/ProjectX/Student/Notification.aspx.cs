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
    public partial class Notification : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }

            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Notifications SET Visited = 'Yes' WHERE Category = 'Student'", con);
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Notifications WHERE Category = 'Student' AND Visited = 'No'", con);
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

            SqlCommand countTNotification = new SqlCommand("SELECT N_ID FROM Notifications WHERE Sender = 'Teacher'", con);
            countTNotification.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter();
            sda1.SelectCommand = countTNotification;

            sda1.Fill(dt1);

            int tNotify = Convert.ToInt32(dt1.Rows.Count.ToString());

            if (tNotify == 0)
            {
                labelforTeacherNotification.Text = "- No Notifications Yet";
            }

            else if (tNotify >= 1)
            {
                labelforTeacherNotification.Style.Add("display", "none");
            }

            SqlCommand getTNotification = new SqlCommand("SELECT Date, Type, Message FROM Notifications WHERE Sender = 'Teacher' ORDER BY N_ID DESC", con);
            getTNotification.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            SqlDataAdapter sda2 = new SqlDataAdapter();
            sda2.SelectCommand = getTNotification;

            sda2.Fill(dt2);

            r2.DataSource = dt2;
            r2.DataBind();

            SqlCommand countANotification = new SqlCommand("SELECT N_ID FROM Notifications WHERE Category = 'Student' AND Sender = 'Admin'", con);
            countANotification.ExecuteNonQuery();

            DataTable dt4 = new DataTable();
            SqlDataAdapter sda4 = new SqlDataAdapter();
            sda4.SelectCommand = countANotification;

            sda4.Fill(dt4);

            int aNotify = Convert.ToInt32(dt4.Rows.Count.ToString());

            if (aNotify == 0)
            {
                labelforAdminNotification.Text = "- No Notifications Yet";
            }

            else if (aNotify >= 1)
            {
                labelforAdminNotification.Style.Add("display", "none");
            }

            SqlCommand getANotification = new SqlCommand("SELECT Date, Type, Message FROM Notifications WHERE Category = 'Student' AND Sender = 'Admin' ORDER BY N_ID DESC", con);
            getANotification.ExecuteNonQuery();

            DataTable dt3 = new DataTable();
            SqlDataAdapter sda3 = new SqlDataAdapter();
            sda3.SelectCommand = getANotification;

            sda3.Fill(dt3);

            r3.DataSource = dt3;
            r3.DataBind();

            con.Close();
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
    }
}