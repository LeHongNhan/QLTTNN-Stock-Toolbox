using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class frmKetQuaHocTap : Form
    {
        public frmKetQuaHocTap()
        {
            InitializeComponent();
        }
        public static string MaLop;
        SQLHelper helper = new SQLHelper();
        void loadCboLop()
        {
            string sql = "select * from Lop";
            DataTable dtLop = new DataTable();
            dtLop = helper.getDatatable(sql);
            cboLop.DataSource = dtLop;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "LopID";
        }

        private void loadDataGridView(object ma)
        {
            string strMa = ma.ToString();
            DataTable data = helper.getDatatable($"select Ho + ' ' + Ten as N'Họ và tên',  Diem, GhiChu from Lop_HocSinh inner join Lop On Lop_HocSinh.LopID = Lop.LopID inner join HocSinh On Lop_HocSinh.HocSinhID = HocSinh.HocSinhID where Lop_HocSinh.LopID = {ma}");
            //dataGridView1.DataSource = data;
            DataView dataView = new DataView(data);

            dgvThongTin.DataSource = dataView;

        }
        private void frmKetQuaHocTap_Load(object sender, EventArgs e)
        {
            loadCboLop();
        }
        
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex == -1)
            {
                return;
            }
            object maLop = ((DataRowView)cboLop.SelectedItem)["LopID"];
            MaLop = maLop.ToString();
            loadDataGridView(maLop);
        }

        private void btnInBangDiem_Click(object sender, EventArgs e)
        {
            frmreportKetQuaHocTap f = new frmreportKetQuaHocTap();
            f.ShowDialog();
        }
    }
}
