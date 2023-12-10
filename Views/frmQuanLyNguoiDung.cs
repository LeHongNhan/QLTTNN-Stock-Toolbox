using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BLL_DAL;

namespace Views
{
    public partial class frmQuanLyNguoiDung : Form
    {
        SQLHelper kn = new SQLHelper();
        string status = "";
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void loadDatagridview()
        {
            string query = "SELECT * FROM NguoiDung";

            DataTable dataTable = kn.getDatatable(query);

            dgvUsers.AutoGenerateColumns = true;

            dgvUsers.DataSource = dataTable;
        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            try
            {
                loadDatagridview();
            }
            finally
            {
                kn.close();
            }

        }

        private void moKhoaControls()
        {
            txtTenDangNhap.Enabled = true;
            txtMatKhau.Enabled = true;
            txtHoVaTen.Enabled = true;
            txtDiaChi.Enabled = true;
            cboGioiTInh.Enabled = true;
            txtSDT.Enabled = true;
        }

        private void KhoaControls()
        {
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            txtHoVaTen.Enabled = false;
            txtDiaChi.Enabled = false;
            cboGioiTInh.Enabled = false;
            txtSDT.Enabled = false;
        }

        private void clearDuLieu()
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtHoVaTen.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            cboGioiTInh.SelectedIndex = 0;
        }

        private int GetNewNguoiDungID()
        {
            string query = "SELECT MAX(NguoiDungID) FROM NguoiDung";

            object result = kn.getScalar(query);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void ThemNguoiDung()
        {
            int nguoiDungID = GetNewNguoiDungID();
            string hoTen = txtHoVaTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string gioiTinh = cboGioiTInh.Text.Trim();
            string soDienThoai = txtSDT.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string queryTaiKhoan = $"INSERT INTO TaiKhoanNguoiDung (TenDangNhap, MatKhau) VALUES ('{tenDangNhap}', '{matKhau}')";
            kn.getNonQuery(queryTaiKhoan);
            string query = $"SET IDENTITY_INSERT NguoiDung ON; INSERT INTO NguoiDung (NguoiDungID, HoTen, DiaChi, GioiTinh, SoDienThoai, TenDangNhap) VALUES ({nguoiDungID}, N'{hoTen}', N'{diaChi}', N'{gioiTinh}', '{soDienThoai}', '{tenDangNhap}'); SET IDENTITY_INSERT NguoiDung OFF;";
            kn.getNonQuery(query);

            loadDatagridview();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            moKhoaControls();
            clearDuLieu();
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            status = "add";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearDuLieu();
            KhoaControls();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void XoaNguoiDung()
        {
            int nguoiDungID = int.Parse(dgvUsers.CurrentRow.Cells["NguoiDungID"].Value.ToString());

            string query = $"DELETE NguoiDung WHERE NguoiDungID = {nguoiDungID}";

            kn.getNonQuery(query);

            loadDatagridview();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (status == "add")
            {
                ThemNguoiDung();
            }

            if (status == "edit")
            {
                SuaNguoiDung();
            }

            clearDuLieu();
            KhoaControls();
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            status = "del";
            if (MessageBox.Show("Bạn có chắc muốn xóa người dùng này?", "Thông báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                XoaNguoiDung();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
        private string LayMatKhauTuDatabase(string tenDangNhap)
        {
            string matKhau = "";

            string query = $"SELECT MatKhau FROM TaiKhoanNguoiDung WHERE TenDangNhap = '{tenDangNhap}'";

            object result = kn.getScalar(query);

            if (result != null && result != DBNull.Value)
            {
                matKhau = result.ToString();
            }
            return matKhau;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                string matKhau = LayMatKhauTuDatabase(row.Cells["TenDangNhap"].Value.ToString().Trim());

                txtHoVaTen.Text = row.Cells["HoTen"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                cboGioiTInh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = matKhau;
            }
        }

        private void SuaNguoiDung()
        {
            int nguoiDungID = int.Parse(dgvUsers.CurrentRow.Cells["NguoiDungID"].Value.ToString());
            string hoTen = txtHoVaTen.Text;
            string diaChi = txtDiaChi.Text;
            string gioiTinh = cboGioiTInh.Text;
            string soDienThoai = txtSDT.Text;
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;

            string queryNguoiDung = $"UPDATE NguoiDung SET HoTen = '{hoTen}', DiaChi = '{diaChi}', GioiTinh = '{gioiTinh}', SoDienThoai = '{soDienThoai}' WHERE NguoiDungID = {nguoiDungID}";
            string queryTaiKhoan = $"UPDATE TaiKhoanNguoiDung SET MatKhau = '{matKhau}' WHERE TenDangNhap = '{tenDangNhap}'";

            kn.getNonQuery(queryNguoiDung);
            kn.getNonQuery(queryTaiKhoan);

            // Sau khi sửa, làm mới dữ liệu trong DataGridView
            loadDatagridview();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            status = "edit";
            moKhoaControls();
        }
    }
}
