using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormValidationForm
{
	public partial class Result : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["finalScore"] != null)
                {
                    int score = (int)Session["finalScore"];
                    lblResult.Text = $"Your score is: {score} out of 3";
                }
            }
        }

    }
}