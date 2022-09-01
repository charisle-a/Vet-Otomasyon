using DatabaseAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Concrete
{
	public class LoginRepository : Repository<Kullanici>, IKullaniciRepository
	{
		public LoginRepository(DbContext context) : base(context)
		{
		}

		public bool Login(string EPosta, string Parola)
		{
			if (context.Set<Kullanici>().FirstOrDefault(x =>
			 x.UserName.ToLower().Equals(EPosta.ToLower()) &&
			 x.Password.Equals(Parola)) != null)
				return true;
			else
				return false;
		}
	}
}
