using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class ThongTinTaiKhoan
    {
        public int id;
        public string hoTen;
        public string diaChi;
        public string gioiTinh;
        public string soDienThoai;
        public string tenDangNhap;
        public ThongTinTaiKhoan() { }
        public ThongTinTaiKhoan(DangNhap dn)
        {
            string tenDN = dn.getTenDangNhap();
            SQLHelper h = new SQLHelper();
            string sql = "select * from NguoiDung where TenDangNhap = '" + tenDN +"' ";
            SqlDataReader rd = h.getDataReader(sql);
            while (rd.Read())
            {
                id = rd.GetInt32(0);
                hoTen = rd.GetString(1);
                diaChi = rd.GetString(2);
                gioiTinh = rd.GetString(3);
                soDienThoai = rd.GetString(4);
                tenDangNhap = rd.GetString(5);
            }
        }
        public int luuThongTin()
        {
            SQLHelper h = new SQLHelper();
            string sql = "Update NguoiDung Set HoTen = N'" + hoTen + "', DiaChi = '" + diaChi + "', GioiTinh = '" + gioiTinh + "', SoDienThoai = '" + soDienThoai + "' where TenDangNhap = '" + tenDangNhap + "'";
            return h.getNonQuery(sql);
        }
    }
}
