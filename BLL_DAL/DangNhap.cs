using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class DangNhap
    {
        public static string taiKhoan;
        static string matKhau;
        SQLHelper conn = new SQLHelper();
        public DangNhap() { }
        public bool checkDangNhap(string TaiKhoan, string MatKhau) 
        {
            DataTable dt = new DataTable();
            string sql = "select * from TaiKhoanNguoiDung where TenDangNhap = '" + TaiKhoan + "' and MatKhau = '"+MatKhau+"'";
            SqlDataAdapter dataAdapter = conn.GetDataAdapter(sql);
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0 ) 
            {
                taiKhoan = TaiKhoan;
                matKhau = MatKhau;
                return true; 
            }
            else
            {
                return false;
            }
        }
        public string getTenDangNhap()
        { return taiKhoan; }
        public bool doiMatKhau(string matKhauCu,string matKhauMoi, string nhapLai)
        {
            if (matKhauCu == matKhau && matKhauMoi == nhapLai)
            {
                SQLHelper h = new SQLHelper();
                string sql = "Update TaiKhoanNguoiDung Set MatKhau = '" + matKhauMoi + "' where TenDangNhap = '" + taiKhoan + "'";
                if (h.getNonQuery(sql) == 1)
                {
                    return true;

                }
            }
            return false;
        }
    }
}
