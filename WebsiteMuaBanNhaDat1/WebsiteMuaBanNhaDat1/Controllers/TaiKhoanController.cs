using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
using BotDetect.Web.Mvc;
using Facebook;
using System.Configuration;
using System.IO;

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
                    tk.anhdaidien = "login.png";
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
                    Session["TaiKhoan"] = kh1;
                    Session["MaTK"] = kh1.ma_taikhoan;
                    Session["NguoiDung"] = kh1.tennguoidung;
                    Session["TenDangNhap"] = kh1.tendangnhap;
                    Session["Email"] = kh1.email;
                    Session["LoaiTK"] = kh1.ghichu;
                    Session["AnhDaiDien"] = kh1.anhdaidien;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["TaiKhoan"] = kh1;
                    Session["MaTK"] = kh1.ma_taikhoan;
                    Session["NguoiDung"] = kh1.tennguoidung;
                    Session["TenDangNhap"] = kh1.tendangnhap;
                    Session["Email"] = kh1.email;
                    Session["LoaiTK"] = kh1.ghichu;
                    Session["AnhDaiDien"] = kh1.anhdaidien;
                    return RedirectToAction("Index", "QuanLy");
                }

            }
            return RedirectToAction("Index", "Home");
        }
        //-------------------------------------- Đăng xuất
        public ActionResult DangXuat()
        {
            if (Session["TaiKhoan"] != null)
            {
                Session["TaiKhoan"] = null;
                Session["MaTK"] = null;
                Session["NguoiDung"] = null;
                Session["TenDangNhap"] = null;
                Session["Email"] = null;
                Session["LoaiTK"] = null;
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
                user.ngaydangky = DateTime.Now;
                var dao = new TaiKhoanDAO();
                var resultInsert = dao.ThemTKFB(user);

                if (resultInsert > 0)
                {
                    Session["TaiKhoan"] = user;
                    Session["MaTK"] = user.ma_taikhoan;
                    Session["NguoiDung"] = user.tennguoidung;
                    Session["AnhDaiDien"] = user.anhdaidien;
                    Session["Email"] = user.email;
                    Session["LoaiTK"] = user.ghichu;
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult HinhDaiDien(int? id)
        {
            var hinh = db.TaiKhoan.SingleOrDefault(n => n.ma_taikhoan == id).anhdaidien.ToString();
            return PartialView("HinhDaiDien", hinh);
        }
        public ActionResult Ten(int? id)
        {
            var ten = db.TaiKhoan.SingleOrDefault(n => n.ma_taikhoan == id).tennguoidung.ToString();
            return PartialView("Ten", ten);
        }
        //-------------------------------------- 
        //**************************************** 
        //-------------------------------------- 
        public ActionResult ThongTin(int? id)
        {
            if (Session["TaiKhoan"] != null)
            {
                var da = db.TaiKhoan.SingleOrDefault(n => n.ma_taikhoan == id);
                return View(da);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        //****************************************

        //Chỉnh sửa thông tin tài khoản
        //**************************************** 
        [HttpGet]
        public ActionResult ChinhSuaThongTin(int? id)
        {
            if (Session["TaiKhoan"] != null)
            {
                //lấy đối tượng tài khoản theo mã
                TaiKhoan tk = db.TaiKhoan.SingleOrDefault(n => n.ma_taikhoan == id);
                if (tk == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                return View(tk);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSuaThongTin(HttpPostedFileBase anhdaidien, FormCollection f)
        {
            int mataikhoan = int.Parse(f["ma_taikhoan"].ToString());
            string tennguoidung = f["tennguoidung"].ToString();
            string tendangnhap = f["tendangnhap"].ToString();
            string matkhau = f["matkhau"].ToString();
            var tk = db.TaiKhoan.SingleOrDefault(n => n.ma_taikhoan == mataikhoan);
            if (ModelState.IsValid)
            {
                tk.tennguoidung = tennguoidung;
                tk.tendangnhap = tendangnhap;
                tk.matkhau = matkhau;
                tk.xacnhan_matkhau = matkhau;
                if (anhdaidien != null && anhdaidien.ContentLength > 0)
                //-------------------------------------- 
                {
                    string fileName = Path.GetFileNameWithoutExtension(anhdaidien.FileName);
                    string extension = Path.GetExtension(anhdaidien.FileName);
                    fileName = fileName + DateTime.Now.ToString("ddMMyyyy") + extension;
                    tk.anhdaidien = fileName.ToString();
                    fileName = Path.Combine(Server.MapPath("~/Content/images1/login/"), fileName);
                    anhdaidien.SaveAs(fileName);
                }
                else
                {
                    string anhdaidien1 = f["oldanhdaidien"].ToString();
                    tk.anhdaidien = anhdaidien1;
                }
                db.Entry(tk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "QuanLy");
            }
            //Thêm vào cơ sở dữ liệu
            return View();
        }
        //**************************************** 
        //Đổi mật khẩu
        //**************************************** 
        [HttpGet]
        public ActionResult DoiMatKhau(int? id)
        {
            if (Session["TaiKhoan"] != null)
            {
                //lấy đối tượng tài khoản theo mã
                TaiKhoan tk = db.TaiKhoan.SingleOrDefault(n => n.ma_taikhoan == id);
                if (tk == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                return View(tk);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DoiMatKhau(FormCollection f)
        {
            int mataikhoan = int.Parse(f["ma_taikhoan"].ToString());
            string tennguoidung = f["tennguoidung"].ToString();
            string tendangnhap = f["tendangnhap"].ToString();
            string matkhau = f["matkhaumoi"].ToString();
            string anhdaidien = f["anhdaidien"].ToString();
            string diachi = f["diachi"].ToString();
            int maquyen = int.Parse(f["maquyen"].ToString());
            string email = f["email"].ToString();
            string dienthoai = f["dienthoai"].ToString();

            var tk = db.TaiKhoan.SingleOrDefault(n => n.ma_taikhoan == mataikhoan);
            if (ModelState.IsValid)
            {
                tk.tennguoidung = tennguoidung;
                tk.tendangnhap = tendangnhap;
                tk.matkhau = matkhau;
                tk.xacnhan_matkhau = matkhau;
                tk.anhdaidien = anhdaidien;
                tk.diachi = diachi;
                tk.maquyen = maquyen;
                tk.email = email;
                tk.dienthoai = dienthoai;
                db.Entry(tk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.ThongBao = "Đổi mật khẩu thành công!";
                return View();
            }
           
            //Thêm vào cơ sở dữ liệu
            return View();
        }
        //**************************************** 
    }
}