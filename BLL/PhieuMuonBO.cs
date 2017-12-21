
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
    public class PhieuMuonBO {

        /**
         * 
         */
         
        public PhieuMuonBO() {
        }

        /**
         * 
         */
        private PhieuMuonDAO phieuMuonDAO=new PhieuMuonDAO();

        /**
         * @return
         */
        public DataTable XemPhieuMuon(string MaDocGia) {
            // TODO implement here
            return phieuMuonDAO.XemPhieuMuon(MaDocGia);
        }
        public DataTable XemHet() {
            return phieuMuonDAO.XemHet();
        }
        /**
         * @param phieuMuonDTO
         */
        public void ThemPhieuMuon(PhieuMuonDTO phieuMuonDTO) {
            phieuMuonDAO.ThemPhieuMuon(phieuMuonDTO);
            // TODO implement here
        }

        /**
         * @param phieuMuonDTO
         */
        public void SuaPhieuMuon(PhieuMuonDTO phieuMuonDTO) {
            phieuMuonDAO.SuaPhieuMuon(phieuMuonDTO);
            // TODO implement here
        }

        /**
         * 
         */
        public void XoaPhieuMuon(string MaPhieuMuon) {
            phieuMuonDAO.XoaPhieuMuon(MaPhieuMuon);
            // TODO implement here
        }

       
        
        /**
         * @return
         */
        public DataTable TimPhieuMuon() {
            // TODO implement here
            return null;
        }

    }
}