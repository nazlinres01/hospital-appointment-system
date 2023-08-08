using HastaneRandevuSistemi.Models;
using HastaneRandevuSistemi.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace HastaneRandevuSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HastaneContext _context;
        private LanguageService _localization;
        public HomeController(ILogger<HomeController> logger, LanguageService localization, HastaneContext context)
        {
            _localization = localization;
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = _localization.Getkey("Hastane Randevu Sistemi");
            ViewBag.WelcomeMessage = _localization.Getkey("Ana Sayfa");
            ViewBag.WelcomeMessage = _localization.Getkey("Randevular");
            ViewBag.WelcomeMessage = _localization.Getkey("Hastalýklar");
            ViewBag.WelcomeMessage = _localization.Getkey("Doktorlar");
            ViewBag.WelcomeMessage = _localization.Getkey("Birimler");
            ViewBag.WelcomeMessage = _localization.Getkey("Poliklinikler");
            ViewBag.WelcomeMessage = _localization.Getkey("Giriþ Yap");
            ViewBag.WelcomeMessage = _localization.Getkey("Kaydol");
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}