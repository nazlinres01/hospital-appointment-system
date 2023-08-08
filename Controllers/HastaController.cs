using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace HastaneRandevuSistemi.Controllers
{

    public class HastaController : Controller
    {
        private readonly HastaneContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        public HastaController(IStringLocalizer<HomeController> localizer, HastaneContext context)
        {
            _localizer = localizer;
            _context = context;
        }

        static List<Hasta> hastalar = new List<Hasta>();

        public IActionResult Index()
        {
            return View(hastalar);
        }

        [HttpPost]
        public IActionResult HastaKaydet()
        {
            string Isim = HttpContext.Request.Form["Isim"];
            string SoyIsim = HttpContext.Request.Form["SoyIsim"];
            string TelefonNumarasi = HttpContext.Request.Form["TelefonNumarasi"];
            string Email = HttpContext.Request.Form["email"];

            Hasta newHasta = new Hasta
            {
                Isim = Isim,
                SoyIsim = SoyIsim,
                TelefonNumarasi = TelefonNumarasi,
                Email = Email,
            };

            hastalar.Add(newHasta);
            return View("Index", hastalar);
        }

        [HttpGet]
        public string HastaKaydetGet()
        {
            string Isim = HttpContext.Request.Query["Isim"];
            string SoyIsim = HttpContext.Request.Query["SoyIsim"];
            string TelefonNumarasi = HttpContext.Request.Query["TelefonNumarasi"];
            string Email = HttpContext.Request.Query["email"];

            string text = Isim + " " + SoyIsim + " " + TelefonNumarasi + " " + Email;
            return text;
        }

        public string HastaKaydetBagla(string Isim, string SoyIsim, string TelefonNumarasi, string Email)
        {
            string text = Isim + " " + SoyIsim + " " + TelefonNumarasi + " " + Email;
            return text;
        }

        public IActionResult HastaKaydetModel(Hasta hasta)
        {
            hastalar.Add(hasta);
            return View("Index", hastalar);
        }
    }
}