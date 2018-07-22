using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;

namespace WebSiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            var lstSanPham = db.SanPhams;
            return PartialView(lstSanPham);
        }

        public ActionResult DangKy(ThanhVien tv)
        {
            if(ModelState.IsValid)
            {
                db.ThanhViens.Add(tv);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return PartialView("~/Views/Home/LoginPartial.cshtml", tv);
        }

        [HttpGet]
        public ActionResult LeftMenu()
        {
            var lstSP = db.SanPhams;
            return PartialView(lstSP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}