using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThirdWebApp
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridView();
                LoadDDLUsers();
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadGridView()
        {
            DGVUsers.DataSource = new DBCon().Search("SELECT * FROM  Users");
            DGVUsers.DataBind();
        }
        private void LoadDDLUsers()
        {
            DDLUsers.DataSource = new DBCon().Search("SELECT * FROM Users");
            DDLUsers.DataTextField = "Name";
            DDLUsers.DataValueField = "Id";
            DDLUsers.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Users (Name, Email, Address) VALUES ('"
                            + TxtName.Text + "','"
                            + TxtEmail.Text + "','"
                            + TxtAddress.Text + "')";

            if (new DBCon().UDI(query))
            {
                LabResult.Text = "Data Saved";
                LoadGridView();
                LoadDDLUsers();
                //ClearInputs();
            }
            else
            {
                LabResult.Text = "Data not saved";
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            TxtName.Text = "";
            TxtEmail.Text = "";
            TxtAddress.Text = "";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            DataTable Dt = new DBCon().Search("SELECT * FROM Users WHERE Id = '" + DDLUsers.SelectedValue.ToString() + "'");
            if (Dt.Rows.Count > 0)
            {
                TxtName.Text = Dt.Rows[0]["Name"].ToString();
                TxtEmail.Text = Dt.Rows[0]["Email"].ToString();
                TxtAddress.Text = Dt.Rows[0]["Address"].ToString();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (new DBCon().UDI("UPDATE Users SET Name ='" + TxtName.Text + "', Email = '" + TxtEmail.Text + "', Address ='" + TxtAddress.Text + "' WHERE Id='" + DDLUsers.SelectedValue.ToString() + "'"))
            {
                LabResult.Text = "Data Updated!";
                LoadGridView();
                LoadDDLUsers();
            }
            else
            {
                LabResult.Text = "Data Not Updated!";
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (new DBCon().UDI("DELETE Users WHERE Id = '" + DDLUsers.SelectedValue.ToString() + "'"))
            {
                LabResult.Text = "Data Deleted!";
                LoadGridView();
                LoadDDLUsers();
            }
            else
            {
                LabResult.Text = "Data Not Deleted!";
            }
        }
        //private void ClearInputs(bool keepId = false)
        //{
        //    if (!keepId) DDLUsers.SelectedValue.ToString() = "";
        //    TxtName.Text = ""; TxtEmail.Text = ""; TxtAddress.Text = "";
        //}

    }
}