using System;
using System.Collections.Generic;
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
            string so_phongngu = f["txt_PhongNgu"].ToString();
            string so_phongkhach = f["txt_PhongKhach"].ToString();
            string so_nhabep = f["txt_NhaBep"].ToString();
            string so_toilet = f["txt_Toilet"].ToString();
            string ngay_batdau = f["txtNgayBatDau"].ToString();
            string ngay_ketthuc = f["txtNgayKetThuc"].ToString();
            //-------------------------------------- 

            //-------------------------------------- 
            double? lat1 = double.Parse(f["lat1"].ToString());
            double? lng1 = double.Parse(f["lng1"].ToString());
            double? lat2 = double.Parse(f["lat2"].ToString());
            double? lng2 = double.Parse(f["lng2"].ToString());
            double? lat3 = double.Parse(f["lat3"].ToString());
            double? lng3 = double.Parse(f["lng3"].ToString());
            double? lat4 = double.Parse(f["lat4"].ToString());
            double? lng4 = double.Parse(f["lng4"].ToString());
            double? lat5 = double.Parse(f["lat5"].ToString());
            double? lng5 = double.Parse(f["lng5"].ToString());
            double? lat6 = double.Parse(f["lat6"].ToString());
            double? lng6 = double.Parse(f["lng6"].ToString());
            //-------------------------------------- 
            string ten_lienhe = f["txtTenLienHe"].ToString();
            string diachi = f["txtDiaChi"].ToString();
            string dienthoai = f["txtDienThoai"].ToString();
            string didong = f["txtDiDong"].ToString();
            string email = f["txtEmail"].ToString();
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