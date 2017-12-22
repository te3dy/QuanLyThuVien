
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
    public class TheLoaiDAO
    {

        /**
         * 
         */
        public TheLoaiDAO()
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
        public DataTable XemTheLoai()
        {
            // TODO implement here
            try
            {
                connection.Open();
                dataTable = new DataTable();
                command = "SELECT * FROM TheLoai";
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
         * @param theLoai
         */
        public void ThemTheLoai(TheLoaiDTO theLoaiDto)
        {
            // TODO implement here
            try
            {
                connection.Open();
                command = "INSERT INTO TheLoai VALUES(@MaTheLoai,@TenTheLoai,@GhiChu)";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaTheLoai", theLoaiDto.MaTheLoai);
                sqlCommand.Parameters.AddWithValue("TenTheLoai", theLoaiDto.TenTheLoai);
                sqlCommand.Parameters.AddWithValue("GhiChu", theLoaiDto.GhiChu);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * @param theLoai
         */
        public void SuaTaiLieu(TheLoaiDTO theLoaiDto)
        {
            try
            {
                connection.Open();
                command = "UPDATE TheLoai SET TenTheLoai=@TenTheLoai, GhiChu=@GhiChu WHERE MaTheLoai=@MaTheLoai";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaTheLoai", theLoaiDto.MaTheLoai);
                sqlCommand.Parameters.AddWithValue("TenTheLoai", theLoaiDto.TenTheLoai);
                sqlCommand.Parameters.AddWithValue("GhiChu", theLoaiDto.GhiChu);
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
        public void XoaTaiLieu(string maTheLoai)
        {
            // TODO implement here
            try
            {
                connection.Open();
                command = "DELETE FROM TheLoai WHERE MaTheLoai=@MaTheLoai";
                sqlCommand = new SqlCommand(command, connection.sqlConnection);
                sqlCommand.Parameters.AddWithValue("MaTheLoai", maTheLoai);
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
        public DataTable TimTaiLieu()
        {
            // TODO implement here
            return null;
        }

    }
}