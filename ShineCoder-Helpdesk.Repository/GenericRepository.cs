using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShineCoder_Helpdesk.Infrastructure;

namespace ShineCoder_Helpdesk.Repository
{
	public class GenericRepository<TEntity> where TEntity : class
	{
		internal HelpdeskDbContext context;
		internal DbSet<TEntity> dbSet;

		public GenericRepository(IHelpdeskDbContext _context)
		{
			this.context = (HelpdeskDbContext?)_context;
			this.dbSet = context.Set<TEntity>();
		}

		public async virtual Task<IEnumerable<TEntity>> GetAsync(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return await orderBy(query).ToListAsync();
			}
			else
			{
				return await query.ToListAsync();
			}
		}

		public async virtual Task<TEntity> GetByIDAsync(object id)
		{
			return await dbSet.FindAsync(id);
		}

		public async virtual void InsertAsyn(TEntity entity)
		{
			await dbSet.AddAsync(entity);
		}

		public async virtual void DeleteAsync(object id)
		{
			TEntity entityToDelete = await dbSet.FindAsync(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
		}

		public async virtual void UpdateAsync(TEntity entityToUpdate)
		{
			dbSet.Attach(entityToUpdate);
			context.Entry(entityToUpdate).State = EntityState.Modified;
		}
	}
}
