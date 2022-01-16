using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eticaret.Models.Classes;

namespace eticaret.Controllers
{
    public class ÖğrenciPanelController : Controller
    {
        Context c = new Context();
        // GET: Öğrenci
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ÜrünEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategorilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();

        }
        [HttpPost]
        [Authorize]
        public ActionResult ÜrünEkle(Ürün p)
        {

            c.Ürüns.Add(p);
            c.SaveChanges();
            return RedirectToAction("ÜrünOnay");
        }

        public ActionResult ÜrünOnay()
        {
            return View();
        }





    }
    
}