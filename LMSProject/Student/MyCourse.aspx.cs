using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMSProject.HelperClass;


namespace LMSProject.Student
{
	public partial class MyCourse : System.Web.UI.Page
	{
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["UserID"] != null)
            {
                BindCourses();
            }
        }

        private void BindCourses()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT c.CourseID, c.Title FROM Courses c JOIN Enrollments e ON c.CourseID = e.CourseID WHERE e.UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        gvCourses.DataSource = dt;
                        gvCourses.DataBind();
                    }
                }
            }
        }
    }
}
