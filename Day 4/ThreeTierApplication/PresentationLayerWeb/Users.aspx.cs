using AppProps;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayerWeb
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                LoadGridView();
                LoadDDLUser();
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            User U = new User()
            {
                Name = TxtName.Text,
                Email = TxtEmail.Text,
                Address = TxtAddress.Text,
            };
            if(new UserBLL().InsertUserBLL(U))
            {
                LabResult.Text = "Data Saved";
                LoadGridView();
                LoadDDLUser();
            }
            else
            {
                LabResult.Text = "Error: Data Not Saved!";
            }
        }
        public void LoadGridView()
        {
            GVUsers.DataSource = new UserBLL().GetUsersBLL();
            GVUsers.DataBind();
        }
        public void LoadDDLUser()
        {
            DDLUsers.DataSource = new UserBLL().GetUsersBLL();
            DDLUsers.DataValueField = "Id";
            DDLUsers.DataTextField = "Name";
            DDLUsers.DataBind();

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            User U = new User()
            {
                Id = Int32.Parse(DDLUsers.SelectedValue.ToString())
            };
            DataTable Dt = new UserBLL().GetUserBLL(U);
            if (Dt.Rows.Count > 0)
            {
                TxtName.Text = Dt.Rows[0]["Name"].ToString();
                TxtEmail.Text = Dt.Rows[0]["Email"].ToString();
                TxtAddress.Text = Dt.Rows[0]["Address"].ToString();
            }
            else
            {
                LabResult.Text = "404:No Data Found";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            User U = new User()
            {
                Id = Int32.Parse(DDLUsers.SelectedValue.ToString()),
                Name = TxtName.Text,
                Email = TxtEmail.Text,
                Address = TxtAddress.Text,
            };
            if (new UserBLL().UpdateUserBLL(U))
            {
                LabResult.Text = "Data Updated";
                LoadGridView();
                LoadDDLUser();
            }
            else
            {
                LabResult.Text = "Error: Data Not Updated!";
            }

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            User U = new User()
            {
                Id = Int32.Parse(DDLUsers.SelectedValue.ToString())
                
            };
            if (new UserBLL().DeleteUserBLL(U))
            {
                LabResult.Text = "Data Deleted";
                LoadGridView();
                LoadDDLUser();
            }
            else
            {
                LabResult.Text = "Error: Data Not Deleted!";
            }

        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            TxtName.Text = "";
            TxtEmail.Text = "";
            TxtAddress.Text = "";

        }
    }
}