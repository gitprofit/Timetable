using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using TimetableWebService.Data.Access.EntityFramework;
using TimetableCore.Data.Access;
using TimetableCore.Data.Model;
using TimetableCore.Util.Errors;
using TimetableWebService.Controllers;

namespace TimetableDataAccessTests
{
	[TestClass]
	public class EntityControllerTest
	{
		UserController controller;

		[TestInitialize]
		public void Init()
		{
			//controller = new UserController("Server=localhost;User Id=liszcz;Password=usFnsiUD;Database=liszcz;");
		}

		[TestCleanup]
		public void Cleanup()
		{
			//
		}

		[TestMethod]
		public void TestGet()
		{
			var users = controller.Get();
			var names = users.Select(t => t.Username);
			var expected = new[] { "UzytkownikJeden", "UzytkownikDwa", "UzytkownikTrzy" };

			CollectionAssert.AreEqual(expected.ToList(), names.ToList());
		}
	}
}
