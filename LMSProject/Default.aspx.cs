using System;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            PlaceHolder phAuth = (PlaceHolder)Master.FindControl("phAuth");
            phAuth.Visible = false;
            string role = Session["UserRole"].ToString();
            switch (role)
            {
                case "Admin":
                    Response.Redirect("~/Admin/Dashboard.aspx");
                    break;
                case "Instructor":
                    Response.Redirect("~/Instructor/Dashboard.aspx");
                    break;
                case "Student":
                    Response.Redirect("~/Student/Dashboard.aspx");
                    break;
            }
        }
    }
}