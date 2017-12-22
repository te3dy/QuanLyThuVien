using BLL;
using GUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows_Form_Project.Properties;

namespace Windows_Form_Project
{
    public partial class FormDangNhap : Form
    {
        FormMain formMain;
        DangNhapBO dangNhapBO = new DangNhapBO();

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            // Hiện tài khoản mật khẩu đã lưu
            txtTaiKhoan.Text = Settings.Default.User;
            txtMatKhau.Text = Settings.Default.Password;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (dangNhapBO.XacNhanDangNhap(txtTaiKhoan.Text, txtMatKhau.Text))
                {
                    // Ẩn form đăng nhập
                    this.Hide();

                    // Lưu tài khoản và mật khẩu
                    if (cbDangNhap.Checked == true)
                    {
                        Settings.Default.User = txtTaiKhoan.Text;
                        Settings.Default.Password = txtMatKhau.Text;
                        Settings.Default.Save();
                    }
                    else
                    {
                        Settings.Default.User = "";
                        Settings.Default.Password = "";
                        Settings.Default.Save();
                    }

                    // Phân quyền
                    if (dangNhapBO.Quyen(txtTaiKhoan.Text, txtMatKhau.Text).Equals("User"))
                    {
                        formMain = new FormMain(this, txtTaiKhoan.Text, txtMatKhau.Text);
                        formMain.QuyenUser();
                    }
                    if (dangNhapBO.Quyen(txtTaiKhoan.Text, txtMatKhau.Text).Equals("Admin"))
                    {
                        formMain = new FormMain(this, txtTaiKhoan.Text, txtMatKhau.Text);
                    }
                    formMain.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông Báo");
                }
            }
            catch
            {
                MessageBox.Show("Không thể đăng nhập", "Thông Báo");
            }
        }

        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }
    }
}
