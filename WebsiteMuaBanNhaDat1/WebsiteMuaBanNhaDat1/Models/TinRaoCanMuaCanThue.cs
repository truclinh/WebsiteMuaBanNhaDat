using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteMuaBanNhaDat1.Models
{
    public class TinRaoCanMuaCanThue
    {
        public System.Guid ma_tinrao { get; set; }
        public string tieude { get; set; }
        public string noidung { get; set; }
        public int? ma_loaihinh { get; set; }
        public int? ma_ndloaihinh { get; set; }
        public string ten_ndloaihinh { get; set; }
        public string ten_tinhtp { get; set; }
        public string ten_quanhuyen { get; set; }
        public string ten_phuongxa { get; set; }
        public string ten_duongpho { get; set; }
        public double? gia_tu { get; set; }
        public double? gia_den { get; set; }
        public string ten_donvi { get; set; }
        public double? dientich_tu { get; set; }
        public double? dientich_den { get; set; }
        public string anh1 { get; set; }
        public string anh2 { get; set; }
        public string anh3 { get; set; }
        public DateTime? ngaydang { get; set; }
        public DateTime? ngayketthuc { get; set; }
    }
}