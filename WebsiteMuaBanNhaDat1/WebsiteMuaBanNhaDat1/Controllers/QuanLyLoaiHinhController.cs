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
    public class QuanLyLoaiHinhController : Controller
    {
        // GET: QuanLyLoaiHinh
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult QuanLyLoaiHinhPartial()

        {
            var model = db.LoaiHinh.OrderByDescending(n => n.ma_loaihinh).ToList();
            return PartialView("_QuanLyLoaiHinhPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SaveNewDocument(FormCollection f)
        {
            string tenloaihinh = f["txtNew_ten_loaihinh"].ToString();
            string nhom = f["txtNew_nhom"].ToString();
            bool comenucon =Boolean.Parse(f["txtNew_comenucon"].ToString());
            string tenkhongdau = f["txtNew_tenkhongdau"].ToString();
            if (ModelState.IsValid)
            {
                try
                {
                    LoaiHinh lh = new LoaiHinh();
                    lh.ten_loaihinh = tenloaihinh;
                    lh.nhom = nhom;
                    lh.comenucon = comenucon;
                    lh.tenkhongdau = tenkhongdau;

                    db.LoaiHinh.Add(lh);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "QuanLyLoaiHinh");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SaveEditDocument(FormCollection f)
        {
            int maloaihinh = int.Parse(f["txtHiddenId"].ToString());
            string tenloaihinh = f["txt_ten_loaihinh"].ToString();
            string nhom = f["txt_nhom"].ToString();
            bool comenucon = Boolean.Parse(f["txt_comenucon"].ToString());
            string tenkhongdau = f["txt_tenkhongdau"].ToString();
            var lh = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == maloaihinh);

            if (ModelState.IsValid)
            {
                try
                {
                    lh.ten_loaihinh = tenloaihinh;
                    lh.nhom = nhom;
                    lh.comenucon = comenucon;
                    lh.tenkhongdau = tenkhongdau;

                    db.Entry(lh).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "QuanLyLoaiHinh");
        }
        public ActionResult Xoa(int? id)
        {
            var model = db.LoaiHinh.OrderByDescending(n => n.ma_loaihinh).ToList();
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ma_loaihinh == id);
                    if (item != null)
                    {
                        db.LoaiHinh.Remove(item);
                        db.SaveChanges();
                    }

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Index", "QuanLyLoaiHinh");
        }
    }
}