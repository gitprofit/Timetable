using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TimetableCore.Model;

namespace TimetableCore.Access.EntityFramework
{
	public abstract class EntityFrameworkRepository<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity
	{
		private ModelContext context;

		public EntityFrameworkRepository(ModelContext context)
		{
			this.context = context;
		}

		public IEnumerable<TEntity> GetAll()
		{
			return context.Set<TEntity>().ToList();
		}

		public TEntity GetById(int id)
		{
			return context.Set<TEntity>().FirstOrDefault(t => t.ID == id);
		}

		public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
		{
			return context.Set<TEntity>().Where(predicate).ToList();
		}

		public void Add(TEntity entity)
		{
			context.Set<TEntity>().Add(entity);
		}

		public void Remove(TEntity entity)
		{
			context.Set<TEntity>().Remove(entity);
		}

		public void Update(TEntity entity)
		{
			context.Entry(entity).State = System.Data.EntityState.Modified;
		}
	}
}
