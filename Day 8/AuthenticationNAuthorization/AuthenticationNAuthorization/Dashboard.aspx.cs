using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationNAuthorization
{
    public partial class Dshboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                LabWelcome.Text = Session["ID"].ToString();
            }
        }
    }
}