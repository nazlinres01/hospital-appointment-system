using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemi.Models
{
	public class ApplicationUser : IdentityUser
	{
		// ID pass email silindi identityuser zaten hepsini kapsiyormus
		public string UserType { get; set; } // "Admin" veya "RegisteredUser" 
		public int TotalSiteVisits { get; set; }
		public int TotalContentCount { get; set; }
		public int TotalUserCount { get; set; }
		
	}
}