using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationNAuthorization
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Zain'sDB\";Integrated Security=True;TrustServerCertificate=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            string Qry = "SELECT ID,AccessLevel FROM Users WHERE Email='" + TxtEmail.Text + "' AND UserPassword='" + TxtPassword.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(Qry, con);
            SqlDataReader SDR =cmd.ExecuteReader();
            if (SDR.HasRows)
            {
                if(SDR.Read())
                {
                    int ID = Int32.Parse(SDR["ID"].ToString());
                    int AccessLevel = Int32.Parse(SDR["AccessLevel"].ToString());
                    Session.Add("ID", ID);
                    Session.Add("AccessLevel", AccessLevel);
                    con.Close();
                    Response.Redirect("Dashboard.aspx");
                }
            }
            else
            {
                LabResult.Text = "Login Failed: Authentication Failed!";
            }
            con.Close();
        }

    }
}