using BLL_DAL;
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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static DangNhap dn = new DangNhap();

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (dn.checkDangNhap(txtTaiKhoan.Text, txtMatKhau.Text))
                {
                    MessageBox.Show("Đăng nhập thành công");
                    this.Hide();
                    frmMain f = new frmMain();
                    f.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại thông tin đăng nhập", "Có lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
            
        }
    }
}
