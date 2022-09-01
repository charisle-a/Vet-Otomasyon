using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Abstract
{
	public interface IKullaniciRepository: IRepository<Kullanici>
	{
		bool Login(string userName, string Parola);
	}
}
