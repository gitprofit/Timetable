using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimetableModel.Domain;

namespace TimetableModel.Repository
{
	interface IRepository<TEntity>
		where TEntity : class, IEntity
	{
		IEnumerable<TEntity> getAll();
		TEntity getById(int id);
		void Add(TEntity entity);
		void Remove(TEntity entity);
		void Update(TEntity entity);
	}
}
