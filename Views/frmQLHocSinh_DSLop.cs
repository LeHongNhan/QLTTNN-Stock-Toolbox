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
    public partial class frmQLHocSinh_DSLop : Form
    {
        static int maHS = -1;
        public frmQLHocSinh_DSLop()
        {
            InitializeComponent();
        }
        SQLHelper h = new SQLHelper(); // Khai báo đối tượng SQLHelper

        private void frmQLHocSinh_DSLop_Load(object sender, EventArgs e)
        {
            // Gọi hàm để load danh sách học sinh khi form được load
            LoadDanhSachHocSinh();
        }

        private void LoadDanhSachHocSinh()
        {
            try
            {
                // Thực hiện truy vấn để lấy danh sách học sinh từ cơ sở dữ liệu
                DataTable dtHocSinh = h.getDatatable("SELECT * FROM HocSinh");

                // Kiểm tra xem có dữ liệu hay không
                if (dtHocSinh.Rows.Count > 0)
                {
                    // Nếu có dữ liệu, hiển thị lên DataGridView hoặc ListBox (tùy thuộc vào control bạn muốn sử dụng)
                    dgvDSHocSinh.DataSource = dtHocSinh;

                }
                else
                {
                    MessageBox.Show("Không có dữ liệu học sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int hocSinhID = -1;
        private void dgvDSHocSinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    // Lấy giá trị của cột "HocSinhID" từ dòng được chọn
            //    DataGridViewRow row = dgvDSHocSinh.Rows[e.RowIndex];
            //    if (int.TryParse(row.Cells["HocSinhID"].Value.ToString(), out int hocSinhID))
            //    {
            //        // Gán giá trị cho biến static "mahs"
            //        maHS = hocSinhID;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không thể lấy giá trị HocSinhID từ dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (maHS == -1)
            {
                MessageBox.Show("Chưa chọn học sinh");

            }
            else {
                if (dgvDSHocSinh.SelectedRows.Count > 0)
                {
                    // Lấy dòng đang được chọn
                    DataGridViewRow selectedRow = dgvDSHocSinh.SelectedRows[0];
                    frmDanhSachLop.maHSChon = maHS;
                }
                Close(); 
            }
        }

        private void dgvDSHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị của cột "HocSinhID" từ dòng được chọn
                DataGridViewRow row = dgvDSHocSinh.Rows[e.RowIndex];
                if (int.TryParse(row.Cells["HocSinhID"].Value.ToString(), out int hocSinhID))
                {
                    // Gán giá trị cho biến static "mahs"
                    maHS = hocSinhID;
                }
                else
                {
                    MessageBox.Show("Không thể lấy giá trị HocSinhID từ dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
