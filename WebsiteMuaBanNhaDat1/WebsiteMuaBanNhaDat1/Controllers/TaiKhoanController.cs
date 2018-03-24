using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
using BotDetect.Web.Mvc;
using Facebook;
using System.Configuration;

namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
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
                Session["AnhDaiDien"] = null;
            }
            return RedirectToAction("Index", "Home");
        }
        //-------------------------------------- Login facebook
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });


            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
              //  string Avatar = "https://graph.facebook.com/"+me.id+"/picture";
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;
                string id = me.id;

                var user = new TaiKhoan();
                user.tendangnhap = email;
                user.matkhau = id;
                user.xacnhan_matkhau = id;
                user.email = email;               
                user.maquyen = 2;
                user.anhdaidien = id;
                user.tennguoidung = firstname + " " + middlename + " " + lastname;
                user.ngaydangky= DateTime.Now;
                var dao = new TaiKhoanDAO();
                var resultInsert = dao.ThemTKFB(user);
               
                if (resultInsert > 0)
                {
                    Session["NguoiDung"] = user.tennguoidung;
                    Session["AnhDaiDien"] = user.anhdaidien;
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}