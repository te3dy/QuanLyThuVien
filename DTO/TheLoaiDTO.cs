
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO{
    /**
     * 
     */
    public class TheLoaiDTO {

        /**
         * 
         */
        public TheLoaiDTO() {
        }

        /**
         * 
         */
        public TheLoaiDTO(string maTheLoai, string tenTheLoai, string ghiChu)
        {
            MaTheLoai = maTheLoai;
            TenTheLoai = tenTheLoai;
            GhiChu = ghiChu;
        }
        public string MaTheLoai;

        /**
         * 
         */
        public string TenTheLoai;

        /**
         * 
         */
        public string GhiChu;

    }
}