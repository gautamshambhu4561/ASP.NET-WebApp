using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginFormwithADO
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    lblWelcome.Text = "Welcome, " + Session["Username"].ToString();
                }
                else
                {
                    Response.Redirect("LoginForm.aspx");
                }
            }
        }
    }
}