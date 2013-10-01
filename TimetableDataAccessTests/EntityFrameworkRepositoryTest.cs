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
			Database.SetInitializer<ModelContext>(new EntityFrameworkDbInitializer());

			context = new ModelContext("Server=localhost;User Id=liszcz;Password=usFnsiUD;Database=liszcz;");

			context.Database.Initialize(true);

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
			
			Assert.AreEqual(expected.Count(), names.Count());
			CollectionAssert.AreEqual(expected.ToList(), names.ToList());
		}

		[TestMethod]
		public void TestUserGetById()
		{
			int id = 1;

			var user = users.GetById(id);
			Assert.IsNotNull(user);

			var name = user.Username;
			var expected = "UzytkownikJeden";
			Assert.AreEqual(expected, name);
			Assert.AreEqual(id, user.Id);
		}

		[TestMethod]
		[ExpectedException(typeof(EntityNotFoundException))]
		public void TestUserGetByIdNotFound()
		{
			int id = -1;
			var user = users.GetById(id);
		}

		[TestMethod]
		public void TestUserAdd()
		{
			var newUser = new User { Username = "NowyUzytkownikDoTestow" };
			
			users.Add(newUser);
			users.SaveChanges();

			var names = users.GetAll().Select(t => t.Username);

			CollectionAssert.Contains(names.ToList(), newUser.Username);
		}

		[TestMethod]
		public void TestUserRemove()
		{
			var user = users.GetById(1);
			var names = users.GetAll().Select(t => t.Username);
			CollectionAssert.Contains(names.ToList(), user.Username);

			users.Remove(user);
			users.SaveChanges();
			names = users.GetAll().Select(t => t.Username);
			CollectionAssert.DoesNotContain(names.ToList(), user.Username);
		}

		[TestMethod]
		[ExpectedException(typeof(EntityNotFoundException))]
		public void TestUserRemoveNotFound()
		{
			var user = new User { Username = "NowyUzytkownikTestowy" };
			users.Remove(user);
		}

		[TestMethod]
		public void TestUserUpdate()
		{
			var user = users.GetAll().First();
			user.Username = "ZaktualizowanyUzytkownik";

			users.Update(user);
			users.SaveChanges();

			var newUser = users.GetAll().First();
			Assert.AreEqual(user.Username, newUser.Username);
		}

		[TestMethod]
		public void TestInstructorGetByOwner()
		{
			var instructors = new EntityFrameworkRepository<Instructor>(context);

			var owner = users.GetAll().Where(t => t.Username == "UzytkownikTrzy").First();
			Assert.IsNotNull(owner);

			var ins = instructors.GetByOwner(owner);
			var names = ins.Select(t => t.Name);
			var expected = new[] { "Prowadzacy Szesc", "Prowadzacy Siedem", "Prowadzacy Osiem" };

			CollectionAssert.AreEqual(expected.ToList(), names.ToList());
		}

		[TestMethod]
		[ExpectedException(typeof(EntityNotOwnableException))]
		public void TestUserGetByOwner()
		{
			var owner = users.GetAll().Where(t => t.Username == "UzytkownikTrzy").First();
			Assert.IsNotNull(owner);

			var user = users.GetByOwner(owner);
		}
	}
}
