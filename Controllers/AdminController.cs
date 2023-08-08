using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;

namespace HastaneRandevuSistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HastaneContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;

        public AdminController(UserManager<ApplicationUser> userManager, HastaneContext context, IStringLocalizer<HomeController> localizer)
        {
            _userManager = userManager;
            _context = context;
            _localizer = localizer;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

   
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View("EditUser", user);
            }
            return View("Error");
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                return View("Error");
            }
            return View("Error");
        }

        public async Task<IActionResult> ContentManagement()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }


        public async Task<IActionResult> Dashboard()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }



    }
}
