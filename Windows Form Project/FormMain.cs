using BLL;
using DTO;
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

namespace Windows_Form_Project
{
    public partial class FormMain : Form
    {
        Form formDangNhap;
        NhanVienBO nhanVienBO = new NhanVienBO();
        DocGiaBO docGiaBO = new DocGiaBO();
        string taiKhoan;
        string matKhau;

        #region Form Setting

        public FormMain(Form opener, string taiKhoan, string matKhau)
        {
            InitializeComponent();
            formDangNhap = opener;
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tabMenu.SelectedTab = null;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            formDangNhap.Close();
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
            FormDoiMatKhau formDoiMatKhau = new FormDoiMatKhau(taiKhoan, matKhau);
            formDoiMatKhau.Show();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có thực sự muốn đăng xuất", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                formDangNhap.Show();
            }
        }

        private void tàiLiệuMượnQuáHạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabMenu.SelectedTab = tabThongKe6;
            subTabThongKe6.SelectedTab = tabTaiLieuMuonQuaHan6;
        }

        private void tàiLiệuHiệnChoMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabMenu.SelectedTab = tabThongKe6;
            subTabThongKe6.SelectedTab = tabTaiLieuDangMuon6;
        }

        private void top10TàiLiệuMượnNhiềuNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabMenu.SelectedTab = tabThongKe6;
            subTabThongKe6.SelectedTab = tabTaiLieuMuonNhieuNhat6;
        }

        private void sốLầnMượnTheoThểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabMenu.SelectedTab = tabThongKe6;
            subTabThongKe6.SelectedTab = tabMuonTheoTheLoai6;
        }
        #endregion

        #region Tab 0: Danh Mục

        #region Tab 1: Tài Liệu

        private void btnLuuTaiLieu1_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaTaiLieu1_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaTaiLieu1_Click(object sender, EventArgs e)
        {

        }

        private void btnNhapLai1_Click(object sender, EventArgs e)
        {

        }

        private void dataTaiLieu1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion

        #region Tab 2: Độc Giả

        private void XemDocGia()
        {
            try
            {
                DataTable dataTable = docGiaBO.XemDocGia();
                //dataTable.Columns.Add("Giới Tính", typeof(string));
                dataDocGia2.DataSource = dataTable;
                //for (int i = 0; i < dataTable.Rows.Count; i++)
                //{
                //    if (dataDocGia2.Rows[i].Cells["GioiTinh"].Value.ToString() == "True")
                //    {
                //        dataDocGia2.Rows[i].Cells[3].Value = "Nam";
                //        //dataDocGia2.UpdateCellValue(i, );
                //    }
                //}
            }
            catch (SqlException sex)
            {
                txtStatus.Text = "Lỗi lấy thông tin";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi bảng Độc Giả";
            }
        }

        private void btnLuuDocGia2_Click(object sender, EventArgs e)
        {
            DocGiaDTO docGiaDTO;
            DateTime ngaySinh = dtNgaySinh2.Value;
            DateTime ngayCap = dtNgayCap2.Value;
            DateTime ngayHetHan = dtNgayHetHan2.Value;
            int result1 = DateTime.Compare(ngaySinh, ngayCap);
            int result2 = DateTime.Compare(ngayCap, ngayHetHan);
            bool gioiTinh = true;
            if (rbGioiTinhNam2.Checked)
            {
                gioiTinh = true;
            }
            if (rbGioiTinhNu2.Checked)
            {
                gioiTinh = false;
            }
            try
            {
                if (result1 < 0 && result2 < 0)
                {
                    docGiaDTO = new DocGiaDTO(txtMaDocGia2.Text, txtHoTen2.Text, gioiTinh, dtNgaySinh2.Text, cbDoiTuong2.Text, dtNgayCap2.Text, dtNgayHetHan2.Text);
                    docGiaBO.ThemDocGia(docGiaDTO);
                }
                else
                {
                    txtStatus.Text = "Nhập sai ngày";
                }
            }
            catch
            {
                txtStatus.Text = "Lỗi lưu độc giả";
            }
            XemDocGia();
        }

        private void btnSuaDocGia2_Click(object sender, EventArgs e)
        {
            DocGiaDTO docGiaDTO;
            DateTime ngaySinh = dtNgaySinh2.Value;
            DateTime ngayCap = dtNgayCap2.Value;
            DateTime ngayHetHan = dtNgayHetHan2.Value;
            int result1 = DateTime.Compare(ngaySinh, ngayCap);
            int result2 = DateTime.Compare(ngayCap, ngayHetHan);
            bool gioiTinh = true;
            try
            {
                if (rbGioiTinhNam2.Checked)
                {
                    gioiTinh = true;
                }
                if (rbGioiTinhNu2.Checked)
                {
                    gioiTinh = false;
                }
                if (result1 < 0 && result2 < 0)
                {
                    docGiaDTO = new DocGiaDTO(txtMaDocGia2.Text, txtHoTen2.Text, gioiTinh, dtNgaySinh2.Text, cbDoiTuong2.Text, dtNgayCap2.Text, dtNgayHetHan2.Text);
                    docGiaBO.SuaDocGia(docGiaDTO);
                }
                else
                {
                    txtStatus.Text = "Nhập sai ngày";
                }
            }
            catch
            {
                txtStatus.Text = "Lỗi Sửa Độc Giả " + txtMaDocGia2.Text;
            }
            XemDocGia();
        }

        private void btnXoaDocGia2_Click(object sender, EventArgs e)
        {
            try
            {
                docGiaBO.XoaDocGia(txtMaDocGia2.Text);
            }
            catch
            {
                txtStatus.Text = "Lỗi Xóa Độc Giả";
            }
            XemDocGia();
        }

        private void btnNhapLai2_Click(object sender, EventArgs e)
        {
            NhapLai(tabDocGia2);
        }

        private void dataDocGia2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataDocGia2.CurrentRow.Index;
            txtMaDocGia2.Text = dataDocGia2.Rows[i].Cells[0].Value.ToString();
            txtHoTen2.Text = dataDocGia2.Rows[i].Cells[1].Value.ToString();
            if(dataDocGia2.Rows[i].Cells[2].Value.ToString() == "True")
            {
                rbGioiTinhNam2.Checked = true;
            }
            if(dataDocGia2.Rows[i].Cells[2].Value.ToString() == "False")
            {
                rbGioiTinhNu2.Checked = true;
            }
            dtNgaySinh2.Text = dataDocGia2.Rows[i].Cells[3].Value.ToString();
            cbDoiTuong2.Text = dataDocGia2.Rows[i].Cells[4].Value.ToString();
            dtNgayCap2.Text = dataDocGia2.Rows[i].Cells[5].Value.ToString();
            dtNgayHetHan2.Text = dataDocGia2.Rows[i].Cells[6].Value.ToString();

        }

        #endregion

        #region Tab 3: Thể Loại

        private void btnLuuTheLoai3_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaTheLoai3_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaTheLoai3_Click(object sender, EventArgs e)
        {

        }

        private void btnNhapLai3_Click(object sender, EventArgs e)
        {

        }

        private void dataTheLoai3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region Tab 4: Nhân Viên

        private void XemNhanVien()
        {
            try
            {
                dataNhanVien4.DataSource = nhanVienBO.XemNhanVien();
            }
            catch (SqlException sex)
            {
                txtStatus.Text = "Lỗi lấy thông tin";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi bảng nhân viên";
            }
        }

        private void btnLuuNhanVien4_Click(object sender, EventArgs e)
        {
            NhanVienDTO nhanVienDTO = new NhanVienDTO(txtMaNhanVien4.Text, txtHoTen4.Text, cbChucVu4.Text, txtTenTaiKhoan4.Text, txtMatKhau4.Text, cbQuyen4.Text);
            try
            {
                if (txtMatKhau4.Text.Equals(txtNhapLaiMatKhau4.Text))
                {
                    nhanVienBO.ThemNhanVien(nhanVienDTO);
                }
                else
                {
                    txtStatus.Text = "Mật khẩu nhập lại không khớp";
                }
            }
            catch
            {
                txtStatus.Text = "Lỗi lưu nhân viên";
            }
            XemNhanVien();
        }

        private void btnSuaNhanVien4_Click(object sender, EventArgs e)
        {
            NhanVienDTO nhanVienDTO = new NhanVienDTO(txtMaNhanVien4.Text, txtHoTen4.Text, cbChucVu4.Text, txtTenTaiKhoan4.Text, txtMatKhau4.Text, cbQuyen4.Text);
            try
            {
                if (txtMatKhau4.Text.Equals(txtNhapLaiMatKhau4.Text))
                {
                    nhanVienBO.SuaNhanVien(nhanVienDTO);
                }
                else
                {
                    txtStatus.Text = "Mật khẩu nhập lại không khớp";
                }
            }
            catch
            {
                txtStatus.Text = "Lỗi sửa nhân viên";
            }
            XemNhanVien();
        }

        private void btnXoaNhanVien4_Click(object sender, EventArgs e)
        {
            try
            {
                nhanVienBO.XoaNhanVien(txtMaNhanVien4.Text);
            }
            catch
            {
                txtStatus.Text = "Mã cần xóa không tồn tại";
            }
            XemNhanVien();
        }

        private void btnNhapLai4_Click(object sender, EventArgs e)
        {
            NhapLai(tabNhanVien4);
        }

        private void dataNhanVien4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataNhanVien4.CurrentRow.Index;
            txtMaNhanVien4.Text = dataNhanVien4.Rows[i].Cells[0].Value.ToString();
            txtHoTen4.Text = dataNhanVien4.Rows[i].Cells[1].Value.ToString();
            cbChucVu4.Text = dataNhanVien4.Rows[i].Cells[2].Value.ToString();
            txtTenTaiKhoan4.Text = dataNhanVien4.Rows[i].Cells[3].Value.ToString();
            txtMatKhau4.Text = dataNhanVien4.Rows[i].Cells[4].Value.ToString();
            txtNhapLaiMatKhau4.Text = dataNhanVien4.Rows[i].Cells[4].Value.ToString();
            cbQuyen4.Text = dataNhanVien4.Rows[i].Cells[5].Value.ToString();
        }
        #endregion

        private void subTabDanhMuc0_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabNhanVien4)
            {
                XemNhanVien();
            }
            if (e.TabPage == tabDocGia2)
            {
                XemDocGia();
            }
        }

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

        public void QuyenDocGia()
        {
            tabIconList.Images.RemoveAt(0);
            tabIconList.Images.RemoveAt(0);
            tabIconList.Images.RemoveAt(0);
            tabMenu.TabPages.Remove(tabDanhMuc0);
            tabMenu.TabPages.Remove(tabMuonTra5);
            tabMenu.TabPages.Remove(tabThongKe6);
            subTabTimKiem7.TabPages.Remove(tabTimKiemPhieuMuon9);
            menuBar.Enabled = false;
            đổiMậtKhẩuToolStripMenuItem.Enabled = false;
        }

        public void QuyenUser()
        {
            subTabDanhMuc0.TabPages.Remove(tabNhanVien4);
            nhânViênToolStripMenuItem.Enabled = false;
        }

        public void NhapLai(TabPage tabPage)
        {
            foreach (Control ctrl in tabPage.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }
        }


        private void AutoComplete(TextBox textBox, DataTable dataTable, string tenCot)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                auto.Add(dataTable.Rows[i].Field<string>(tenCot));
            }
            txtTenTaiLieu1.AutoCompleteCustomSource = auto;
        }
    }
}
