using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data.SqlClient;
using System.Configuration;

namespace LoginRole
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string conStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT Role FROM Users WHERE Username=@Username AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string role = result.ToString();
                    if (role == "hr")
                        Response.Redirect("HRDashboard.aspx");
                    else if (role == "user")
                        Response.Redirect("UserDashboard.aspx");
                    else
                        lblMessage.Text = "Unknown role.";
                }
                else
                {
                    lblMessage.Text = "Invalid credentials.";
                }
            }
        }
    }

}