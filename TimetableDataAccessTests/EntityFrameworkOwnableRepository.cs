using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimetableWebService.Data.Access.EntityFramework;
using TimetableCore.Data.Access;
using System.Data.Entity;
using TimetableCore.Data.Model;

namespace TimetableDataAccessTests
{
	[TestClass]
	public class EntityFrameworkOwnableRepository
	{
		private ModelContext context;
		private IRepository<User> users;
		private IOwnableRepository<Instructor> instructors;

		[TestInitialize]
		public void Init()
		{
			Database.SetInitializer<ModelContext>(new EntityFrameworkDbInitializer());

			context = new ModelContext("Server=localhost;User Id=liszcz;Password=usFnsiUD;Database=liszcz;");

			context.Database.Initialize(true);

			instructors = new EntityFrameworkOwnableRepository<Instructor>(context);
			users = new EntityFrameworkRepository<User>(context);
		}

		[TestCleanup]
		public void Cleanup()
		{
			context.Dispose();
		}

		[TestMethod]
		public void TestInstructorGetByOwner()
		{
			var owner = users.GetAll().Where(t => t.Username == "UzytkownikTrzy").First();
			Assert.IsNotNull(owner);

			var ins = instructors.GetByOwner(owner);
			var names = ins.Select(t => t.Name);
			var expected = new[] { "Prowadzacy Szesc", "Prowadzacy Siedem", "Prowadzacy Osiem" };

			CollectionAssert.AreEqual(expected.ToList(), names.ToList());
		}
	}
}
