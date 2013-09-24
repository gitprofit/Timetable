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
			var connStr =
				System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnLocal"].ConnectionString;
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
			var entity = repository.GetById(id);
			if (entity == null) throw new HttpResponseException(HttpStatusCode.NotFound);
			else return repository.GetById(id);
		}

		// POST api/<controller>
		public HttpResponseMessage Post([FromBody]TEntity value)
		{
			repository.Add(value);
			repository.SaveChanges();
			return Request.CreateResponse(HttpStatusCode.OK);
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]TEntity value)
		{
			repository.Update(value);
			repository.SaveChanges();
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
			var entity = repository.GetById(id);
			repository.Remove(entity);
			repository.SaveChanges();
		}
	}
}