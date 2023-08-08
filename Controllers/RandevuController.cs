using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace HastaneRandevuSistemi.Controllers
{

    public class RandevuController : Controller
    {
        private readonly HastaneContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        public RandevuController(IStringLocalizer<HomeController> localizer, HastaneContext context)
        {
            _localizer = localizer;
            _context = context;
        }

        public IActionResult Randevular()
        {
            var randevular = _context.Randevus.ToList();
            return View(randevular);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}