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
		public HttpResponseMessage Get(int id)
		{
			var entity = repository.GetById(id);
			if (entity == null) return Request.CreateResponse(HttpStatusCode.NotFound);
			else return Request.CreateResponse(HttpStatusCode.OK, entity);
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
			repository.Update(id, value);
			repository.SaveChanges();

			/*
			  var princess = context.Princesses.Find(1);
  var rapunzel = new Princess { Id = 1, Name = "Rapunzel" };
  var rosannella = new PrincessDto { Id = 1, Name = "Rosannella" };

  // Change the current and original values by copying the values
  // from other objects
  var entry = context.Entry(princess);
  entry.CurrentValues.SetValues(rapunzel);
  entry.OriginalValues.SetValues(rosannella);

  // Print out current and original values
  Console.WriteLine("Current values:");
  PrintValues(entry.CurrentValues);

  Console.WriteLine("\nOriginal values:");
  PrintValues(entry.OriginalValues);
			 * */
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