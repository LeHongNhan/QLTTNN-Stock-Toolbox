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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Views
{
    public partial class frmreportKetQuaHocTap : Form
    {
        public frmreportKetQuaHocTap()
        {
            InitializeComponent();
        }

        private void reportKetQuaHocTap_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-IH11UO7O;Initial Catalog=QLTrungTamNgoaiNgu;User ID=sa;Password=123");
            SqlDataAdapter adapter = new SqlDataAdapter($"select TenLop, Ho, Ten,  Diem, GhiChu from Lop_HocSinh inner join Lop On Lop_HocSinh.LopID = Lop.LopID inner join HocSinh On Lop_HocSinh.HocSinhID = HocSinh.HocSinhID where Lop_HocSinh.LopID = '{frmKetQuaHocTap.MaLop}'", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "dsKetQuaHocTap");
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Views.reportKQHT.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables[0];
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
