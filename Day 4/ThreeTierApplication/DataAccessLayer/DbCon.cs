using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbCon
    {
        private SqlConnection conn;
        public DbCon()
        {
            conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Zain'sDB\";Integrated Security=True;TrustServerCertificate=True");
        }
        public bool UDI(string Qry)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(Qry, conn);
            bool Result = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return Result;
        }
        public DataTable Search(string Qry)
        {
            conn.Open();
            SqlDataAdapter Sda = new SqlDataAdapter(Qry, conn);
            DataTable Dt = new DataTable();
            Sda.Fill(Dt);
            conn.Close();
            return Dt;
        }
    }
}
