using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SecondWebApp.App_Code
{
    public class DBCon : IDisposable
    {
        private readonly SqlConnection _con;

        public DBCon()
        {
            string cs = ConfigurationManager.ConnectionStrings["AppCon"].ConnectionString;
            _con = new SqlConnection(cs);
        }

        public bool UDI(string qry, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(qry, _con))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                if (_con.State != ConnectionState.Open) _con.Open();
                int rows = cmd.ExecuteNonQuery();
                _con.Close();
                return rows > 0;
            }
        }

        public DataTable Search(string qry, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(qry, _con))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void Dispose()
        {
            if (_con != null) _con.Dispose();
        }
    }
}