
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    /**
     * 
     */
    public class NhanVienDTO
    {

        /**
         * 
         */
        public NhanVienDTO()
        {
        }

        /**
         * 
         */
        public string MaNhanVien;

        /**
         * 
         */
        public string HoTen;

        /**
         * 
         */
        public string ChucVu;

        /**
         * 
         */
        public string TaiKhoan;

        /**
         * 
         */
        public string MatKhau;

        /**
         * 
         */
        public string Quyen;

        public NhanVienDTO(string maNhanVien, string hoTen, string chucVu, string taiKhoan, string matKhau, string quyen)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            ChucVu = chucVu;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            Quyen = quyen;
        }
    }
}