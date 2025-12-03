using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMSProject.HelperClass;

namespace LMSProject.Instructor
{
	public partial class ViewStudents : System.Web.UI.Page
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
                BindStudents(Convert.ToInt32(ddlCourse.SelectedValue));
        }

        private void BindStudents(int courseId)
        {
            gvStudents.DataSource = DBHelper.GetEnrolledStudents(courseId);
            gvStudents.DataBind();
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCourse.SelectedValue != "")
            {
                BindStudents(Convert.ToInt32(ddlCourse.SelectedValue));
            }
            else
            {
                gvStudents.DataSource = null;
                gvStudents.DataBind();
            }
        }
    }
}
