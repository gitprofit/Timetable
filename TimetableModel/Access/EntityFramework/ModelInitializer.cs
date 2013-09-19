using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TimetableCore.Model;

namespace TimetableCore.Access.EntityFramework
{
	class ModelInitializer : DropCreateDatabaseAlways<ModelContext>
	{
		protected override void Seed(ModelContext context)
		{
			base.Seed(context);

			var classes = new ClassRepository(context);
			var courses = new CourseRepository(context);
			var schedules = new ScheduleRepository(context); 
			var terms = new TermRepository(context);
			var users = new UserRepository(context);

			var user = new User { Username = "User1" };
			var sched = new Schedule { Name = "Sched1", Owner = user };

			users.Add(user);
			schedules.Add(sched);

			context.SaveChanges();
		}
	}
}
