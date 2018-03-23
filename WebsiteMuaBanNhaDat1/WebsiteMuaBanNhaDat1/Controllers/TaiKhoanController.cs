using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
using BotDetect.Web.Mvc;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        public ActionResult DangKy(TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                if (dao.KiemTraTenDN(model.tendangnhap))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.KiemTraEmail(model.email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var tk = new TaiKhoan();
                    tk.tendangnhap = model.tendangnhap;
                    tk.matkhau = model.matkhau;
                    tk.xacnhan_matkhau = model.xacnhan_matkhau;
                    tk.tennguoidung = model.tennguoidung;
                    tk.diachi = model.diachi;
                    tk.email = model.email;
                    tk.dienthoai = model.dienthoai;
                    tk.maquyen = 2;
                    tk.ngaydangky = DateTime.Now;
                    var result = dao.Them(tk);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new TaiKhoan();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }
        //-------------------------------------- Đăng nhập
        public ActionResult DangNhapPartial()
        {
            return PartialView("DangNhapPartial");
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string txtEmail = f["txtEmail"].ToString();
            string txtPass = f["txtPass"].ToString();
            //TaiKhoan kh1 = db.TaiKhoan.SingleOrDefault(n => n.tendangnhap == txtEmail && n.matkhau == txtPass);
            TaiKhoan kh1 = db.TaiKhoan.SingleOrDefault(n => n.email == txtEmail && n.matkhau == txtPass);
            TaiKhoan kh2 = db.TaiKhoan.SingleOrDefault(n => n.email == txtEmail);
            if (kh2 != null && kh2.matkhau != txtPass)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Mật khẩu không đúng!');window.location.href='/Home/Index';</script>");
            }
            else if (kh1 == null)
            // exampleInputPassword2
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Đăng nhập thất bại!');window.location.href='/Home/Index';</script>");
            }
            else if (kh1 != null)
            {
                if (kh1.maquyen == 2)
                {
                    Session["NguoiDung"] = kh1.tennguoidung;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["Admin"] = kh1.tennguoidung;
                    return RedirectToAction("Index", "Home");
                }

            }
            return RedirectToAction("Index", "Home");
        }
        //-------------------------------------- Đăng xuất
        public ActionResult DangXuat()
        {
            if (Session["NguoiDung"] != null)
            {
                Session["NguoiDung"] = null;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}