using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LMSProject.Admin
{
	public partial class ManageAnnouncements : System.Web.UI.Page
    {
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCourses();
                BindAnnouncements();
            }
        }

        private void BindCourses()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT CourseID, Title FROM Courses";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        ddlCourse.DataSource = dt;
                        ddlCourse.DataTextField = "Title";
                        ddlCourse.DataValueField = "CourseID";
                        ddlCourse.DataBind();
                    }
                }
            }
        }

        private void BindAnnouncements()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT a.AnnouncementID, a.Title, a.Content, a.PostedDate, c.Title AS CourseTitle FROM Announcements a LEFT JOIN Courses c ON a.CourseID = c.CourseID";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvAnnouncements.DataSource = dt;
                    gvAnnouncements.DataBind();
                }
            }
        }

        protected void btnAddAnnouncement_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtContent.Text) && ddlCourse.SelectedValue != "0")
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "INSERT INTO Announcements (Title, Content, PostedDate, CourseID) VALUES (@Title, @Content, @PostedDate, @CourseID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Content", txtContent.Text.Trim());
                        cmd.Parameters.AddWithValue("@PostedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(ddlCourse.SelectedValue));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        BindAnnouncements();
                        txtTitle.Text = "";
                        txtContent.Text = "";
                        ddlCourse.SelectedValue = "0";
                    }
                }
            }
            else
            {
                errorMessage.InnerText = "Please fill all fields and select a course.";
                errorMessage.Attributes.Remove("class");
                errorMessage.Attributes.Add("class", "alert alert-danger");
            }
        }
    }
}
