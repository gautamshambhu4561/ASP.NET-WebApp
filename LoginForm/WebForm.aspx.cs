using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace LoginForm
{
    public partial class WebForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

           protected void Button1_Click(object sender, EventArgs e)
        {
            string username = userName.Text.Trim();
            string password = userPassword.Text;

            string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    conn.Open();
                    int userCount = (int)cmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        Session["Username"] = username;
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid login.";
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

