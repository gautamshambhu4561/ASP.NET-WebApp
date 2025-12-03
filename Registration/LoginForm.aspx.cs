using System;
using System.Web.UI;

namespace SimpleLoginForm
{
    public partial class LoginForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                if (Request.QueryString["username"] != null && Request.QueryString["password"] != null)
                {
                    string registeredUsername = Request.QueryString["username"];
                    string registeredPassword = Request.QueryString["password"];
                    Session["RegisteredUsername"] = registeredUsername;
                    Session["RegisteredPassword"] = registeredPassword;

                    txtUsername.Text = registeredUsername;
                    txtPassword.Text = registeredPassword;

                    lblMessage.Text = "Successfully registered. Please log in.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate credentials against the session-stored values
            if (Session["RegisteredUsername"] != null && Session["RegisteredPassword"] != null)
            {
                string registeredUsername = Session["RegisteredUsername"].ToString();
                string registeredPassword = Session["RegisteredPassword"].ToString();

                if (username == registeredUsername && password == registeredPassword)
                {
                    lblMessage.Text = "Login successful!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Invalid username or password!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "No registered user found. Please register first.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
