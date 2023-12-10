using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.Diagnostics;

namespace Views
{
    public partial class frmReportHoaDon : Form
    {
        public frmReportHoaDon()
        {
            InitializeComponent();
        }

        private void frmReportHoaDon_Load(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-IH11UO7O;Initial Catalog=QLTrungTamNgoaiNgu;User ID=sa;Password=123");
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT ChiTietHoaDon.HoaDonID, TenLop, TenSach, SoLuong, TongTien, Ho + ' ' + Ten AS TenHocSinh FROM ChiTietHoaDon INNER JOIN Lop ON ChiTietHoaDon.LopID = Lop.LopID INNER JOIN Sach ON ChiTietHoaDon.SachID = Sach.SachID INNER JOIN HoaDon ON ChiTietHoaDon.HoaDonID = HoaDon.HoaDonID INNER JOIN HocSinh ON HoaDon.HocSinhID = HocSinh.HocSinhID Where ChiTietHoaDon.HoaDonID = '{frmHoaDon.maHoaDon}'", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ChiTietHoaDon");
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Views.ReportHoaDon.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables[0];
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
