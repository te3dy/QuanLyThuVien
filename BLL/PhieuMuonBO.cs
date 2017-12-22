
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
        public DataTable TimPhieuMuon(string col1, string info1, string link1, string col2, string info2, string link2, string col3, string info3) {
            DataTable dataTimKiem;
            try
            {
                DataTable dataPhieuMuon = XemHet();
                string subCommand1 = col1 + "='" + info1 + "'";
                string subCommand2 = link1 + " " + col2 + "='" + info2 + "'";
                string subCommand3 = link2 + " " + col3 + "='" + info3 + "'";
                string command = subCommand1;
                if (!String.IsNullOrWhiteSpace(link1) && !String.IsNullOrWhiteSpace(link2))
                {
                    command += " " + subCommand2 + " " + subCommand3;
                }
                if (String.IsNullOrWhiteSpace(link1) && !String.IsNullOrWhiteSpace(link2))
                {
                    command += " " + subCommand3;
                }
                if (!String.IsNullOrWhiteSpace(link1) && String.IsNullOrWhiteSpace(link2))
                {
                    command += " " + subCommand2;
                }
                DataRow[] dataRow = dataPhieuMuon.Select(command);
                dataTimKiem = XemHet();
                dataTimKiem.Clear();
                foreach (DataRow row in dataRow)
                {
                    dataTimKiem.Rows.Add(row.ItemArray);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTimKiem;
        }

    }
}