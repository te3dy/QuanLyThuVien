using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;

namespace BLL
{
    /**
     * 
     */
    public class DocGiaBO
    {

        /**
         * 
         */
        public DocGiaBO()
        {
        }

        /**
         * 
         */
        private DocGiaDAO docGiaDAO = new DocGiaDAO();
        private DataTable dataTable;

        /**
         * @return
         */
        public DataTable XemDocGia()
        {
            try
            {
                dataTable = docGiaDAO.XemDocGia();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        /**
         * @param docGiaDTO
         */
        public void ThemDocGia(DocGiaDTO docGiaDTO)
        {
            try
            {
                docGiaDAO.ThemDocGia(docGiaDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @param docGiaDTO
         */
        public void SuaDocGia(DocGiaDTO docGiaDTO)
        {
            try
            {
                docGiaDAO.SuaDocGia(docGiaDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * 
         */
        public void XoaDocGia(string maDocGia)
        {
            try
            {
                docGiaDAO.XoaDocGia(maDocGia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @return
         */
        public DataTable TimDocGia()
        {
            // TODO implement here
            return null;
        }

    }
}