using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstApplication_8Sep_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=ZainMohyuddin;Initial Catalog=zainDB;Integrated Security=True";
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            string Qry = "INSERT INTO Users ( Name,Email, Address) VALUES ('"+TxtName.Text+ "','" + TxtEmail.Text + "','" + TxtAddress.Text + "')";
            SqlCommand Cmd = new SqlCommand(Qry, Con);
            if (Cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Saved!");
            }
            else
            {
                MessageBox.Show("Lo G wich hogaye!");
            }
            Con.Close();
            LoadGridView();
        }

        private void LoadGridView()
        {
            string ConnectionString = "Data Source=ZainMohyuddin;Initial Catalog=zainDB;Integrated Security=True";
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            string Qry = "SELECT * FROM Users";
            SqlDataAdapter SDA = new SqlDataAdapter(Qry, Con);
            DataTable Dt = new DataTable();
            SDA.Fill(Dt);
            Con.Close();
            DGVUsers.DataSource = Dt;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=ZainMohyuddin;Initial Catalog=zainDB;Integrated Security=True";
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            string Qry = "SELECT * FROM Users WHERE ID = '" + TxtId.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(Qry, Con);
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
                MessageBox.Show("404");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Established connection
            string ConnectionStrirng = "Data Source=ZainMohyuddin;Initial Catalog=zainDB;Integrated Security=True";
            SqlConnection Con = new SqlConnection(ConnectionStrirng);
            //Open Connection
            Con.Open();
            //Create query
            string Qry = "DELETE FROM Users WHERE ID='" + TxtId.Text + "'";
            SqlCommand cmd = new SqlCommand(Qry, Con);
            //Display User
            if (cmd.ExecuteNonQuery() > 0)
            {

                MessageBox.Show("Data Deleted");

            }
            else
            {
                MessageBox.Show("Man an Error");

            }
            //Close Connection
            Con.Close();
            LoadGridView();
        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            string Name = TxtName.Text;
            string Email = TxtEmail.Text;
            string Address = TxtAddress.Text;
            MessageBox.Show(
                "Name: " + Name + "\n" +
                "Email: " + Email + "\n" +
                "Address: " + Address
                );
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Established connection
            string ConnectionStrirng = "Data Source=ZainMohyuddin;Initial Catalog=zainDB;Integrated Security=True";
            SqlConnection Con = new SqlConnection(ConnectionStrirng);
            //Open Connection
            Con.Open();
            //Create query
            string Qry = "UPDATE Users SET Name = '" + TxtName.Text +
             "', Email = '" + TxtEmail.Text +
             "', Address = '" + TxtAddress.Text +
             "' WHERE ID = '" + TxtId.Text + "'";
            SqlCommand cmd = new SqlCommand(Qry, Con);
            //Display User
            if (cmd.ExecuteNonQuery() > 0)
            {

                MessageBox.Show("Data Updated");

            }
            else
            {
                MessageBox.Show("Man an Error");

            }
            //Close Connection
            Con.Close();
            LoadGridView();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
