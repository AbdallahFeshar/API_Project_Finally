using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly StoreData _dbcontext;
        public GenericRepository(StoreData dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
		{
			if(typeof(T) == typeof(Product)) 
				return (IEnumerable<T>) await _dbcontext.products.Include(p => p.brand).Include(p => p.type).ToListAsync();
			else
			return await _dbcontext.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			//return await  _dbcontext.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
			return await _dbcontext.Set<T>().FindAsync(id);
		}
	}
}
