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
    public partial class FormDangNhap : Form
    {
        FormMain formMain = new FormMain();

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //formMain.Enabled = true;
            //this.Hide();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            //formMain.Show();
            //formMain.Enabled = false;
        }
    }
}
