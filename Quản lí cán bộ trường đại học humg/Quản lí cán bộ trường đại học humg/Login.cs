using Quản_lí_cán_bộ_trường_đại_học_humg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lí_cán_bộ_trường_đại_học_mỏ_địa_chất_hà_nội
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Load += Login_Load;

            cbMk.CheckedChanged += cbMk_CheckedChanged;
        }
        private bool ValidateLogin(string account, string password)
        {

            return (account == "correctUsername" && password == "correctPassword");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            string taiKhoan = tbTk.Text;
            string matKhau = tbMk.Text;

            if (string.IsNullOrWhiteSpace(taiKhoan) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập cả tài khoản và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (taiKhoan == "Admin" && matKhau == "admin123")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TrangChu trangChu = new TrangChu();
                trangChu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {

            tbMk.UseSystemPasswordChar = true;
        }
        private void cbMk_CheckedChanged(object sender, EventArgs e)
        {
            tbMk.UseSystemPasswordChar = !cbMk.Checked;
        }

        private void tbTk_TextChanged(object sender, EventArgs e)
        {
            string accountInputValue = tbTk.Text;

            if (string.IsNullOrWhiteSpace(accountInputValue))
            {
                errorTaiKhoan.SetError(tbTk, "Tài khoản không được để khoảng trắng");

            }
            if (char.IsDigit(accountInputValue[0]))
            {
                errorTaiKhoan.SetError(tbTk, "Tài khoản không được số đứng đầu.");
            }


        }

       
    }
}
