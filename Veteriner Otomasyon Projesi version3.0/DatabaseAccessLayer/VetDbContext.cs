using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
	public class VetDbContext:DbContext
	{
		public DbSet<Doktorlar> Doktorlars { get; set; }
		public DbSet<Musteri> Musteriler { get; set; }
		public DbSet<Randevular> Randevulars { get; set; }
		public DbSet<Kullanici>Kullanicilar { get; set; }
		public VetDbContext():base("name=VetDbConnString")
		{
			Database.SetInitializer<VetDbContext>(new MyInitializer());
		}

	}
	public class MyInitializer:CreateDatabaseIfNotExists<VetDbContext>
	{
		protected override void Seed(VetDbContext context)
		{
			base.Seed(context); 
		}
	}
}
