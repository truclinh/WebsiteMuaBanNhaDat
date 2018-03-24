using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class TinTheoLoaiHinhController : Controller
    {
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        // GET: TinTheoLoaiHinh
        //-------------------------------------- Phân theo loại tin
        public ActionResult TinTheoLoaiHinh(int? ma_ndloaihinh, int? ma_loaihinh)
        {
            if (ma_loaihinh == 1||ma_loaihinh==2)
            {
                return RedirectToAction("L_CanBanCanChoThue", "TinTheoLoaiHinh", new { _ma_ndloaihinh = ma_ndloaihinh, _ma_loaihinh = ma_loaihinh });
            }
            else if(ma_loaihinh==3 ||ma_loaihinh==4)
            {
                return RedirectToAction("L_CanMuaCanThue", "TinTheoLoaiHinh", new { _ma_ndloaihinh = ma_ndloaihinh, _ma_loaihinh = ma_loaihinh });
            }
            return null;
        }
        //--------------------------------------Tin cần bán, cần cho thuê
        public ActionResult L_CanBanCanChoThue(int? _ma_ndloaihinh, int? _ma_loaihinh)
        {
            string tenloaihinh = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == _ma_loaihinh).tenkhongdau.ToString();
            ViewBag.TenLoaiHinh = tenloaihinh;
            ViewBag.TenLoaiND = db.NoiDungLoaiHinh.SingleOrDefault(n => n.ma_ndloaihinh == _ma_ndloaihinh).ten_ndloaihinh.ToString();
            ViewBag.TinRaoCBCHT = (from cb in db.TinRaoCBCHT
                                         join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                                         join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                                         join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                                         where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp && cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen && cb.ma_loaihinh ==_ma_loaihinh &&cb.ma_ndloaihinh==_ma_ndloaihinh)
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
            return View();
        }
        //--------------------------------------Tin cần mua, cần thuê
        public ActionResult L_CanMuaCanThue(int? _ma_ndloaihinh, int? _ma_loaihinh)
        {
            string tenloaihinh = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == _ma_loaihinh).tenkhongdau.ToString();
            ViewBag.TenLoaiHinh = tenloaihinh;
            ViewBag.TenLoaiND = db.NoiDungLoaiHinh.SingleOrDefault(n => n.ma_ndloaihinh == _ma_ndloaihinh).ten_ndloaihinh.ToString();
            ViewBag.TinRaoCMCT = (from cb in db.TinRaoCMCT
                                        join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                                        join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                                        join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                                        join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                                        join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                                        where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp && cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen && px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == _ma_loaihinh && cb.ma_ndloaihinh==_ma_ndloaihinh)
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
            return View();
        }
    }
}