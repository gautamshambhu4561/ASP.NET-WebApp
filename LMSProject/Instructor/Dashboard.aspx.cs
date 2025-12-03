using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMSProject.HelperClass;

namespace LMSProject.Instructor
{
	public partial class Dashboard : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    lblUserName.Text = Session["UserName"].ToString();
                }
                if (Session["UserID"] != null)
                {
                    gvCourses.DataSource = DBHelper.GetInstructorCourses(Convert.ToInt32(Session["UserID"]));
                    gvCourses.DataBind();
                }
            }
        }
    }
}