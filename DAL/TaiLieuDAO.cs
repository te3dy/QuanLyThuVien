
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
    public class TaiLieuDAO
    {

        /**
         * 
         */
        public TaiLieuDAO()
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
        public DataTable XemTaiLieu()
        {
            try
            {
                connection.Open();
                dataTable = new DataTable();
                command = "SELECT * FROM TaiLieu";
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
         * @param taiLieu
         */
        public void ThemTaiLieu(TaiLieuDTO taiLieu)
        {
            // TODO implement here
            try
            {
                connection.Open();
                command = "INSERT INTO TaiLieu VALUES(@MaTaiLieu,@TenTaiLieu,@MaTheLoai,@SoLuong,@NhaXuatBan,@NamXuatBan,@TacGia)";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaTaiLieu", taiLieu.MaTaiLieu);
                sqlCommand.Parameters.AddWithValue("TenTaiLieu", taiLieu.TenTaiLieu);
                sqlCommand.Parameters.AddWithValue("MaTheLoai", taiLieu.MaTheLoai);
                sqlCommand.Parameters.AddWithValue("SoLuong", taiLieu.SoLuong);
                sqlCommand.Parameters.AddWithValue("NhaXuatBan", taiLieu.NhaXuatBan);
                sqlCommand.Parameters.AddWithValue("NamXuatBan", taiLieu.NamXuatBan);
                sqlCommand.Parameters.AddWithValue("TacGia", taiLieu.TacGia);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @param taiLieu
         */
        public void SuaTaiLieu(TaiLieuDTO taiLieu)
        {
            // TODO implement here
            try
            {
                connection.Open();
                command = "UPDATE TaiLieu SET TenTaiLieu=@TenTaiLieu,MaTheLoai=@MaTheLoai,SoLuong=@SoLuong,NhaXuatBan=@NhaXuatBan,NamSanXuat=@NamSanXuat, TacGia = @TacGia WHERE MaTaiLieu=@MaTaiLieu";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaTaiLieu", taiLieu.MaTaiLieu);
                sqlCommand.Parameters.AddWithValue("TenTaiLieu", taiLieu.TenTaiLieu);
                sqlCommand.Parameters.AddWithValue("MaTheLoai", taiLieu.MaTheLoai);
                sqlCommand.Parameters.AddWithValue("SoLuong", taiLieu.SoLuong);
                sqlCommand.Parameters.AddWithValue("NhaXuatBan", taiLieu.NhaXuatBan);
                sqlCommand.Parameters.AddWithValue("NamXuatBan", taiLieu.NamXuatBan);
                sqlCommand.Parameters.AddWithValue("TacGia", taiLieu.TacGia);
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
        public void XoaTaiLieu(string maTaiLieu)
        {
            // TODO implement here
            try
            {
                connection.Open();
                command = "DELETE FROM TaiLieu WHERE MaTaiLieu=@MaTaiLieu";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaTaiLieu", maTaiLieu);
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
        public DataTable TimTaiLieu(string col, string info)
        {
            return null;
        }

    }
}