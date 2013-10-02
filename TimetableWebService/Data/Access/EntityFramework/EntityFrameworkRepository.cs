using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TimetableCore.Util.Errors;
using TimetableCore.Data.Model;
using TimetableCore.Data.Access;

namespace TimetableWebService.Data.Access.EntityFramework
{
	public class EntityFrameworkRepository<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity
	{
		protected ModelContext context;

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
			try { return context.Set<TEntity>().First(t => t.Id == id); }
			catch (Exception ex) { throw new EntityNotFoundException(typeof(TEntity).Name, ex); }
		}

		public IEnumerable<TEntity> GetByOwner(User owner)
		{
			try
			{
				return
					context.Set<TEntity>()
					.ToList()
					.Cast<IOwnable>()
					.Where(t => t.Owner.Id == owner.Id)
					.Cast<TEntity>()
					.ToList();
			}
			catch (Exception ex)
			{
				throw new EntityNotOwnableException(typeof(TEntity).Name, ex);
			}
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
			var oldEntity = GetById(entity.Id);
			context.Entry(oldEntity).CurrentValues.SetValues(entity);
		} 

		public void SaveChanges()
		{
			try { context.SaveChanges(); }
			catch (Exception ex)
			{
				throw new EntityPersistenceException(ex);
			}
				
		}
	}
}
