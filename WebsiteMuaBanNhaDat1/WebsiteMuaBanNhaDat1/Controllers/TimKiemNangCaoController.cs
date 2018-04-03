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
                                        //var chkDTKhongXacDinh = f["chkDTKhongXacDinh"];
                                        var txtGiaMin = f["GiaMin"];
                                        #region txtDTMin
                                        if (txtDTMin.Length != 0)
                                        {
                                            #region txtGiaMin
                                            if (txtGiaMin != null && txtGiaMin.ToString().Length != 0)
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
                                                else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem2", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        duongpho = int.Parse(cboDuongPho),
                                                        dientich = double.Parse(txtDTMin.ToString()),
                                                        gia = double.Parse(txtGiaMin.ToString())
                                                        // , donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                            }
                                            else if ((txtGiaMin != null && txtGiaMin.ToString().Length == 0) || (txtGiaMin == null))
                                            {
                                                if ((cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận") || (cboDonVi.Length != 0 && cboDonVi == "Thỏa thuận"))
                                                {
                                                    return RedirectToAction("KetQuaTimKiem3", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        duongpho = int.Parse(cboDuongPho),
                                                        dientich = double.Parse(txtDTMin.ToString()),
                                                        // gia = double.Parse(txtGiaMin.ToString()),
                                                        donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                                else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem4", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        duongpho = int.Parse(cboDuongPho),
                                                        dientich = double.Parse(txtDTMin.ToString())
                                                        //,gia = double.Parse(txtGiaMin.ToString()),
                                                        //donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                            }
                                            #endregion txtGiaMin
                                        }
                                        else
                                        {
                                            #region txtGiaMin
                                            if (txtGiaMin != null && txtGiaMin.ToString().Length != 0)
                                            {
                                                if (cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem5", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        duongpho = int.Parse(cboDuongPho),
                                                        // dientich = double.Parse(txtDTMin.ToString()),
                                                        gia = double.Parse(txtGiaMin.ToString()),
                                                        donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                                else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem6", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        duongpho = int.Parse(cboDuongPho),
                                                        // dientich = double.Parse(txtDTMin.ToString()),
                                                        gia = double.Parse(txtGiaMin.ToString())
                                                        // , donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                            }
                                            else
                                            {
                                                if ((cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận") || (cboDonVi.Length != 0 && cboDonVi == "Thỏa thuận"))
                                                {
                                                    return RedirectToAction("KetQuaTimKiem7", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        duongpho = int.Parse(cboDuongPho),
                                                        //dientich = double.Parse(txtDTMin.ToString()),
                                                        // gia = double.Parse(txtGiaMin.ToString()),
                                                        donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                                else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem8", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        duongpho = int.Parse(cboDuongPho)
                                                        // , dientich = double.Parse(txtDTMin.ToString())
                                                        //,gia = double.Parse(txtGiaMin.ToString()),
                                                        //donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                            }
                                            #endregion txtGiaMin
                                        }
                                        #endregion txtDTMin
                                    }
                                    else
                                    {
                                        var txtDTMin = f["DTMin"];
                                        //var chkDTKhongXacDinh = f["chkDTKhongXacDinh"];
                                        var txtGiaMin = f["GiaMin"];
                                        #region txtDTMin
                                        if (txtDTMin.Length != 0)
                                        {
                                            #region txtGiaMin
                                            if (txtGiaMin != null && txtGiaMin.ToString().Length != 0)
                                            {
                                                if (cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem9", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                       // duongpho = int.Parse(cboDuongPho),
                                                        dientich = double.Parse(txtDTMin.ToString()),
                                                        gia = double.Parse(txtGiaMin.ToString()),
                                                        donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                                else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem10", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                       // duongpho = int.Parse(cboDuongPho),
                                                        dientich = double.Parse(txtDTMin.ToString()),
                                                        gia = double.Parse(txtGiaMin.ToString())
                                                        // , donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                            }
                                            else if ((txtGiaMin != null && txtGiaMin.ToString().Length == 0) || (txtGiaMin == null))
                                            {
                                                if ((cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận") || (cboDonVi.Length != 0 && cboDonVi == "Thỏa thuận"))
                                                {
                                                    return RedirectToAction("KetQuaTimKiem11", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        //duongpho = int.Parse(cboDuongPho),
                                                        dientich = double.Parse(txtDTMin.ToString()),
                                                        // gia = double.Parse(txtGiaMin.ToString()),
                                                        donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                                else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem12", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        //duongpho = int.Parse(cboDuongPho),
                                                        dientich = double.Parse(txtDTMin.ToString())
                                                        //,gia = double.Parse(txtGiaMin.ToString()),
                                                        //donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                            }
                                            #endregion txtGiaMin
                                        }
                                        else
                                        {
                                            #region txtGiaMin
                                            if (txtGiaMin != null && txtGiaMin.ToString().Length != 0)
                                            {
                                                if (cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem13", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        //duongpho = int.Parse(cboDuongPho),
                                                        // dientich = double.Parse(txtDTMin.ToString()),
                                                        gia = double.Parse(txtGiaMin.ToString()),
                                                        donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                                else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem14", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        //duongpho = int.Parse(cboDuongPho),
                                                        // dientich = double.Parse(txtDTMin.ToString()),
                                                        gia = double.Parse(txtGiaMin.ToString())
                                                        // , donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                            }
                                            else
                                            {
                                                if ((cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận") || (cboDonVi.Length != 0 && cboDonVi == "Thỏa thuận"))
                                                {
                                                    return RedirectToAction("KetQuaTimKiem15", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        //duongpho = int.Parse(cboDuongPho),
                                                        //dientich = double.Parse(txtDTMin.ToString()),
                                                        // gia = double.Parse(txtGiaMin.ToString()),
                                                        donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                                else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                                {
                                                    return RedirectToAction("KetQuaTimKiem16", "TimKiemNangCao", new
                                                    {
                                                        tukhoa = txtTuKhoa,
                                                        loaihinh = int.Parse(cboLoaiHinh),
                                                        ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                                        tinhtp = int.Parse(cboTinhTP),
                                                        quanhuyen = int.Parse(cboQuanHuyen),
                                                        phuongxa = int.Parse(cboPhuongXa),
                                                        //duongpho = int.Parse(cboDuongPho)
                                                        // , dientich = double.Parse(txtDTMin.ToString())
                                                        //,gia = double.Parse(txtGiaMin.ToString()),
                                                        //donvi = int.Parse(cboDonVi)
                                                    });
                                                }
                                            }
                                            #endregion txtGiaMin
                                        }
                                        #endregion txtDTMin
                                    }
                                }
                                else
                                {
                                    //string cboDuongPho = f["cboDuongPho1"].ToString();
                                    //if (cboDuongPho.Length != 0)
                                    //{
                                    //    var txtDTMin = f["DTMin"];
                                    //    //var chkDTKhongXacDinh = f["chkDTKhongXacDinh"];
                                    //    var txtGiaMin = f["GiaMin"];
                                    //    #region txtDTMin
                                    //    if (txtDTMin.Length != 0)
                                    //    {
                                    //        #region txtGiaMin
                                    //        if (txtGiaMin != null && txtGiaMin.ToString().Length != 0)
                                    //        {
                                    //            if (cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem1", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    duongpho = int.Parse(cboDuongPho),
                                    //                    dientich = double.Parse(txtDTMin.ToString()),
                                    //                    gia = double.Parse(txtGiaMin.ToString()),
                                    //                    donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //            else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem2", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    duongpho = int.Parse(cboDuongPho),
                                    //                    dientich = double.Parse(txtDTMin.ToString()),
                                    //                    gia = double.Parse(txtGiaMin.ToString())
                                    //                    // , donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //        }
                                    //        else if ((txtGiaMin != null && txtGiaMin.ToString().Length == 0) || (txtGiaMin == null))
                                    //        {
                                    //            if ((cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận") || (cboDonVi.Length != 0 && cboDonVi == "Thỏa thuận"))
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem3", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    duongpho = int.Parse(cboDuongPho),
                                    //                    dientich = double.Parse(txtDTMin.ToString()),
                                    //                    // gia = double.Parse(txtGiaMin.ToString()),
                                    //                    donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //            else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem4", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    duongpho = int.Parse(cboDuongPho),
                                    //                    dientich = double.Parse(txtDTMin.ToString())
                                    //                    //,gia = double.Parse(txtGiaMin.ToString()),
                                    //                    //donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //        }
                                    //        #endregion txtGiaMin
                                    //    }
                                    //    else
                                    //    {
                                    //        #region txtGiaMin
                                    //        if (txtGiaMin != null && txtGiaMin.ToString().Length != 0)
                                    //        {
                                    //            if (cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem5", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    duongpho = int.Parse(cboDuongPho),
                                    //                    // dientich = double.Parse(txtDTMin.ToString()),
                                    //                    gia = double.Parse(txtGiaMin.ToString()),
                                    //                    donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //            else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem6", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    duongpho = int.Parse(cboDuongPho),
                                    //                    // dientich = double.Parse(txtDTMin.ToString()),
                                    //                    gia = double.Parse(txtGiaMin.ToString())
                                    //                    // , donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //        }
                                    //        else
                                    //        {
                                    //            if ((cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận") || (cboDonVi.Length != 0 && cboDonVi == "Thỏa thuận"))
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem7", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    duongpho = int.Parse(cboDuongPho),
                                    //                    //dientich = double.Parse(txtDTMin.ToString()),
                                    //                    // gia = double.Parse(txtGiaMin.ToString()),
                                    //                    donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //            else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem8", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    duongpho = int.Parse(cboDuongPho)
                                    //                    // , dientich = double.Parse(txtDTMin.ToString())
                                    //                    //,gia = double.Parse(txtGiaMin.ToString()),
                                    //                    //donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //        }
                                    //        #endregion txtGiaMin
                                    //    }
                                    //    #endregion txtDTMin
                                    //}
                                    //else
                                    //{
                                    //    var txtDTMin = f["DTMin"];
                                    //    //var chkDTKhongXacDinh = f["chkDTKhongXacDinh"];
                                    //    var txtGiaMin = f["GiaMin"];
                                    //    #region txtDTMin
                                    //    if (txtDTMin.Length != 0)
                                    //    {
                                    //        #region txtGiaMin
                                    //        if (txtGiaMin != null && txtGiaMin.ToString().Length != 0)
                                    //        {
                                    //            if (cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem9", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    // duongpho = int.Parse(cboDuongPho),
                                    //                    dientich = double.Parse(txtDTMin.ToString()),
                                    //                    gia = double.Parse(txtGiaMin.ToString()),
                                    //                    donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //            else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem10", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    // duongpho = int.Parse(cboDuongPho),
                                    //                    dientich = double.Parse(txtDTMin.ToString()),
                                    //                    gia = double.Parse(txtGiaMin.ToString())
                                    //                    // , donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //        }
                                    //        else if ((txtGiaMin != null && txtGiaMin.ToString().Length == 0) || (txtGiaMin == null))
                                    //        {
                                    //            if ((cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận") || (cboDonVi.Length != 0 && cboDonVi == "Thỏa thuận"))
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem11", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    //duongpho = int.Parse(cboDuongPho),
                                    //                    dientich = double.Parse(txtDTMin.ToString()),
                                    //                    // gia = double.Parse(txtGiaMin.ToString()),
                                    //                    donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //            else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem12", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    //duongpho = int.Parse(cboDuongPho),
                                    //                    dientich = double.Parse(txtDTMin.ToString())
                                    //                    //,gia = double.Parse(txtGiaMin.ToString()),
                                    //                    //donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //        }
                                    //        #endregion txtGiaMin
                                    //    }
                                    //    else
                                    //    {
                                    //        #region txtGiaMin
                                    //        if (txtGiaMin != null && txtGiaMin.ToString().Length != 0)
                                    //        {
                                    //            if (cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem13", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    //duongpho = int.Parse(cboDuongPho),
                                    //                    // dientich = double.Parse(txtDTMin.ToString()),
                                    //                    gia = double.Parse(txtGiaMin.ToString()),
                                    //                    donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //            else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem14", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    //duongpho = int.Parse(cboDuongPho),
                                    //                    // dientich = double.Parse(txtDTMin.ToString()),
                                    //                    gia = double.Parse(txtGiaMin.ToString())
                                    //                    // , donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //        }
                                    //        else
                                    //        {
                                    //            if ((cboDonVi.Length != 0 && cboDonVi != "Thỏa thuận") || (cboDonVi.Length != 0 && cboDonVi == "Thỏa thuận"))
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem15", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    //duongpho = int.Parse(cboDuongPho),
                                    //                    //dientich = double.Parse(txtDTMin.ToString()),
                                    //                    // gia = double.Parse(txtGiaMin.ToString()),
                                    //                    donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //            else if (cboDonVi.Length == 0 && cboDonVi != "Thỏa thuận")
                                    //            {
                                    //                return RedirectToAction("KetQuaTimKiem16", "TimKiemNangCao", new
                                    //                {
                                    //                    tukhoa = txtTuKhoa,
                                    //                    loaihinh = int.Parse(cboLoaiHinh),
                                    //                    ndloaihinh = int.Parse(cboNoiDungLoaiHinh),
                                    //                    tinhtp = int.Parse(cboTinhTP),
                                    //                    quanhuyen = int.Parse(cboQuanHuyen),
                                    //                    phuongxa = int.Parse(cboPhuongXa),
                                    //                    //duongpho = int.Parse(cboDuongPho)
                                    //                    // , dientich = double.Parse(txtDTMin.ToString())
                                    //                    //,gia = double.Parse(txtGiaMin.ToString()),
                                    //                    //donvi = int.Parse(cboDonVi)
                                    //                });
                                    //            }
                                    //        }
                                    //        #endregion txtGiaMin
                                    //    }
                                    //    #endregion txtDTMin
                                    //}
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
        //-------------------------------------- KẾT QUẢ TÌM KIẾM NÂNG CAO

        //-------------------------------------- TÌM KIẾM 1
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, đường phố, diện tích, giá,đơn vị
        public ActionResult KetQuaTimKiem1(int? page, string tukhoa, int? loaihinh,
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_duongpho == duongpho && cb.ma_donvi == donvi
                      && cb.dientich == dientich && cb.gia == gia)
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
        //----------------------------------------- TÌM KIẾM 2
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, đường phố, diện tích, giá,(đơn vị)
        public ActionResult KetQuaTimKiem2(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, int? duongpho,
            double? dientich, double? gia)
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
            //ViewBag.donvi = donvi;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_duongpho == duongpho
                      && cb.dientich == dientich && cb.gia == gia)
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
        //----------------------------------------- TÌM KIẾM 3
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, đường phố, diện tích,( giá,)đơn vị
        public ActionResult KetQuaTimKiem3(int? page, string tukhoa, int? loaihinh,
        int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, int? duongpho, double? dientich, int? donvi)
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
            //ViewBag.gia = gia;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_duongpho == duongpho && cb.ma_donvi == donvi
                      && cb.dientich == dientich)
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
        //----------------------------------------- TÌM KIẾM 3
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, đường phố, diện tích,( giá,đơn vị)
        public ActionResult KetQuaTimKiem4(int? page, string tukhoa, int? loaihinh,
        int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, int? duongpho, double? dientich)
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
            // ViewBag.gia = gia;
            // ViewBag.donvi = donvi;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_duongpho == duongpho
                      && cb.dientich == dientich)
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
        //-------------------------------------- TÌM KIẾM 5
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, đường phố, (diện tích), giá,đơn vị
        public ActionResult KetQuaTimKiem5(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, int? duongpho, double? gia, int? donvi)
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
            // ViewBag.dientich = dientich;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_duongpho == duongpho && cb.ma_donvi == donvi
                       && cb.gia == gia)
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
        //-------------------------------------- TÌM KIẾM 6
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, đường phố, (diện tích), giá,(đơn vị)
        public ActionResult KetQuaTimKiem6(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, int? duongpho, double? gia)
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
            // ViewBag.dientich = dientich;
            ViewBag.gia = gia;
            // ViewBag.donvi = donvi;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_duongpho == duongpho && cb.gia == gia)
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
        //-------------------------------------- TÌM KIẾM 7
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, đường phố, (diện tích, giá),đơn vị
        public ActionResult KetQuaTimKiem7(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, int? duongpho, int? donvi)
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
            //ViewBag.dientich = dientich;
            // ViewBag.gia = gia;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_duongpho == duongpho && cb.ma_donvi == donvi
                      )
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
        //-------------------------------------- TÌM KIẾM 8
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, đường phố, (diện tích, giá,đơn vị)
        public ActionResult KetQuaTimKiem8(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, int? duongpho)
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
            //  ViewBag.dientich = dientich;
            //  ViewBag.gia = gia;
            //ViewBag.donvi = donvi;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_duongpho == duongpho)
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
        //-------------------------------------- TÌM KIẾM 9
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, (đường phố), diện tích, giá,đơn vị
        public ActionResult KetQuaTimKiem9(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, double? dientich, double? gia, int? donvi)
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
            //ViewBag.duongpho = duongpho;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_donvi == donvi
                      && cb.dientich == dientich && cb.gia == gia)
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
        //-------------------------------------- TÌM KIẾM 10
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã,( đường phố), diện tích, giá,(đơn vị)
        public ActionResult KetQuaTimKiem10(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, double? dientich, double? gia)
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
           // ViewBag.duongpho = duongpho;
            ViewBag.dientich = dientich;
            ViewBag.gia = gia;
           // ViewBag.donvi = donvi;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa 
                      && cb.dientich == dientich && cb.gia == gia)
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
        //-------------------------------------- TÌM KIẾM 11
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, (đường phố,) diện tích, (giá),đơn vị
        public ActionResult KetQuaTimKiem11(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, double? dientich, int? donvi)
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
            //ViewBag.duongpho = duongpho;
            ViewBag.dientich = dientich;
           // ViewBag.gia = gia;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && cb.ma_donvi == donvi
                      && cb.dientich == dientich)
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
        //-------------------------------------- TÌM KIẾM 12
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, (đường phố), diện tích,( giá,đơn vị)
        public ActionResult KetQuaTimKiem12(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa,  double? dientich)
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
            //ViewBag.duongpho = duongpho;
            ViewBag.dientich = dientich;
           // ViewBag.gia = gia;
            //ViewBag.donvi = donvi;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa 
                      && cb.dientich == dientich )
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
        //-------------------------------------- TÌM KIẾM 13
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, (đường phố, diện tích), giá,đơn vị
        public ActionResult KetQuaTimKiem13(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa,  double? gia, int? donvi)
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
            //ViewBag.duongpho = duongpho;
           // ViewBag.dientich = dientich;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa 
                      && cb.ma_donvi == donvi && cb.gia == gia)
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
        //-------------------------------------- TÌM KIẾM 14
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, (đường phố, diện tích), giá,(đơn vị)
        public ActionResult KetQuaTimKiem14(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, double? gia)
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
            //ViewBag.duongpho = duongpho;
            //ViewBag.dientich = dientich;
            ViewBag.gia = gia;
            //ViewBag.donvi = donvi;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa 
                       && cb.gia == gia)
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
        //-------------------------------------- TÌM KIẾM 15
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, (đường phố, diện tích, giá),đơn vị
        public ActionResult KetQuaTimKiem15(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa, int? donvi)
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
            //ViewBag.duongpho = duongpho;
           // ViewBag.dientich = dientich;
           // ViewBag.gia = gia;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa && 
                      cb.ma_donvi == donvi
                      )
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
        //-------------------------------------- TÌM KIẾM 16
        // Từ khóa,loại hình, nội dung loại hình, tỉnh tp,quận huyện,
        //phường xã, (đường phố, diện tích, giá,đơn vị)
        public ActionResult KetQuaTimKiem16(int? page, string tukhoa, int? loaihinh,
            int? ndloaihinh, int? tinhtp, int? quanhuyen, int? phuongxa)
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
           // ViewBag.duongpho = duongpho;
            //ViewBag.dientich = dientich;
           // ViewBag.gia = gia;
           // ViewBag.donvi = donvi;
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
                      cb.ma_tinhtp == tinhtp && cb.ma_quanhuyen == quanhuyen && cb.ma_phuongxa == phuongxa)
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


