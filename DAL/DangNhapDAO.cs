
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
    public class DangNhapDAO {

        /**
         * 
         */
        public DangNhapDAO() {
        }

        /**
         * 
         */
        private Connection connection = new Connection();
        private DataTable dataTable;
        private string command;
        private SqlCommand sqlCommand;
        /**
         * @return
         */
        public DataTable ThongTinDangNhap(string taiKhoan, string matKhau)
        {
            try
            {
                connection.Open();
                dataTable = new DataTable();
                command = "SELECT * FROM NhanVien WHERE TaiKhoan=@TaiKhoan AND MatKhau=@MatKhau";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("TaiKhoan", taiKhoan);
                sqlCommand.Parameters.AddWithValue("MatKhau", matKhau);
                dataTable.Load(sqlCommand.ExecuteReader());
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        /**
         * 
         */
        public void DoiMatKhau(string taiKhoan, string matKhau)
        {
            try
            {
                connection.Open();
                command = "UPDATE NhanVien SET MatKhau=@MatKhau WHERE TaiKhoan=@TaiKhoan";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("TaiKhoan", taiKhoan);
                sqlCommand.Parameters.AddWithValue("MatKhau", matKhau);
                dataTable.Load(sqlCommand.ExecuteReader());
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}