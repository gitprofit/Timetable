using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimetableCore.Data.Model;
using TimetableCore.Data.Access;
using TimetableCore.Util.Errors;
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
		public HttpResponseMessage Get(int id)
		{
			try
			{
				var entity = repository.GetById(id);
				return Request.CreateResponse(HttpStatusCode.OK, entity);
			}
			catch(EntityNotFoundException)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}
		}

		// POST api/<controller>
		public HttpResponseMessage Post([FromBody]TEntity value)
		{
			repository.Add(value);
			repository.SaveChanges();
			return Request.CreateResponse(HttpStatusCode.OK);
		}

		// PUT api/<controller>/5
		public HttpResponseMessage Put(int id, [FromBody]TEntity value)
		{
			if (id == value.ID)
			{
				try
				{
					repository.Update(value);
					repository.SaveChanges();
					return Request.CreateResponse(HttpStatusCode.OK);
				}
				catch (EntityNotFoundException)
				{
					return Request.CreateResponse(HttpStatusCode.NotFound);
				}
			}
			else return Request.CreateResponse(HttpStatusCode.BadRequest);
		}

		// DELETE api/<controller>/5
		public HttpResponseMessage Delete(int id)
		{
			try
			{
				var entity = repository.GetById(id);
				repository.Remove(entity);
				repository.SaveChanges();
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (EntityNotFoundException)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}
		}
	}
}