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
    public class TimKiemNangCaoController : Controller
    {
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        // GET: TimKiemNangCao
        //-------------------------------------- Tìm kiếm nâng cao
        [HttpPost]
        public ActionResult TimKiemNangCao(FormCollection f)
        {
            string txtTuKhoa = f["txtTuKhoa1"].ToString();
            string cboLoaiHinh = f["cboLoaiHinh1"].ToString();

            string cboNoiDungLoaiHinh = f["cboNoiDungLoaiHinh1"].ToString();
            string cboTinhTP = f["cboTinhTP1"].ToString();
            //string cboQuanHuyen = f["cboQuanHuyen1"].ToString();
            //string cboPhuongXa = f["cboPhuongXa1"].ToString();
            //string cboDuongPho = f["cboDuongPho1"].ToString();
            //string txtDTMin=f["DTMin"].ToString();
            //string txtGiaMin=f["GiaMin"].ToString();
            string cboDonVi = f["cboDonVi1"].ToString();

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
                if (txtTuKhoa.Length != 0 && cboLoaiHinh.Length != 0)
                {
                    if (cboNoiDungLoaiHinh.Length != 0)
                    {
                        if (cboTinhTP.Length != 0)
                        {
                            string cboQuanHuyen = f["cboQuanHuyen1"].ToString();
                            if (cboQuanHuyen.Length != 0)
                            {
                                string cboPhuongXa = f["cboPhuongXa1"].ToString();
                                if (cboPhuongXa.Length != 0)
                                {
                                    string cboDuongPho = f["cboDuongPho1"].ToString();
                                    if (cboDuongPho.Length != 0)
                                    {
                                        var txtDTMin = f["DTMin"];
                                        var chkDTKhongXacDinh = f["chkDTKhongXacDinh"];
                                        var txtGiaMin = f["GiaMin"];
                                        //if (txtDTMin != null && txtGiaMin != null && chkDTKhongXacDinh == null && cboDonVi != "Thỏa thuận" && cboDonVi.Length != 0)
                                        //{

                                        //}
                                        if (txtDTMin != null)
                                        {
                                            if (txtGiaMin != null)
                                            {
                                                if (cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem1", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        duongpho = int.Parse(cboDuongPho),
                                                        dientich = double.Parse(txtDTMin.ToString()),
                                                        gia = double.Parse(txtGiaMin.ToString()),
                                                        donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                                else
                                                {
                                                }
                                            }
                                            else
                                            {
                                                if (cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận")
                                                {

                                                }
                                                else if (cboDonVi.Length != 0 && cboDonVi == "Thỏa thuận")
                                                {

                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (chkDTKhongXacDinh != null)
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {

                                }
                            }
                            else
                            {

                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                else if (txtTuKhoa.Length == 0 && cboLoaiHinh.Length != 0)
                {

                }

            }
            else
            {

            }
            return View();
        }
        //-------------------------------------- 
        //-------------------------------------- 
        //-------------------------------------- Kết quả tìm kiếm
        //-------------------1------------------- Đầy đủ các trường--- 
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, đường phố, diện tích, giá,đơn vị
        public ActionResult KetQuaTimKiem1(int? page,string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, int? duongpho, double? dientich, double? gia, int? donvi)
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
            ViewBag.quanhuyen = quanhuyen;
            ViewBag.phuongxa = phuongxa;
            ViewBag.duongpho = duongpho;
            ViewBag.dientich = dientich;
            ViewBag.gia = gia;
            ViewBag.donvi = donvi;
            //-------------------------------------- 
            //var da = db.TinRaoCBCHT.Where(n => n.ma_loaihinh == 1 && n.ma_ndloaihinh == 1 && n.ma_tinhtp == 4 &&
            //  n.ma_quanhuyen == 7 && n.ma_phuongxa == 12 && n.ma_duongpho == 1 && n.dientich == 82 && n.gia == 3.3 && n.tieude.Contains("PHÒNG"));
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_duongpho == duongpho  && cb.ma_donvi == donvi
                      &&cb.dientich == dientich && cb.gia == gia)
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
    }
}


