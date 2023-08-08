using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace HastaneRandevuSistemi.Controllers
{
    

    public class DoktorController : Controller
    {   
        private readonly HastaneContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        public DoktorController(IStringLocalizer<HomeController> localizer, HastaneContext context)
        {
            _localizer = localizer;
            _context = context;
        }

        static List<Doktor> doktorlar = new List<Doktor>();

        public IActionResult Index()
        {

            return View(doktorlar);
        }

        [HttpPost]
        public IActionResult DoktorKaydet()
        {
            string isim = HttpContext.Request.Form["Isim"];
            string soyIsim = HttpContext.Request.Form["SoyIsim"];
            int birimId = int.Parse(HttpContext.Request.Form["BirimId"]);
            int poliklinikId = int.Parse(HttpContext.Request.Form["PoliklinikId"]);

            Doktor newDoktor = new Doktor
            {
                Isim = isim,
                SoyIsim = soyIsim,
                BirimId = birimId,
                PoliklinikId = poliklinikId

            };

            doktorlar.Add(newDoktor);
            return View("Index", doktorlar);
        }

        [HttpGet]
        public string DoktorKaydetGet()
        {
            string isim = HttpContext.Request.Query["Isim"];
            string soyIsim = HttpContext.Request.Query["SoyIsim"];
            int birimId = int.Parse(HttpContext.Request.Query["BirimId"]);
            int poliklinikId = int.Parse(HttpContext.Request.Query["PoliklinikId"]);

            string text = isim + " " + soyIsim + " " + birimId + " " + poliklinikId;
            return text;
        }

        public IActionResult DoktorKaydetModel(Doktor doktor)
        {
            doktorlar.Add(doktor);
            return View("Index", doktorlar);
        }
    }
}