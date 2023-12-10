using Microsoft.Reporting.WinForms;
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
    public partial class frmReportThoiKhoaBieu : Form
    {
        public frmReportThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void frmReportThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-IH11UO7O;Initial Catalog=QLTrungTamNgoaiNgu;User ID=sa;Password=123");
            SqlDataAdapter adapter = new SqlDataAdapter($"select TenLop , TenThu , CONVERT(varchar(8), GioBatDau, 108) + ' -> ' + CONVERT(varchar(8), GioKetThuc, 108) AS N'GioHoc'  from ThoiKhoaBieu inner join Lop on ThoiKhoaBieu.LopID = Lop.LopID inner join Thu on ThoiKhoaBieu.ThuID = Thu.ThuID inner join ThoiGian On ThoiKhoaBieu.ThoiGianID = ThoiGian.ThoiGianID", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ThoiKhoaBieu");
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Views.reportThoiKhoaBieu.rdlc";
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
