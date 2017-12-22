
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
    public class TaiLieuBO
    {

        /**
         * 
         */
        public TaiLieuBO()
        {
        }

        /**
         * 
         */
        private TaiLieuDAO taiLieuDAO = new TaiLieuDAO();
        private DataTable dataTable;

        /**
         * @return
         */
        public DataTable XemTaiLieu()
        {
            // TODO implement here
            try
            {
                dataTable = taiLieuDAO.XemTaiLieu();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        /**
         * @param taiLieuDTO
         */
        public void ThemTaiLieu(TaiLieuDTO taiLieuDTO)
        {
            // TODO implement here
            try
            {
                taiLieuDAO.ThemTaiLieu(taiLieuDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @param taiLieuDTO
         */
        public void SuaTaiLieu(TaiLieuDTO taiLieuDTO)
        {
            // TODO implement here
            try
            {
                taiLieuDAO.SuaTaiLieu(taiLieuDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * 
         */
        public void XoaTaiLieu(string maTaiLieu)
        {
            // TODO implement here
            try
            {
                taiLieuDAO.XoaTaiLieu(maTaiLieu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @return
         */
        public DataTable TimTaiLieu(string col, string info)
        {
            try
            {
                dataTable = taiLieuDAO.TimTaiLieu(col, info);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public DataTable TimTaiLieu(string col1, string info1, string link1, string col2, string info2, string link2, string col3, string info3)
        {
            try
            {
                dataTable = taiLieuDAO.TimTaiLieu(col1, info1, link1, col2, info2, link2, col3, info3);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }
    }
}