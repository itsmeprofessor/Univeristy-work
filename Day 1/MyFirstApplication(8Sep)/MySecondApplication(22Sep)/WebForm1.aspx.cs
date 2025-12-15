using MySecondApplication_22Sep_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace 
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySecondApplication_22Sep_
{
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public WebForm1()
        {
            InitializeComponent();
            LoadGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (new DBCon().UDI("INSERT INTO Users (Name,Email,Address) VALUES ('" + TxtName.Text + "','" + TxtEmail.Text + "','" + TxtAddress.Text + "')"))
            {
                MessageBox.Show("Data Saved!");
                LoadGridView();
            }
            else
            {
                MessageBox.Show("Data Not saved!");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (new DBCon().UDI("UPDATE Users SET Name ='" + TxtName.Text + "', Email = '" + TxtEmail.Text + "', Address ='" + TxtAddress.Text + "' WHERE Id='" + TxtID.Text + "'"))
            {
                MessageBox.Show("Data Updated!");
                LoadGridView();
            }
            else
            {
                MessageBox.Show("Data Not Updated!");
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (new DBCon().UDI("DELETE Users WHERE Id = '" + TxtID.Text + "'"))
            {
                MessageBox.Show("Data Deleted!");
                LoadGridView();
            }
            else
            {
                MessageBox.Show("Data Not Deleted!");
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DataTable Dt = new DBCon().Search("SELECT * FROM Users WHERE Id = '" + TxtID.Text + "'");
            if (Dt.Rows.Count > 0)
            {
                TxtName.Text = Dt.Rows[0]["Name"].ToString();
                TxtEmail.Text = Dt.Rows[0]["Email"].ToString();
                TxtAddress.Text = Dt.Rows[0]["Address"].ToString();
            }
        }
        private void LoadGridView()
        {
            DGVUsers.DataSource = new DBCon().Search("SELECT * FROM  Users");
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtName.Text = "";
            TxtEmail.Text = "";
            TxtAddress.Text = "";
        }
    }
}