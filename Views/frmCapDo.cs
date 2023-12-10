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
    public partial class frmCapDo : Form
    {
        SQLHelper helper = new SQLHelper();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public frmCapDo()
        {
            InitializeComponent();
        }

        void loadThongTin()
        {
            ds.Tables.Clear();
            adapter = helper.GetDataAdapter("Select CapDoID as N'Mã cấp độ', TenCapDo as N'Tên cấp độ' from CapDo");
            adapter.Fill(ds, "CapDo");
            dgvDS.DataSource = ds.Tables["CapDo"];
        }

        private void frmCapDo_Load(object sender, EventArgs e)
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
            //DataRow row = ds.Tables["CapDo"].Rows[vt];

            //txtTenCapDo.Text = row["Tên cấp độ"].ToString();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["CapDo"].NewRow();
            row["Tên cấp độ"] = txtTenCapDo.Text;
            
            ds.Tables["CapDo"].Rows.Add(row);
            SqlCommandBuilder b = new SqlCommandBuilder(adapter);
            adapter.Update(ds.Tables["CapDo"]);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["CapDo"].Rows[vt];
            row.BeginEdit();
            row["Tên cấp độ"] = txtTenCapDo.Text;
            row.EndEdit();
            int kq = adapter.Update(ds.Tables["CapDo"]);
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
            DataRow row = ds.Tables["CapDo"].Rows[vt];
            ds.Tables["CapDo"].Rows.Remove(row);
            SqlCommandBuilder b = new SqlCommandBuilder(adapter);

            int kq = adapter.Update(ds.Tables["CapDo"]);
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
        int indexCapDo = -1;
        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị từ cột "tenCapDo" của dòng được chọn
                object cellValue = dgvDS.Rows[e.RowIndex].Cells["Tên cấp độ"].Value;
                indexCapDo = e.RowIndex;
                // Kiểm tra nếu giá trị không phải là null
                if (cellValue != null)
                {
                    // Gán giá trị từ cell vào TextBox
                    txtTenCapDo.Text = cellValue.ToString();
                }
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (indexCapDo == -1)
            {
                return;
            }
            object cellValue = dgvDS.Rows[indexCapDo].Cells["Mã cấp độ"].Value;
            frmKhoaHoc.maCapDo = int.Parse(cellValue.ToString());
            Close();
        }
    }
}
