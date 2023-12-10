using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class frmXepLichHoc : Form
    {
        public frmXepLichHoc()
        {
            InitializeComponent();
        }
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

        void loadCboThoiGian()
        {
            string sql = "SELECT ThoiGianID, CONVERT(varchar(8), GioBatDau, 108) + ' -> ' + CONVERT(varchar(8), GioKetThuc, 108) AS 'Gio' FROM ThoiGian;";
            DataTable dtThoiGian = new DataTable();
            dtThoiGian = helper.getDatatable(sql);
            cboThoiGian.DataSource = dtThoiGian;
            cboThoiGian.DisplayMember = "Gio";
            cboThoiGian.ValueMember = "ThoiGianID";
        }

        void loadCboThu()
        {
            string sql = "SELECT * from Thu";
            DataTable dtThu = new DataTable();
            dtThu = helper.getDatatable(sql);
            cboThu.DataSource = dtThu;
            cboThu.DisplayMember = "TenThu";
            cboThu.ValueMember = "ThuID";
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex == -1)
            {
                return;
            }
            //maLop = ((DataRowView)cboLop.SelectedItem)["LopID"];
            
        }
        void loadDataGridView()
        {
            DataTable data = helper.getDatatable("select TenLop as N'Lớp', TenThu as N'Thứ', CONVERT(varchar(8), GioBatDau, 108) + ' -> ' + CONVERT(varchar(8), GioKetThuc, 108) AS N'Giờ học'  from ThoiKhoaBieu inner join Lop on ThoiKhoaBieu.LopID = Lop.LopID inner join Thu on ThoiKhoaBieu.ThuID = Thu.ThuID inner join ThoiGian On ThoiKhoaBieu.ThoiGianID = ThoiGian.ThoiGianID");
            DataView dataView = new DataView(data);            
            dgvTKB.DataSource = dataView;
        }
        private void frmXepLichHoc_Load(object sender, EventArgs e)
        {
            loadCboLop();
            loadCboThoiGian();
            loadCboThu();
            loadDataGridView();
        }

        private void cboThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXeplich_Click(object sender, EventArgs e)
        {
            try
            {
                object maLop = ((DataRowView)cboLop.SelectedItem)["LopID"];
                object maThoiGian = ((DataRowView)cboThoiGian.SelectedItem)["ThoiGianID"];
                object maThu = ((DataRowView)cboThu.SelectedItem)["ThuID"];
                String sql = $"insert into ThoiKhoaBieu values ({maLop},{maThoiGian},{maThu})";
                helper.getNonQuery(sql);
                loadDataGridView();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lịch đã có");
            }
        }

        private void btnSuaLich_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaLich_Click(object sender, EventArgs e)
        {
            object maLop = ((DataRowView)cboLop.SelectedItem)["LopID"];
            object maThoiGian = ((DataRowView)cboThoiGian.SelectedItem)["ThoiGianID"];
            object maThu = ((DataRowView)cboThu.SelectedItem)["ThuID"];
            try
            {

                string deleteString = $"delete from ThoiKhoaBieu where LopID = {maLop} and ThoiGianID = {maThoiGian} and ThuID = {maThu} ";
                if (helper.getNonQuery(deleteString) == 0)
                {
                    MessageBox.Show("Chưa xóa được");
                    return;
                }
                
                MessageBox.Show("Đã xóa thành công");
                loadDataGridView();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        int vt;
        private void dgvTKB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            vt = e.RowIndex;
            
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            frmReportThoiKhoaBieu f = new frmReportThoiKhoaBieu();
            f.ShowDialog();
        }
    }
}
