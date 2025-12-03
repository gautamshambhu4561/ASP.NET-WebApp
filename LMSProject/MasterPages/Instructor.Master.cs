using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMSProject.MasterPages
{
	public partial class Instructor : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Instructor")
            {
                Response.Redirect("~/Auth/Login.aspx");
            }

        }
	}
}