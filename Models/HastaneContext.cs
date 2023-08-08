using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace HastaneRandevuSistemi.Models
{
	public class HastaneContext : DbContext
	{
		public HastaneContext(DbContextOptions<HastaneContext> options)
			: base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers
		{   
			get; 
			set; 
		}
        public DbSet<Birim> Birims
		{
			get;
			set;
		}
		public DbSet<Doktor> Doktors
		{
			get;
			set;
		}
		public DbSet<Hasta> Hastas
		{
			get;
			set;
		}
		public DbSet<Hastalik> Hastaliks
		{
			get;
			set;
		}
		public DbSet<Poliklinik> Polikliniks
		{
			get;
			set;
		}
		public DbSet<Randevu> Randevus
		{
			get;
			set;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database = HastaneRandevuSistemi;Trusted_Connection = True;");
		}
	}
}