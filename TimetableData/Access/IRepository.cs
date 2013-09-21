﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TimetableData.Model;

namespace TimetableData.Access
{
	public interface IRepository<TEntity>
		where TEntity : class, IEntity
	{
		IEnumerable<TEntity> GetAll();
		TEntity GetById(int id);
		IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate);
		void Add(TEntity entity);
		void Remove(TEntity entity);
		void Update(TEntity entity);
	}
}