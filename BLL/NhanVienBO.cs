
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
    public class NhanVienBO
    {

        /**
         * 
         */
        public NhanVienBO()
        {
        }

        /**
         * 
         */
        private NhanVienDAO nhanVienDAO = new NhanVienDAO();
        private DataTable dataTable;
        /**
         * @return
         */
        public DataTable XemNhanVien()
        {
            try
            {
                dataTable = nhanVienDAO.XemNhanVien();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        /**
         * @param nhanVienDTO
         */
        public void ThemNhanVien(NhanVienDTO nhanVienDTO)
        {
            try
            {
                nhanVienDAO.ThemNhanVien(nhanVienDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @param nhanVienDTO
         */
        public void SuaNhanVien(NhanVienDTO nhanVienDTO)
        {
            try
            {
                nhanVienDAO.SuaNhanVien(nhanVienDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * 
         */
        public void XoaNhanVien(string maNhanVien)
        {
            try
            {
                nhanVienDAO.XoaNhanVien(maNhanVien);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @return
         */
        public DataTable TimNhanVien()
        {
            // TODO implement here
            return null;
        }

    }
}