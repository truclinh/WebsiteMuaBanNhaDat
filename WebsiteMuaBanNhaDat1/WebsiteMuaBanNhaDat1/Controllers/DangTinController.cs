using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMuaBanNhaDat1.Models;
namespace WebsiteMuaBanNhaDat1.Controllers
{
    public class DangTinController : Controller
    {
        MuaBanNhaDatEntities db = new MuaBanNhaDatEntities();
        // GET: DangTin
        //-------------------------------------- Đăng tin Cần bán, cần cho thuê
        [HttpGet]
        public ActionResult DangTinCBCHT()
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DangTinCBCHT(IEnumerable<HttpPostedFileBase> files, FormCollection f)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            //-------------------------------------- 
            TinRaoCBCHT tr = new TinRaoCBCHT();

            string tieude = f["txtTieuDe"].ToString();
            int? loaihinh = int.Parse(f["cboLoaiHinh2"].ToString());
            int? ndloaihinh = int.Parse(f["cboNoiDungLoaiHinh2"].ToString());
            int? tinhtp = int.Parse(f["cboTinhTP2"].ToString());
            int? quanhuyen = int.Parse(f["cboQuanHuyen2"].ToString());
            int? phuongxa = int.Parse(f["cboPhuongXa2"].ToString());
            int? duongpho = int.Parse(f["cboDuongPho2"].ToString());
            double? dientich = double.Parse(f["txtDienTich"].ToString());
            double? gia = double.Parse(f["txtGiaMin"].ToString());
            int? donvi = int.Parse(f["cboDonVi2"].ToString());
            string mota = f["txtMoTa"].ToString();
            int? so_phongngu = int.Parse(f["txt_PhongNgu"].ToString());
            int? so_phongkhach = int.Parse(f["txt_PhongKhach"].ToString());
            int? so_nhabep = int.Parse(f["txt_NhaBep"].ToString());
            int? so_toilet = int.Parse(f["txt_Toilet"].ToString());
            string ngay_batdau = f["txtNgayBatDau"].ToString();
            string ngay_ketthuc = f["txtNgayKetThuc"].ToString();
            string anh1 = "";
            string anh2 = "";
            string anh3 = "";
            string anh4 = "";
            string anh360 = "";
            //--------------------------------------
            int i = 0;

            foreach (var file in files)
            {
                i++;
                if (file != null && file.ContentLength > 0)
                {
                    //file.SaveAs(Path.Combine(Server.MapPath("~/Image/"), Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid() + Path.GetExtension(file.FileName)));
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    fileName = fileName + DateTime.Now.ToString("ddMMyyyy") + extension;
                    switch (i)
                    {
                        case 1:
                            anh1 += fileName;
                            break;
                        case 2:
                            anh2 += fileName;
                            break;
                        case 3:
                            anh3 += fileName;
                            break;
                        case 4:
                            anh4 += fileName;
                            break;
                        case 5:
                            anh360 += fileName;
                            break;
                    }
                    db.SaveChanges();
                    //file.ImagePath = "~/Image/" + fileName;
                    if (i == 5)
                    {
                        fileName = Path.Combine(Server.MapPath("~/Content/images1/anh360/"), fileName);
                    }
                    else
                    {
                        fileName = Path.Combine(Server.MapPath("~/Content/images1/"), fileName);
                    }

                    file.SaveAs(fileName);

                }
            }
            tr.ma_tinrao = Guid.NewGuid();
            tr.tieude = tieude;
            tr.ma_loaihinh = loaihinh;
            tr.ma_ndloaihinh = ndloaihinh;
            tr.ma_tinhtp = tinhtp;
            tr.ma_quanhuyen = quanhuyen;
            tr.ma_phuongxa = phuongxa;
            tr.ma_duongpho = duongpho;
            tr.dientich = dientich;
            tr.gia = gia;
            tr.ma_donvi = donvi;
            tr.mota = mota;
            tr.so_phongngu = so_phongngu;
            tr.so_phongkhach = so_phongkhach;
            tr.so_nhabep = so_nhabep;
            tr.so_toilet = so_toilet;
            tr.anh1 = anh1;
            tr.anh2 = anh2;
            tr.anh3 = anh3;
            tr.anh4 = anh4;
            tr.anh360do = anh360;
            tr.ngaydang = DateTime.Parse(ngay_batdau);
            tr.ngayketthuc = DateTime.Parse(ngay_ketthuc);
            db.TinRaoCBCHT.Add(tr);
            db.SaveChanges();
            //-------------------------------------- 

