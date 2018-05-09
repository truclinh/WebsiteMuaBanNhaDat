using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class NhanXetController : Controller
    {
        // GET: NhanXet
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        public ActionResult NhanXet_VoDanh(FormCollection f,Guid? _ma_tinrao,int? _ma_loaihinh)
        {
            string hoten = f["txtHoTen"].ToString();
            string email = f["txtEmail"].ToString();
            string noidung = f["txtNoiDung"].ToString();
            var da = db.LienHe.SingleOrDefault(n => n.ma_tinrao == _ma_tinrao);
            var model = db.NhanXet.Where(n=>n.ma_tinrao==_ma_tinrao).ToList();
            ViewBag.NhanXet = model;
            var url = Url.Action("ChiTiet", "ChiTietTinRao", new { ma_tinrao = _ma_tinrao, ma_loaihinh = _ma_loaihinh });
            var nhom = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == _ma_loaihinh).nhom.ToString();
            if (ModelState.IsValid)
            {
                try
                {
                        NhanXet nx = new NhanXet();
                        nx.ma_tinrao = _ma_tinrao;
                        nx.hoten = hoten;
                        nx.email = email;
                        nx.noidung = noidung;
                        nx.thanhvien = false;
                        nx.ngaydang = DateTime.Now;
                    if (nhom == "CBCHT")
                    {
                        nx.ghichu = "1";
                    }
                    else
                    {
                        nx.ghichu = "2";
                    }
                        db.NhanXet.Add(nx);
                        db.SaveChanges();
                        ViewBag.KetQua = "Đăng ký nhận tin thành công!";
                    //--------------------------------------
                    MailMessage mail = new MailMessage();
                    mail.Subject = "Nhận xét tin rao";
                    mail.From = new MailAddress("thaitruclinh.96@gmail.com");
                    mail.To.Add(da.email);
                    mail.Body = "Anh/Chị " + hoten + " (Email: " + email + ") đã nhận xét tin localhost:44300 " + url.ToString() + " với nội dung: \"" + noidung + "\"";
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    NetworkCredential netCre =
                                     new NetworkCredential("thaitruclinh.96@gmail.com", "ljnh25121996L");
                    smtp.Credentials = netCre;

                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        // Handle exception here 

                    }
                    //-------------------------------------- 


                    return RedirectToAction("ChiTiet", "ChiTietTinRao", new {ma_tinrao=_ma_tinrao ,ma_loaihinh=_ma_loaihinh});
                    //return Json(nx, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult NhanXet_ThanhVien(FormCollection f, Guid? _ma_tinrao, int? _ma_loaihinh)
        {
            string hoten = f["txtHoTen1"].ToString();
            string email = f["txtEmail1"].ToString();
            string noidung = f["txtNoiDung1"].ToString();
            var da = db.LienHe.SingleOrDefault(n => n.ma_tinrao == _ma_tinrao);
            var model = db.NhanXet.Where(n => n.ma_tinrao == _ma_tinrao).ToList();
            ViewBag.NhanXet = model;
            var url = Url.Action("ChiTiet", "ChiTietTinRao", new { ma_tinrao = _ma_tinrao, ma_loaihinh = _ma_loaihinh });
            var nhom = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == _ma_loaihinh).nhom.ToString();

            if (ModelState.IsValid)
            {
                try
                {
                        NhanXet nx = new NhanXet();
                        nx.ma_tinrao = _ma_tinrao;
                        nx.hoten = hoten;
                        nx.email = email;
                        nx.noidung = noidung;
                        nx.thanhvien = true;
                        nx.ngaydang = DateTime.Now;
                    if (nhom == "CBCHT")
                    {
                        nx.ghichu = "1";
                    }
                    else
                    {
                        nx.ghichu = "2";
                    }
                    db.NhanXet.Add(nx);
                        db.SaveChanges();
                    //--------------------------------------
                    MailMessage mail = new MailMessage();
                    mail.Subject = "Nhận xét tin rao";
                    mail.From = new MailAddress("thaitruclinh.96@gmail.com");
                    mail.To.Add(da.email);
                    mail.Body = "Anh/Chị "+hoten + " (Email: "+email+") đã nhận xét tin localhost:44300 " + url.ToString() + " với nội dung: \"" + noidung + "\"";
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    NetworkCredential netCre =
                                     new NetworkCredential("thaitruclinh.96@gmail.com", "ljnh25121996L");
                    smtp.Credentials = netCre;

                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        // Handle exception here 

                    }
                    //-------------------------------------- 
                    ViewBag.KetQua = "Đăng ký nhận tin thành công!";
                    //return Json(nx, JsonRequestBehavior.AllowGet);
                      return RedirectToAction("ChiTiet", "ChiTietTinRao", new { ma_tinrao = _ma_tinrao, ma_loaihinh = _ma_loaihinh });
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Index", "Home");
        }
        //-------------------------------------- Nhận xét bài đăng Phong thủy
        public ActionResult NXBaiDangPT_VoDanh(FormCollection f, int? ma_baiviet)
        {
            string hoten = f["txtHoTen"].ToString();
            string email = f["txtEmail"].ToString();
            string noidung = f["txtNoiDung"].ToString();
            var model = db.NhanXet.Where(n => n.ma_baiviet==ma_baiviet).ToList();
            ViewBag.NhanXet = model;
            var da = db.PhongThuy.SingleOrDefault(n => n.id == ma_baiviet);
            if (ModelState.IsValid)
            {
                try
                {
                    NhanXet nx = new NhanXet();
                    nx.ma_baiviet = ma_baiviet;
                    nx.hoten = hoten;
                    nx.email = email;
                    nx.noidung = noidung;
                    nx.thanhvien = false;
                    nx.ngaydang = DateTime.Now;
                    db.NhanXet.Add(nx);
                    db.SaveChanges();
                    ViewBag.KetQua = "Đăng ký nhận tin thành công!";
                    //--------------------------------------
                    MailMessage mail = new MailMessage();
                    mail.Subject = "Nhận xét tin rao";
                    mail.From = new MailAddress("thaitruclinh.96@gmail.com");
                    mail.To.Add("thaitruclinh151296@gmail.com");
                    mail.Body = "Anh/Chị " + hoten + " (Email: " + email + ") đã nhận xét bài viết \""+da.tieude+"\" với nội dung: \"" + noidung + "\"";
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    NetworkCredential netCre =
                                     new NetworkCredential("thaitruclinh.96@gmail.com", "ljnh25121996L");
                    smtp.Credentials = netCre;

                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        // Handle exception here 

                    }
                    //-------------------------------------- 


                    return RedirectToAction("DocTiep", "Home", new { ma_baiviet = ma_baiviet});
                    //return Json(nx, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult NXBaiDangPT_ThanhVien(FormCollection f, int? ma_baiviet)
        {
            string hoten = f["txtHoTen1"].ToString();
            string email = f["txtEmail1"].ToString();
            string noidung = f["txtNoiDung1"].ToString();
            var model = db.NhanXet.Where(n => n.ma_baiviet == ma_baiviet).ToList();
            ViewBag.NhanXet = model;
            var da = db.PhongThuy.SingleOrDefault(n => n.id == ma_baiviet);

            if (ModelState.IsValid)
            {
                try
                {
                    NhanXet nx = new NhanXet();
                    nx.ma_baiviet = ma_baiviet;
                    nx.hoten = hoten;
                    nx.email = email;
                    nx.noidung = noidung;
                    nx.thanhvien = true;
                    nx.ngaydang = DateTime.Now;
                    db.NhanXet.Add(nx);
                    db.SaveChanges();
                    //--------------------------------------
                    MailMessage mail = new MailMessage();
                    mail.Subject = "Nhận xét tin rao";
                    mail.From = new MailAddress("thaitruclinh.96@gmail.com");
                    mail.To.Add("thaitruclinh151296@gmail.com");
                    mail.Body = "Anh/Chị " + hoten + " (Email: " + email + ") đã nhận xét bài viết \"" + da.tieude + "\" với nội dung: \"" + noidung + "\"";
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    NetworkCredential netCre =
                                     new NetworkCredential("thaitruclinh.96@gmail.com", "ljnh25121996L");
                    smtp.Credentials = netCre;

                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        // Handle exception here 

                    }
                    //-------------------------------------- 
                    ViewBag.KetQua = "Đăng ký nhận tin thành công!";
                    //return Json(nx, JsonRequestBehavior.AllowGet);
                    return RedirectToAction("DocTiep", "Home", new { ma_baiviet = ma_baiviet });
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}