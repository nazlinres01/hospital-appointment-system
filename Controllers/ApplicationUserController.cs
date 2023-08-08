using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneRandevuSistemi.Controllers
{
	public class ApplicationUserController : Controller
	{
		private readonly IStringLocalizer<HomeController> _localizer;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly HastaneContext _context;

		public ApplicationUserController(IStringLocalizer<HomeController> localizer, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, HastaneContext context)
		{
			_localizer = localizer;
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var users = _userManager.Users.ToList();
			return View(users);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(string userName, string password)
		{
			var user = await _userManager.FindByNameAsync(userName);
			var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

			if (result.Succeeded)
			{
				return View("UserProfile", user);
			}

			return View("LoginFailed");
		}

		[HttpGet]
		public async Task<IActionResult> Profile()
		{
			var user = await _userManager.GetUserAsync(User);
			return View(user);
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(string userName, string password)
		{
			var user = new ApplicationUser
			{
				UserName = userName,
				Email = userName
			};
			var result = await _userManager.CreateAsync(user, password);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProfile(ApplicationUser updatedUser)
		{
			var user = await _userManager.FindByIdAsync(updatedUser.Id);

			if (user != null)
			{
				user.UserName = updatedUser.UserName;
				user.Email = updatedUser.Email;

				var result = await _userManager.UpdateAsync(user);

				if (result.Succeeded)
				{
					return RedirectToAction("Profile");
				}
			}

			return View("Error");
		}
	}
}
