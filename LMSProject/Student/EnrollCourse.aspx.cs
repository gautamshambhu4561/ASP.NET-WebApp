using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMSProject.HelperClass;

namespace LMSProject.Student
{
	public partial class EnrollCourse : System.Web.UI.Page
	{
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCourses();
            }
        }

        private void BindCourses()
        {
            rptCourses.DataSource = DBHelper.GetCourses();
            rptCourses.DataBind();
        }

        protected void btnEnroll_Click(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (Session["UserID"] != null)
            {
                int courseId = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32(Session["UserID"]);
                if (DBHelper.EnrollUser(userId, courseId))
                {
                    BindCourses();
                }
                else
                {
                    errorMessage.InnerText = "Failed to enroll. Please try again.";
                    errorMessage.Attributes.Remove("class");
                    errorMessage.Attributes.Add("class", "alert alert-danger");
                }
            }
            else
            {
                errorMessage.InnerText = "Please log in to enroll.";
                errorMessage.Attributes.Remove("class");
                errorMessage.Attributes.Add("class", "alert alert-danger");
            }
        }

        protected bool IsEnrolled(int courseId)
        {
            if (Session["UserID"] == null) return false;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT COUNT(*) FROM Enrollments WHERE UserID = @UserID AND CourseID = @CourseID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}
