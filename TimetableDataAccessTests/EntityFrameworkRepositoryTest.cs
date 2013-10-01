using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using TimetableWebService.Data.Access.EntityFramework;
using TimetableCore.Data.Access;
using TimetableCore.Data.Model;
using TimetableCore.Util.Errors;

namespace TimetableDataAccessTests
{
	[TestClass]
	public class EntityFrameworkRepositoryTest : BaseTest
	{
		private ModelContext context;
		private IRepository<User> users;

		[TestInitialize]
		public void Init()
		{
			WriteLine("EntityFrameworkRepoTest init!");
			Database.SetInitializer<ModelContext>(new EntityFrameworkDbInitializer());

			context = new ModelContext("Server=localhost;User Id=liszcz;Password=usFnsiUD;Database=liszcz;");
			users = new EntityFrameworkRepository<User>(context);
		}

		[TestCleanup]
		public void Cleanup()
		{
			context.Dispose();
		}

		[TestMethod]
		public void TestUserGetAll()
		{
			var all = users.GetAll();
			var names = all.Select(t => t.Username);

			var expected = new [] { "UzytkownikJeden", "UzytkownikDwa", "UzytkownikTrzy" };
			
			Assert.AreEqual(names.Count(), expected.Count());
			CollectionAssert.AreEqual(names.ToList(), expected.ToList());
		}

		[TestMethod]
		public void TestUserGetById()
		{
			int id = 1;

			var user = users.GetById(id);
			Assert.IsNotNull(user);

			var name = user.Username;
			var expected = "UzytkownikJeden";
			Assert.AreEqual(name, expected);
			Assert.AreEqual(user.Id, id);
		}

		[TestMethod]
		[ExpectedException(typeof(EntityNotFoundException))]
		public void TestUserGetByIdNotFound()
		{
			int id = -1;
			var user = users.GetById(id);
		}
	}
}
