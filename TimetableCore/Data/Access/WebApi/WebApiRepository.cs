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
		protected string serviceRoot;
		protected string controllerName;
		protected string serviceUrl;

		private HttpClient client;

		public WebApiRepository(string serviceRoot)
		{
			this.serviceRoot = serviceRoot;
			this.controllerName = typeof(TEntity).Name;
			this.serviceUrl = serviceRoot + "/" + controllerName + "/";

			client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public IEnumerable<TEntity> GetAll()
		{
			HttpResponseMessage response = client.GetAsync(serviceUrl).Result;
			return response.Content.ReadAsAsync<IEnumerable<TEntity>>().Result;
		}

		public TEntity GetById(int id)
		{
			HttpResponseMessage response = client.GetAsync(serviceUrl + id).Result;
			return response.Content.ReadAsAsync<TEntity>().Result;
		}

		public IEnumerable<TEntity> GetByOwner(User owner)
		{
			throw new NotImplementedException();
		}

		public void Add(TEntity entity)
		{
			HttpResponseMessage response = client.PostAsJsonAsync(serviceUrl, entity).Result;
			if (!response.IsSuccessStatusCode)
				throw new Exception("TODO");
		}

		public void Remove(TEntity entity)
		{
			HttpResponseMessage response = client.DeleteAsync(serviceUrl + entity.Id).Result;
			if (!response.IsSuccessStatusCode)
				throw new Exception("TODO");
		}

		public void Update(TEntity entity)
		{
			HttpResponseMessage response = client.PutAsJsonAsync(serviceUrl + entity.Id, entity).Result;
			if (!response.IsSuccessStatusCode)
				throw new Exception("TODO");
		}

		public void SaveChanges()
		{
			//
		}
	}
}
