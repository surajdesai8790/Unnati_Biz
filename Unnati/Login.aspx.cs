using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Unnati
{
    public partial class Login : System.Web.UI.Page
    {
        private string conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBCON"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = txtUserName.Text.ToString().Trim();
                string Password = txtPassword.Text.ToString().Trim();

                DataTable dt = new DataTable();

                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("LoginUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
                cmd.Dispose();
                con.Dispose();

                if (dt.Rows.Count > 0)
                {
                    if (UserName == dt.Rows[0][2].ToString() && Password == dt.Rows[0][3].ToString())
                    {
                        Session["UserName"] = dt.Rows[0][1].ToString();
                        Session["UserId"] = dt.Rows[0][0].ToString();
                        Session["UserEmail"] = dt.Rows[0][2].ToString();
                        Response.Redirect("Dashboard.aspx");
                    }
                }

                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}