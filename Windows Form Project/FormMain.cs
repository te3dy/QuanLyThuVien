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
    public partial class FormMain : Form
    {
        #region Form Setting

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tabMenu.SelectedTab = null;
            this.reportThongKe6.RefreshReport();
        }
        #endregion

        #region Tab Setting

        private void tabMenu_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabMenu.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabMenu.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(Brushes.LightBlue, e.Bounds);
            }
            else
            {
                _textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", (float)10.0, FontStyle.Regular);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Far;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, _stringFlags);

            // Draw image
            int y = -90;
            for (int i = 0; i < 4; i++)
            {
                g.DrawImage(tabIconList.Images[i], new Rectangle(12, y += 100, 80, 80));
            }
        }

        #endregion

        #region Menu Setting

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau formDoiMatKhau = new FormDoiMatKhau();
            formDoiMatKhau.Show();
        }

        #endregion

        #region Tab 0: Danh Mục

        #region Tab 1: Tài Liệu
        #endregion

        #region Tab 2: Độc Giả
        #endregion

        #region Tab 3: Thể Loại
        #endregion

        #region Tab 4: Nhân Viên
        #endregion

        #endregion

        #region Tab 5: Mượn Trả
        #endregion

        #region Tab 6: Thống Kê
        #endregion

        #region Tab 7: Tìm Kiếm

        #region Tab 8: Tài Liệu
        #endregion

        #region Tab 9: Phiếu Mượn
        #endregion

        #endregion

    }
}
