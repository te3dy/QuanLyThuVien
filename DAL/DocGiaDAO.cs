
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    /**
     * 
     */
    public class DocGiaDAO
    {

        /**
         * 
         */
        public DocGiaDAO()
        {
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
        public DataTable XemDocGia()
        {
            try
            {
                connection.Open();
                dataTable = new DataTable();
                command = "SELECT * FROM DocGia";
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
         * @param docGia
         */
        public void ThemDocGia(DocGiaDTO docGia)
        {
            try
            {
                connection.Open();
                command = "INSERT INTO DocGia VALUES(@MaDocGia,@HoTen,@GioiTinh,@NgaySinh,@DoiTuong,@NgayCap,@NgayHetHan)";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaDocGia", docGia.MaDocGia);
                sqlCommand.Parameters.AddWithValue("HoTen", docGia.HoTen);
                sqlCommand.Parameters.AddWithValue("GioiTinh", docGia.GioiTinh);
                sqlCommand.Parameters.AddWithValue("NgaySinh", docGia.NgaySinh);
                sqlCommand.Parameters.AddWithValue("DoiTuong", docGia.DoiTuong);
                sqlCommand.Parameters.AddWithValue("NgayCap", docGia.NgayCap);
                sqlCommand.Parameters.AddWithValue("NgayHetHan", docGia.NgayHetHan);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @param docGia
         */
        public void SuaDocGia(DocGiaDTO docGia)
        {
            try
            {
                connection.Open();
                command = "UPDATE DocGia SET HoTen=@HoTen,GioiTinh=@GioiTinh,NgaySinh=@NgaySinh,DoiTuong=@DoiTuong,NgayCap=@NgayCap,NgayHetHan=@NgayHetHan WHERE MaDocGia=@MaDocGia";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaDocGia", docGia.MaDocGia);
                sqlCommand.Parameters.AddWithValue("HoTen", docGia.HoTen);
                sqlCommand.Parameters.AddWithValue("GioiTinh", docGia.GioiTinh);
                sqlCommand.Parameters.AddWithValue("NgaySinh", docGia.NgaySinh);
                sqlCommand.Parameters.AddWithValue("DoiTuong", docGia.DoiTuong);
                sqlCommand.Parameters.AddWithValue("NgayCap", docGia.NgayCap);
                sqlCommand.Parameters.AddWithValue("NgayHetHan", docGia.NgayHetHan);
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
        public void XoaDocGia(string maDocGia)
        {
            try
            {
                connection.Open();
                command = "DELETE FROM DocGia WHERE MaDocGia=@MaDocGia";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaDocGia", maDocGia);
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
        public DataTable TimDocGia()
        {
            // TODO implement here
            return null;
        }

    }
}