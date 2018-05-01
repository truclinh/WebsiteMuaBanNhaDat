using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
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
            var model = db.LoaiHinh.OrderBy(n => n.ma_loaihinh).ToList();
            return PartialView("_QuanLyLoaiHinhPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyLoaiHinhPartialAddNew(WebsiteMuaBanNhaDat1.Models.LoaiHinh item)
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
            return PartialView("_QuanLyLoaiHinhPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyLoaiHinhPartialUpdate(WebsiteMuaBanNhaDat1.Models.LoaiHinh item)
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
            return PartialView("_QuanLyLoaiHinhPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyLoaiHinhPartialDelete(System.Int32 ma_loaihinh)
        {
            var model = new object[0];
            if (ma_loaihinh >= 0)
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
            return PartialView("_QuanLyLoaiHinhPartial", model);
        }
    }
}