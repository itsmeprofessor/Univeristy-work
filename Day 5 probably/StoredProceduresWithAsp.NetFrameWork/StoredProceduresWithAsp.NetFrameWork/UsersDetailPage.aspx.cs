using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoredProceduresWithAsp.NetFrameWork
{
    public partial class UsersDetailPage : System.Web.UI.Page
    {
        private string ConnectionString = "Data Source=ZainMohyuddin;Initial Catalog=zainDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGVAndDDL();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "InsertUser";
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Name", TxtName.Text);
            Cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
            Cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);
            if (Cmd.ExecuteNonQuery() > 0)
            {
                LoadGVAndDDL();
                LabResult.Text = "Data saved";


            }
            else
            {
                LabResult.Text = "Error : Data not saved";
            }
            Con.Close();
        }
        private void LoadGVAndDDL()
        {
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "GetUsers";
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);
            DataTable Dt = new DataTable();
            SDA.Fill(Dt);
            Con.Close();
            GVUsers.DataSource = Dt;
            GVUsers.DataBind();
            DDLUsers.DataSource = Dt;
            DDLUsers.DataValueField = "Id";
            DDLUsers.DataTextField = "Name";
            DDLUsers.DataBind();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "UpdateUser";
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(DDLUsers.SelectedValue));
            Cmd.Parameters.AddWithValue("@Name", TxtName.Text);
            Cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
            Cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);
            if (Cmd.ExecuteNonQuery() > 0)
            {
                LoadGVAndDDL();
                LabResult.Text = "Data updated";

            }
            else
            {
                LabResult.Text = "Error : Data not updated";
            }
            Con.Close();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "DeleteUser";
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(DDLUsers.SelectedValue));

            if (Cmd.ExecuteNonQuery() > 0)
            {
                LoadGVAndDDL();
                LabResult.Text = "Data deleted";

            }
            else
            {
                LabResult.Text = "Error : Data not deleted";
            }
            Con.Close();
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            TxtName.Text = "";
            TxtEmail.Text = "";
            TxtAddress.Text = "";

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "GetUser";
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Id", DDLUsers.SelectedValue.ToString());
            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);
            DataTable Dt = new DataTable();
            SDA.Fill(Dt);
            Con.Close();

            if (Dt.Rows.Count > 0)
            {
                TxtName.Text = Dt.Rows[0]["Name"].ToString();
                TxtEmail.Text = Dt.Rows[0]["Email"].ToString();
                TxtAddress.Text = Dt.Rows[0]["Address"].ToString();
            }
            else
            {
                LabResult.Text = "Error : 404";
            }
        }
    }
}