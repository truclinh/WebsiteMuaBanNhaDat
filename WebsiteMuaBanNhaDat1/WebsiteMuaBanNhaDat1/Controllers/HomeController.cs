using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class HomeController : Controller
    {
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        // GET: Home
        public ActionResult Index()
       {
            //ViewBag.TinRaoNoiBat = db.TinRaoCBCHT.Take(5).ToList();
            ViewBag.TinRaoNoiBat = (from cb in db.TinRaoCBCHT
                         join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                         join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp                    
                         join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                           where (cb.ma_tinhtp==tp.ma_tinhtp &&  tp.ma_tinhtp==qh.ma_tinhtp && cb.ma_donvi==dv.ma_donvi &&cb.ma_quanhuyen==qh.ma_quanhuyen )                   
                         select new TinRao
                         {
                             ma_tinrao = cb.ma_tinrao,
                             ma_loaihinh=cb.ma_loaihinh,
                             tieude = cb.tieude,
                            ten_tinhtp = tp.ten_tinhtp,
                            ten_quanhuyen = qh.ten_quanhuyen,
                             so_phongngu = cb.so_phongngu,
                             so_phongkhach = cb.so_phongkhach,
                             so_nhabep = cb.so_nhabep,
                             so_toilet = cb.so_toilet,
                             gia = cb.gia,
                             anh1=cb.anh1,
                            ten_donvi=dv.ten_donvi,
                            ngaydang=cb.ngaydang
                         }
                           ).ToList();
            return View();
        }
        //--------------------------------------Menu Nhà đất bán
         public ActionResult NhaDatBan_MenuPartial()
        {
            var da = db.NoiDungLoaiHinh.Where(n => n.ma_loaihinh == 1).ToList().OrderBy(n => n.ten_ndloaihinh); ;
            return PartialView("NhaDatBan_MenuPartial",da);
        }
        //-------------------------------------- Menu Nhà đất cho thuê
        public ActionResult NhaDatChoThue_MenuPartial()
        {
            var da = db.NoiDungLoaiHinh.Where(n => n.ma_loaihinh == 2).ToList().OrderBy(n => n.ten_ndloaihinh); ;
            return PartialView("NhaDatBan_MenuPartial", da);
        }
        //-------------------------------------- Menu Cần mua
        public ActionResult CanMua_MenuPartial()
        {
            var da = db.NoiDungLoaiHinh.Where(n => n.ma_loaihinh == 3).ToList().OrderBy(n => n.ten_ndloaihinh); ;
            return PartialView("NhaDatBan_MenuPartial", da);
        }
              //-------------------------------------- Menu Cần thuê
        public ActionResult CanThue_MenuPartial()
        {
            var da = db.NoiDungLoaiHinh.Where(n => n.ma_loaihinh == 4).ToList().OrderBy(n => n.ten_ndloaihinh); ;
            return PartialView("NhaDatBan_MenuPartial", da);
        }
    }
}