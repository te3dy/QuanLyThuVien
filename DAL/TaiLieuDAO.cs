
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
    public class TaiLieuDAO {

        /**
         * 
         */
        public TaiLieuDAO() {
        }

        /**
         * 
         */
        private Connection connection;

        /**
         * @return
         */
        public DataTable XemTaiLieu() {
            // TODO implement here
            return null;
        }

        /**
         * @param taiLieu
         */
        public void ThemTaiLieu(TaiLieuDTO taiLieu) {
            // TODO implement here
        }

        /**
         * @param taiLieu
         */
        public void SuaTaiLieu(TaiLieuDTO taiLieu) {
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