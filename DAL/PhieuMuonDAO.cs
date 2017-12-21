
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using System.Data;
namespace DAL{
   
    /**
     * 
     */
    public class PhieuMuonDAO {
       
        SqlCommand command;
        string querry="";

        /**
         * 
         */
        public PhieuMuonDAO() {
        }

        /**
         * 
         */
        private Connection connection = new Connection();

        /**
         * @return
         */
        public DataTable XemHet() {
            DataTable dt = new DataTable();
            
            querry = "select * from PhieuMuon";
            connection.Open();
            command = new SqlCommand(querry, connection.sqlConnection);
            // TODO implement here
            dt.Load(command.ExecuteReader());
            connection.Close();
            return dt;
        }
        public DataTable XemPhieuMuon(string MaDocGia) {
            DataTable dt = new DataTable();
               querry = "select * from PhieuMuon where MaDocGia=@MaDocGia";
             
            connection.Open();
            command = new SqlCommand(querry,connection.sqlConnection);
            command.Parameters.AddWithValue("MaDocGia",MaDocGia);
            // TODO implement here
            dt.Load(command.ExecuteReader());
            connection.Close();
            return dt;
        }

        /**
         * @param phieuMuon
         */
        public void ThemPhieuMuon(PhieuMuonDTO phieuMuon) {
            querry = "insert PhieuMuon values(@MaPhieuMuon,@MaDocGia,@NgayMuon,@MaNhanVien)";
            connection.Open();
            command = new SqlCommand(querry, connection.sqlConnection);
            command.Parameters.AddWithValue("MaPhieuMuon",phieuMuon.MaPhieuMuon);
            command.Parameters.AddWithValue("MaDocGia", phieuMuon.MaDocGia);
            command.Parameters.AddWithValue("NgayMuon", phieuMuon.NgayMuon);
            command.Parameters.AddWithValue("MaNhanVien", phieuMuon.MaNhanVien);
            command.ExecuteNonQuery();
            // TODO implement here

            connection.Close();
            // TODO implement here
        }

        /**
         * @param phieuMuon
         */
        public void SuaPhieuMuon(PhieuMuonDTO phieuMuon) {
            querry = "update PhieuMuon set MaDocGia=@MaDocGia,NgayMuon=@NgayMuon,MaNhanVien=@MaNhanVien where MaPhieuMuon=@MaPhieuMuon";
            connection.Open();
            command = new SqlCommand(querry, connection.sqlConnection);
            command.Parameters.AddWithValue("MaPhieuMuon", phieuMuon.MaPhieuMuon);
            command.Parameters.AddWithValue("MaDocGia", phieuMuon.MaPhieuMuon);
            command.Parameters.AddWithValue("NgayMuon", phieuMuon.NgayMuon);
            command.Parameters.AddWithValue("MaNhanVien", phieuMuon.MaNhanVien);
            command.ExecuteNonQuery();
            // TODO implement here

            connection.Close();
            // TODO implement here
        }

        /**
         * 
         */
        public void XoaPhieuMuon(string MaPhieuMuon) {
            querry = "delete PhieuMuon where MaPhieuMuon=@MaPhieuMuon";
            connection.Open();
            command = new SqlCommand(querry, connection.sqlConnection);
            command.Parameters.AddWithValue("MaPhieuMuon",MaPhieuMuon);
            command.ExecuteNonQuery();
            // TODO implement here

            connection.Close();
            // TODO implement here
        }

        

        /**
         * @return
         */
        public DataTable TimPhieuMuon() {
            // TODO implement here
            return null;
        }

    }
}