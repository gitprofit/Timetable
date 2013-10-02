using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using TimetableWebService.Data.Access.EntityFramework;
using TimetableCore.Data.Access;
using TimetableCore.Data.Model;
using TimetableCore.Util.Errors;
using TimetableWebService.Controllers;
using System.Web.Http;
using System.Net;

namespace TimetableDataAccessTests
{
	[TestClass]
	public class EntityControllerTest
	{
		EntityController<User> users;
		EntityController<Course> courses;
		ModelContext context;

		[TestInitialize]
		public void Init()
		{
			Database.SetInitializer<ModelContext>(new EntityFrameworkDbInitializer());
			context = new ModelContext("Server=localhost;User Id=liszcz;Password=usFnsiUD;Database=liszcz;");
			context.Database.Initialize(true);

			var usersRepo = new EntityFrameworkRepository<User>(context);
			users = new EntityController<User>(usersRepo);
			users.Request = new System.Net.Http.HttpRequestMessage();

			var coursesRepo = new EntityFrameworkRepository<Course>(context);
			courses = new EntityController<Course>(coursesRepo);
			courses.Request = new System.Net.Http.HttpRequestMessage();
		}

		[TestCleanup]
		public void Cleanup()
		{
			context.Dispose();
		}

		[TestMethod]
		public void TestGet()
		{
			var usr = users.Get();
			var names = usr.Select(t => t.Username);
			var expected = new[] { "UzytkownikJeden", "UzytkownikDwa", "UzytkownikTrzy" };

			CollectionAssert.AreEqual(expected.ToList(), names.ToList());
		}

		[TestMethod]
		public void TestGetOne()
		{
			var user = users.Get(1);
			Assert.IsNotNull(user);
			var name = user.Username;
			var expected = "UzytkownikJeden";

			Assert.AreEqual(expected, name);
		}

		[TestMethod]
		[ExpectedException(typeof(HttpResponseException))]
		public void TestGetOneNotFound()
		{
			var user = users.Get(-1);
		}

		[TestMethod]
		public void TestPost()
		{
			var newUser = new User { Username = "NowyUzytkownikDoTestow" };

			users.Post(newUser);
			var names = users.Get().Select(t => t.Username);

			CollectionAssert.Contains(names.ToList(), newUser.Username);
		}

		[TestMethod]
		public void TestPut()
		{
			var user = users.Get().First();
			user.Username = "ZaktualizowanyUzytkownik";

			var response = users.Put(user.Id, user);
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

			var newUser = users.Get().First();
			Assert.AreEqual(user.Username, newUser.Username);
		}

		[TestMethod]
		public void TestPutNofFound()
		{
			int id = 999;
			var user = new User { Id = id, Username = "NowyUzytkownikTestowy" };

			var response = users.Put(user.Id, user);
			Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
		}

		[TestMethod]
		public void TestPutInvalidUser()
		{
			int id = 999;
			var user = new User { Id = id, Username = "NowyUzytkownikTestowy" };

			var response = users.Put(1, user);
			Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
		}

		[TestMethod]
		public void TestDelete()
		{
			var user = users.Get(1);
			var names = users.Get().Select(t => t.Username);
			CollectionAssert.Contains(names.ToList(), user.Username);

			var response = users.Delete(user.Id);
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

			names = users.Get().Select(t => t.Username);
			CollectionAssert.DoesNotContain(names.ToList(), user.Username);

			response = users.Delete(user.Id);
			Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
		}

		[TestMethod]
		public void TestPostCourseWithoutRequiredFK()
		{
			var course = new Course { Name = "Testowe zajecia" };
			var response = courses.Post(course);
			Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
		}

		[TestMethod]
		public void TestPostCourseWithRequiredFK()
		{
			var owner = users.Get(1);
			var course = new Course { Name = "Testowe zajecia", Owner = owner };
			var response = courses.Post(course);
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
		}
	}
}
