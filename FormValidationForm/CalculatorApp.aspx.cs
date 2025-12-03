using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormValidationForm
{
    public partial class CalculatorApp : System.Web.UI.Page
    {
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(txtNum1.Text);
            double num2 = Convert.ToDouble(txtNum2.Text);
            string op = ddlOperation.SelectedValue;
            double result = 0;

            switch (op)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/": result = num2 != 0 ? num1 / num2 : 0; break;
            }

            lblResult.Text = $"Result: {result}";

            // Use connection string from Web.config
            string conStr = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "INSERT INTO Calculations (Num1, Num2, Operation, Result) VALUES (@n1, @n2, @op, @res)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n1", num1);
                cmd.Parameters.AddWithValue("@n2", num2);
                cmd.Parameters.AddWithValue("@op", op);
                cmd.Parameters.AddWithValue("@res", result);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}