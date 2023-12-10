using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class frmThuVienSach : Form
    {
        public frmThuVienSach()
        {
            InitializeComponent();
        }
        SQLHelper helper = new SQLHelper();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        void loadThongTin()
        {
            ds.Tables.Clear();
            adapter = helper.GetDataAdapter("Select SachId as N'Mã sách', TenSach as N'Tên sách', TenTacgia as N'Tác giả', Gia as N'Giá' from Sach");
            adapter.Fill(ds, "Sach");
            dgvThongTinSach.DataSource = ds.Tables["Sach"];
        }
        private void frmThuVienSach_Load(object sender, EventArgs e)
        {
            loadThongTin();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["Sach"].NewRow();
            row["Tên sách"] = txtTenSach.Text;
            row["Tác giả"] = txtTacGia.Text;
            row["Giá"] = txtGia.Text;
            ds.Tables["Sach"].Rows.Add(row);
            SqlCommandBuilder b = new SqlCommandBuilder(adapter);
            adapter.Update(ds.Tables["Sach"]);
        }


        int vt;
        private void dgvThongTinSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1)
            //{
            //    return;
            //}
            //vt = e.RowIndex;
            //DataRow row = ds.Tables["Sach"].Rows[vt];

            //txtTenSach.Text = row["Tên sách"].ToString();
            //txtTacGia.Text = row["Tác giả"].ToString();
            //txtGia.Text = row["Giá"].ToString();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["Sach"].Rows[vt];
            row.BeginEdit();
            row["Tên sách"] = txtTenSach.Text;
            row["Tác giả"] = txtTacGia.Text;
            row["Giá"] = txtGia.Text;
            row.EndEdit();
            int kq = adapter.Update(ds.Tables["Sach"]);
            if (kq > 0)
            {
                loadThongTin();
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["Sach"].Rows[vt];
            ds.Tables["Sach"].Rows.Remove(row);
            SqlCommandBuilder b = new SqlCommandBuilder(adapter);
            
            int kq = adapter.Update(ds.Tables["Sach"]);
            if (kq > 0) { MessageBox.Show("Xóa thành công"); }
            else { MessageBox.Show("Xóa không được"); }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvThongTinSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            vt = e.RowIndex;
            DataRow row = ds.Tables["Sach"].Rows[vt];

            txtTenSach.Text = row["Tên sách"].ToString();
            txtTacGia.Text = row["Tác giả"].ToString();
            txtGia.Text = row["Giá"].ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (radTenSach.Checked)
            {
                ds.Tables["Sach"].Clear();
                string sql = "Select SachId as N'Mã sách', TenSach as N'Tên sách', TenTacgia as N'Tác giả', Gia as N'Giá' from Sach where TenSach Like N'%" + txtTimKiem.Text + "%'";
                adapter = helper.GetDataAdapter(sql);
                adapter.Fill(ds.Tables["Sach"]);
                dgvThongTinSach.DataSource = ds.Tables["Sach"];

            }
            if (radTenTacGia.Checked)
            {
                ds.Tables["Sach"].Clear();
                string sql = "Select SachId as N'Mã sách', TenSach as N'Tên sách', TenTacgia as N'Tác giả', Gia as N'Giá' from Sach where TenTacGia Like N'%" + txtTimKiem.Text + "%'";
                adapter = helper.GetDataAdapter(sql);
                adapter.Fill(ds.Tables["Sach"]);
                dgvThongTinSach.DataSource = ds.Tables["Sach"];
            }

            if (radTenSach.Checked == false && radTenTacGia.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn phương thức tìm kiếm", "Thông báo");
                return;
            }
        }
    }
}
