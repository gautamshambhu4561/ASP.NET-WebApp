using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LoginFormwithADO
{
    public partial class LoginForm : Page
    {
        string connectionString = "Data Source=localhost;Initial Catalog=UserDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connectionString = "Data Source=localhost;Initial Catalog=UserDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int userCount = (int)cmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            //  session data
                            Session["Username"] = username;

                            //  Redirect to dashboard page
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                        {
                            lblMessage.Text = "Invalid username or password.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

    }
}
