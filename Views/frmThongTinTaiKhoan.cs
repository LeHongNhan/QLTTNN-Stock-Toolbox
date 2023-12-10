using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Views
{
    public partial class frmThongTinTaiKhoan : Form
    {
        public frmThongTinTaiKhoan()
        {
            InitializeComponent();
        }
        ThongTinTaiKhoan thongTin = new ThongTinTaiKhoan(frmDangNhap.dn);
        void loadThongTin()
        {
            string taiKhoan = frmDangNhap.dn.getTenDangNhap();
            txtHoVaTen.Text = thongTin.hoTen;
            txtDiaChi.Text = thongTin.diaChi;
            txtSDT.Text = thongTin.soDienThoai;
            txtTenDangNhap.Text = thongTin.tenDangNhap;
            if (thongTin.gioiTinh == "Nam")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            txtHoVaTen.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            

        }
        private void frmThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            loadThongTin();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            txtHoVaTen.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            grbGioiTinh.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            thongTin.hoTen = txtHoVaTen.Text;
            thongTin.diaChi = txtDiaChi.Text;
            thongTin.soDienThoai = txtSDT.Text;
            if (radNam.Checked)
            {
                thongTin.gioiTinh = radNam.Text;
            }
            else if (radNu.Checked) 
            {
                thongTin.gioiTinh = radNu.Text;
            }
            thongTin.luuThongTin();
        }
    }
}
