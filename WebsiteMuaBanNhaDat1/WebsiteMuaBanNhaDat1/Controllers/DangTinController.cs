﻿using System;
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
        public ActionResult DangTinCBCHT()
        {
            ViewBag.DMLoaiHinh = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");
            ViewBag.DMLoaiHinh1 = new SelectList(db.LoaiHinh.ToList().Where(n => n.nhom == "CBCHT" || n.nhom == "CMCT").OrderBy(n => n.ma_loaihinh), "ma_loaihinh", "ten_loaihinh");
            ViewBag.DMTinhTP1 = new SelectList(db.TinhTP.ToList().OrderBy(n => n.ten_tinhtp), "ma_tinhtp", "ten_tinhtp");

            return View();
        }
    }
}