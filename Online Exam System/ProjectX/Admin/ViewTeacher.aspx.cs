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
    public partial class ViewTeacher : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }

            if (!IsPostBack)
            {
                getteacher_details();
            }

            try
            {
                con.Open();

                nameLabel.Text = "Admin";
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        string c = ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString;

        public void getteacher_details()
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Teachers", con);

                try
                {
                    con.Open();

                    teacherDetails.DataSource = cmd.ExecuteReader();
                    teacherDetails.DataBind();
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}