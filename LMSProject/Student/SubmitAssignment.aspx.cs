using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMSProject.HelperClass;

namespace LMSProject.Student
{
	public partial class SubmitAssignment : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && fuSubmission.HasFile && Request.QueryString["AssignmentID"] != null)
            {
                int assignmentId = Convert.ToInt32(Request.QueryString["AssignmentID"]);
                string fileName = Path.GetFileName(fuSubmission.FileName);
                string filePath = Server.MapPath("~/Uploads/" + fileName);
                fuSubmission.SaveAs(filePath);

                if (DBHelper.SubmitAssignment(assignmentId, Convert.ToInt32(Session["UserID"]), "~/Uploads/" + fileName))
                {
                    Response.Redirect("MyCourses.aspx");
                }
                else
                {
                    errorMessage.InnerText = "Failed to submit assignment. Please try again.";
                    errorMessage.Attributes.Remove("class");
                    errorMessage.Attributes.Add("class", "alert alert-danger");
                }
            }
            else
            {
                errorMessage.InnerText = "Please select a file and ensure assignment ID is valid.";
                errorMessage.Attributes.Remove("class");
                errorMessage.Attributes.Add("class", "alert alert-danger");
            }
        }
    }
}
