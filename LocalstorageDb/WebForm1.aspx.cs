using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalstorageDb
{
	public partial class WebForm1 : System.Web.UI.Page
    {
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

                conn.Open();
                int userCount = (int)cmd.ExecuteScalar();

                if (userCount > 0)
                {
                    Session["Username"] = username;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }
            }
        }
}
}