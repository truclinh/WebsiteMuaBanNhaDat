using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class TinRaoNhaDatController : Controller
    {
        // GET: TinRaoNhaDat
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        public ActionResult Index()
        {
            ViewBag.TinRao = new SelectList(db.TinRaoCBCHT.ToList().OrderBy(n => n.ma_tinrao), "ma_tinrao", "tieude");
            ViewBag.XacNhan = new SelectList(db.XacNhan.ToList().OrderBy(n => n.id), "noidung", "ten");

            return View();
        }
        [ValidateInput(false)]
        public ActionResult NX_TinRaoNhaDatPartial()
        {
            ViewBag.TinRao = new SelectList(db.TinRaoCBCHT.ToList().OrderBy(n => n.ma_tinrao), "ma_tinrao", "tieude");
            ViewBag.XacNhan = new SelectList(db.XacNhan.ToList().OrderBy(n => n.id), "noidung", "ten");

            ViewBag.TinRao1 = db.TinRaoCBCHT.ToList().OrderBy(n => n.ma_tinrao).Select(i => new { MaTR = i.ma_tinrao, TenTR = i.tieude });
            ViewBag.XacNhan1 = db.XacNhan.ToList().OrderBy(n => n.id).Select(i => new { NoiDung = i.noidung, Ten = i.ten });

            var model = db.NhanXet.Where(n => n.ma_baiviet == null && n.ma_tinrao != null ).OrderByDescending(n=>n.ngaydang).ToList();
            return PartialView("_NX_TinRaoNhaDatPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SaveNewDocument(FormCollection f)
        {
            ViewBag.TinRao = new SelectList(db.TinRaoCBCHT.ToList().OrderBy(n => n.ma_tinrao), "ma_tinrao", "tieude");
            ViewBag.XacNhan = new SelectList(db.XacNhan.ToList().OrderBy(n => n.id), "noidung", "ten");

            Guid matinrao = Guid.Parse(f["txtNew_ma_tinrao"].ToString());
            string hoten = f["txtNew_hoten"].ToString();
            string email = f["txtNew_email"].ToString();
            string noidung = f["txtNew_noidung"].ToString();
            bool thanhvien = bool.Parse(f["txtNew_thanhvien"].ToString());

            if (ModelState.IsValid)
            {
                try
                {
                    NhanXet nx = new NhanXet();
                    nx.ma_tinrao = matinrao;
                    nx.hoten = hoten;
                    nx.email = email;
                    nx.noidung = noidung;
                    nx.thanhvien = thanhvien;
                    nx.ngaydang = DateTime.Now;

                    db.NhanXet.Add(nx);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "TinRaoNhaDat");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SaveEditDocument(FormCollection f)
        {
            ViewBag.TinRao = new SelectList(db.TinRaoCBCHT.ToList().OrderBy(n => n.ma_tinrao), "ma_tinrao", "tieude");
            ViewBag.XacNhan = new SelectList(db.XacNhan.ToList().OrderBy(n => n.id), "noidung", "ten");

            int id = int.Parse(f["txtHiddenId"].ToString());
            Guid matinrao = Guid.Parse(f["txt_ma_tinrao"].ToString());
            string hoten = f["txt_hoten"].ToString();
            string email = f["txt_email"].ToString();
            string noidung = f["txt_noidung"].ToString();
            bool thanhvien = bool.Parse(f["txt_thanhvien"].ToString());

            var nx = db.NhanXet.SingleOrDefault(n => n.id == id);
            if (ModelState.IsValid)
            {
                try
                {
                    nx.ma_tinrao = matinrao;
                    nx.hoten = hoten;
                    nx.email = email;
                    nx.noidung = noidung;
                    nx.thanhvien = thanhvien;

                    db.Entry(nx).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "TinRaoNhaDat");
        }
        public ActionResult Xoa(int? id)
        {
            var model = db.NhanXet.OrderByDescending(n => n.id).ToList();
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                    {
                        db.NhanXet.Remove(item);
                        db.SaveChanges();
                    }

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Index", "TinRaoNhaDat");
        }
    }
}