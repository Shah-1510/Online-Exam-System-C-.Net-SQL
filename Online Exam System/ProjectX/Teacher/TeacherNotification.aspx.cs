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
    public partial class TeacherNotification : System.Web.UI.Page
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
                notificationHeading.InnerText = "No New Notifications";
            }

            r1.DataSource = dt;
            r1.DataBind();

            SqlCommand cmdTeacher = new SqlCommand("SELECT TeacherName FROM Teachers WHERE Email = '" + Session["email"] + "' ", con);
            var user = cmdTeacher.ExecuteScalar();

            string userName = user.ToString();
            nameLabel.Text = userName.ToString();

            SqlCommand countANotification = new SqlCommand("SELECT N_ID FROM Notifications WHERE Category = 'Teacher' AND Sender = 'Admin'", con);
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

            SqlCommand getANotification = new SqlCommand("SELECT Date, Type, Message FROM Notifications WHERE Category = 'Teacher' AND Sender = 'Admin' ORDER BY N_ID DESC", con);
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