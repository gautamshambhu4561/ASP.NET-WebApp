using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AllValidatorsDemo.aspx
{
	public partial class ValidationDemo : System.Web.UI.Page
	{
        protected void cvEven_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            int number;
            // Check if input is numeric and even
            if (int.TryParse(args.Value, out number))
                args.IsValid = (number % 2 == 0);
            else
                args.IsValid = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
                lblResult.Text = "Form submitted successfully!";
            else
                lblResult.Text = "";
        }
    }
}