using System;
using System.Data.SqlClient;

namespace DbConnectionTestProject
{
    public partial class TestConnection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=UserDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    lblResult.Text = "Database connection successful.";
                }
                catch (Exception ex)
                {
                    lblResult.Text = "Connection failed: " + ex.Message;
                    
                }
            }
        }
    }
}
