using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimetableCore.Data.Model;
using TimetableCore.Data.Access;
using TimetableWebService.Data.Access.EntityFramework;

namespace TimetableWebService.Controllers
{
	public class EntityController<TEntity> : ApiController
		where TEntity : class, IEntity
	{
		IRepository<TEntity> repository;

		public EntityController()
		{
			var connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnLocal"].ConnectionString;
			var context = new ModelContext(connStr);
			repository = new EntityFrameworkRepository<TEntity>(context);
		}

		// GET api/<controller>
		public IEnumerable<TEntity> Get()
		{
			return repository.GetAll();
		}

		// GET api/<controller>/5
		public TEntity Get(int id)
		{
			//return "value";
			throw new NotImplementedException();
		}

		// POST api/<controller>
		public void Post([FromBody]TEntity value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]TEntity value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{

		}
	}

	public class ScheduleController : EntityController<Schedule>
	{
		//
	}
}