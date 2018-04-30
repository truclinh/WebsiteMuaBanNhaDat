using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class QuanLyController : Controller
    {
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        // GET: QuanLy
        public ActionResult Index()
        {
            var da = db.LoaiHinh.OrderBy(n => n.ma_loaihinh).Where(n => n.ghichu == "1").ToList();
            return View(da);
        }
        //-------------------------------------- Menu chính
        public ActionResult MenuPartial()
        {
            var da = db.LoaiHinh.OrderBy(n => n.ma_loaihinh).Where(n => n.ghichu == "1").ToList();
            return PartialView("MenuPartial", da);
        }
        //--------------------------------------Menu item
        public ActionResult MenuItemPartial(int? ma)
        {
            var da = db.NoiDungLoaiHinh.Where(n => n.ma_loaihinh == ma).ToList().OrderBy(n => n.ten_ndloaihinh);
            return PartialView("MenuItemPartial", da);
        }
        //-------------------------------------- Xem thêm
        public ActionResult XemThem(int? ma_loaihinh)
        {
            var da = db.NoiDungLoaiHinh.Where(n => n.ma_loaihinh == ma_loaihinh).ToList().OrderBy(n => n.ten_ndloaihinh);
            var da1 = db.LoaiHinh.FirstOrDefault(n => n.ma_loaihinh == ma_loaihinh);
            ViewBag.TenMuc = da1.ten_loaihinh.ToString();
            return View(da);
        }
        //-------------------------------------- Xem thêm
        public ActionResult XemThem1(int? ma_loaihinh, int? ma_ndloaihinh)
        {
            var da = db.NoiDungLoaiHinh.SingleOrDefault(n => n.ma_loaihinh == ma_loaihinh && n.ma_ndloaihinh == ma_ndloaihinh);
            var da1 = db.LoaiHinh.FirstOrDefault(n => n.ma_loaihinh == ma_loaihinh);
            ViewBag.TenMuc = da1.ten_loaihinh.ToString();
            return RedirectToAction("Index",da.tenkhongdau.ToString());
        }
        //-------------------------------------- Nhận xét
        public ActionResult NhanXet(string loai)
        {
            if (loai.Length!=0)
            {
                return RedirectToAction("Index", loai);
            }
            return View();
        }
        //-------------------------------------- Tài khoản
        public ActionResult TaiKhoan()
        {
            return RedirectToAction("Index","QuanLyTaiKhoan");
        }
        //-------------------------------------- Liên hệ
        public ActionResult LienHe()
        {
            return RedirectToAction("Index", "QuanLyLienHe");
        }
        //-------------------------------------- Loại hình
        public ActionResult LoaiHinh()
        {
            return RedirectToAction("Index", "QuanLyLoaiHinh");
        }
        //-------------------------------------- Nội dung
        public ActionResult NoiDungLoaiHinh()
        {
            return RedirectToAction("Index", "QuanLyNoiDungLoaiHinh");
        }
        //-------------------------------------- Bài đăng phong thủy
        public ActionResult BaiDangPhongThuy()
        {
            return RedirectToAction("Index", "QuanLyBaiDangPhongThuy");
        }
        //-------------------------------------- Email đăng ký
        public ActionResult EmailDangKy()
        {
            return RedirectToAction("Index", "QuanLyEmailDangKy");            
        }
    }
}