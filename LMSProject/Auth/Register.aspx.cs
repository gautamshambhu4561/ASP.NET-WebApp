using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using LMSProject.HelperClass;

namespace LMSProject.Auth
{
	public partial class Register : System.Web.UI.Page
	{
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Response.Redirect("~/Pages/Default.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsEmailUnique(txtEmail.Text.Trim()))
            {
                if (DBHelper.RegisterUser(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text, "Student"))
                {
                    Response.Redirect("~/Auth/Login.aspx");
                }
                else
                {
                    errorMessage.InnerText = "Registration failed. Try again.";
                    errorMessage.Attributes.Remove("class");
                    errorMessage.Attributes.Add("class", "alert alert-danger");
                }
            }
            else
            {
                errorMessage.InnerText = "Email already registered.";
                errorMessage.Attributes.Remove("class");
                errorMessage.Attributes.Add("class", "alert alert-danger");
            }
        }

        private bool IsEmailUnique(string email)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() == 0;
                }
            }
        }
    }
}
