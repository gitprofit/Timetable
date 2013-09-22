using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TimetableData.Model;

namespace TimetableData.Access.WebApi
{
	public class WebApiRepository<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity
	{
		protected string apiServer;
		protected string controllerName;
		protected string apiAddress;

		public WebApiRepository(string apiServer)
		{
			this.apiServer = apiServer;
			this.controllerName = typeof(TEntity).Name;
			this.apiAddress = apiServer + "/api" + controllerName + "/";
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			throw new NotImplementedException();
		}

		public TEntity GetById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public void Add(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Remove(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Update(TEntity entity)
		{
			throw new NotImplementedException();
		}
	}

	public class ScheduleRepository : WebApiRepository<Schedule>
	{
		public ScheduleRepository(string apiServer)
			: base(apiServer)
		{ }

		public override IEnumerable<Schedule> GetAll()
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpResponseMessage response = client.GetAsync(apiAddress).Result;
			return response.Content.ReadAsAsync<IEnumerable<Schedule>>().Result;
		}
	}
}
