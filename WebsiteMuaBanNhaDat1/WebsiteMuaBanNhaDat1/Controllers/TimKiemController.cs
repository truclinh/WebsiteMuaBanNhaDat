using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
using PagedList;
using PagedList.Mvc;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        //-------------------------------------- Tìm kiếm
        [HttpPost]
        public ActionResult TimKiem(FormCollection f)
        {
            string txtTuKhoa = f["txtTuKhoa"].ToString();
            string cboLoaiHinh = f["cboLoaiHinh"].ToString();
            // string cboNoiDungLoaiHinh = f["cboNoiDungLoaiHinh"].ToString();
            string cboTinhTP = f["cboTinhTP"].ToString();
            if (txtTuKhoa.Length != 0)
            {
                if (cboLoaiHinh.Length != 0 && cboTinhTP.Length != 0)
                {
                    string cboNoiDungLoaiHinh = f["cboNoiDungLoaiHinh"].ToString();
                    if (cboNoiDungLoaiHinh.Length != 0)
                    {
                        return RedirectToAction("KetQuaTimKiem1", "TimKiem", new { tukhoa = txtTuKhoa, loaihinh = int.Parse(cboLoaiHinh), ndloaihinh = int.Parse(cboNoiDungLoaiHinh), tinhtp = int.Parse(cboTinhTP) });
                    }
                    else
                    {
                        return RedirectToAction("KetQuaTimKiem5", "TimKiem", new { tukhoa = txtTuKhoa, loaihinh = int.Parse(cboLoaiHinh), tinhtp = int.Parse(cboTinhTP) });
                    }
                }
                else if (cboLoaiHinh.Length != 0 && cboTinhTP.Length == 0)
                {
                    string cboNoiDungLoaiHinh = f["cboNoiDungLoaiHinh"].ToString();
                    if (cboNoiDungLoaiHinh.Length != 0)
                    {
                        return RedirectToAction("KetQuaTimKiem2", "TimKiem", new { tukhoa = txtTuKhoa, loaihinh = int.Parse(cboLoaiHinh), ndloaihinh = int.Parse(cboNoiDungLoaiHinh) });
                    }
                    else
                    {
                        return RedirectToAction("KetQuaTimKiem6", "TimKiem", new { tukhoa = txtTuKhoa, loaihinh = int.Parse(cboLoaiHinh) });
                    }
                }
            }
            else
            {
                if (cboLoaiHinh.Length != 0 && cboTinhTP.Length != 0)
                {
                    string cboNoiDungLoaiHinh = f["cboNoiDungLoaiHinh"].ToString();
                    if (cboNoiDungLoaiHinh.Length != 0)
                    {
                        return RedirectToAction("KetQuaTimKiem3", "TimKiem", new { loaihinh = int.Parse(cboLoaiHinh), ndloaihinh = int.Parse(cboNoiDungLoaiHinh), tinhtp = int.Parse(cboTinhTP) });
                    }
                    else
                    {
                        return RedirectToAction("KetQuaTimKiem7", "TimKiem", new { loaihinh = int.Parse(cboLoaiHinh), tinhtp = int.Parse(cboTinhTP) });
                    }

                }
                else if (cboLoaiHinh.Length != 0 && cboTinhTP.Length == 0)
                {
                    string cboNoiDungLoaiHinh = f["cboNoiDungLoaiHinh"].ToString();
                    if (cboNoiDungLoaiHinh.Length != 0)
                    {
                        return RedirectToAction("KetQuaTimKiem4", "TimKiem", new { loaihinh = int.Parse(cboLoaiHinh), ndloaihinh = int.Parse(cboNoiDungLoaiHinh) });
                    }
                    else
                    {
                        return RedirectToAction("KetQuaTimKiem8", "TimKiem", new { loaihinh = int.Parse(cboLoaiHinh) });
                    }
                }
            }
            return View();
        }
        //-------------------------------------- Tìm kiếm nâng cao
        [HttpPost]
        public ActionResult TimKiemNangCao(FormCollection f)
        {
            string txtTuKhoa = f["txtTuKhoa1"].ToString();
            string cboLoaiHinh = f["cboLoaiHinh1"].ToString();
            string cboTinhTP = f["cboTinhTP1"].ToString();
            string cboQuanHuyen = f["cboQuanHuyen1"].ToString();
            string cboPhuongXa = f["cboPhuongXa1"].ToString();
            string cboDuongPho = f["cboDuongPho1"].ToString();
            //string txtDTMin = f["DTMin"].ToString();
            //string txtDTMax = f["DTMax"].ToString();
            //string chkDTKhongXacDinh = f["chkDTKhongXacDinh"].ToString();
            //string txtGiaMin = f["GiaMin"].ToString();
            //string txtGiaMax = f["GiaMax"].ToString();
            //string chkGiaThoaThuan = f["chkGiaThoaThuan"].ToString();
            int? lh = int.Parse(cboLoaiHinh);
            var da = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == lh);
            if (da.nhom == "CBCHT")
            {
                var txtDTMax = f["DTMax"] = null;
                var txtGiaMax = f["GiaMax"] = null;

                // string txtGiaMin = f["GiaMin"].ToString();
                var DTKhongXacDinh = f["chkDTKhongXacDinh"];
                var GiaThoaThuan = f["chkGiaThoaThuan"];
                if (DTKhongXacDinh != null)
                {
                    string chkDTKhongXacDinh = DTKhongXacDinh.ToString();
                }
                else
                {
                    string txtDTMin = f["DTMin"].ToString();
                }
                if (GiaThoaThuan != null)
                {
                    string chkGiaThoaThuan = GiaThoaThuan.ToString();
                }
                else
                {
                    string txtGiaMin = f["GiaMin"].ToString();
                }
            }

            return View();
        }
        //-------------------------------------- 
        //-------------------------------------- Kết quả tìm kiếm
        //-------------------1------------------- Đầy đủ các trường--- Từ khóa,loại hình, nội dung loại hình, tỉnh tp
        public ActionResult KetQuaTimKiem1(string tukhoa, int? loaihinh, int? ndloaihinh, int? tinhtp)
        {
            var nhom = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == loaihinh).nhom.ToString();
            if (nhom == "CBCHT")
            {
                return RedirectToAction("KetQuaTimKiem1_CBCHT", "TimKiem", new { tukhoa = tukhoa, loaihinh = loaihinh, ndloaihinh = ndloaihinh, tinhtp = tinhtp });
            }
            else
            {
                return RedirectToAction("KetQuaTimKiem1_CMCT", "TimKiem", new { tukhoa = tukhoa, loaihinh = loaihinh, ndloaihinh = ndloaihinh, tinhtp = tinhtp });
            }
        }
        //------------------2-------------------- Từ khóa,(loại hình, nội dung loại hình), tỉnh tp
        //public ActionResult KetQuaTimKiem2(string tukhoa, int? tinhtp)
        //{
        //    var da = (from cb in db.TinRaoCBCHT
        //              join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
        //              join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
        //              join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
        //              join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
        //              join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
        //              join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
        //              where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
        //              cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
        //              cb.ma_ndloaihinh == nd.ma_ndloaihinh && cb.ma_phuongxa == px.ma_phuongxa &&
        //              cb.ma_duongpho == dp.ma_duongpho && px.ma_quanhuyen == qh.ma_quanhuyen &&
        //              dp.ma_phuongxa == px.ma_phuongxa &&
        //              cb.ma_tinhtp == tinhtp)
        //              select new TinRao
        //              {
        //                  ma_tinrao = cb.ma_tinrao,
        //                  tieude = cb.tieude,
        //                  ma_loaihinh = cb.ma_loaihinh,
        //                  ma_ndloaihinh = nd.ma_ndloaihinh,
        //                  ten_ndloaihinh = nd.ten_ndloaihinh,
        //                  ten_tinhtp = tp.ten_tinhtp,
        //                  ten_quanhuyen = qh.ten_quanhuyen,
        //                  ten_phuongxa = px.ten_phuongxa,
        //                  ten_duongpho = dp.ten_duongpho,
        //                  dientich = cb.dientich,
        //                  gia = cb.gia,
        //                  ten_donvi = dv.ten_donvi,
        //                  mota = cb.mota,
        //                  so_phongngu = cb.so_phongngu,
        //                  so_phongkhach = cb.so_phongkhach,
        //                  so_nhabep = cb.so_nhabep,
        //                  so_toilet = cb.so_toilet,
        //                  anh1 = cb.anh1,
        //                  anh2 = cb.anh2,
        //                  anh3 = cb.anh3,
        //                  anh4 = cb.anh4,
        //                  anh360do = cb.anh360do,
        //                  ngaydang = cb.ngaydang,
        //                  ngayketthuc = cb.ngayketthuc
        //              }
        //                 ).Where(n => n.tieude.Contains(tukhoa)).ToList();
        //    ViewBag.KQ_CBCHT = da;
        //    var da1 = (from cb in db.TinRaoCMCT
        //               join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
        //               join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
        //               join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
        //               join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
        //               join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
        //               join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
        //               where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
        //               cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
        //               px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa &&
        //               cb.ma_tinhtp == tinhtp)
        //               select new TinRaoCanMuaCanThue
        //               {
        //                   ma_tinrao = cb.ma_tinrao,
        //                   tieude = cb.tieude,
        //                   noidung = cb.noidung,
        //                   ma_loaihinh = cb.ma_loaihinh,
        //                   ma_ndloaihinh = cb.ma_ndloaihinh,
        //                   ten_ndloaihinh = nd.ten_ndloaihinh,
        //                   ten_tinhtp = tp.ten_tinhtp,
        //                   ten_quanhuyen = qh.ten_quanhuyen,
        //                   ten_phuongxa = px.ten_phuongxa,
        //                   ten_duongpho = dp.ten_duongpho,
        //                   gia_tu = cb.gia_tu,
        //                   gia_den = cb.gia_den,
        //                   ten_donvi = dv.ten_donvi,
        //                   dientich_tu = cb.dientich_tu,
        //                   dientich_den = cb.dientich_den,
        //                   anh1 = cb.anh1,
        //                   anh2 = cb.anh2,
        //                   anh3 = cb.anh3,
        //                   ngaydang = cb.ngaydang,
        //                   ngayketthuc = cb.ngayketthuc
        //               }
        //                ).Where(n => n.tieude.Contains(tukhoa)).ToList();
        //    ViewBag.KQ_CMCT = da1;
        //    return View();
        //}
        //------------------3-------------------- Từ khóa,loại hình, nội dung loại hình, (tỉnh tp)
        public ActionResult KetQuaTimKiem2(string tukhoa, int? loaihinh, int? ndloaihinh)
        {
            var nhom = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == loaihinh).nhom.ToString();
            if (nhom == "CBCHT")
            {
                return RedirectToAction("KetQuaTimKiem2_CBCHT", "TimKiem", new { tukhoa = tukhoa, loaihinh = loaihinh, ndloaihinh = ndloaihinh });
            }
            else
            {
                return RedirectToAction("KetQuaTimKiem2_CMCT", "TimKiem", new { tukhoa = tukhoa, loaihinh = loaihinh, ndloaihinh = ndloaihinh });
            }
        }
        //-----------------3-------------------- (Từ khóa),loại hình, nội dung loại hình, tỉnh tp
        public ActionResult KetQuaTimKiem3(int? loaihinh, int? ndloaihinh, int? tinhtp)
        {

            var nhom = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == loaihinh).nhom.ToString();
            if (nhom == "CBCHT")
            {
                return RedirectToAction("KetQuaTimKiem3_CBCHT", "TimKiem", new { loaihinh = loaihinh, ndloaihinh = ndloaihinh, tinhtp = tinhtp });
            }
            else
            {
                return RedirectToAction("KetQuaTimKiem3_CMCT", "TimKiem", new { loaihinh = loaihinh, ndloaihinh = ndloaihinh, tinhtp = tinhtp });
            }
        }
        //-----------------4--------------------- (Từ khóa),loại hình, nội dung loại hình, (tỉnh tp)
        public ActionResult KetQuaTimKiem4(int? loaihinh, int? ndloaihinh)
        {
            var nhom = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == loaihinh).nhom.ToString();
            if (nhom == "CBCHT")
            {
                return RedirectToAction("KetQuaTimKiem4_CBCHT", "TimKiem", new { loaihinh = loaihinh, ndloaihinh = ndloaihinh });
            }
            else
            {
                return RedirectToAction("KetQuaTimKiem4_CMCT", "TimKiem", new { loaihinh = loaihinh, ndloaihinh = ndloaihinh });
            }
        }
        //-----------------5--------------------- Từ khóa,loại hình, (nội dung loại hình), (tỉnh tp)
        public ActionResult KetQuaTimKiem5(string tukhoa, int? loaihinh, int? tinhtp)
        {
            var nhom = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == loaihinh).nhom.ToString();
            if (nhom == "CBCHT")
            {
                return RedirectToAction("KetQuaTimKiem5_CBCHT", "TimKiem", new { tukhoa = tukhoa, loaihinh = loaihinh, tinhtp = tinhtp });
            }
            else
            {
                return RedirectToAction("KetQuaTimKiem5_CMCT", "TimKiem", new { tukhoa = tukhoa, loaihinh = loaihinh, tinhtp = tinhtp });
            }
        }
        //-----------------6--------------------- Từ khóa,loại hình, (nội dung loại hình, tỉnh tp)
        public ActionResult KetQuaTimKiem6(string tukhoa, int? loaihinh)
        {
            var nhom = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == loaihinh).nhom.ToString();
            if (nhom == "CBCHT")
            {
                return RedirectToAction("KetQuaTimKiem6_CBCHT", "TimKiem", new { tukhoa = tukhoa, loaihinh = loaihinh });
            }
            else
            {
                return RedirectToAction("KetQuaTimKiem6_CMCT", "TimKiem", new { tukhoa = tukhoa, loaihinh = loaihinh });
            }
        }
        //-----------------7--------------------- (Từ khóa),loại hình,( nội dung loại hình,) tỉnh tp
        public ActionResult KetQuaTimKiem7(int? loaihinh, int? tinhtp)
        {
            var nhom = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == loaihinh).nhom.ToString();
            if (nhom == "CBCHT")
            {
                return RedirectToAction("KetQuaTimKiem7_CBCHT", "TimKiem", new { loaihinh = loaihinh, tinhtp = tinhtp });
            }
            else
            {
                return RedirectToAction("KetQuaTimKiem7_CMCT", "TimKiem", new { loaihinh = loaihinh, tinhtp = tinhtp });
            }
        }
        //-----------------8--------------------- (Từ khóa),loại hình,( nội dung loại hình, tỉnh tp)
        public ActionResult KetQuaTimKiem8(int? loaihinh)
        {
            var nhom = db.LoaiHinh.SingleOrDefault(n => n.ma_loaihinh == loaihinh).nhom.ToString();
            if (nhom == "CBCHT")
            {
                return RedirectToAction("KetQuaTimKiem8_CBCHT", "TimKiem", new { loaihinh = loaihinh });
            }
            else
            {
                return RedirectToAction("KetQuaTimKiem8_CMCT", "TimKiem", new { loaihinh = loaihinh });
            }
        }
        //-------------------------------------- 
        //-------------------------------------- Lấy nội dung loại hình theo mã loại hình
        public JsonResult LayNoiDungLoaiHinh(int? ma_loaihinh)
        {
            var lstNoiDungLH = db.NoiDungLoaiHinh.Where(n => n.ma_loaihinh == ma_loaihinh).ToList();
            return Json(new SelectList(lstNoiDungLH, "ma_ndloaihinh", "ten_ndloaihinh", JsonRequestBehavior.AllowGet));
        }
        //-------------------------------------- Lấy Đơn vị
        public JsonResult LayDonVi(int? ma_loaihinh)
        {
            var lst = db.DonVi.Where(n => n.ma_loaihinh == ma_loaihinh).ToList();
            return Json(new SelectList(lst, "ma_donvi", "ten_donvi", JsonRequestBehavior.AllowGet));
        }
        //-------------------------------------- Lấy Quận/Huyện theo mã Tỉnh/TP
        public JsonResult LayQuanHuyen(int? ma_tinhtp)
        {
            var lst = db.QuanHuyen.Where(n => n.ma_tinhtp == ma_tinhtp).ToList();
            return Json(new SelectList(lst, "ma_quanhuyen", "ten_quanhuyen", JsonRequestBehavior.AllowGet));
        }
        //-------------------------------------- Lấy Phường/Xã theo mã Quận/Huyện
        public JsonResult LayPhuongXa(int? ma_quanhuyen)
        {
            var lst = db.PhuongXa.Where(n => n.ma_quanhuyen == ma_quanhuyen).ToList();
            return Json(new SelectList(lst, "ma_phuongxa", "ten_phuongxa", JsonRequestBehavior.AllowGet));
        }
        //-------------------------------------- Lấy Đường/Phố theo mã Phường/Xã
        public JsonResult LayDuongPho(int? ma_phuongxa)
        {
            var lst = db.DuongPho.Where(n => n.ma_phuongxa == ma_phuongxa).ToList();
            return Json(new SelectList(lst, "ma_duongpho", "ten_duongpho", JsonRequestBehavior.AllowGet));
        }
        //-------------------------------------- 
        //-------------------------------------- TÌM KIẾM 1
        public ActionResult KetQuaTimKiem1_CBCHT(int? page, string tukhoa, int? loaihinh, int? ndloaihinh, int? tinhtp)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
            ViewBag.ndloaihinh = ndloaihinh;
            ViewBag.tinhtp = tinhtp;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCBCHT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      cb.ma_ndloaihinh == nd.ma_ndloaihinh && cb.ma_phuongxa == px.ma_phuongxa &&
                      cb.ma_duongpho == dp.ma_duongpho && px.ma_quanhuyen == qh.ma_quanhuyen &&
                      dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == loaihinh && cb.ma_ndloaihinh == ndloaihinh &&
                      cb.ma_tinhtp == tinhtp)
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
                         ).Where(n => n.tieude.Contains(tukhoa)).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CBCHT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        public ActionResult KetQuaTimKiem1_CMCT(int? page, string tukhoa, int? loaihinh, int? ndloaihinh, int? tinhtp)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
            ViewBag.ndloaihinh = ndloaihinh;
            ViewBag.tinhtp = tinhtp;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCMCT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa
                      && cb.ma_loaihinh == loaihinh && cb.ma_ndloaihinh == ndloaihinh &&
                      cb.ma_tinhtp == tinhtp)
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
                         ).Where(n => n.tieude.Contains(tukhoa)).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize); ;
            ViewBag.KQ_CMCT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        //-------------------------------------- TÌM KIẾM 2
        public ActionResult KetQuaTimKiem2_CBCHT(int? page, string tukhoa, int? loaihinh, int? ndloaihinh)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
            ViewBag.ndloaihinh = ndloaihinh;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCBCHT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      cb.ma_ndloaihinh == nd.ma_ndloaihinh && cb.ma_phuongxa == px.ma_phuongxa &&
                      cb.ma_duongpho == dp.ma_duongpho && px.ma_quanhuyen == qh.ma_quanhuyen &&
                      dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == loaihinh && cb.ma_ndloaihinh == ndloaihinh)
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
                         ).Where(n => n.tieude.Contains(tukhoa)).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CBCHT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        public ActionResult KetQuaTimKiem2_CMCT(int? page, string tukhoa, int? loaihinh, int? ndloaihinh)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
            ViewBag.ndloaihinh = ndloaihinh;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCMCT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa
                      && cb.ma_loaihinh == loaihinh && cb.ma_ndloaihinh == ndloaihinh)
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
                         ).Where(n => n.tieude.Contains(tukhoa)).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CMCT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        //-------------------------------------- TÌM KIẾM 3
        public ActionResult KetQuaTimKiem3_CBCHT(int? page, int? loaihinh, int? ndloaihinh, int? tinhtp)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.tinhtp = tinhtp;
            ViewBag.loaihinh = loaihinh;
            ViewBag.ndloaihinh = ndloaihinh;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCBCHT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      cb.ma_ndloaihinh == nd.ma_ndloaihinh && cb.ma_phuongxa == px.ma_phuongxa &&
                      cb.ma_duongpho == dp.ma_duongpho && px.ma_quanhuyen == qh.ma_quanhuyen &&
                      dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == loaihinh && cb.ma_ndloaihinh == ndloaihinh &&
                      cb.ma_tinhtp == tinhtp)
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
                        ).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CBCHT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        public ActionResult KetQuaTimKiem3_CMCT(int? page, int? loaihinh, int? ndloaihinh, int? tinhtp)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.tinhtp = tinhtp;
            ViewBag.loaihinh = loaihinh;
            ViewBag.ndloaihinh = ndloaihinh;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCMCT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa
                      && cb.ma_loaihinh == loaihinh && cb.ma_ndloaihinh == ndloaihinh &&
                      cb.ma_tinhtp == tinhtp)
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
                         ).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CMCT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        //-------------------------------------- TÌM KIẾM 4
        public ActionResult KetQuaTimKiem4_CBCHT(int? page, int? loaihinh, int? ndloaihinh)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.loaihinh = loaihinh;
            ViewBag.ndloaihinh = ndloaihinh;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCBCHT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      cb.ma_ndloaihinh == nd.ma_ndloaihinh && cb.ma_phuongxa == px.ma_phuongxa &&
                      cb.ma_duongpho == dp.ma_duongpho && px.ma_quanhuyen == qh.ma_quanhuyen &&
                      dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == loaihinh && cb.ma_ndloaihinh == ndloaihinh)
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
                         ).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CBCHT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        public ActionResult KetQuaTimKiem4_CMCT(int? page, int? loaihinh, int? ndloaihinh)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.loaihinh = loaihinh;
            ViewBag.ndloaihinh = ndloaihinh;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCMCT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa
                      && cb.ma_loaihinh == loaihinh && cb.ma_ndloaihinh == ndloaihinh)
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
          ).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CMCT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        //-------------------------------------- TÌM KIẾM 5
        public ActionResult KetQuaTimKiem5_CBCHT(int? page, string tukhoa, int? loaihinh, int? tinhtp)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
            //ViewBag.ndloaihinh = ndloaihinh;
            ViewBag.tinhtp = tinhtp;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCBCHT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      cb.ma_ndloaihinh == nd.ma_ndloaihinh && cb.ma_phuongxa == px.ma_phuongxa &&
                      cb.ma_duongpho == dp.ma_duongpho && px.ma_quanhuyen == qh.ma_quanhuyen &&
                      dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == loaihinh && cb.ma_tinhtp == tinhtp)
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
                         ).Where(n => n.tieude.Contains(tukhoa)).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CBCHT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        public ActionResult KetQuaTimKiem5_CMCT(int? page, string tukhoa, int? loaihinh, int? tinhtp)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
            //ViewBag.ndloaihinh = ndloaihinh;
            ViewBag.tinhtp = tinhtp;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCMCT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa
                      && cb.ma_loaihinh == loaihinh &&
                      cb.ma_tinhtp == tinhtp)
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
                         ).Where(n => n.tieude.Contains(tukhoa)).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize); ;
            ViewBag.KQ_CMCT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();

        }
        //-------------------------------------- TÌM KIẾM 6
        public ActionResult KetQuaTimKiem6_CBCHT(int? page, string tukhoa, int? loaihinh)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
            //ViewBag.ndloaihinh = ndloaihinh;
           // ViewBag.tinhtp = tinhtp;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCBCHT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      cb.ma_ndloaihinh == nd.ma_ndloaihinh && cb.ma_phuongxa == px.ma_phuongxa &&
                      cb.ma_duongpho == dp.ma_duongpho && px.ma_quanhuyen == qh.ma_quanhuyen &&
                      dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == loaihinh)
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
                         ).Where(n => n.tieude.Contains(tukhoa)).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CBCHT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        public ActionResult KetQuaTimKiem6_CMCT(int? page, string tukhoa, int? loaihinh)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
           // ViewBag.ndloaihinh = ndloaihinh;
            //ViewBag.tinhtp = tinhtp;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCMCT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa
                      && cb.ma_loaihinh == loaihinh)
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
                         ).Where(n => n.tieude.Contains(tukhoa)).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize); ;
            ViewBag.KQ_CMCT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        //-------------------------------------- TÌM KIẾM 7
        public ActionResult KetQuaTimKiem7_CBCHT(int? page, int? loaihinh, int? tinhtp)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
           // ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
           // ViewBag.ndloaihinh = ndloaihinh;
            ViewBag.tinhtp = tinhtp;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCBCHT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      cb.ma_ndloaihinh == nd.ma_ndloaihinh && cb.ma_phuongxa == px.ma_phuongxa &&
                      cb.ma_duongpho == dp.ma_duongpho && px.ma_quanhuyen == qh.ma_quanhuyen &&
                      dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == loaihinh &&
                      cb.ma_tinhtp == tinhtp)
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
                         ).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CBCHT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        public ActionResult KetQuaTimKiem7_CMCT(int? page,int? loaihinh, int? tinhtp)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            //ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
            //ViewBag.ndloaihinh = ndloaihinh;
            ViewBag.tinhtp = tinhtp;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCMCT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa
                      && cb.ma_loaihinh == loaihinh &&
                      cb.ma_tinhtp == tinhtp)
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
                         ).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize); ;
            ViewBag.KQ_CMCT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        //-------------------------------------- TÌM KIẾM 7
        public ActionResult KetQuaTimKiem8_CBCHT(int? page, int? loaihinh)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            // ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
            // ViewBag.ndloaihinh = ndloaihinh;
           // ViewBag.tinhtp = tinhtp;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCBCHT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      cb.ma_ndloaihinh == nd.ma_ndloaihinh && cb.ma_phuongxa == px.ma_phuongxa &&
                      cb.ma_duongpho == dp.ma_duongpho && px.ma_quanhuyen == qh.ma_quanhuyen &&
                      dp.ma_phuongxa == px.ma_phuongxa && cb.ma_loaihinh == loaihinh)
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
                         ).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize);
            ViewBag.KQ_CBCHT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
        public ActionResult KetQuaTimKiem8_CMCT(int? page, int? loaihinh)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            //-------------------------------------- Phân trang
            //Tạo biến số sản phẩm trên trang
            int pageSize = 1;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //-------------------------------------- 
            //ViewBag.tukhoa = tukhoa;
            ViewBag.loaihinh = loaihinh;
            //ViewBag.ndloaihinh = ndloaihinh;
            //ViewBag.tinhtp = tinhtp;
            //-------------------------------------- 
            var da = (from cb in db.TinRaoCMCT
                      join tp in db.TinhTP on cb.ma_tinhtp equals tp.ma_tinhtp
                      join qh in db.QuanHuyen on tp.ma_tinhtp equals qh.ma_tinhtp
                      join dv in db.DonVi on cb.ma_donvi equals dv.ma_donvi
                      join nd in db.NoiDungLoaiHinh on cb.ma_ndloaihinh equals nd.ma_ndloaihinh
                      join px in db.PhuongXa on cb.ma_phuongxa equals px.ma_phuongxa
                      join dp in db.DuongPho on cb.ma_duongpho equals dp.ma_duongpho
                      where (cb.ma_tinhtp == tp.ma_tinhtp && tp.ma_tinhtp == qh.ma_tinhtp &&
                      cb.ma_donvi == dv.ma_donvi && cb.ma_quanhuyen == qh.ma_quanhuyen &&
                      px.ma_quanhuyen == qh.ma_quanhuyen && dp.ma_phuongxa == px.ma_phuongxa
                      && cb.ma_loaihinh == loaihinh)
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
                         ).OrderByDescending(n => n.ngaydang).ToPagedList(pageNumber, pageSize); ;
            ViewBag.KQ_CMCT = da;
            ViewBag.KetQua = da.TotalItemCount.ToString();
            return View();
        }
    }
}