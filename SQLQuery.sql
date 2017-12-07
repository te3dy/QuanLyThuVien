USE [D:\GITHUB\QUANLYTHUVIEN\DAL\DATABASE.MDF]
GO
CREATE TABLE TheLoai
(
  MaTheLoai CHAR(10) PRIMARY KEY,
  TenTheLoai NVARCHAR(50),
  GhiChu NVARCHAR(150)
)
GO
CREATE TABLE TaiLieu
(
  MaTaiLieu CHAR(10) PRIMARY KEY,
  TenTaiLieu NVARCHAR(50),
  MaTheLoai CHAR(10),
  SoLuong INT,
  NhaXuatBan NVARCHAR(50),
  NamXuatBan INT,
  TacGia NVARCHAR(50),
  FOREIGN KEY(MaTheLoai) REFERENCES dbo.TheLoai(MaTheLoai)
)
GO
CREATE TABLE NhanVien
( 
  MaNhanVien CHAR(10) PRIMARY KEY,
  HoTen NVARCHAR(50),
  ChucVu NVARCHAR(50),
  TaiKhoan VARCHAR(20) UNIQUE,
  MatKhau VARCHAR(20),
  Quyen VARCHAR(20)
)
GO
CREATE TABLE DocGia
(
  MaDocGia CHAR(10) PRIMARY KEY,
  HoTen NVARCHAR(50),
  GioiTinh BIT,
  NgaySinh DATE,
  DoiTuong NVARCHAR(50),
  NgayCap DATE,
  NgayHetHan DATE
)
GO
CREATE TABLE PhieuMuon
(
  MaPhieuMuon CHAR(10) PRIMARY KEY,
  MaDocGia CHAR(10),
  NgayMuon DATE,
  MaNhanVien CHAR(10),
  FOREIGN KEY(MaDocGia) REFERENCES dbo.DocGia(MaDocGia),
  FOREIGN KEY(MaNhanVien) REFERENCES dbo.NhanVien(MaNhanVien)
)
GO
CREATE TABLE PhieuMuonChiTieu
(
  MaPhieuMuon CHAR(10),
  MaTaiLieu CHAR(10),
  SoLuongMuon INT,
  NgayTra DATE,
  PRIMARY KEY(MaPhieuMuon,MaTaiLieu),
  FOREIGN KEY(MaPhieuMuon) REFERENCES dbo.PhieuMuon(MaPhieuMuon),
  FOREIGN KEY(MaTaiLieu) REFERENCES dbo.TaiLieu(MaTaiLieu)
)


