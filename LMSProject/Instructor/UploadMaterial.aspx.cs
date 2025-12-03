using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMSProject.HelperClass;

namespace LMSProject.Instructor
{
	public partial class UploadMaterial : System.Web.UI.Page
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
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && fuMaterial.HasFile && !string.IsNullOrEmpty(txtTitle.Text) && ddlCourse.SelectedValue != "")
            {
                string fileName = Path.GetFileName(fuMaterial.FileName);
                string filePath = Server.MapPath("~/Uploads/" + fileName);
                fuMaterial.SaveAs(filePath);

                if (DBHelper.UploadMaterial(Convert.ToInt32(ddlCourse.SelectedValue), txtTitle.Text.Trim(), "~/Uploads/" + fileName))
                {
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    errorMessage.InnerText = "Failed to upload material. Please try again.";
                    errorMessage.Attributes.Remove("class");
                    errorMessage.Attributes.Add("class", "alert alert-danger");
                }
            }
            else
            {
                errorMessage.InnerText = "Please fill all fields and select a file.";
                errorMessage.Attributes.Remove("class");
                errorMessage.Attributes.Add("class", "alert alert-danger");
            }
        }
    }
}
