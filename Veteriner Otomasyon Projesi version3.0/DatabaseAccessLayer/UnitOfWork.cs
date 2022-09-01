using DatabaseAccessLayer.Concrete;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
	public class UnitOfWork:IDisposable
	{
		private readonly VetDbContext context;

		private Repository<Musteri> musteriRepo;
		private LoginRepository kullaniciRepo;
		private Repository<Randevular> randevuRepo;
		private Repository<Doktorlar> doktorRepo;

		public Repository<Musteri> MusteriWork
		{
			get
			{
				if (musteriRepo == null)
					musteriRepo = new Repository<Musteri>(context);
				return musteriRepo;
			}
			
		}
		public LoginRepository kullaniciWork
		{
			get
			{
				if (kullaniciRepo == null)
					kullaniciRepo = new LoginRepository(context);
				return kullaniciRepo;
			}

		}
		public Repository<Randevular> randevuWork
		{
			get
			{
				if (randevuRepo == null)
					randevuRepo = new Repository<Randevular>(context);
				return randevuRepo;
			}

		}
		public Repository<Doktorlar> doktorWork
		{
			get
			{
				if (doktorRepo == null)
					doktorRepo = new Repository<Doktorlar>(context);
				return doktorRepo;
			}

		}
		public UnitOfWork()
		{
			context = new VetDbContext();
		}
		public void Save()
		{
			using (var transaction=context.Database.BeginTransaction())
			{
				try
				{
					context.SaveChanges();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					throw ex;
				}
			}
		}

		public void Dispose()
		{
			doktorRepo?.Dispose();
			kullaniciRepo?.Dispose();
			musteriRepo?.Dispose();
			randevuRepo?.Dispose();

			context?.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
