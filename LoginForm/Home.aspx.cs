using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginForm
{
	public partial class Home : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    lblWelcome.Text = "Welcome, " + Session["Username"].ToString() + "!";
                }
                else
                {
                    Response.Redirect("WebForm.aspx"); // If session is empty, redirect to login
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("WebForm.aspx");
        }
    }
}