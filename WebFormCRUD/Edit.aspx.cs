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

    public partial class Edit : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                string conStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        txtName.Text = rdr["Name"].ToString();
                        txtEmail.Text = rdr["Email"].ToString();
                        txtCourse.Text = rdr["Course"].ToString();
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Students SET Name=@Name, Email=@Email, Course=@Course WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("Default.aspx");
            }
        }
    }

}