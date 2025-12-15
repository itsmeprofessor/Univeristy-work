using SecondWebApp.App_Code;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Xml.Linq;

namespace SecondWebApp
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadGrid();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            using (var db = new DBCon())
            {
                bool ok = db.UDI(
                    "INSERT INTO Users (Name, Email, Address) VALUES (@Name, @Email, @Address)",
                    new SqlParameter("@Name", TxtName.Text.Trim()),
                    new SqlParameter("@Email", TxtEmail.Text.Trim()),
                    new SqlParameter("@Address", TxtAddress.Text.Trim())
                );
                LabResult.Text = ok ? "Data Saved!" : "Save failed.";
                ClearInputs();
                LoadGrid();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtId.Text))
            {
                LabResult.Text = "Please provide Id to update.";
                return;
            }

            using (var db = new DBCon())
            {
                bool ok = db.UDI(
                    "UPDATE Users SET Name=@Name, Email=@Email, Address=@Address WHERE Id=@Id",
                    new SqlParameter("@Name", TxtName.Text.Trim()),
                    new SqlParameter("@Email", TxtEmail.Text.Trim()),
                    new SqlParameter("@Address", TxtAddress.Text.Trim()),
                    new SqlParameter("@Id", TxtId.Text.Trim())
                );
                LabResult.Text = ok ? "Data Updated!" : "Update failed or Id not found.";
                LoadGrid();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtId.Text))
            {
                LabResult.Text = "Please provide Id to delete.";
                return;
            }

            using (var db = new DBCon())
            {
                bool ok = db.UDI(
                    "DELETE FROM Users WHERE Id=@Id",
                    new SqlParameter("@Id", TxtId.Text.Trim())
                );
                LabResult.Text = ok ? "Data Deleted!" : "Delete failed or Id not found.";
                ClearInputs();
                LoadGrid();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            using (var db = new DBCon())
            {
                DataTable dt = db.Search(
                    "SELECT * FROM Users WHERE Id = @Id",
                    new SqlParameter("@Id", TxtId.Text.Trim())
                );

                if (dt.Rows.Count > 0)
                {
                    TxtName.Text = dt.Rows[0]["Name"].ToString();
                    TxtEmail.Text = dt.Rows[0]["Email"].ToString();
                    TxtAddress.Text = dt.Rows[0]["Address"].ToString();
                    LabResult.Text = "Record found.";
                }
                else
                {
                    LabResult.Text = "No record found for this Id.";
                    ClearInputs(keepId: true);
                }
            }
        }

        private void LoadGrid()
        {
            using (var db = new DBCon())
            {
                DGVUsers.DataSource = db.Search("SELECT * FROM Users ORDER BY Id DESC");
                DGVUsers.DataBind();
            }
        }

        private void ClearInputs(bool keepId = false)
        {
            if (!keepId) TxtId.Text = "";
            TxtName.Text = "";
            TxtEmail.Text = "";
            TxtAddress.Text = "";
        }
    }
}
