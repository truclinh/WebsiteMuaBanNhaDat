using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class ChiTietTinRaoController : Controller
    {
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        // GET: ChiTietTinRao
        //-------------------------------------- Xem chi tiết theo loại hình

        public ActionResult ChiTiet(Guid? ma_tinrao, int? ma_loaihinh)
        {
            if (ma_loaihinh == 1 || ma_loaihinh == 2)
            {
                return RedirectToAction("ChiTiet_CanBanCanChoThue", "ChiTietTinRao", new { _ma_tinrao = ma_tinrao, _ma_loaihinh = ma_loaihinh });
            }
            else if (ma_loaihinh == 3 || ma_loaihinh == 4)
            {
                return RedirectToAction("ChiTiet_CanMuaCanThue", "ChiTietTinRao", new { _ma_tinrao = ma_tinrao, _ma_loaihinh = ma_loaihinh });
            }
            return null;
        }
        //-------------------------------------- Chi tiết CB-CHT
        public ActionResult ChiTiet_CanBanCanChoThue(Guid? _ma_tinrao, int? _ma_loaihinh)
        {
            string tenloaihinh = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == _ma_loaihinh).tenkhongdau.ToString();
            ViewBag.TenLoaiHinh = tenloaihinh;
          var ma = db.TinRaoCBCHT.SingleOrDefault(n => n.ma_tinrao == _ma_tinrao);
            ViewBag.TieuDeTin = db.NoiDungLoaiHinh.SingleOrDefault(n => n.ma_ndloaihinh ==ma.ma_ndloaihinh).ten_ndloaihinh.ToString();
            // ViewBag.TenLoaiND = db.NoiDungLoaiHinh.SingleOrDefault(n => n.ma_ndloaihinh == _ma_ndloaihinh).ten_ndloaihinh.ToString();
            ViewBag.TinRaoCBCHT = (from cb in db.TinRaoCBCHT
                                   join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                                   join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                                   join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                                   join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                                   join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                                   join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                                   where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp && cb.ma_donvi == dv.ma_donvi &&
                                   cb.ma_quanhuyen == qh.ma_quanhuyen && cb.ma_ndloaihinh == nd.ma_ndloaihinh && cb.ma_phuongxa == px.ma_phuongxa &&
                                   cb.ma_duongpho == dp.ma_duongpho && px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa &&
                                   cb.ma_loaihinh == _ma_loaihinh && cb.ma_tinrao == _ma_tinrao)
                                   select new TinRao
                                   {
                                       ma_tinrao = cb.ma_tinrao,
                                       tieude = cb.tieude,
                                       ma_loaihinh = cb.ma_loaihinh,
                                       ma_ndloaihinh = nd.ma_ndloaihinh,
                                       ten_ndloaihinh = nd.ten_ndloaihinh,
                                       ten_tinhtp = tp.ten_tinhtp,
                                       ten_quanhuyen = qh.ten_quanhuyen,
                                       ten_phuongxa = px.ten_phuongxa,
                                       ten_duongpho = dp.ten_duongpho,
                                       dientich = cb.dientich,
                                       gia = cb.gia,
                                       ten_donvi = dv.ten_donvi,
                                       mota = cb.mota,
                                       so_phongngu = cb.so_phongngu,
                                       so_phongkhach = cb.so_phongkhach,
                                       so_nhabep = cb.so_nhabep,
                                       so_toilet = cb.so_toilet,
                                       anh1 = cb.anh1,
                                       anh2 = cb.anh2,
                                       anh3 = cb.anh3,
                                       anh4 = cb.anh4,
                                       anh360do = cb.anh360do,
                                       ngaydang = cb.ngaydang,
                                       ngayketthuc = cb.ngayketthuc
                                   }
                          ).ToList();
            return View();
        }
        //-------------------------------------- Chi tiết CM - CT
        public ActionResult ChiTiet_CanMuaCanThue(Guid? _ma_tinrao, int? _ma_loaihinh)
        {
            string tenloaihinh = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == _ma_loaihinh).tenkhongdau.ToString();
            ViewBag.TenLoaiHinh = tenloaihinh;
            int? ma = db.TinRaoCMCT.SingleOrDefault(n => n.ma_tinrao == _ma_tinrao).ma_ndloaihinh;
            ViewBag.TieuDeTin = db.NoiDungLoaiHinh.SingleOrDefault(n => n.ma_ndloaihinh == ma).ten_ndloaihinh.ToString();
            ViewBag.TinRaoCMCT = (from cb in db.TinRaoCMCT
                                  join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                                  join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                                  join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                                  join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                                  join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                                  join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                                  where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp && cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen && px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == _ma_loaihinh && cb.ma_tinrao == _ma_tinrao)
                                  select new TinRaoCanMuaCanThue
                                  {
                                      ma_tinrao = cb.ma_tinrao,
                                      tieude = cb.tieude,
                                      noidung = cb.noidung,
                                      ma_loaihinh = cb.ma_loaihinh,
                                      ma_ndloaihinh = cb.ma_ndloaihinh,
                                      ten_ndloaihinh = nd.ten_ndloaihinh,
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
                                      anh2 = cb.anh2,
                                      anh3 = cb.anh3,
                                      ngaydang = cb.ngaydang,
                                      ngayketthuc = cb.ngayketthuc
                                  }
                          ).ToList();
            return View();
        }
    }
}