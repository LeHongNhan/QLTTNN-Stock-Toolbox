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
    public partial class frmLop : Form
    {
        public frmLop()
        {
            InitializeComponent();
        }

        SQLHelper helper = new SQLHelper();
        DataSet dataSet = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable data;
        private void Lop_load()
        {
            SQLHelper hp = new SQLHelper();
             data = hp.getDatatable("SELECT Lop.LopID as N'Mã lớp', TenLop as N'Tên lớp', NgayBatDau as N'Ngày bắt đầu', NgayKetThuc as N'Ngày kết thúc', HocPhi as N'Học phí', gv.Ho + ' ' + gv.Ten as N'Tên giáo viên', Khoa.MoTa as N'Khóa' FROM Lop INNER JOIN GiaoVien gv ON Lop.GiaoVienID = gv.GiaoVienID INNER JOIN Khoa ON Lop.KhoaID = Khoa.KhoaID");
            DataView dataView = new DataView(data);
            dgvDanhSachLop.DataSource = dataView;
            DataColumn[] key = new DataColumn[1];
            key[0] = data.Columns["Mã lớp"];
            data.PrimaryKey = key;
        }
        private void frmLop_Load(object sender, EventArgs e)
        {
            dgvDanhSachLop.AllowUserToAddRows = false;
            Lop_load();
            giaoVien_load();
            khoa_load();
            load_ma_lop();
            //biding();
        }
        private void load_ma_lop()
        {
            string sql = "select max (LopID) from LOP";
            int kq = (int)helper.getScalar(sql);
            kq++;
            txtMaLop.Text = kq.ToString();
        }    
        private void giaoVien_load()
        {
            SQLHelper hp = new SQLHelper();
            DataTable GiaoVien_Tabble = new DataTable();
           string sql = ("select GiaoVienID, ho + ' ' + ten as tengv from GiaoVien");
            GiaoVien_Tabble = hp.getDatatable(sql);
            cboGiangVien.DataSource = GiaoVien_Tabble;
            cboGiangVien.DisplayMember = "tengv";
            cboGiangVien.ValueMember = "GiaoVienID";
        }


        private void khoa_load()
        {
            SQLHelper hp = new SQLHelper();
            DataTable GiaoVien_Tabble = new DataTable();
            string sql = ("select KhoaID, MoTa from Khoa");
            GiaoVien_Tabble = hp.getDatatable(sql);
            cboKhoa.DataSource = GiaoVien_Tabble;
            cboKhoa.DisplayMember = "MoTa";
            cboKhoa.ValueMember = "KhoaID";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(dtpNgayKetThuc.Text) < DateTime.Parse(dtpNgayBatDau.Text))
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!float.TryParse(txtHocPhi.Text, out float hocPhi))
            {
                MessageBox.Show("Học phí không điền đúng định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SQLHelper hp = new SQLHelper();
            adapter = hp.GetDataAdapter("select LopID as N'Mã lớp', TenLop as N'Tên lớp', NgayBatDau as N'Ngày bắt đầu', NgayKetThuc as N'Ngày kết thúc', HocPhi as N'Học phí', GiaoVienID as N'Mã giáo viên', KhoaID as N'Khóa' from LOP");
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataRow row = table.NewRow();
            row["Mã Lớp"] = txtMaLop.Text;
            row["Tên lớp"] = txtTenLop.Text;
            row["Ngày bắt đầu"] = dtpNgayBatDau.Text;
            row["Ngày kết thúc"] = dtpNgayKetThuc.Text;
            row["Học phí"] = txtHocPhi.Text;
            row["Mã giáo viên"] = cboGiangVien.SelectedValue.ToString();
            row["khóa"] = cboKhoa.SelectedValue.ToString();
            table.Rows.Add(row); 
            SqlCommandBuilder cmb = new SqlCommandBuilder(adapter);
            adapter.Update(table);
            MessageBox.Show("Thêm thành công", "Thông báo");
            Lop_load();
        }

        private void btnChonGV_Click(object sender, EventArgs e)
        {
            frmChonGV chonGV = new frmChonGV();
            chonGV.Show();
        }
       

        int vt;
        private void dgvDanhSachLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }
            vt = e.RowIndex;
            DataRow row = data.Rows[vt];
            txtMaLop.Text = row["Mã lớp"].ToString();
            txtTenLop.Text = row["Tên lớp"].ToString();
            txtHocPhi.Text = row["Học phí"].ToString();
            cboGiangVien.Text = row["Tên giáo viên"].ToString();
            dtpNgayBatDau.Text = row["Ngày bắt đầu"].ToString();
            dtpNgayKetThuc.Text = row["Ngày kết thúc"].ToString();
            cboKhoa.Text = row["Khóa"].ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SQLHelper hp = new SQLHelper();
            adapter = hp.GetDataAdapter("select LopID as N'Mã lớp', TenLop as N'Tên lớp', NgayBatDau as N'Ngày bắt đầu', NgayKetThuc as N'Ngày kết thúc', HocPhi as N'Học phí', GiaoVienID as N'Mã giáo viên', KhoaID as N'Khóa' from LOP");
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataColumn[] key = new DataColumn[1];
            key[0] = table.Columns["Mã lớp"];
            table.PrimaryKey = key;
            DataRow row = table.Rows.Find(txtMaLop.Text);
            if (row != null)
            {
                row["Tên lớp"] = txtTenLop.Text;
                row["Ngày bắt đầu"] = dtpNgayBatDau.Text;
                row["Ngày kết thúc"] = dtpNgayKetThuc.Text;
                row["Học phí"] = txtHocPhi.Text;
                row["Mã giáo viên"] = cboGiangVien.SelectedValue.ToString();
                row["khóa"] = cboKhoa.SelectedValue.ToString();
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(adapter);
            adapter.Update(table);
            Lop_load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SQLHelper hp = new SQLHelper();
            adapter = hp.GetDataAdapter("select LopID as N'Mã lớp', TenLop as N'Tên lớp', NgayBatDau as N'Ngày bắt đầu', NgayKetThuc as N'Ngày kết thúc', HocPhi as N'Học phí', GiaoVienID as N'Mã giáo viên', KhoaID as N'Khóa' from LOP");
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataColumn[] key = new DataColumn[1];
            key[0] = table.Columns["Mã lớp"];
            table.PrimaryKey = key;
            DataRow row = table.Rows.Find(txtMaLop.Text);
            if (row != null)
                row.Delete();
            SqlCommandBuilder cmb = new SqlCommandBuilder(adapter);
            adapter.Update(table);
            Lop_load();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachLop_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void dgvDanhSachLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
