using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimetableCore.Model;

namespace TimetableCore.Access
{
	interface IRepository<TEntity>
		where TEntity : class, IEntity
	{
		IEnumerable<TEntity> GetAll();
		TEntity GetById(int id);
		void Add(TEntity entity);
		void Remove(TEntity entity);
		void Update(TEntity entity);
	}
}
