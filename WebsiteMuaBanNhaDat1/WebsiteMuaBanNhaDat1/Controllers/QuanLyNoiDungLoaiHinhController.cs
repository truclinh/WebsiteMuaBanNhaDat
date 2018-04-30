using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
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
            return View();
        }

        [ValidateInput(false)]
        public ActionResult QuanLyNoiDungLoaiHinhPartial()
        {
            var model = db.NoiDungLoaiHinh.OrderBy(n => n.ma_loaihinh).ToList();
            return PartialView("_QuanLyNoiDungLoaiHinhPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyNoiDungLoaiHinhPartialAddNew(WebsiteMuaBanNhaDat1.Models.NoiDungLoaiHinh item)
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
            return PartialView("_QuanLyNoiDungLoaiHinhPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyNoiDungLoaiHinhPartialUpdate(WebsiteMuaBanNhaDat1.Models.NoiDungLoaiHinh item)
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
            return PartialView("_QuanLyNoiDungLoaiHinhPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyNoiDungLoaiHinhPartialDelete(System.Int32 ma_ndloaihinh)
        {
            var model = new object[0];
            if (ma_ndloaihinh >= 0)
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
            return PartialView("_QuanLyNoiDungLoaiHinhPartial", model);
        }
    }
}