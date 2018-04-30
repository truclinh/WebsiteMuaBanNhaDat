using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
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
        public ActionResult QuanLyEmailDangKyPartialAddNew(WebsiteMuaBanNhaDat1.Models.DangKyNhanThongBao item)
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
            return PartialView("_QuanLyEmailDangKyPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyEmailDangKyPartialUpdate(WebsiteMuaBanNhaDat1.Models.DangKyNhanThongBao item)
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
            return PartialView("_QuanLyEmailDangKyPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyEmailDangKyPartialDelete(System.Int32 id)
        {
            var model = new object[0];
            if (id >= 0)
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
            return PartialView("_QuanLyEmailDangKyPartial", model);
        }
    }
}