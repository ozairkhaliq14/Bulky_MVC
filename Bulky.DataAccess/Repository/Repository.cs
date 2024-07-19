using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
			_db = db;
			this.dbSet = _db.Set<T>();
        }

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public T Get(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Remove(T entity)
		{
			throw new NotImplementedException();
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			throw new NotImplementedException();
		}
	}
}
