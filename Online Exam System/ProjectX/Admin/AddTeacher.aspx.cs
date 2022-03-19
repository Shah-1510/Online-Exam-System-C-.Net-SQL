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
    public partial class AddTeacher : System.Web.UI.Page
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
                getCoursedrp();

            }

            btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#404a48");

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

        protected void add(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                try
                {
                    SqlCommand AddTeacher = new SqlCommand("INSERT INTO Teachers VALUES('" + name.Text + "', '" + email.Text + "', '" + pass.Text + "', '" + selectCourse.SelectedItem.Text + "')", con);

                    con.Open();
                    
                    AddTeacher.ExecuteNonQuery();

                    Response.Write("<script> alert('Teacher Successfully Added') </script>");

                    name.Text = "";
                    email.Text = "";
                    pass.Text = "";
                    selectCourse.SelectedIndex = -1;

                    con.Close();
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public void getCoursedrp()
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Courses", con);

                try
                {
                    con.Open();

                    selectCourse.DataSource = cmd.ExecuteReader();
                    selectCourse.DataBind();

                    ListItem li = new ListItem("Select Course", "-1");
                    selectCourse.Items.Insert(0, li);
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void EmailCheck(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                try
                {
                    string EmailID = email.Text;

                    SqlCommand cmd = new SqlCommand("SELECT Email FROM Teachers WHERE Email ='" + EmailID + "'", con);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        errorMsg.Text = "* Email Address already exists";
                        savebtn.Enabled = false;
                    }

                    else
                    {
                        errorMsg.Text = "";
                        savebtn.Enabled = true;
                    }

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