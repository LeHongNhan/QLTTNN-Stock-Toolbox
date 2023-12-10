using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class frmHoaDon : Form
    {
        public static string maHoaDon;
        SQLHelper helper = new SQLHelper();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public static int maHSChon  = -1;
        public frmHoaDon()
        {
            InitializeComponent();
        }
        string layTenHocVien( int maHSChon)
        {
            helper.open();
            string tenDoTuoi = "";
            SqlDataReader r = helper.getDataReader($"select Ho + ' ' + Ten from HocSinh Where HocSinhID = {maHSChon}");
            while (r.Read())
            {
                tenDoTuoi = r.GetString(0);
            }
            helper.close();
            return tenDoTuoi;
        }
        private void btnChonHocVien_Click(object sender, EventArgs e)
        {
            frmHoaDon_HocVien f = new frmHoaDon_HocVien();
            f.ShowDialog();
            if (maHSChon != -1)
            {
                btnChonHocVien.Text = layTenHocVien(maHSChon);
            }
        }

        void load_cboHoaDon()
        {
            string sql = "select * from HoaDon";
            DataTable dt_HD = new DataTable();
            dt_HD = helper.getDatatable(sql);
            cboHoaDon.DataSource = dt_HD;
            cboHoaDon.DisplayMember = "HoaDonID";
            cboHoaDon.ValueMember = "HoaDonID";

            dtpNgayThanhToan.DataBindings.Clear();
            dtpNgayThanhToan.DataBindings.Add("Text", cboHoaDon.DataSource, "NgayThanHToan");
        }

        void load_cboSach()
        {
            string sql = "select * from Sach";
            DataTable dt_Sach = new DataTable();
            dt_Sach = helper.getDatatable(sql);
            cboSach.DataSource = dt_Sach;
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "SachID";
        }
        void load_cboLop()
        {
            string sql = "select * from Lop";
            DataTable dt_Lop = new DataTable();
            dt_Lop = helper.getDatatable(sql);
            cboLop.DataSource = dt_Lop;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "LopID";
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            load_cboHoaDon();
            load_cboSach();
            load_cboLop();
        }
        

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (maHSChon == -1) { MessageBox.Show("Hãy chọn học sinh"); return; }
            DateTime homNay = DateTime.Today;
            String strDate = homNay.ToString("dd") + homNay.ToString("MM") + homNay.ToString("yyyy");
            int dg = 0;
            String strNgay = homNay.ToString("yyyy-MM-dd");
            string sql = "select count(HoaDonID) from HoaDon where NgayThanhToan= '" + strNgay + "'";
            int stt = (int)helper.getScalar(sql);
            stt++;
            String strStt = stt.ToString("000");
            String maHD = "HD" + strDate + strStt;

            String maHS = maHSChon.ToString();

            sql = "insert into HoaDon values('" + maHD + "','" + strNgay + "','" + maHSChon + "')";
            helper.getNonQuery(sql);
            MessageBox.Show("Tạo hóa đơn thành công");
            txtMaHoaDon.Text = maHD;
            load_cboHoaDon();

        }
        private void loadDataGridView(String ma)
        {
            DataTable data = helper.getDatatable("Select ChiTietHoaDon.HoaDonID as N'Mã hóa đơn', TenLop as N'Tên lớp', TenSach as N'Tên sách', SoLuong as N'Số lượng', TongTien as 'Tổng tiền' from ChiTietHoaDon inner join Sach ON ChiTietHoaDon.SachID = Sach.SachID inner join Lop on ChiTietHoaDon.LopID = lop.LopID");
            //dataGridView1.DataSource = data;
            DataView dataView = new DataView(data);
            dataView.RowFilter = "[Mã hóa đơn] = '" + ma + "'";
            dgvChiTietHoaDon.DataSource = dataView;

        }

        private void btnThemThongTin_Click(object sender, EventArgs e)
        {
            String maHD = cboHoaDon.SelectedValue.ToString();
            String maSach = cboSach.SelectedValue.ToString();
            String maLop = cboLop.SelectedValue.ToString();
            int sl;
            if (txtSoLuong.Text == "")
            {
                sl = 0;
            }
            else
            {
                sl = int.Parse(txtSoLuong.Text);
            }
            int dg = int.Parse(txtDonGia.Text);
            int hocPhi = int.Parse(txtHocPhi.Text);
            if (chkDongTien.Checked == false)
            {
                hocPhi = 0;
            }
            int tt = dg * sl + hocPhi;
            String checkDong = "SELECT COUNT(*) FROM ChiTietHoaDon WHERE HoaDonID = '" + maHD + "'";
            int soDong = (int) helper.getScalar(checkDong);
            if (soDong > 0)
            {
                // Nếu đã có dòng thì thực hiện UPDATE
                String updateQuery = "UPDATE ChiTietHoaDon SET lopID = '" + maLop + "', SachID = " + maSach + ", SoLuong = " + sl + ", TongTien = " + tt + " WHERE HoaDonID = '" + maHD + "'";
                helper.getNonQuery(updateQuery);
                MessageBox.Show("Đã cập nhật thông tin");
                loadDataGridView(maHD);
                return;
            }
            String sql = "insert into ChiTietHoaDon values ('" + maHD + "','" + maLop + "'," + maSach + "," + sl + ", " + tt + ")";
            helper.getNonQuery(sql);
            //cap nhat lai thanh tien cho hoa don
            MessageBox.Show("Đã thêm chi tiết");
            loadDataGridView(maHD);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cboHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboHoaDon.SelectedIndex == -1)
            {
                return;
            }
            String maHD = cboHoaDon.SelectedValue.ToString();
            loadDataGridView(maHD);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSach.SelectedIndex == -1)
            {
                return;
            }

            // Lấy giá trị của cột "Gia" từ dòng được chọn trong ComboBox
            object giaObj = ((DataRowView)cboSach.SelectedItem)["Gia"];

            // Kiểm tra xem giá trị có tồn tại không
            if (giaObj != DBNull.Value)
            {
                int gia = Convert.ToInt32(giaObj);

                // Gán giá trị vào TextBox
                txtDonGia.Text = gia.ToString();
            }
            else
            {
                // Xử lý khi giá trị không tồn tại
                // (Có thể đặt giá trị mặc định hoặc làm gì đó khác)
                txtDonGia.Text = "";
            }
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex == -1)
            {
                return;
            }

            // Lấy giá trị của cột "HocPhi" từ dòng được chọn trong ComboBox
            object hocPhiObj = ((DataRowView)cboLop.SelectedItem)["HocPhi"];

            // Kiểm tra xem giá trị có tồn tại không
            if (hocPhiObj != DBNull.Value)
            {
                int hocPhi = Convert.ToInt32(hocPhiObj);

                // Gán giá trị vào TextBox
                txtHocPhi.Text = hocPhi.ToString();
            }
            else
            {
                // Xử lý khi giá trị không tồn tại
                // (Có thể đặt giá trị mặc định hoặc làm gì đó khác)
                txtHocPhi.Text = "";
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            maHoaDon = cboHoaDon.SelectedValue.ToString();
            frmReportHoaDon f = new frmReportHoaDon();
            f.ShowDialog();
        }
    }
}
