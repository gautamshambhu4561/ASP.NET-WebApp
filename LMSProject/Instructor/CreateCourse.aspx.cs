using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMSProject.HelperClass;

namespace LMSProject.Instructor
{
	public partial class CreateCourse : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCreateCourse_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && !string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtDescription.Text))
            {
                if (DBHelper.CreateCourse(txtTitle.Text.Trim(), txtDescription.Text.Trim(), Convert.ToInt32(Session["UserID"])))
                {
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    errorMessage.InnerText = "Failed to create course. Please try again.";
                    errorMessage.Attributes.Remove("class");
                    errorMessage.Attributes.Add("class", "alert alert-danger");
                }
            }
            else
            {
                errorMessage.InnerText = "Please fill all fields and ensure you are logged in.";
                errorMessage.Attributes.Remove("class");
                errorMessage.Attributes.Add("class", "alert alert-danger");
            }
        }
    }

}