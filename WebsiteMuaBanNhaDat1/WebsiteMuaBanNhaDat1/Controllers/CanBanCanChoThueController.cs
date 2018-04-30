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
            return View();
        }

        [ValidateInput(false)]
        public ActionResult CanBanCanChoThuePartial()
        {
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