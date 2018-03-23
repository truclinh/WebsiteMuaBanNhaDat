using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Models
{
    public class TaiKhoanDAO
    {
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        //-------------------------------------- Kiểm tra tài khoản tồn tại
        public bool KiemTraTenDN(string tendangnhap)
        {
            return db.TaiKhoan.Count(x => x.tendangnhap == tendangnhap) > 0;
        }
        //-------------------------------------- Kiểm tra email tồn tại
        public bool KiemTraEmail(string email)
        {
            return db.TaiKhoan.Count(x => x.email == email) > 0;
        }
        //-------------------------------------- Thêm dữ liệu khi Đăng ký
        public int? Them(TaiKhoan tk)
        {
            db.TaiKhoan.Add(tk);
            db.SaveChanges();
            return tk.ma_taikhoan;
        }
    }
}