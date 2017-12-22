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
        TaiLieuBO taiLieuBO = new TaiLieuBO();
        TheLoaiBO theLoaiBO = new TheLoaiBO();
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
            // TODO: This line of code loads data into the 'duLieuPhanMem.VW_TaiLieuQuaHan' table. You can move, or remove it, as needed.
            this.vW_TaiLieuQuaHanTableAdapter.Fill(this.duLieuPhanMem.VW_TaiLieuQuaHan);
            // TODO: This line of code loads data into the 'duLieuPhanMem.VW_SoLanMuon' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'duLieuPhanMem.VW_TaiLieuChoMuon' table. You can move, or remove it, as needed.
          //  this.vW_TaiLieuChoMuonTableAdapter.Fill(duLieuPhanMem.VW_SoLanMuon);
            // TODO: This line of code loads data into the 'duLieuPhanMem.VW_TaiLieuMuonNhieuNhat' table. You can move, or remove it, as needed.
            this.vW_TaiLieuMuonNhieuNhatTableAdapter.Fill(this.duLieuPhanMem.VW_TaiLieuMuonNhieuNhat);
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
        private void XemTaiLieu()
        {
            try
            {
                DataTable dataTable = taiLieuBO.XemTaiLieu();
                dataTaiLieu1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi bảng Độc Giả";
            }
        }
        private void btnLuuTaiLieu1_Click(object sender, EventArgs e)
        {
            try
            {
                TaiLieuDTO taiLieuDTO = new TaiLieuDTO(txtMaTaiLieu1.Text, txtTenTaiLieu1.Text, txtMaTheLoai1.Text, 10, txtNhaXuatBan1.Text
                    , 20, txtTacGia1.Text);
                taiLieuBO.ThemTaiLieu(taiLieuDTO);
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi ghi thông tin !";
            }

            XemTaiLieu();
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
                dataTable.Columns.Add("Giới Tính");
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["GioiTinh"].ToString() == "True")
                    {
                        row["Giới Tính"] = "Nam";
                    }
                    if (row["GioiTinh"].ToString() == "False")
                    {
                        row["Giới Tính"] = "Nữ";
                    }
                }
                dataTable.Columns.Remove("GioiTinh");
                dataDocGia2.DataSource = dataTable;
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
            if (dataDocGia2.Rows[i].Cells[6].Value.ToString() == "Nam")
            {
                rbGioiTinhNam2.Checked = true;
            }
            if (dataDocGia2.Rows[i].Cells[6].Value.ToString() == "Nữ")
            {
                rbGioiTinhNu2.Checked = true;
            }
            dtNgaySinh2.Text = dataDocGia2.Rows[i].Cells[2].Value.ToString();
            cbDoiTuong2.Text = dataDocGia2.Rows[i].Cells[3].Value.ToString();
            dtNgayCap2.Text = dataDocGia2.Rows[i].Cells[4].Value.ToString();
            dtNgayHetHan2.Text = dataDocGia2.Rows[i].Cells[5].Value.ToString();

        }

        #endregion

        #region Tab 3: Thể Loại
        private void XemTheLoai()
        {
            try
            {
                DataTable dataTable = theLoaiBO.XemTheLoai();
                dataTheLoai3.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi bảng thể loại";
            }
        }
        private void btnLuuTheLoai3_Click(object sender, EventArgs e)
        {
            try
            {
                TheLoaiDTO theLoaiDTO = new TheLoaiDTO(txtMaTheLoai3.Text, txtTenTheLoai3.Text, txtGhiChu3.Text);
                theLoaiBO.ThemTheLoai(theLoaiDTO);
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi ghi thông tin !";
            }

            XemTheLoai();
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
                DataTable dataTable = nhanVienBO.XemNhanVien();
                dataNhanVien4.DataSource = dataTable;
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
            // Mở tab khi tab được chọn
            if (e.TabPage == tabNhanVien4)
            {
                DataTable dataTable = nhanVienBO.XemNhanVien();
                AutoComplete(txtMaNhanVien4, dataTable, "MaNhanVien");
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

        // Lọc tên cột tài liệu từ combobox để truy vấn
        private string TenCotTaiLieu(string comboBoxText)
        {
            string tenCot = "";
            if (comboBoxText == "Mã Tài Liệu")
            {
                tenCot = "MaTaiLieu";
            }
            if (comboBoxText == "Tên Tài Liệu")
            {
                tenCot = "TenTaiLieu";
            }
            if (comboBoxText == "Tên Thể Loại")
            {
                tenCot = "MaTheLoai";
            }
            if (comboBoxText == "Nhà Xuất Bản")
            {
                tenCot = "NhaXuatBan";
            }
            if (comboBoxText == "Năm Xuất Bản")
            {
                tenCot = "NamXuatBan";
            }
            if (comboBoxText == "Tác Giả")
            {
                tenCot = "TacGia";
            }
            return tenCot;
        }

        // Lọc các từ nối AND OR từ combobox
        private string TuNoi(string comboBoxText)
        {
            string tuNoi = "";
            if (comboBoxText == "Và")
            {
                tuNoi = "AND";
            }
            if (comboBoxText == "Hoặc")
            {
                tuNoi = "OR";
            }
            return tuNoi;
        }

        private void btnTimKiem8_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = taiLieuBO.TimTaiLieu(TenCotTaiLieu(cbTimKiem8.Text), txtTimKiem8.Text);
                dataTimKiem8.DataSource = dataTable;
            }
            catch
            {
                txtStatus.Text = "Lỗi Tìm Kiếm Tài Liệu";
            }
        }

        private void btnTimKiemNangCao8_Click(object sender, EventArgs e)
        {
            try
            {
                string col1 = TenCotTaiLieu(cbTimKiemNangCao18.Text);
                string col2 = TenCotTaiLieu(cbTimKiemNangCao28.Text);
                string col3 = TenCotTaiLieu(cbTimKiemNangCao38.Text);
                string link1 = TuNoi(cbTuyChonTimKiemNangCao18.Text);
                string link2 = TuNoi(cbTuyChonTimKiemNangCao28.Text);
                string info1 = txtTimKiemNangCao18.Text;
                string info2 = txtTimKiemNangCao28.Text;
                string info3 = txtTimKiemNangCao38.Text;
                //DataTable dataTable = taiLieuBO.TimTaiLieu(col1, info1, link1, col2, info2, link2, col3, info3);
                DataTable dataTable1 = taiLieuBO.XemTaiLieu();
                string subCommand1 = col1 + "='" + info1 + "'";
                string subCommand2 = link1 + " " + col2 + "='" + info2 + "'";
                string subCommand3 = link2 + " " + col3 + "='" + info3 + "'";
                string command = subCommand1;
                if (!String.IsNullOrWhiteSpace(col2) && !String.IsNullOrWhiteSpace(col3))
                {
                    command += " " + subCommand2 + " " + subCommand3;
                }
                if (String.IsNullOrWhiteSpace(col2) && !String.IsNullOrWhiteSpace(col3))
                {
                    command += " " + subCommand3;
                }
                if (!String.IsNullOrWhiteSpace(col2) && String.IsNullOrWhiteSpace(col3))
                {
                    command += " " + subCommand2;
                }
                DataRow[] dataRow = dataTable1.Select(command);
                DataTable dataTable2 = taiLieuBO.XemTaiLieu();
                dataTable2.Clear();
                foreach (DataRow row in dataRow)
                {
                    dataTable2.Rows.Add(row.ItemArray);
                }
                dataTimKiem8.DataSource = dataTable2;
                txtStatus.Text = "";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi Tìm Kiếm Tài Liệu";
            }
        }

        #endregion

        #region Tab 9: Phiếu Mượn
        #endregion

        #endregion

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
            textBox.AutoCompleteCustomSource = auto;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //txtStatus.Visible = false;
            //timer.Stop();
        }

        private void subTabThongKe6_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPage == tabTaiLieuMuonQuaHan6)
            {
                this.reprotTaiLieuMuonQuaHan6.RefreshReport();
            }
            if(e.TabPage == tabTaiLieuDangMuon6)
            {
                this.reportTaiLieuDangMuon6.RefreshReport();
            }
            if(e.TabPage == tabTaiLieuMuonNhieuNhat6)
            {
                this.reportTop10MuonNhieu6.RefreshReport();
            }
            if(e.TabPage == tabMuonTheoTheLoai6)
            {
                this.reportMuonTheoTheLoai6.RefreshReport();
            }
        }
    }
}
