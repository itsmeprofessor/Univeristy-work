using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationNAuthorization
{
    public partial class AdminDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
                Response.Redirect("Login.aspx");

            int level = Convert.ToInt32(Session["AccessLevel"]);

            if (level != 1)
            {
                RedirectToOwnDashboard(level);
            }

            LabAdmin.Text = "Welcome Admin. User ID: " + Session["ID"];
        }

        void RedirectToOwnDashboard(int level)
        {
            if (level == 3) Response.Redirect("ClientDashboard.aspx");
            if (level == 2) Response.Redirect("EmployeeDashboard.aspx");
        }
    }
}