using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class QuanLyNoiDungLoaiHinhController : Controller
    {
        // GET: QuanLyNoiDungLoaiHinh
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        public ActionResult Index()
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.Where(n => n.comenucon == true).ToList().OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            return View();
        }

        [ValidateInput(false)]
        public ActionResult QuanLyNoiDungLoaiHinhPartial()
        {
            ViewBag.DMLoaiHinh1 = db.LoaiHinh.Where(n=>n.comenucon==true).ToList().OrderBy(n => n.ma_loaihinh).Select(i => new { MaLH = i.ma_loaihinh, TenLH = i.ten_loaihinh });
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.Where(n => n.comenucon == true).ToList().OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");

            var model = db.NoiDungLoaiHinh.OrderBy(n => n.ma_loaihinh).ToList();
            return PartialView("_QuanLyNoiDungLoaiHinhPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SaveNewDocument(FormCollection f)
        {
            string ten_ndloaihinh = f["txtNew_ten_ndloaihinh"].ToString();
            string tenkhongdau = f["txtNew_tenkhongdau"].ToString();
            int ma_loaihinh =int.Parse(f["txtNew_ma_loaihinh"].ToString());
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.Where(n => n.comenucon == true).ToList().OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            if (ModelState.IsValid)
            {
                try
                {
                    NoiDungLoaiHinh nd = new NoiDungLoaiHinh();
                    nd.ten_ndloaihinh = ten_ndloaihinh;
                    nd.tenkhongdau = tenkhongdau;
                    nd.ma_loaihinh = ma_loaihinh;

                    db.NoiDungLoaiHinh.Add(nd);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "QuanLyNoiDungLoaiHinh");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SaveEditDocument(FormCollection f)
        {
            int ma_ndloaihinh = int.Parse(f["txtHiddenId"].ToString());
            string ten_ndloaihinh = f["txt_ten_ndloaihinh"].ToString();
            string tenkhongdau = f["txt_tenkhongdau"].ToString();
            int ma_loaihinh = int.Parse(f["txt_ma_loaihinh"].ToString());
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.Where(n => n.comenucon == true).ToList().OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            var nd = db.NoiDungLoaiHinh.SingleOrDefault(n => n.ma_ndloaihinh == ma_ndloaihinh);
            if (ModelState.IsValid)
            {
                try
                {
                    nd.ten_ndloaihinh = ten_ndloaihinh;
                    nd.tenkhongdau = tenkhongdau;
                    nd.ma_loaihinh = ma_loaihinh;

                    db.Entry(nd).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "QuanLyNoiDungLoaiHinh");
        }
        public ActionResult Xoa(int? id)
        {
            var model = db.NoiDungLoaiHinh.OrderByDescending(n => n.ma_ndloaihinh).ToList();
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ma_ndloaihinh == id);
                    if (item != null)
                    {
                        db.NoiDungLoaiHinh.Remove(item);
                        db.SaveChanges();
                    }

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Index", "QuanLyNoiDungLoaiHinh");
        }
    }
}