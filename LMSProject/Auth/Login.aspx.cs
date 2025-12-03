using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMSProject.HelperClass;

namespace LMSProject.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Response.Redirect("~/Pages/Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (DBHelper.ValidateUser(txtEmail.Text.Trim(), txtPassword.Text))
            {
                Response.Redirect("~/Pages/Default.aspx");
            }
            else
            {
                errorMessage.InnerText = "Invalid email or password.";
                errorMessage.Attributes.Remove("class");
                errorMessage.Attributes.Add("class", "alert alert-danger");
            }
        }
    }
}