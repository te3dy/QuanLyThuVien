
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
    public class PhieuMuonChiTietDAO
    {

        /**
         * 
         */
        public PhieuMuonChiTietDAO()
        {
        }

        /**
         * 
         */
        private Connection connection = new Connection();

        private SqlCommand command;
        string querry = "";
        /**
         * @return
         */
        public DataTable XemPhieuMuonChiTiet(string MaPhieuMuon)
        {
            DataTable dt = new DataTable();
            querry = "select * from PhieuMuonChiTieu where MaPhieuMuon=@MaPhieuMuon";
            connection.Open();
            command = new SqlCommand(querry, connection.sqlConnection);
            command.Parameters.AddWithValue("MaPhieuMuon", MaPhieuMuon);
            dt.Load(command.ExecuteReader());
            connection.Close();
            return dt;
        }

        /**
         * @param phieuMuonChiTiet
         */
        public void ThemPhieuMuonChiTiet(PhieuMuonChiTietDTO phieuMuonChiTiet)
        {
            querry = "insert PhieuMuonChiTieu values(@MaPhieuMuon,@MaTaiLieu,@SoLuongMuon,@NgayTra)";
            connection.Open();
            command = new SqlCommand(querry, connection.sqlConnection);
            command.Parameters.AddWithValue("MaPhieuMuon", phieuMuonChiTiet.MaPhieuMuon);
            command.Parameters.AddWithValue("MaTaiLieu", phieuMuonChiTiet.MaSach);
            command.Parameters.AddWithValue("SoLuongMuon", phieuMuonChiTiet.SoLuongMuon);
            command.Parameters.AddWithValue("NgayTra", phieuMuonChiTiet.NgayTra);
            command.ExecuteNonQuery();
            connection.Close();
            // TODO implement here
            // TODO implement here
        }

        /**
         * @param phieuMuonChiTiet
         */
        public void SuaPhieuMuonChiTiet(PhieuMuonChiTietDTO phieuMuonChiTiet)
        {
            querry = "update PhieuMuonChiTieu set MaTaiLieu=@MaTaiLieu,SoLuongMuon=@SoLuongMuon,NgayTra=@NgayTra where MaPhieuMuon=@MaPhieuMuon";
            connection.Open();
            command = new SqlCommand(querry, connection.sqlConnection);
            command.Parameters.AddWithValue("MaPhieuMuon", phieuMuonChiTiet.MaPhieuMuon);
            command.Parameters.AddWithValue("MaTaiLieu", phieuMuonChiTiet.MaSach);
            command.Parameters.AddWithValue("SoLuongMuon", phieuMuonChiTiet.SoLuongMuon);
            command.Parameters.AddWithValue("NgayTra", phieuMuonChiTiet.NgayTra);
            command.ExecuteNonQuery();
            // TODO implement here

            connection.Close();
            // TODO implement here
            // TODO implement here
        }

        /**
         * 
         */
        public void XoaPhieuMuonChiTiet(string MaPhieuMuon)
        {
            querry = "delete PhieuMuonChiTieu where MaPhieuMuon=@MaPhieuMuon ";
            connection.Open();
            command = new SqlCommand(querry, connection.sqlConnection);
            command.Parameters.AddWithValue("MaPhieuMuon", MaPhieuMuon);
            command.ExecuteNonQuery();
            // TODO implement here
            connection.Close();
            // TODO implement here
        }

        /**
         * @return
         */
        public DataTable TimPhieuMuonChiTiet()
        {
            // TODO implement here
            return null;
        }

    }
}