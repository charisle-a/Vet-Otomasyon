using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Abstract
{
	public interface IRepository<T>:IDisposable where T:class
	{
		IEnumerable<T> GetAll();
		T GetItem(Object key);
		void Add(T item);
		void Remover(T item);
		void Update(T item);
	}
}
