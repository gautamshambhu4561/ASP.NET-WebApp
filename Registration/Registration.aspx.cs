using System;
using System.Web.UI;

namespace SimpleLoginForm
{
    public partial class RegistrationForm : Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;

           
            bool isRegistered = RegisterUser(username, password, email);

            if (isRegistered)
            {
                // Redirect to the login page 
                string redirectUrl = $"LoginForm.aspx?username={username}&password={password}";
                Response.Redirect(redirectUrl);
            }
            else
            {
                lblMessage.Text = "Registration failed. Please try again.";
            }
        }

        private bool RegisterUser(string username, string password, string email)
        {
      
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(email))
            {
                return true;
            }
            return false;
        }
    }
}

