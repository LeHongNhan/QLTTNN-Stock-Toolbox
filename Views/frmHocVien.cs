using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class frmHocVien : Form
    {
        SQLHelper helper = new SQLHelper();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public frmHocVien()
        {
            InitializeComponent();
        }
        private bool IsValidEmail(string email)
        {
            // Biểu thức chính quy kiểm tra định dạng email
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        void loadThongTin()
        {
            ds.Tables.Clear();
            adapter = helper.GetDataAdapter("Select Ho as N'Họ', Ten as N'Tên', email as N'Email', NgaySinh as N'Ngày sinh', SoDienThoai as N'Số điện thoại', DiaChi as N'Địa chỉ' from HocSinh");
            adapter.Fill(ds, "HocSinh");
            dgvDS.DataSource = ds.Tables["HocSinh"];
        }

        private void frmHocVien_Load(object sender, EventArgs e)
        {
            loadThongTin();
        }

        int vt;
        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1)
            //{
            //    return;
            //}
            //vt = e.RowIndex;
            //DataRow row = ds.Tables["HocSinh"].Rows[vt];

            //txtHo.Text = row["Họ"].ToString();
            //txtTen.Text = row["Tên"].ToString();
            //txtEmail.Text = row["Email"].ToString();
            //mtxtNgaySinh.Text = row["Ngày sinh"].ToString();
            //txtSdt.Text = row["Số điện thoại"].ToString();
            //txtDiaChi.Text = row["Địa chỉ"].ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["HocSinh"].NewRow();
            row["Họ"] = txtHo.Text;
            row["Tên"] = txtTen.Text;
            row["Email"] = txtEmail.Text;
            row["Ngày sinh"] = dtpNgaySinh.Text;
            row["Số điện thoại"] = txtSdt.Text;
            row["Địa chỉ"] = txtDiaChi.Text;
            
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!");
                return;
            }
            if (txtSdt.Text.Length != 10)
            {
                MessageBox.Show("Kiểm tra số điện thoại");
                return;
            }
            else
            {
                ds.Tables["HocSinh"].Rows.Add(row);
                SqlCommandBuilder b = new SqlCommandBuilder(adapter);
                adapter.Update(ds.Tables["HocSinh"]);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            try
            {
                DataRow row = ds.Tables["HocSinh"].Rows[vt];
                ds.Tables["HocSinh"].Rows.Remove(row);
                SqlCommandBuilder b = new SqlCommandBuilder(adapter);

                int kq = adapter.Update(ds.Tables["HocSinh"]);
                if (kq > 0)
                {
                    loadThongTin();
                    MessageBox.Show("Xóa không được");
                }
                else
                {
                    MessageBox.Show("Xóa thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["HocSinh"].Rows[vt];

            if (txtSdt.Text.Length != 10)
            {
                MessageBox.Show("Kiểm tra số điện thoại");
                return;
            }
            else
            {
                
                int kq = adapter.Update(ds.Tables["HocSinh"]);
                if (kq > 0)
                {
                    row["Họ"] = txtHo.Text;
                    row["Tên"] = txtTen.Text;
                    row["Email"] = txtEmail.Text;
                    row["Ngày sinh"] = dtpNgaySinh.Text;
                    row["Số điện thoại"] = txtSdt.Text;
                    row["Địa chỉ"] = txtDiaChi.Text;
                    row.EndEdit();
                    loadThongTin();
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            vt = e.RowIndex;
            DataRow row = ds.Tables["HocSinh"].Rows[vt];
            txtHo.Text = row["Họ"].ToString();
            txtTen.Text = row["Tên"].ToString();
            txtEmail.Text = row["Email"].ToString();
            dtpNgaySinh.Text = row["Ngày sinh"].ToString();
            txtSdt.Text = row["Số điện thoại"].ToString();
            txtDiaChi.Text = row["Địa chỉ"].ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpNgaySinh.Value;
            DateTime currentDate = DateTime.Now;

            // So sánh ngày sinh với ngày hiện tại
            if (selectedDate > currentDate)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Đặt lại ngày sinh thành ngày hiện tại
                dtpNgaySinh.Value = currentDate;
            }
        }
    }
}
