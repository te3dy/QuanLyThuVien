
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;
using System.Data;

namespace BLL
{
    /**
     * 
     */
    public class PhieuMuonChiTietBO {

        /**
         * 
         */
        public PhieuMuonChiTietBO() {
        }

        /**
         * 
         */
        private PhieuMuonChiTietDAO phieuMuonChiTietDAO = new PhieuMuonChiTietDAO();

        /**
         * @return
         */
        public DataTable XemPhieuMuonChiTiet(string MaPhieuMuon) {
            // TODO implement here
            return phieuMuonChiTietDAO.XemPhieuMuonChiTiet(MaPhieuMuon);
        }

        /**
         * @param phieuMuonChiTietDAO
         */
        public void ThemPhieuMuonChiTiet(PhieuMuonChiTietDTO phieuMuonChiTietDTO) {
            phieuMuonChiTietDAO.ThemPhieuMuonChiTiet(phieuMuonChiTietDTO);
            // TODO implement here
        }

        /**
         * @param phieuMuonChiTietDAO
         */
        public void SuaPhieuMuonChiTiet(PhieuMuonChiTietDTO phieuMuonChiTietDTO) {
            phieuMuonChiTietDAO.SuaPhieuMuonChiTiet(phieuMuonChiTietDTO);
            // TODO implement here
        }

        /**
         * 
         */
        public void XoaPhieuMuonChiTiet(string MaPhieuMuon) {
            phieuMuonChiTietDAO.XoaPhieuMuonChiTiet(MaPhieuMuon);
            // TODO implement here
        }

        /**
         * @return
         */
        public DataTable TimPhieuMuonChiTiet() {
            // TODO implement here
            return null;
        }

    }
}