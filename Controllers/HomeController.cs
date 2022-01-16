using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eticaret.Models.Classes;


namespace eticaret.Controllers
{


    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Teknoloji()
        {

            var urun = c.Ürüns.Where(x => x.KategoriAd == "1" && "Yayımlanmış" == x.Durum).ToList();
                return View(urun);
        }
        public ActionResult BeyazEsya()
        {

            var urunler = c.Ürüns.Where(x => x.KategoriAd == "2" && "Yayımlanmış" == x.Durum).ToList();
            return View(urunler);
        }
        public ActionResult Index()
        {
            var urunler = c.Ürüns.Where(x=>x.Durum=="Yayımlanmış").ToList();
            return View(urunler);
        }

        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {


            return View();
        }
    }
}
