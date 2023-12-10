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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Views
{
    public partial class frmGiangVien : Form
    {
        SQLHelper helper = new SQLHelper();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public frmGiangVien()
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
            adapter = helper.GetDataAdapter("Select Ho as N'Họ', Ten as N'Tên', email as N'Email', SoDienThoai as N'Số điện thoại', Mota as N'Mô tả' from GiaoVien ");
            adapter.Fill(ds, "GiaoVien");
            dgvDS.DataSource = ds.Tables["GiaoVien"];
        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            loadThongTin();
        }

        int vt;
        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string emailAddress = txtEmail.Text.Trim();

            // Kiểm tra định dạng email bằng biểu thức chính quy
            if (!IsValidEmail(emailAddress))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }
            if (txtSdt.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }
            DataRow row = ds.Tables["GiaoVien"].NewRow();
            row["Họ"] = txtHo.Text;
            row["Tên"] = txtTen.Text;
            row["Email"] = txtEmail.Text;
            row["Số điện thoại"] = txtSdt.Text;
            row["Mô tả"] = txtMoTa.Text;
            ds.Tables["GiaoVien"].Rows.Add(row);
            SqlCommandBuilder b = new SqlCommandBuilder(adapter);
            adapter.Update(ds.Tables["GiaoVien"]);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["GiaoVien"].Rows[vt];
            row.BeginEdit();
            row["Họ"] = txtHo.Text;
            row["Tên"] = txtTen.Text;
            row["Email"] = txtEmail.Text;
            row["Số điện thoại"] = txtSdt.Text;
            row["Mô tả"] = txtMoTa.Text;
            row.EndEdit();
            int kq = adapter.Update(ds.Tables["GiaoVien"]);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ds.Tables["GiaoVien"].Rows[vt];
                ds.Tables["GiaoVien"].Rows.Remove(row);
                SqlCommandBuilder b = new SqlCommandBuilder(adapter);

                int kq = adapter.Update(ds.Tables["GiaoVien"]);
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

        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            vt = e.RowIndex;
            DataRow row = ds.Tables["GiaoVien"].Rows[vt];

            txtHo.Text = row["Họ"].ToString();
            txtTen.Text = row["Tên"].ToString();
            txtEmail.Text = row["Email"].ToString();
            txtSdt.Text = row["Số điện thoại"].ToString();
            txtMoTa.Text = row["Mô tả"].ToString();
        }
    }
}
