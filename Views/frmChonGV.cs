using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using System.Data.SqlClient;

namespace Views
{
    public partial class frmChonGV : Form
    {
        public frmChonGV()
        {
            InitializeComponent();
        }
        SQLHelper helper = new SQLHelper();
        DataSet dataSet = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();

        private void GiaoVien_load()
        {
            dataSet.Tables.Clear();
            adapter = helper.GetDataAdapter("select GiaoVienID as N'Mã giáo viên', Mota as N'Mô tả',Ho as N'Họ', Ten as N'Tên',email as N'Email', SoDienThoai as N'Số điện thoại' from GiaoVien");
            adapter.Fill(dataSet, "GiaoVien");
            cboMoTa.DataSource = dataSet.Tables["GiaoVien"];
            cboMoTa.DisplayMember = "Mô tả";
            cboMoTa.ValueMember = "Mã giáo viên";
        }

        private void load_GiaoVien_dgv()
        {
            dataSet.Tables.Clear();
            adapter = helper.GetDataAdapter("select GiaoVienID as N'Mã giáo viên', Mota as N'Mô tả',Ho as N'Họ', Ten as N'Tên',email as N'Email', SoDienThoai as N'Số điện thoại' from GiaoVien");
            adapter.Fill(dataSet, "GiaoVien");
            dgvDSGV.DataSource = dataSet.Tables["GiaoVien"];
        }
        private void frmChonGV_Load(object sender, EventArgs e)
        {
            load_GiaoVien_dgv();
        }

        private void cboMoTa_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboMoTa_SelectedValueChanged(object sender, EventArgs e)
        {
            load_GiaoVien_dgv();
        }
    }
}
