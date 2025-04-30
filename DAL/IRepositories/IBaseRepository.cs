using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
	public interface IBaseRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		void Delete(T entity);
		Task SaveAsync();
	}
}
