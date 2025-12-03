using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginFormwithADO
{
	public partial class Adding2Numbers : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Get user inputs
            int number1 = int.Parse(txtFirst.Text.Trim());
            int number2 = int.Parse(txtSecond.Text.Trim());
            int result = number1 + number2;

            
            string connectionString = @"Data Source=localhost;Initial Catalog=UserDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO SumResults (Number1, Number2, Result) VALUES (@n1, @n2, @res)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@n1", number1);
                    cmd.Parameters.AddWithValue("@n2", number2);
                    cmd.Parameters.AddWithValue("@res", result);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();

                    lblResult.Text = rows > 0 ? $"Sum = {result} (Saved to DB)." : "Failed to insert data.";
                }
            }
        }
    }
}