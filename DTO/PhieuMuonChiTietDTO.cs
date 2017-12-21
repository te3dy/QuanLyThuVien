
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO{
    /**
     * 
     */
    public class PhieuMuonChiTietDTO {

        /**
         * 
         */
        public PhieuMuonChiTietDTO() {
        }

        public PhieuMuonChiTietDTO(string maPhieuMuon, string maSach, int soLuongMuon, string ngayTra)
        {
            MaPhieuMuon = maPhieuMuon;
            MaSach = maSach;
            SoLuongMuon = soLuongMuon;
            NgayTra = ngayTra;
        }




        /**
         * 
         */
        public string MaPhieuMuon;

        /**
         * 
         */
        public string MaSach;

        /**
         * 
         */
        public int SoLuongMuon;

        /**
         * 
         */
        public String NgayTra;

    }
}