using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimetableModel.Domain;

namespace TimetableModel.Repository.Crud
{
	public class CrudRepository<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity
	{
		private ModelContext context;

		public CrudRepository(ModelContext context)
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
			throw new NotImplementedException();
		}
	}
}
