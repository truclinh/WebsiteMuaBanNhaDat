using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class QuanLyController : Controller
    {
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        // GET: QuanLy
        public ActionResult Index()
        {
            var da = db.LoaiHinh.OrderBy(n => n.ma_loaihinh).ToList();
            return View(da);
        }
        //-------------------------------------- Menu chính
        public ActionResult MenuPartial()
        {
            var da = db.LoaiHinh.OrderBy(n => n.ma_loaihinh).ToList();
            return PartialView("MenuPartial", da);
        }
        //--------------------------------------Menu item
        public ActionResult MenuItemPartial(int? ma)
        {
            var da = db.NoiDungLoaiHinh.Where(n => n.ma_loaihinh == ma).ToList().OrderBy(n => n.ten_ndloaihinh);
            return PartialView("MenuItemPartial", da);
        }
    }
}