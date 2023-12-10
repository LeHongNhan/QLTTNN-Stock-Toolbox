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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public bool isThoat = true;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tsDangXuat_Click(object sender, EventArgs e)
        {
            isThoat = false;
            this.Close();
            frmDangNhap f = new frmDangNhap();
            f.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
            {
                Application.Exit();
            }
        }

        private void tsThongTinTaiKhoan_Click(object sender, EventArgs e)
        {
            frmThongTinTaiKhoan f = new frmThongTinTaiKhoan();
            f.MdiParent = this;
            f.Show();
        }

        private void tsDoiMK(object sender, EventArgs e)
        {
            frmDoiMatKhau f = new frmDoiMatKhau();
            f.MdiParent = this;
            f.Show();
        }

        private void tsQLNguoiDung_Click(object sender, EventArgs e)
        {
            if (frmDangNhap.dn.getTenDangNhap() != "Admin")
            {
                MessageBox.Show("Không được truy cập!");
                return;
            }
            frmQuanLyNguoiDung f = new frmQuanLyNguoiDung();
            f.MdiParent = this;
            f.Show();
        }

        private void tsThuVienSach_Click(object sender, EventArgs e)
        {
            frmThuVienSach f = new frmThuVienSach();
            f.MdiParent = this;
            f.Show();
        }

        private void tsHocVienTrongLop_Click(object sender, EventArgs e)
        {
            frmDanhSachLop f = new frmDanhSachLop();
            f.MdiParent = this;
            f.Show();
        }

        private void taojToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon f = new frmHoaDon();
            f.MdiParent = this;
            f.Show();
        }

        private void tsHocVien_Click(object sender, EventArgs e)
        {
            frmHocVien f = new frmHocVien();
            f.MdiParent = this;
            f.Show();
        }

        private void tsDanhSachLop_Click(object sender, EventArgs e)
        {
            frmLop f = new frmLop();
            f.MdiParent = this;
            f.Show();
        }

        private void tsHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void tsLichHoc_Click(object sender, EventArgs e)
        {
            frmXepLichHoc f = new frmXepLichHoc();
            f.MdiParent = this;
            f.Show();
        }

        private void kếtQuảHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKetQuaHocTap f  = new frmKetQuaHocTap();
            f.MdiParent = this;
            f.Show();
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Số điện thoại: 0372880194 \n email: nhangaren2605@gmail.com");
        }

        private void tsGiangVien_Click(object sender, EventArgs e)
        {
            frmGiangVien f = new frmGiangVien();
            f.MdiParent = this;
            f.Show();
        }

        private void tsLop_Click(object sender, EventArgs e)
        {

        }

        private void khóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhoaHoc f = new frmKhoaHoc();
            f.MdiParent = this;
            f.Show();
        }
    }
}
