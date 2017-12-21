
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO{
    /**
     * 
     */
    public class TaiLieuDTO {

        /**
         * 
         */
        public TaiLieuDTO() {
        }
        public TaiLieuDTO(string maTaiLieu, string tenTaiLieu, string maTheLoai, int soLuong, string nhaXuatBan, int namXuatBan, string tacGia )
        {
            MaTaiLieu = maTaiLieu;
            TenTaiLieu = tenTaiLieu;
            MaTheLoai = maTheLoai;
            SoLuong = soLuong;
            NhaXuatBan = nhaXuatBan;
            NamXuatBan = namXuatBan;
            TacGia = tacGia;
        }
        /**
         * 
         */
        public string MaTaiLieu;

        /**
         * 
         */
        public string TenTaiLieu;

        /**
         * 
         */
        public string MaTheLoai;

        /**
         * 
         */
        public int SoLuong;

        /**
         * 
         */
        public string NhaXuatBan;

        /**
         * 
         */
        public int NamXuatBan;

        /**
         * 
         */
        public string TacGia;

    }
}