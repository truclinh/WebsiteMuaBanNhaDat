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
    public class QuanLyEmailDangKyController : Controller
    {
        // GET: QuanLyEmailDangKy
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult QuanLyEmailDangKyPartial()
        {
            var model = db.DangKyNhanThongBao.OrderBy(n => n.id).ToList();
            return PartialView("_QuanLyEmailDangKyPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SaveNewDocument(FormCollection f)
        {
            string email = f["txtNew_email"].ToString();
            if (ModelState.IsValid)
            {
                try
                {
                    DangKyNhanThongBao dk = new DangKyNhanThongBao();
                    dk.email = email;
                    dk.ngaydangky = DateTime.Now;
                    db.DangKyNhanThongBao.Add(dk);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "QuanLyEmailDangKy");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SaveEditDocument(FormCollection f)
        {
            int id = int.Parse(f["txtHiddenId"].ToString());
            string email = f["txtNew_email"].ToString();
            var dk = db.DangKyNhanThongBao.SingleOrDefault(n => n.id == id);
            if (ModelState.IsValid)
            {
                try
                {
                    dk.email = email;

                    db.Entry(dk).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "QuanLyEmailDangKy");
        }
        public ActionResult Xoa(int? id)
        {
            var model = db.DangKyNhanThongBao.OrderByDescending(n => n.id).ToList();
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                    {
                        db.DangKyNhanThongBao.Remove(item);
                        db.SaveChanges();
                    }

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Index", "QuanLyEmailDangKy");
        }
    }
}