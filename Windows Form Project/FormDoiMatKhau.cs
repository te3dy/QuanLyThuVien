using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Form_Project
{
    public partial class FormDoiMatKhau : Form
    {
        DangNhapBO dangNhapBO = new DangNhapBO();
        string taiKhoan;
        string matKhau;

        public FormDoiMatKhau(string taiKhoan, string matKhau)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dangNhapBO.ThongTinDangNhap(taiKhoan, matKhau);
            try
            {
                if (txtMatKhauCu.Text.Equals(matKhau))
                {
                    if(txtMatKhauMoi.Text.Equals(txtNhapLaiMatKhau.Text))
                    {
                        if (!txtMatKhauMoi.Text.Equals(txtMatKhauCu.Text))
                        {
                            dangNhapBO.DoiMatKhau(taiKhoan, txtMatKhauMoi.Text);
                            MessageBox.Show("Đổi mật khẩu thành công", "Thông Báo");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu mới không được trùng mật khẩu cũ", "Thông Báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu nhập lại không đúng", "Thông Báo");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác", "Thông Báo");
                }
            }
            catch
            {
                MessageBox.Show("Đổi mật khẩu không thành công", "Thông Báo");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
