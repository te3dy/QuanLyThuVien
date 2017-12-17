
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    /**
     * 
     */
    public class DocGiaDTO
    {

        /**
         * 
         */
        public DocGiaDTO()
        {
        }

        /**
         * 
         */
        public string MaDocGia;

        /**
         * 
         */
        public string HoTen;

        /**
         * 
         */
        public bool GioiTinh;

        /**
         * 
         */
        public string NgaySinh;

        /**
         * 
         */
        public string DoiTuong;

        /**
         * 
         */
        public string NgayCap;

        /**
         * 
         */
        public string NgayHetHan;

        public DocGiaDTO(string maDocGia, string hoTen, bool gioiTinh, string ngaySinh, string doiTuong, string ngayCap, string ngayHetHan)
        {
            MaDocGia = maDocGia;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DoiTuong = doiTuong;
            NgayCap = ngayCap;
            NgayHetHan = ngayHetHan;
        }
    }
}