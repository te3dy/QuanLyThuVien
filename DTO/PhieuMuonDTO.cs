
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO{
    /**
     * 
     */
    public class PhieuMuonDTO {

        /**
         * 
         */
        public PhieuMuonDTO() {
        }

        public PhieuMuonDTO(string maPhieuMuon, string maDocGia, string ngayMuon, string maNhanVien)
        {
            MaPhieuMuon = maPhieuMuon;
            MaDocGia = maDocGia;
            NgayMuon = ngayMuon;
            MaNhanVien = maNhanVien;
        }

        /**
         * 
         */
        public string MaPhieuMuon;

        /**
         * 
         */
        public string MaDocGia;

        /**
         * 
         */
        public string NgayMuon;

        /**
         * 
         */
        public string MaNhanVien;

    }
}