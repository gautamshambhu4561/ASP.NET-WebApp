using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormValidationForm
{
	public partial class ValidationForm : System.Web.UI.Page
	{
            protected void Page_Load(object sender, EventArgs e)
            {
            // Disable unobtrusive validation
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

            protected void cvCustom_ServerValidate(object source, ServerValidateEventArgs args)
            {
                if (args.Value == "ABC123")
                    args.IsValid = true;
                else
                    args.IsValid = false;
            }

            protected void btnSubmit_Click(object sender, EventArgs e)
            {
                if (Page.IsValid)
                {
                    Response.Write("<script>alert('Form Submitted Successfully!');</script>");
                }
            }
        }

    }
