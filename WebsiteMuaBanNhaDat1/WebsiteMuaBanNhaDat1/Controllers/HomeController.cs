using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class HomeController : Controller
    {
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        // GET: Home
        //-------------------------------------- ViewBag 
        public void ViewBagData()
        {
            ViewBag.TinRaoCBCHTNoiBat = (from cb in db.TinRaoCBCHT
                                         join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                                         join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                                         join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                                         where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp && cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen)
                                         select new TinRao
                                         {
                                             ma_tinrao = cb.ma_tinrao,
                                             ma_loaihinh = cb.ma_loaihinh,
                                             tieude = cb.tieude,
                                             ten_tinhtp = tp.ten_tinhtp,
                                             ten_quanhuyen = qh.ten_quanhuyen,
                                             so_phongngu = cb.so_phongngu,
                                             so_phongkhach = cb.so_phongkhach,
                                             so_nhabep = cb.so_nhabep,
                                             so_toilet = cb.so_toilet,
                                             gia = cb.gia,
                                             anh1 = cb.anh1,
                                             ten_donvi = dv.ten_donvi,
                                             ngaydang = cb.ngaydang
                                         }
                          ).ToList();
            ViewBag.TinRaoCMCTNoiBat = (from cb in db.TinRaoCMCT
                                        join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                                        join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                                        join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                                        join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                                        join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                                        where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp && cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen && px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa)
                                        select new TinRaoCanMuaCanThue
                                        {
                                            ma_tinrao = cb.ma_tinrao,
                                            tieude = cb.tieude,
                                            ma_loaihinh = cb.ma_loaihinh,
                                            ten_tinhtp = tp.ten_tinhtp,
                                            ten_quanhuyen = qh.ten_quanhuyen,
                                            ten_phuongxa = px.ten_phuongxa,
                                            ten_duongpho = dp.ten_duongpho,
                                            gia_tu = cb.gia_tu,
                                            gia_den = cb.gia_den,
                                            ten_donvi = dv.ten_donvi,
                                            dientich_tu = cb.dientich_tu,
                                            dientich_den = cb.dientich_den,
                                            anh1 = cb.anh1,
                                            ngaydang = cb.ngaydang
                                        }
                          ).ToList();
            ViewBag.lstLoaiHinhCBCHT = db.LoaiHinh.OrderBy(n => n.ma_loaihinh).Where(n => n.nhom == "CBCHT").ToList();
            ViewBag.lstLoaiHinhCMCT = db.LoaiHinh.OrderBy(n => n.ma_loaihinh).Where(n => n.nhom == "CMCT").ToList();
            ViewBag.TinRaoMoiNhat = db.TinRaoCBCHT.Take(4).ToList();
            ViewBag.PhongThuy = db.PhongThuy.Take(3).ToList();
        }
        //-------------------------------------- Lấy năm hiện tại
        public string LayNamHienTai()
        {
            return DateTime.Now.Year.ToString();
        }
        public ActionResult Index()
        {
            //ViewBag.TinRaoNoiBat = db.TinRaoCBCHT.Take(5).ToList();
            ViewBagData();
            ViewBag.KetQua = "";
            return View();
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
        //-------------------------------------- Tin nổi bật cho từng mục Cần bán, cho thuê
        public ActionResult TinNoiBatPartial(int? ma)
        {
            //var da = db.TinRaoCBCHT.Where(n => n.ma_loaihinh == ma).ToList().OrderBy(n => n.ma_ndloaihinh);
            ViewBag.TinRaoCBCHTNoiBat = (from cb in db.TinRaoCBCHT
                                         join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                                         join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                                         join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                                         where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp && cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen && cb.ma_loaihinh == ma)
                                         select new TinRao
                                         {
                                             ma_tinrao = cb.ma_tinrao,
                                             ma_loaihinh = cb.ma_loaihinh,
                                             tieude = cb.tieude,
                                             ten_tinhtp = tp.ten_tinhtp,
                                             ten_quanhuyen = qh.ten_quanhuyen,
                                             so_phongngu = cb.so_phongngu,
                                             so_phongkhach = cb.so_phongkhach,
                                             so_nhabep = cb.so_nhabep,
                                             so_toilet = cb.so_toilet,
                                             gia = cb.gia,
                                             anh1 = cb.anh1,
                                             ten_donvi = dv.ten_donvi,
                                             ngaydang = cb.ngaydang
                                         }
                          ).ToList();
            return PartialView("TinNoiBatPartial");
        }
        //-------------------------------------- Tin nổi bật cho từng mục Cần mua, cần thuê
        public ActionResult TinNoiBatCMCTPartial(int? ma)
        {
            //var da = db.TinRaoCBCHT.Where(n => n.ma_loaihinh == ma).ToList().OrderBy(n => n.ma_ndloaihinh);
            ViewBag.TinRaoCMCTNoiBat = (from cb in db.TinRaoCMCT
                                        join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                                        join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                                        join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                                        join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                                        join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                                        where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp && cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen && px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == ma)
                                        select new TinRaoCanMuaCanThue
                                        {
                                            ma_tinrao = cb.ma_tinrao,
                                            tieude = cb.tieude,
                                            ma_loaihinh = cb.ma_loaihinh,
                                            ten_tinhtp = tp.ten_tinhtp,
                                            ten_quanhuyen = qh.ten_quanhuyen,
                                            ten_phuongxa = px.ten_phuongxa,
                                            ten_duongpho = dp.ten_duongpho,
                                            gia_tu = cb.gia_tu,
                                            gia_den = cb.gia_den,
                                            ten_donvi = dv.ten_donvi,
                                            dientich_tu = cb.dientich_tu,
                                            dientich_den = cb.dientich_den,
                                            anh1 = cb.anh1,
                                            ngaydang = cb.ngaydang
                                        }
                         ).Take(3).ToList();
            return PartialView("TinNoiBatCMCTPartial");
        }
        //-------------------------------------- Footer
        public ActionResult FooterPartial()
        {
            var da = db.LoaiHinh.OrderBy(n => n.ma_loaihinh).ToList();
            return PartialView("FooterPartial", da);
        }
        //-------------------------------------- Đăng ký nhận tin
        public ActionResult DangKyNhanTin(FormCollection f)
        {
            string txtEmail = f["txtEmail"].ToString();
            var model = db.DangKyNhanThongBao;
            if (ModelState.IsValid)
            {
                try
                {
                    var x = db.DangKyNhanThongBao.Where(n => n.email == txtEmail);
                    if ( x.Count()== 0)
                    {
                        DangKyNhanThongBao dknt = new DangKyNhanThongBao();
                        dknt.email = txtEmail;
                        dknt.ngaydangky = DateTime.Now;
                        db.DangKyNhanThongBao.Add(dknt);
                        db.SaveChanges();
                        ViewBagData();
                        ViewBag.KetQua = "Đăng ký nhận tin thành công!";
                        return View("Index");
                    }
                    else
                    {
                        ViewBagData();
                        ViewBag.KetQua = "Email đã được đăng ký trước đó!";
                        return View("Index");
                    }

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return null;
        }
    }
}