using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableCore.Data.Model;
using TimetableCore.Data.Access;
using TimetableWebService.Data.Access.EntityFramework;


namespace TimetableManualTests
{
	class EntityFrameworkRepositoryTests
	{
		string connectionString;
		ModelContext context;
		IRepository<User> repository;

		public void Initialize()
		{
			connectionString = "Server=localhost;User Id=liszcz;Password=usFnsiUD;Database=liszcz;";
			context = new ModelContext(connectionString);
			repository = new EntityFrameworkRepository<User>(context);
		}

		public void Cleanup()
		{
			//
		}

		public void TestGetAll()
		{
			Initialize();


			var users = repository.GetAll();
			foreach (var user in users)
			{
				Console.WriteLine(user.Id + ", " + user.Username
					+ ", S:" + user.Schedules.Count
					+ ", I" + user.Instructors.Count
					+ ", T" + user.Terms.Count);
			}
			Console.WriteLine("done!");

			var newUser = new User { Username = "Mietek" };

			repository.Add(newUser);
			repository.SaveChanges();

			users = repository.GetAll();
			foreach (var user in users)
			{
				Console.WriteLine(user.Id + ", " + user.Username
					+ ", S:" + user.Schedules.Count
					+ ", I" + user.Instructors.Count
					+ ", T" + user.Terms.Count);
			}
			Console.WriteLine("done!");

			Console.WriteLine("---------------------------");


			Cleanup();
		}

		public void TestUpdate()
		{
			Initialize();

			var newUser = new User { Id = 1, Username = "Zbyszek" };

			repository.Update(newUser);

			var user = repository.GetById(1);


			Console.WriteLine(user.Id + ", " + user.Username
					+ ", S:" + user.Schedules.Count
					+ ", I:" + user.Instructors.Count
					+ ", T:" + user.Terms.Count);

			Console.WriteLine("done!");

			Console.WriteLine("---------------------------");


			Cleanup();
		}
	}
}
