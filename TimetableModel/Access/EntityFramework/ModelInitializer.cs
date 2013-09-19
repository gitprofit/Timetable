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

			var user = new User { Username = "Andrzej" };

			var sched = new Schedule { Name = "Plan podstawowy", Owner = user };

			var course1 = new Course { Name = "Analiza", Schedule = sched };
			var class11 = new Class { Name = "Wykład", Instructor = "Miro Baran", Course = course1 };
			var class12 = new Class { Name = "Cwiczenia", Instructor = "Asia Jałmuzna", Course = course1 };

			var course2 = new Course { Name = "Algebra", Schedule = sched };
			var class21 = new Class { Name = "Wykład", Instructor = "Andy Herdi", Course = course2 };
			var class22 = new Class { Name = "Cwiczenia", Instructor = "Pati Mach", Course = course2 };

			var term11 = new Term { DayOfWeek = System.DayOfWeek.Thursday, StartTime = new TimeSpan(9,0,0), Duration = new TimeSpan(3,0,0), Class = class11 };
			var term12 = new Term { StartTime = new TimeSpan(13,30,0), Duration = new TimeSpan(1,30,0), Class = class12 };
			var term21 = new Term { StartTime = new TimeSpan(7,30,0), Duration = new TimeSpan(3,0,0), Class = class21 };
			var term22 = new Term { StartTime = new TimeSpan(16,0,0), Duration = new TimeSpan(2,15,0), Class = class22 };


			var coursesSeed = new[] { course1, course2 };
			var classesSeed = new[] { class11, class12, class21, class22 };
			var termSeed = new[] { term11, term12, term21, term22 };

			users.Add(user);
			schedules.Add(sched);
			foreach(var c in coursesSeed) courses.Add(c);
			foreach(var c in classesSeed) classes.Add(c);
			foreach(var c in termSeed) terms.Add(c);
			

			context.SaveChanges();
		}
	}
}
