using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace LMSProject.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    lblUserName.Text = Session["UserName"].ToString();
                }
                BindUserStats();
            }
        }

        private void BindUserStats()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT Role, COUNT(*) as Count FROM Users GROUP BY Role";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvUserStats.DataSource = dt;
                    gvUserStats.DataBind();
                }
            }
        }
    }
}