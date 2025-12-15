using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySecondApplication_22Sep_
{
    internal class DBCon
    {
        private SqlConnection Con;
        public DBCon()
        {
            Con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Zain's DB\";Integrated Security=True;Trust Server Certificate=True");
        }
        public bool UDI(string Qry)
        {
            Con.Open();
            SqlCommand Cmd = new SqlCommand(Qry, Con);
            bool Result = Cmd.ExecuteNonQuery() > 0;
            Con.Close();
            return Result;

        }


        public DataTable Search(string Qry)
        {
            Con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(Qry, Con);
            DataTable Dt = new DataTable();
            SDA.Fill(Dt);
            Con.Close();
            return Dt;
        }
    }
}
