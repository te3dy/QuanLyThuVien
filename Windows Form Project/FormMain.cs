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
        DangNhapBO dangNhapBO = new DangNhapBO();
        NhanVienBO nhanVienBO = new NhanVienBO();
        DocGiaBO docGiaBO = new DocGiaBO();
        TaiLieuBO taiLieuBO = new TaiLieuBO();
        TheLoaiBO theLoaiBO = new TheLoaiBO();
        PhieuMuonBO phieuMuonBO = new PhieuMuonBO();
        PhieuMuonChiTietBO phieuMuonChiTietBO = new PhieuMuonChiTietBO();
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
            try
            {
                DataTable dataTable = dangNhapBO.ThongTinDangNhap(taiKhoan, matKhau);
                tênNhânViênToolStripMenuItem.Text = dataTable.Rows[0]["HoTen"].ToString();
            }
            catch
            {

            }
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
                txtStatus.Text = "";
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
                TaiLieuDTO taiLieuDTO = new TaiLieuDTO(txtMaTaiLieu1.Text, txtTenTaiLieu1.Text, txtMaTheLoai1.Text, int.Parse(txtSoLuong1.Text), txtNhaXuatBan1.Text
                    , int.Parse(txtNamXuatBan1.Text), txtTacGia1.Text);
                taiLieuBO.ThemTaiLieu(taiLieuDTO);
                txtStatus.Text = "";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi ghi thông tin !";
            }
            XemTaiLieu();
        }

        private void btnSuaTaiLieu1_Click(object sender, EventArgs e)
        {
            try
            {
                TaiLieuDTO taiLieuDTO = new TaiLieuDTO(txtMaTaiLieu1.Text, txtTenTaiLieu1.Text, txtMaTheLoai1.Text, int.Parse(txtSoLuong1.Text), txtNhaXuatBan1.Text
                    , int.Parse(txtNamXuatBan1.Text), txtTacGia1.Text);
                taiLieuBO.SuaTaiLieu(taiLieuDTO);
                txtStatus.Text = "";
            }
            catch
            {
                txtStatus.Text = "Lỗi sửa tài liệu";
            }
        }

        private void btnXoaTaiLieu1_Click(object sender, EventArgs e)
        {
            try
            {
                taiLieuBO.XoaTaiLieu(txtMaTaiLieu1.Text);
            }
            catch
            {
                txtStatus.Text = "Lỗi xóa tài liệu";
            }
            XemTaiLieu();
        }

        private void btnNhapLai1_Click(object sender, EventArgs e)
        {
            NhapLai(tabTaiLieu1);
        }

        private void dataTaiLieu1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataTaiLieu1.CurrentRow.Index;
            txtMaTaiLieu1.Text = dataTaiLieu1.Rows[i].Cells[0].Value.ToString();
            txtTenTaiLieu1.Text = dataTaiLieu1.Rows[i].Cells[1].Value.ToString();
            txtMaTheLoai1.Text = dataTaiLieu1.Rows[i].Cells[2].Value.ToString();
            txtSoLuong1.Text = dataTaiLieu1.Rows[i].Cells[3].Value.ToString();
            txtNhaXuatBan1.Text = dataTaiLieu1.Rows[i].Cells[4].Value.ToString();
            txtNamXuatBan1.Text = dataTaiLieu1.Rows[i].Cells[5].Value.ToString();
            txtTacGia1.Text = dataTaiLieu1.Rows[i].Cells[6].Value.ToString();
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
                    txtStatus.Text = "";
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
                    docGiaBO.SuaDocGia(docGiaDTO);
                    txtStatus.Text = "";
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
            try
            {
                TheLoaiDTO theLoaiDTO = new TheLoaiDTO(txtMaTheLoai3.Text, txtTenTheLoai3.Text, txtGhiChu3.Text);
                theLoaiBO.SuaTheLoai(theLoaiDTO);
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi ghi thông tin !";
            }

            XemTheLoai();
        }

        private void btnXoaTheLoai3_Click(object sender, EventArgs e)
        {
            try
            {
                theLoaiBO.XoaTheLoai(txtMaTheLoai3.Text);
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi ghi thông tin !";
            }

            XemTheLoai();
        }

        private void btnNhapLai3_Click(object sender, EventArgs e)
        {
            NhapLai(tabTheLoai3);
        }

        private void dataTheLoai3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataTheLoai3.CurrentRow.Index;
            txtMaTheLoai3.Text = dataTheLoai3.Rows[i].Cells[0].Value.ToString();
            txtTenTheLoai3.Text = dataTheLoai3.Rows[i].Cells[1].Value.ToString();
            txtGhiChu3.Text = dataTheLoai3.Rows[i].Cells[2].Value.ToString();
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
                XemNhanVien();
            }
            if (e.TabPage == tabDocGia2)
            {
                XemDocGia();
            }
            if (e.TabPage == tabTaiLieu1)
            {
                XemTaiLieu();
            }
            if (e.TabPage == tabTheLoai3)
            {
                XemTheLoai();
            }
        }

        #endregion

        #region Tab 5: Mượn Trả
        #endregion

        #region Tab 6: Thống Kê
        private void subTabThongKe6_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabTaiLieuMuonQuaHan6)
            {
                this.reprotTaiLieuMuonQuaHan6.RefreshReport();
            }
            if (e.TabPage == tabTaiLieuDangMuon6)
            {
                this.reportTaiLieuDangMuon6.RefreshReport();
            }
            if (e.TabPage == tabTaiLieuMuonNhieuNhat6)
            {
                this.reportTop10MuonNhieu6.RefreshReport();
            }
            if (e.TabPage == tabMuonTheoTheLoai6)
            {
                this.reportMuonTheoTheLoai6.RefreshReport();
            }
        }
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
            if (comboBoxText == "Mã Thể Loại")
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

        private void btnTimKiemNangCao8_Click(object sender, EventArgs e)
        {
            string col1 = TenCotTaiLieu(cbTimKiemNangCao18.Text);
            string col2 = TenCotTaiLieu(cbTimKiemNangCao28.Text);
            string col3 = TenCotTaiLieu(cbTimKiemNangCao38.Text);
            string link1 = TuNoi(cbTuyChonTimKiemNangCao18.Text);
            string link2 = TuNoi(cbTuyChonTimKiemNangCao28.Text);
            string info1 = txtTimKiemNangCao18.Text;
            string info2 = txtTimKiemNangCao28.Text;
            string info3 = txtTimKiemNangCao38.Text;
            try
            {
                DataTable dataTable = taiLieuBO.TimTaiLieu(col1, info1, link1, col2, info2, link2, col3, info3);
                dataTimKiem8.DataSource = dataTable;
                txtStatus.Text = "";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi Tìm Kiếm Tài Liệu";
            }
        }
        private void cbTuyChonTimKiemNangCao18_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cbTuyChonTimKiemNangCao18.Text))
            {
                txtTimKiemNangCao28.Enabled = false;
                cbTimKiemNangCao28.Enabled = false;
            }
            else
            {
                txtTimKiemNangCao28.Enabled = true;
                cbTimKiemNangCao28.Enabled = true;
            }
        }

        private void cbTuyChonTimKiemNangCao28_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cbTuyChonTimKiemNangCao28.Text))
            {
                txtTimKiemNangCao38.Enabled = false;
                cbTimKiemNangCao38.Enabled = false;
            }
            else
            {
                txtTimKiemNangCao38.Enabled = true;
                cbTimKiemNangCao38.Enabled = true;
            }
        }
        #endregion

        #region Tab 9: Phiếu Mượn

        // Lọc tên cột tài liệu từ combobox để truy vấn
        private string TenCotPhieuMuon(string comboBoxText)
        {
            string tenCot = "";
            if (comboBoxText == "Mã Phiếu Mượn")
            {
                tenCot = "MaPhieuMuon";
            }
            if (comboBoxText == "Mã Độc Giả")
            {
                tenCot = "MaDocGia";
            }
            if (comboBoxText == "Mã Nhân Viên")
            {
                tenCot = "MaNhanVien";
            }
            if (comboBoxText == "Ngày Mượn")
            {
                tenCot = "NgayMuon";
            }
            return tenCot;
        }

        private void btnTimKiemNangCao9_Click(object sender, EventArgs e)
        {
            string col1 = TenCotPhieuMuon(cbTimKiemNangCao19.Text);
            string col2 = TenCotPhieuMuon(cbTimKiemNangCao29.Text);
            string col3 = TenCotPhieuMuon(cbTimKiemNangCao39.Text);
            string link1 = TuNoi(cbTuyChonTimKiemNangCao19.Text);
            string link2 = TuNoi(cbTuyChonTimKiemNangCao29.Text);
            string info1 = txtTimKiemNangCao19.Text;
            string info2 = txtTimKiemNangCao29.Text;
            string info3 = txtTimKiemNangCao39.Text;
            try
            {
                DataTable dataTable = phieuMuonBO.TimPhieuMuon(col1, info1, link1, col2, info2, link2, col3, info3);
                dataTimKiem9.DataSource = dataTable;
                txtStatus.Text = "";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Lỗi Tìm Kiếm Phiếu Mượn";
            }
        }

        private void cbTuyChonTimKiemNangCao19_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cbTuyChonTimKiemNangCao19.Text))
            {
                txtTimKiemNangCao29.Enabled = false;
                cbTimKiemNangCao29.Enabled = false;
            }
            else
            {
                txtTimKiemNangCao29.Enabled = true;
                cbTimKiemNangCao29.Enabled = true;
            }
        }

        private void cbTuyChonTimKiemNangCao29_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cbTuyChonTimKiemNangCao29.Text))
            {
                txtTimKiemNangCao39.Enabled = false;
                cbTimKiemNangCao39.Enabled = false;
            }
            else
            {
                txtTimKiemNangCao39.Enabled = true;
                cbTimKiemNangCao39.Enabled = true;
            }
        }

        private void dataTimKiem9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataTimKiem9.CurrentRow.Index;
            string maPhieuMuon = dataTimKiem9.Rows[index].Cells[0].Value.ToString();
            try
            {
                DataTable dataTable = phieuMuonChiTietBO.XemPhieuMuonChiTiet(maPhieuMuon);
                dataTable.Columns.Remove("MaPhieuMuon");
                dataPhieuMuonTaiLieu9.DataSource = dataTable;
                txtStatus.Text = "";
            }
            catch
            {
                txtStatus.Text = "Lỗi lấy tài liệu trong phiếu mượn " + maPhieuMuon;
            }
        }
        #endregion

        private void subTabTimKiem7_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (e.TabPage == tabTimKiemTaiLieu8)
                {
                    dataTimKiem8.DataSource = taiLieuBO.XemTaiLieu();
                }
                if (e.TabPage == tabTimKiemPhieuMuon9)
                {
                    dataTimKiem9.DataSource = phieuMuonBO.XemHet();
                }
                txtStatus.Text = "";
            }
            catch
            {
                txtStatus.Text = "Lỗi lấy thông tin";
            }
        }

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
    }
}
