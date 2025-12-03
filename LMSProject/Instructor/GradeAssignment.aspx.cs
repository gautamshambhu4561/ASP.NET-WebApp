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
using LMSProject.HelperClass;

namespace LMSProject.Instructor
{
	public partial class GradeAssignment : System.Web.UI.Page
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
            ddlCourse.DataSource = DBHelper.GetInstructorCourses(Convert.ToInt32(Session["UserID"]));
            ddlCourse.DataTextField = "Title";
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataBind();
            if (ddlCourse.Items.Count > 0)
                BindSubmissions(Convert.ToInt32(ddlCourse.SelectedValue));
        }

        private void BindSubmissions(int courseId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT s.SubmissionID, u.Name AS UserName, s.FilePath, s.Grade FROM Submissions s JOIN Users u ON s.UserID = u.UserID JOIN Assignments a ON s.AssignmentID = a.AssignmentID WHERE a.CourseID = @CourseID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        gvSubmissions.DataSource = dt;
                        gvSubmissions.DataBind();
                    }
                }
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCourse.SelectedValue != "")
            {
                BindSubmissions(Convert.ToInt32(ddlCourse.SelectedValue));
            }
            else
            {
                gvSubmissions.DataSource = null;
                gvSubmissions.DataBind();
            }
        }

        protected void btnSaveGrade_Click(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            int submissionId = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSubmissions.Rows.Cast<GridViewRow>().FirstOrDefault(r => ((Button)r.FindControl("btnSaveGrade")).CommandArgument == e.CommandArgument);
            if (row != null)
            {
                TextBox txtGrade = (TextBox)row.FindControl("txtGrade");
                int grade;
                if (int.TryParse(txtGrade.Text, out grade) && grade >= 0 && grade <= 100)
                {
                    if (DBHelper.UpdateGrade(submissionId, grade))
                    {
                        BindSubmissions(Convert.ToInt32(ddlCourse.SelectedValue));
                    }
                    else
                    {
                        errorMessage.InnerText = "Failed to update grade.";
                        errorMessage.Attributes.Remove("class");
                        errorMessage.Attributes.Add("class", "alert alert-danger");
                    }
                }
                else
                {
                    errorMessage.InnerText = "Please enter a valid grade (0-100).";
                    errorMessage.Attributes.Remove("class");
                    errorMessage.Attributes.Add("class", "alert alert-danger");
                }
            }
        }
    }
}
