using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationNAuthorization
{
    public partial class ClientDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
                Response.Redirect("Login.aspx");

            int level = Convert.ToInt32(Session["AccessLevel"]);

            if (level != 3)
            {
                RedirectToOwnDashboard(level);
            }

            LabClient.Text = "Welcome Client. User ID: " + Session["ID"];
        }

        void RedirectToOwnDashboard(int level)
        {
            if (level == 2) Response.Redirect("EmployeeDashboard.aspx");
            if (level == 1) Response.Redirect("AdminDashboard.aspx");
        }
    }
}