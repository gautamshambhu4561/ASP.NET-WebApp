using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data.SqlClient;
using System.Configuration;

namespace WebFormCRUD
{
    public partial class Add : System.Web.UI.Page
    {
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "INSERT INTO Students (Name, Email, Course) VALUES (@Name, @Email, @Course)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Default.aspx");
            }
        }
    }

}