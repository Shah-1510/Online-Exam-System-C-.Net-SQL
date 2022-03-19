using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Globalization;

namespace ProjectX
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void EmailCheck(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);

            string EmailID = email.Text.Trim();

            SqlCommand cmd = new SqlCommand("SELECT Email FROM Students WHERE Email ='" + EmailID + "'", con);

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                errorMsg.Text = "* Email Address already exists";
                email.Focus();
                signupbtn.Enabled = false;
            }

            else
            {
                errorMsg.Text = "";
                signupbtn.Enabled = true;
            }

            con.Close();
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;

            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        protected void Signup(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectX"].ConnectionString);

                    conn.Open();

                    string insert = "INSERT INTO Students(FirstName, LastName, Email, Password, Gender, Age, Semester, Enrollment) VALUES (@firstname, @lastname, @email, @password, @gender, @age, @semester, @enrollment)";

                    SqlCommand cmd = new SqlCommand(insert, conn);

                    string iDate = dob.Text;
                    DateTime oDate = Convert.ToDateTime(iDate);
                    int age = CalculateAge(oDate);

                    string a = "02-131192-";
                    int b = 000;
                    string enroll = a + b.ToString("D3");
                    b++;

                    cmd.Parameters.AddWithValue("@firstname", fname.Text);
                    cmd.Parameters.AddWithValue("@lastname", lname.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@password", pass.Text);
                    cmd.Parameters.AddWithValue("@gender", gen.Text);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@semester", option.SelectedValue);
                    cmd.Parameters.AddWithValue("@enrollment", enroll);

                    cmd.ExecuteNonQuery();

                    Response.Write("<script> alert('Registration Successful') </script>");

                    conn.Close();

                    fname.Text = "";
                    lname.Text = "";
                    email.Text = "";
                    pass.Text = "";
                    cpass.Text = "";
                    gen.ClearSelection();
                    dob.Text = "";
                    option.SelectedIndex = 0;

                    Response.Redirect("/Home/Index.aspx");
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}