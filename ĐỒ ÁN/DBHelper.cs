using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN
{
    class DBHelper
    {
        private static DBHelper _Instance;
        public SqlConnection conect { get; set; }
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string s = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=DoAn;Integrated Security=True";
                    _Instance = new DBHelper(s);
                }
                return _Instance;
            }
            private set { }
        }
        private DBHelper(string s)
        {
            conect = new SqlConnection(s);
        }
        public DataTable GetRecord(string Query)
        {
            DataTable data = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(Query, conect);
            conect.Open();
            da.Fill(data);
            conect.Close();
            return data;
        }
        public void ExcuteDB(string Query)          //UPDATE cho DB
        {
            SqlCommand cmd = new SqlCommand(Query, conect);
            conect.Open();
            cmd.ExecuteNonQuery();
            conect.Close();
        }
    }
}
