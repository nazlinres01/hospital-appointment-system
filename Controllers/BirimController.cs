using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace HastaneRandevuSistemi.Controllers
{
    
    public class BirimController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly HastaneContext _context;

        public BirimController(IStringLocalizer<HomeController> localizer, HastaneContext context)
        {
            _localizer = localizer;
            _context = context;
        }
        static List<Birim> birimler = new List<Birim>();

        public IActionResult Index()
        {
            return View(birimler);
        }

        [HttpPost]
        public IActionResult BirimKaydet()
        {
            string isim = HttpContext.Request.Form["Isim"];

            Birim newBirim = new Birim()
            {
                Isim = isim,
            };

            birimler.Add(newBirim);
            return View("Index", birimler);
        }

        [HttpGet]
        public string BirimKaydetGet()
        {
            string isim = HttpContext.Request.Query["Isim"];

            string text = isim;
            return text;
        }

        public string BirimKaydetBagla(string isim)
        {
            string text = isim;
            return text;
        }

        public IActionResult BirimKaydetModel(Birim birim)
        {
            birimler.Add(birim);
            return View("Index", birimler);
        }
    }
}