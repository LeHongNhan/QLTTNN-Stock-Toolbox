using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Data.Common;

namespace BLL_DAL
{
    public class SQLHelper
    {
        static string connString = "Data Source=LAPTOP-IH11UO7O;Initial Catalog=QLTrungTamNgoaiNgu;User ID=sa;Password=123;";
        static SqlConnection connect;
        public SQLHelper()
        {
            connect = new SqlConnection(connString);
        }
        public void open()
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();
        }
        public void close()
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
        public int getNonQuery(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            int kq = cmd.ExecuteNonQuery();
            close();
            return kq;
        }
        public SqlDataReader getDataReader(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            SqlDataReader rd = cmd.ExecuteReader();
            //close();
            return rd;
        }
        public DataTable getDatatable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            da.Fill(dt);
            return dt;
        }
        public SqlDataAdapter GetDataAdapter(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            return da;
        }
        public object getScalar(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            object kq = cmd.ExecuteScalar();
            close();
            return kq;
        }

    }
}
