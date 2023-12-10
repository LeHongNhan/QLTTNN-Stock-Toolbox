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
    public partial class frmDoTuoi : Form
    {
        SQLHelper helper = new SQLHelper();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public frmDoTuoi()
        {
            InitializeComponent();
        }

        void loadThongTin()
        {
            ds.Tables.Clear();
            adapter = helper.GetDataAdapter("Select DoTuoiID as N'Mã độ tuổi', TenDoTuoi as N'Tên độ tuổi' from DoTuoi");
            adapter.Fill(ds, "DoTuoi");
            dgvDS.DataSource = ds.Tables["DoTuoi"];
        }

        private void frmDoTuoi_Load(object sender, EventArgs e)
        {
            loadThongTin();
        }

        int vt;

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["DoTuoi"].NewRow();
            row["Tên độ tuổi"] = txtTenDoTuoi.Text;

            ds.Tables["DoTuoi"].Rows.Add(row);
            SqlCommandBuilder b = new SqlCommandBuilder(adapter);
            adapter.Update(ds.Tables["DoTuoi"]);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["DoTuoi"].Rows[vt];
            row.BeginEdit();
            row["Tên độ tuổi"] = txtTenDoTuoi.Text;
            row.EndEdit();
            int kq = adapter.Update(ds.Tables["DoTuoi"]);
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
            DataRow row = ds.Tables["DoTuoi"].Rows[vt];
            ds.Tables["DoTuoi"].Rows.Remove(row);
            SqlCommandBuilder b = new SqlCommandBuilder(adapter);
            adapter.Update(ds.Tables["DoTuoi"]);
            int kq = adapter.Update(ds.Tables["DoTuoi"]);
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

        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static int indexDoTuoi = -1;
        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị từ cột "tenCapDo" của dòng được chọn
                object cellValue = dgvDS.Rows[e.RowIndex].Cells["Tên độ tuổi"].Value;
                indexDoTuoi = e.RowIndex;
                vt = e.RowIndex;
                // Kiểm tra nếu giá trị không phải là null
                if (cellValue != null)
                {
                    // Gán giá trị từ cell vào TextBox
                    txtTenDoTuoi.Text = cellValue.ToString();
                }
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (indexDoTuoi == -1)
            {
                return;
            }
            object cellValue = dgvDS.Rows[indexDoTuoi].Cells["Mã độ tuổi"].Value;
            frmKhoaHoc.maDoTuoi = int.Parse(cellValue.ToString());
            Close();
        }
    }
}
