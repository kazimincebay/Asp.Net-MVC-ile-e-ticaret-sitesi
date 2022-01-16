using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eticaret.Models.Classes;

namespace eticaret.Controllers
{
    public class ÜrünController : Controller
    {
        // GET: Ürün
        
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var urunler = c.Ürüns.ToList();
            return View("Index",urunler);
        }

        [HttpGet]
        [Authorize]
        public ActionResult YeniUrun()
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
        public ActionResult YeniUrun(Ürün p)
        {
            
            c.Ürüns.Add(p);
            c.SaveChanges();
            return RedirectToAction("ÜrünOnay");
        }
        [Authorize]
        public ActionResult ÜrünOnay()
        {
            return View();
        }
        
        public ActionResult UrunYayımla(int id)
        {
            var isim = c.Ürüns.Find(id);
            isim.Durum = "Yayımlanmış";
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Urunsil(int id)
        {
            var degerler = c.Ürüns.Find(id);
            degerler.Durum = "Yayınlanmamış";
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategorilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            var urun = c.Ürüns.Find(id);
            return View("ÜrünGetir", urun);
        }

        public ActionResult UrunGuncelle(Ürün p)
        {
            var urn = c.Ürüns.Find(p.ÜrünID);
            urn.ÜrünAd = p.ÜrünAd;
            urn.ÜrünBilgi = p.ÜrünBilgi;
            urn.ÜrünFiyat = p.ÜrünFiyat;
            urn.ÜrünGörsel = p.ÜrünGörsel;
            urn.ÜrünBilgi = p.ÜrünBilgi;
            urn.KategoriAd = p.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ÜrünBilgi(int id)
        {
            var degerler = c.Ürüns.Where(x => x.ÜrünID == id).ToList();
            return View(degerler);
        }




    }
}