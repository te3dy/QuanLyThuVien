
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
    public class TheLoaiBO {

        /**
         * 
         */
        public TheLoaiBO() {
        }

        /**
         * 
         */
        private TheLoaiDAO theLoaiDAO = new TheLoaiDAO();
        private DataTable dataTable;

        /**
         * @return
         */
        public DataTable XemTheLoai() {
            // TODO implement here
            try
            {
                dataTable = theLoaiDAO.XemTheLoai();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        /**
         * @param theLoaiDTO
         */
        public void ThemTheLoai(TheLoaiDTO theLoaiDTO) {
            // TODO implement here
            try
            {
                theLoaiDAO.ThemTheLoai(theLoaiDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @param theLoaiDTO
         */
        public void SuaTheLoai(TheLoaiDTO theLoaiDTO) {
            // TODO implement here
            try
            {
                theLoaiDAO.SuaTaiLieu(theLoaiDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * 
         */
        public void XoaTheLoai(string maTheLoai) {
            // TODO implement here
            try
            {
                theLoaiDAO.XoaTaiLieu(maTheLoai);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @return
         */
        public DataTable TimTheLoai() {
            // TODO implement here
            return null;
        }

    }
}