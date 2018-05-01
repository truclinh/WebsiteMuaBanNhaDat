using System;
using System.Collections.Generic;
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
            return View();
        }
        [ValidateInput(false)]
        public ActionResult NX_TinRaoNhaDatPartial()
        {
            var model = db.NhanXet.Where(n => n.ma_baiviet == null && n.ma_tinrao != null).ToList();
            return PartialView("_NX_TinRaoNhaDatPartial", model);
        }
    }
}