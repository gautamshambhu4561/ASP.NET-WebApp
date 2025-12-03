using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMSProject.HelperClass;
namespace LMSProject.Student
{
	public partial class CourseContent : System.Web.UI.Page
	{        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["CourseID"] != null)
            {
                int courseId = Convert.ToInt32(Request.QueryString["CourseID"]);
                BindMaterials(courseId);
                BindAssignments(courseId);
                BindAnnouncements(courseId);
            }
        }

        private void BindMaterials(int courseId)
        {
            gvMaterials.DataSource = DBHelper.GetCourseMaterials(courseId);
            gvMaterials.DataBind();
        }

        private void BindAssignments(int courseId)
        {
            gvAssignments.DataSource = DBHelper.GetCourseAssignments(courseId);
            gvAssignments.DataBind();
        }

        private void BindAnnouncements(int courseId)
        {
            gvAnnouncements.DataSource = DBHelper.GetCourseAnnouncements(courseId);
            gvAnnouncements.DataBind();
        }
    }

}