            //-------------------------------------- 

            double? lat1 = double.Parse(f["lat1"].ToString().Replace('.',','));
            double? lng1 = double.Parse(f["lng1"].ToString().Replace('.', ','));
            double? lat2 = double.Parse(f["lat2"].ToString().Replace('.', ','));
            double? lng2 = double.Parse(f["lng2"].ToString().Replace('.', ','));
            double? lat3 = double.Parse(f["lat3"].ToString().Replace('.', ','));
            double? lng3 = double.Parse(f["lng3"].ToString().Replace('.', ','));
            double? lat4 = double.Parse(f["lat4"].ToString().Replace('.', ','));
            double? lng4 = double.Parse(f["lng4"].ToString().Replace('.', ','));
            double? lat5 = double.Parse(f["lat5"].ToString().Replace('.', ','));
            double? lng5 = double.Parse(f["lng5"].ToString().Replace('.', ','));
            double? lat6 = double.Parse(f["lat6"].ToString().Replace('.', ','));
            double? lng6 = double.Parse(f["lng6"].ToString().Replace('.', ','));
            //-------------------------------------- 
            ToaDo td = new ToaDo();
            td.ma_tinrao = tr.ma_tinrao;
            td.lat1 = lat1;
            td.lng1 = lng1;
            td.lat2 = lat2;
            td.lng2 = lng2;
            td.lat3 = lat3;
            td.lng3 = lng3;
            td.lat4 = lat4;
            td.lng4 = lng4;
            td.lat5 = lat5;
            td.lng5 = lng5;
            td.lat6 = lat6;
            td.lng6 = lng6;
            db.ToaDo.Add(td);
            db.SaveChanges();
            //-------------------------------------- 

            string ten_lienhe = f["txtTenLienHe"].ToString();
            string diachi = f["txtDiaChi"].ToString();
            string dienthoai = f["txtDienThoai"].ToString();
            string didong = f["txtDiDong"].ToString();
            string email = f["txtEmail"].ToString();
            LienHe lh = new LienHe();
            lh.ma_tinrao = tr.ma_tinrao;
            lh.ten_lienhe = ten_lienhe;
            lh.dienthoai = dienthoai;
            lh.didong = didong;
            lh.email = email;
            db.LienHe.Add(lh);
                db.SaveChanges();
            //-------------------------------------- 
            return View();
        }
        //-------------------------------------- Đăng tin cần mua, cần mua
        [HttpGet]
        public ActionResult DangTinCMCT()
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DangTinCMCT(IEnumerable<HttpPostedFileBase> files, FormCollection f)
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            //-------------------------------------- 
            string tieude = f["txtTieuDe"].ToString();
            int? loaihinh = int.Parse(f["cboLoaiHinh2"].ToString());
            int? ndloaihinh = int.Parse(f["cboNoiDungLoaiHinh2"].ToString());
            int? tinhtp = int.Parse(f["cboTinhTP2"].ToString());
            int? quanhuyen = int.Parse(f["cboQuanHuyen2"].ToString());
            int? phuongxa = int.Parse(f["cboPhuongXa2"].ToString());
            int? duongpho = int.Parse(f["cboDuongPho2"].ToString());
            double? dientichtu = double.Parse(f["txtDTMin"].ToString());
            double? dientichden = double.Parse(f["txtDTMax"].ToString());
            double? giatu = double.Parse(f["txtGiaMin"].ToString());
            double? giaden = double.Parse(f["txtGiaMax"].ToString());
            int? donvi = int.Parse(f["cboDonVi2"].ToString());
            string mota = f["txtMoTa"].ToString();
            string ngay_batdau = f["txtNgayBatDau"].ToString();
            string ngay_ketthuc = f["txtNgayKetThuc"].ToString();
            //-------------------------------------- 
            string ten_lienhe = f["txtTenLienHe"].ToString();
            string diachi = f["txtDiaChi"].ToString();
            string dienthoai = f["txtDienThoai"].ToString();
            string didong = f["txtDiDong"].ToString();
            string email = f["txtEmail"].ToString();
            //-------------------------------------- 
            return View();
        }
    }
}