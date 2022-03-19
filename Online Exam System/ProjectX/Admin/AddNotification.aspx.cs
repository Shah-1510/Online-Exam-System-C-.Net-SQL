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

namespace ProjectX.Admin
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

            btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#404a48");

            try
            {
                nameLabel.Text = "Admin";
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void save(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand AddNotification = new SqlCommand("INSERT INTO Notifications(Category, Sender, Type, Message) VALUES('" + selectCategory.SelectedItem + "', 'Admin', '" + type.Text + "', '" + message.Text + "')", con);
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