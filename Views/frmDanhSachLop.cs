using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Views
{
    public partial class frmDanhSachLop : Form
    {
        public frmDanhSachLop()
        {
            InitializeComponent();
        }

        private void lblDanhSachHocSinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        SQLHelper h = new SQLHelper();
        DataSet ds = new DataSet();
        SqlDataAdapter daKhoaHoc = new SqlDataAdapter();
        SqlDataAdapter daLopHoc = new SqlDataAdapter();
        SqlDataAdapter daHocSinh = new SqlDataAdapter();
        void loadHocSinHKhoaHoc(int lopID)
        {
            try 
            {
                daHocSinh = h.GetDataAdapter("Select HocSinh.HocSinhID, HocSinh.Ho, HocSinh.Ten, HocSinh.NgaySinh, HocSinh.DiaChi, HocSinh.SoDienThoai, HocSinh.email from Lop_HocSinh inner join HocSinh on Lop_HocSinh.HocSinhID = HocSinh.HocSinhID where Lop_HocSinh.Lop_HocSinhID = '"+lopID+"'");
                daHocSinh.Fill(ds, "HocSinh");
                lstHocSinh.DataSource = ds.Tables["HocSinh"];
                lstHocSinh.DisplayMember = "HocSinhID";

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        void loadKhoaHoc()
        {
            try 
            {
                daKhoaHoc = h.GetDataAdapter("select KhoaID, MoTa from Khoa");
                daKhoaHoc.Fill(ds, "Khoa");
                cboKhoaHoc.DataSource = ds.Tables["Khoa"];
                cboKhoaHoc.DisplayMember = "MoTa";   
                cboKhoaHoc.ValueMember = "KhoaID";
                cboKhoaHoc.SelectedIndex = 1;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        void loadLop(int idKhoa)
        {
            try 
            {
                if (ds.Tables.Count >1)
                {
                    ds.Tables.RemoveAt(1);
                }
                daLopHoc = h.GetDataAdapter("Select LopID, TenLop from Lop where KhoaID = '"+idKhoa+"'");
                daLopHoc.Fill(ds, "Lop");
                cboLop.DataSource = ds.Tables["Lop"];
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "LopID";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void loadHocSinh(int maLop)
        {
            SqlDataAdapter hsAdapter = h.GetDataAdapter("select *, Ho + ' ' + Ten as N'Họ và tên' from Lop_HocSinh, HocSinh where LopID = '" + maLop + "' and Lop_HocSinh.HocSinhID = HocSinh.HocSinhID");
            hsAdapter.Fill(ds, "LopHocSinh");
            lstHocSinh.DataSource = ds.Tables["LopHocSinh"];
            lstHocSinh.DisplayMember = "Họ và tên";
            lstHocSinh.ValueMember = "HocSinhID";
        }
        

        private void frmDanhSachLop_Load(object sender, EventArgs e)
        {
            
            loadKhoaHoc();
            cboKhoaHoc.SelectedIndex = 1;

        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoaHoc.SelectedIndex == -1  || cboKhoaHoc.SelectedValue == null)
            {
                return;
            }
            if (int.TryParse(cboKhoaHoc.SelectedValue.ToString(), out int maKhoa))
            {
                loadLop(maKhoa);
            }
            else
            {
                //MessageBox.Show("Không thể ép kiểu giá trị SelectedValue thành kiểu int.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        int maLop = -1;
        static bool IsTableExists(DataSet dataSet, string tableName)
        {
            // Kiểm tra xem DataSet có bảng nào không
            if (dataSet.Tables.Count > 0)
            {
                // Duyệt qua danh sách các bảng trong DataSet
                foreach (DataTable table in dataSet.Tables)
                {
                    // So sánh tên bảng
                    if (table.TableName == tableName)
                    {
                        return true; // Bảng tồn tại
                    }
                }
            }
            return false; // Bảng không tồn tại
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoaHoc.SelectedIndex == -1 || cboKhoaHoc.SelectedValue == null)
            {
                return;
            }

            DataRowView rowLop = cboLop.SelectedValue as DataRowView;

            if (int.TryParse(cboLop.SelectedValue.ToString(), out int maLop))
            {
                foreach (DataTable table in ds.Tables)
                {
                    // So sánh tên bảng
                    if (table.TableName == "LopHocSinh")
                    {
                        ds.Tables["LopHocSinh"].Rows.Clear();
                    }
                }
                loadHocSinh(maLop);
            }
            else
            {
                //MessageBox.Show("Không thể ép kiểu giá trị SelectedValue thành kiểu int.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public static int maHSChon = -1;
        private void btnQuanLyHocSinh_Click(object sender, EventArgs e)
        {
            if (int.TryParse(cboLop.SelectedValue.ToString(), out int maLop))
            {
                frmQLHocSinh_DSLop f = new frmQLHocSinh_DSLop();
                f.ShowDialog();
                f.StartPosition = FormStartPosition.CenterScreen;
                h.getNonQuery($"insert into Lop_HocSinh values ('{maLop}', '{maHSChon}', null, null)");

                if (cboKhoaHoc.SelectedIndex == -1 || cboKhoaHoc.SelectedValue == null)
                {
                    return;
                }

                DataRowView rowLop = cboLop.SelectedValue as DataRowView;
                foreach (DataTable table in ds.Tables)
                {
                    // So sánh tên bảng
                    if (table.TableName == "LopHocSinh")
                    {
                        ds.Tables["LopHocSinh"].Rows.Clear();
                    }
                }
                loadHocSinh(maLop);

            }
            else
            {
                MessageBox.Show("Hãy chọn lớp để thêm học sinh");
                return;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void LoadThongTinHocSinh(int hocSinhID)
        {
            // Thực hiện truy vấn để lấy thông tin học sinh từ HocSinhID
            // Sử dụng SQLHelper hoặc một lớp khác trong BLL_DAL để thực hiện truy vấn này
            // Dưới đây là một ví dụ giả sử bạn có một hàm GetHocSinhByID trong SQLHelper

            try
            {
                DataTable dtHocSinh = h.getDatatable("SELECT * FROM HocSinh inner join Lop_HocSinh ON Lop_HocSinh.HocSinhID = HocSinh.HocSinhID where HocSinh.HocSinhID = " + hocSinhID);

                if (dtHocSinh.Rows.Count > 0)
                {
                    // Lấy thông tin từ DataRow
                    string ho = dtHocSinh.Rows[0]["Ho"].ToString();
                    string ten = dtHocSinh.Rows[0]["Ten"].ToString();
                    string diaChi = dtHocSinh.Rows[0]["DiaChi"].ToString();
                    string soDienThoai = dtHocSinh.Rows[0]["SoDienThoai"].ToString();
                    string email = dtHocSinh.Rows[0]["email"].ToString();
                    string diem = dtHocSinh.Rows[0]["Diem"].ToString();
                    string GhiChu = dtHocSinh.Rows[0]["GhiChu"].ToString();

                    // Hiển thị thông tin lên các TextBox
                    txtHo.Text = ho;
                    txtTen.Text = ten;
                    txtDiaChi.Text = diaChi;
                    txtSoDienThoai.Text = soDienThoai;
                    txtEmail.Text = email;
                    txtDiem.Text = diem;
                    txtGhiChu.Text = GhiChu;
                }
                else
                {
                    // Xử lý trường hợp không tìm thấy học sinh
                    MessageBox.Show("Không tìm thấy thông tin học sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int hocSinhID;
        private void lstHocSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHocSinh.SelectedItems.Count > 0)
            {
                if (int.TryParse(lstHocSinh.SelectedValue.ToString(), out int hocSinhID))
                {
                    LoadThongTinHocSinh(hocSinhID);
                    txtDiem.Enabled = false;
                    txtGhiChu.Enabled = false;
                }
                else
                {
                    //MessageBox.Show("Không thể ép kiểu giá trị SelectedValue thành kiểu int.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Lấy giá trị của HocSinhID từ phần tử được chọn
                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtDiem.Enabled = true;
            txtGhiChu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtDiem.Text) >10 || int.Parse(txtDiem.Text) < 0)
            {
                MessageBox.Show("Không hợp lệ!");
                txtDiem.Text = "";
                return;
            }
            string diem = txtDiem.Text;
            string ghiChu = txtGhiChu.Text;
            try
            {
                // Kiểm tra xem đã chọn học sinh nào chưa
                if (hocSinhID >= 0)
                {
                    // Gọi hàm cập nhật thông tin học sinh từ SQLHelper
                    if (int.TryParse(lstHocSinh.SelectedValue.ToString(), out int hocSinhID))
                    {
                        h.getNonQuery($"UPDATE Lop_HocSinh SET Diem = {diem}, GhiChu = N'{ghiChu}' WHERE HocSinhID = {hocSinhID}");  
                    }
                    // Cập nhật thông tin điểm và ghi chú của học sinh trong bảng Lop_HocSinh

                    // Thông báo thành công
                    loadHocSinh(maLop);
                    MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn học sinh để cập nhật thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
