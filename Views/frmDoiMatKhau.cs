using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (frmDangNhap.dn.doiMatKhau(txtMatKhauCu.Text, txtMatKhauMoi.Text, txtNhapLai.Text))
            {
                MessageBox.Show("Đã đổi mật khẩu");
            }
            else
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
        }
    }
}
