
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL{
    /**
     * 
     */
    public class NhanVienDAO {

        /**
         * 
         */
        public NhanVienDAO() {
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
        public DataTable XemNhanVien()
        {
            try
            {
                connection.Open();
                dataTable = new DataTable();
                command = "SELECT * FROM NhanVien";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
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
         * @param nhanVien
         */
        public void ThemNhanVien(NhanVienDTO nhanVien)
        {
            try
            {
                connection.Open();
                command = "INSERT INTO NhanVien VALUES(@MaNhanVien,@HoTen,@ChucVu,@TaiKhoan,@MatKhau,@Quyen)";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaNhanVien", nhanVien.MaNhanVien);
                sqlCommand.Parameters.AddWithValue("HoTen", nhanVien.HoTen);
                sqlCommand.Parameters.AddWithValue("ChucVu", nhanVien.ChucVu);
                sqlCommand.Parameters.AddWithValue("TaiKhoan", nhanVien.TaiKhoan);
                sqlCommand.Parameters.AddWithValue("MatKhau", nhanVien.MatKhau);
                sqlCommand.Parameters.AddWithValue("Quyen", nhanVien.Quyen);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @param nhanVien
         */
        public void SuaNhanVien(NhanVienDTO nhanVien)
        {
            try
            {
                connection.Open();
                command = "UPDATE NhanVien SET HoTen=@HoTen,ChucVu=@ChucVu,TaiKhoan=@TaiKhoan,MatKhau=@MatKhau,Quyen=@Quyen WHERE MaNhanVien=@MaNhanVien";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaNhanVien", nhanVien.MaNhanVien);
                sqlCommand.Parameters.AddWithValue("HoTen", nhanVien.HoTen);
                sqlCommand.Parameters.AddWithValue("ChucVu", nhanVien.ChucVu);
                sqlCommand.Parameters.AddWithValue("TaiKhoan", nhanVien.TaiKhoan);
                sqlCommand.Parameters.AddWithValue("MatKhau", nhanVien.MatKhau);
                sqlCommand.Parameters.AddWithValue("Quyen", nhanVien.Quyen);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
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
                connection.Open();
                command = "DELETE FROM NhanVien WHERE MaNhanVien=@MaNhanVien";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaNhanVien", maNhanVien);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @return
         */
        public DataTable TimNhanVien() {
            // TODO implement here
            return null;
        }

    }
}