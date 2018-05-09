using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class CanBanCanChoThueController : Controller
    {
        // GET: CanBanCanChoThue
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        public ActionResult Index()
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            //ViewBag.DMLoaiHinh1 = db.LoaiHinh.ToList().Select(i => new { MaLH = i.ma_loaihinh, TenLH = i.ten_loaihinh });

            ViewBag.DMNDLoaiHinh = new SelectList(db.NoiDungLoaiHinh.ToList().OrderBy(n => n.ma_ndloaihinh), "ma_ndloaihinh", "ten_ndloaihinh");
           // ViewBag.DMNDLoaiHinh1 = db.NoiDungLoaiHinh.ToList().Select(i => new { MaNDLH = i.ma_ndloaihinh, TenNDLH = i.ten_ndloaihinh });

            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ma_tinhtp), "ma_tinhtp", "ten_tinhtp");
           // ViewBag.DMTinhTP1 = db.TinhTP.ToList().Select(i => new { MaTP = i.ma_tinhtp, TenTP = i.ten_tinhtp });

            ViewBag.DMQuanHuyen = new SelectList(db.QuanHuyen.ToList().OrderBy(n => n.ma_quanhuyen), "ma_quanhuyen", "ten_quanhuyen");
          //  ViewBag.DMQuanHuyen1 = db.QuanHuyen.ToList().Select(i => new { MaQH = i.ma_quanhuyen, TenQH = i.ten_quanhuyen });

            ViewBag.DMPhuongXa = new SelectList(db.PhuongXa.ToList().OrderBy(n => n.ma_phuongxa), "ma_phuongxa", "ten_phuongxa");
           // ViewBag.DMPhuongXa1 = db.PhuongXa.ToList().Select(i => new { MaPX = i.ma_phuongxa, TenPX = i.ten_phuongxa });

            ViewBag.DMDuongPho = new SelectList(db.DuongPho.ToList().OrderBy(n => n.ma_duongpho), "ma_duongpho", "ten_duongpho");
         //   ViewBag.DMDuongPho1 = db.DuongPho.ToList().Select(i => new { MaDP = i.ma_duongpho, TenDP = i.ten_duongpho });

            ViewBag.DMDonVi = new SelectList(db.DonVi.ToList().OrderBy(n => n.ma_donvi), "ma_donvi", "ten_donvi");
          //  ViewBag.DMDonVi1 = db.DonVi.ToList().Select(i => new { MaDV = i.ma_donvi, TenDV = i.ten_donvi });


            return View();
        }

        [ValidateInput(false)]
        public ActionResult CanBanCanChoThuePartial()
        {
            ViewBag.DMLoaiHinh1 = db.LoaiHinh.ToList().Select(i => new { MaLH = i.ma_loaihinh, TenLH= i.ten_loaihinh });

            ViewBag.DMNDLoaiHinh1 = db.NoiDungLoaiHinh.ToList().Select(i => new { MaNDLH = i.ma_ndloaihinh, TenNDLH = i.ten_ndloaihinh });

            ViewBag.DMTinhTP1 = db.TinhTP.ToList().Select(i => new { MaTP = i.ma_tinhtp, TenTP = i.ten_tinhtp });

            ViewBag.DMQH1 = db.QuanHuyen.ToList().Select(i => new { MaQH = i.ma_quanhuyen, TenQH = i.ten_quanhuyen});

            ViewBag.DMPX1 = db.PhuongXa.ToList().Select(i => new { MaPX = i.ma_phuongxa, TenPX = i.ten_phuongxa });

            ViewBag.DMDP1 = db.DuongPho.ToList().Select(i => new { MaDP = i.ma_duongpho, TenDP = i.ten_duongpho });

            ViewBag.DMDV1 = db.DonVi.ToList().Select(i => new { MaDV = i.ma_donvi, TenDV = i.ten_donvi });

            var model = db.TinRaoCBCHT.OrderBy(n => n.ngaydang).ToList();
            return PartialView("_CanBanCanChoThuePartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CanBanCanChoThuePartialAddNew(WebsiteMuaBanNhaDat1.Models.TinRaoCBCHT item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_CanBanCanChoThuePartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CanBanCanChoThuePartialUpdate(WebsiteMuaBanNhaDat1.Models.TinRaoCBCHT item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_CanBanCanChoThuePartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CanBanCanChoThuePartialDelete(System.Guid ma_tinrao)
        {
            var model = new object[0];
            if (ma_tinrao != null)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_CanBanCanChoThuePartial", model);
        }
    }
}