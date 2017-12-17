
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    /**
     * 
     */
    public class DangNhapBO
    {

        /**
         * 
         */
        public DangNhapBO()
        {
        }

        /**
         * 
         */
        private DangNhapDAO dangNhapDAO = new DangNhapDAO();
        private DataTable dataTable;
        /**
         * @return
         */
        public bool XacNhanDangNhap(string taiKhoan, string matKhau)
        {
            bool flag = false;
            dataTable = ThongTinDangNhap(taiKhoan, matKhau);
            int row = dataTable.Rows.Count;
            if (row == 1)
            {
                flag = true;
            }
            return flag;
        }

        public DataTable ThongTinDangNhap(string taiKhoan, string matKhau)
        {
            try
            {
                dataTable = dangNhapDAO.ThongTinDangNhap(taiKhoan, matKhau);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }
        /**
         * @return
         */
        public string Quyen(string taiKhoan, string matKhau)
        {
            dataTable = ThongTinDangNhap(taiKhoan, matKhau);
            string quyen = dataTable.Rows[0]["Quyen"].ToString();
            return quyen;
        }

        /**
         * 
         */
        public void DoiMatKhau(string taiKhoan, string matKhau)
        {
            dangNhapDAO.DoiMatKhau(taiKhoan, matKhau);
        }

    }
}