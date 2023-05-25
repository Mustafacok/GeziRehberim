using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeziRehberim.BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		void TInsert(T t);
		void TUpdate(T t);
		void TDelete(T t);
		T GetByID(int id);
		List<T> TGetList();
	}
}
