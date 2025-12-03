using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMSProject.HelperClass;

namespace LMSProject.Student
{
	public partial class ViewGrades : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["UserID"] != null)
            {
                BindGrades();
            }
        }

        private void BindGrades()
        {
            gvGrades.DataSource = DBHelper.GetUserSubmissions(Convert.ToInt32(Session["UserID"]));
            gvGrades.DataBind();
        }
    }
}
