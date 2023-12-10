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
    public partial class frmKhoaHoc : Form
    {
        public static int maDoTuoi = -1;
        public static int maCapDo = -1;
        SQLHelper helper = new SQLHelper();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        void loadThongTin()
        {
            ds.Tables.Clear();
            adapter = helper.GetDataAdapter("select KhoaID as N'Mã khoa', MoTa as N'Mô tả khoa', TenCapDo as N'Cấp độ', TenDoTuoi as 'Độ tuổi' from khoa inner join CapDo ON khoa.CapDoID = CapDo.CapDoID inner join DoTuoi ON Khoa.DoTuoiID = DoTuoi.DoTuoiID;");
            adapter.Fill(ds, "Khoa");
            dgvThongTin.DataSource = ds.Tables["Khoa"];
        }
        string  layTenDoTuoi(int madoTuoi)
        {
            helper.open();
            string tenDoTuoi = "";
            SqlDataReader r = helper.getDataReader($"select TenDoTuoi from DoTuoi Where DoTuoiID = {maDoTuoi}");
            while (r.Read())
            {
                tenDoTuoi = r.GetString(0);
            }
            helper.close();
            return tenDoTuoi;
        }
        string layTenCapDo (int maCapDo)
        {
            helper.open();
            string tenCapDo = "";
            SqlDataReader r = helper.getDataReader($"select TenCapDo from CapDo Where CapDoID = {maCapDo}");
            while (r.Read())
            {
                tenCapDo = r.GetString(0);
            }
            helper.close();
            return tenCapDo;
        }
        public frmKhoaHoc()
        {
            InitializeComponent();
        }

        private void btnDoTuoi_Click(object sender, EventArgs e)
        {
            frmDoTuoi f = new frmDoTuoi();
            f.ShowDialog();
            if (maDoTuoi != -1)
            {
                btnDoTuoi.Text = layTenDoTuoi(maDoTuoi);
            }
        }

        private void btnCapDo_Click(object sender, EventArgs e)
        {
            frmCapDo f = new frmCapDo();

            f.ShowDialog();
            if (maCapDo != -1)
            {
                btnCapDo.Text = layTenCapDo(maCapDo);
            }
        }
        private void frmKhoaHoc_Load(object sender, EventArgs e)
        {
            loadThongTin();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenKhoa.Text == "")
            {
                MessageBox.Show("Kiểm tra tên khoa");
            }
            if (maDoTuoi == -1 || maCapDo == -1)
            {
                MessageBox.Show("Kiểm tra độ tuổi, cấp độ");
                return;
            }
            helper.getNonQuery($"insert into Khoa(MoTa, CapDoID, DoTuoiID) values(N'{txtTenKhoa.Text}','{maCapDo}','{maDoTuoi}')");
            loadThongTin();
        }
        int indexKhoa = -1;
        int maKhoa = -1;
        private void dgvThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị từ cột "tenCapDo" của dòng được chọn
                object cellValue = dgvThongTin.Rows[e.RowIndex].Cells["Mô tả khoa"].Value;
                indexKhoa = e.RowIndex;
                // Kiểm tra nếu giá trị không phải là null
                maKhoa = (int) dgvThongTin.Rows[e.RowIndex].Cells["Mã khoa"].Value;
                if (cellValue != null)
                {
                    // Gán giá trị từ cell vào TextBox
                    txtTenKhoa.Text = cellValue.ToString();
                }
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (indexKhoa == -1 || maKhoa == -1)
            {
                MessageBox.Show("Chưa chọn khóa");
                return;
            }
            helper.getNonQuery($" update Khoa set MoTa = N'{txtTenKhoa.Text}', CapDoID = {maCapDo} , DoTuoiID = {maDoTuoi} where khoaID = {maKhoa}");
            loadThongTin();
        }

        private void dgvThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
