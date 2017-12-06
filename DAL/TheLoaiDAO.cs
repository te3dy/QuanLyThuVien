
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAL
{
    /**
     * 
     */
    public class TheLoaiDAO {

        /**
         * 
         */
        public TheLoaiDAO() {
        }

        /**
         * 
         */
        private Connection connection;

        /**
         * @return
         */
        public DataTable XemTheLoai() {
            // TODO implement here
            return null;
        }

        /**
         * @param theLoai
         */
        public void ThemTheLoai(TheLoaiDTO theLoai) {
            // TODO implement here
        }

        /**
         * @param theLoai
         */
        public void SuaTaiLieu(TheLoaiDTO theLoai) {
            // TODO implement here
        }

        /**
         * 
         */
        public void XoaTaiLieu() {
            // TODO implement here
        }

        /**
         * @return
         */
        public DataTable TimTaiLieu() {
            // TODO implement here
            return null;
        }

    }
}