using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using TimetableCore.Data.Model;

namespace TimetableCore.Data.Access.WebApi
{
	public class WebApiRepository<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity
	{
		private string serviceRoot;
		private string controllerName;
		private string serviceUrl;

		private HttpClient client;

		public WebApiRepository(string serviceRoot)
		{
			this.serviceRoot = serviceRoot;
			this.controllerName = typeof(TEntity).Name;
			this.serviceUrl = serviceRoot + controllerName + "/";

			client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			HttpResponseMessage response = client.GetAsync(serviceUrl).Result;
			return response.Content.ReadAsAsync<IEnumerable<TEntity>>().Result;
		}

		public TEntity GetById(int id)
		{
			HttpResponseMessage response = client.GetAsync(serviceUrl + id).Result;
			return response.Content.ReadAsAsync<TEntity>().Result;
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

		public void SaveChanges()
		{
			throw new NotImplementedException();
		}
	}
}
