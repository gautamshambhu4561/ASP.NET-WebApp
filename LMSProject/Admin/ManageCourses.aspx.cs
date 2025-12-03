using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LMSProject.Admin
{
	public partial class ManageCourses : System.Web.UI.Page
	{
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInstructors();
                BindCourses();
            }
        }

        private void BindInstructors()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT UserID, Name FROM Users WHERE Role = 'Instructor'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        ddlInstructor.DataSource = dt;
                        ddlInstructor.DataTextField = "Name";
                        ddlInstructor.DataValueField = "UserID";
                        ddlInstructor.DataBind();
                    }
                }
            }
        }

        private void BindCourses()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT c.CourseID, c.Title, c.Description, u.Name AS InstructorName FROM Courses c JOIN Users u ON c.InstructorID = u.UserID";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvCourses.DataSource = dt;
                    gvCourses.DataBind();
                }
            }
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtDescription.Text) && ddlInstructor.SelectedValue != "0")
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "INSERT INTO Courses (Title, Description, InstructorID) VALUES (@Title, @Description, @InstructorID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@InstructorID", Convert.ToInt32(ddlInstructor.SelectedValue));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        BindCourses();
                        txtTitle.Text = "";
                        txtDescription.Text = "";
                        ddlInstructor.SelectedValue = "0";
                    }
                }
            }
            else
            {
                errorMessage.InnerText = "Please fill all fields and select an instructor.";
                errorMessage.Attributes.Remove("class");
                errorMessage.Attributes.Add("class", "alert alert-danger");
            }
        }
    }
}
