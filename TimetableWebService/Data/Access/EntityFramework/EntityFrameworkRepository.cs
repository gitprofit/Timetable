using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TimetableCore.Util.Errors;

namespace TimetableWebService.Data.Access.EntityFramework
{
	public class EntityFrameworkRepository<TEntity> : TimetableCore.Data.Access.IRepository<TEntity>
		where TEntity : class, TimetableCore.Data.Model.IEntity
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
			try { return context.Set<TEntity>().First(t => t.ID == id); }
			catch (Exception ex) { throw new EntityNotFoundException(typeof(TEntity).Name, ex); }
		}

		public IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate)
		{
			return context.Set<TEntity>().Where(predicate).ToList();
		}

		public void Add(TEntity entity)
		{
			context.Set<TEntity>().Add(entity);
		}

		public void Remove(TEntity entity)
		{
			try { context.Set<TEntity>().Remove(entity); }
			catch (Exception ex) { throw new EntityNotFoundException(typeof(TEntity).Name, ex); }
		}

		public void Update(TEntity entity)
		{
			var oldEntity = GetById(entity.ID);
			context.Entry(oldEntity).CurrentValues.SetValues(entity);
			context.Entry(oldEntity).OriginalValues.SetValues(oldEntity);
			context.Entry(oldEntity).State = System.Data.EntityState.Modified;
			context.Entry(entity).State = System.Data.EntityState.Detached;
		}

		public void SaveChanges()
		{
			context.SaveChanges();
		}
	}
}
