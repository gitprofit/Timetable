using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TimetableCore.Data.Model;

namespace TimetableWebService.Data.Access.EntityFramework
{
	class ModelInitializer : DropCreateDatabaseAlways<ModelContext>
	{
		protected override void Seed(ModelContext context)
		{
			base.Seed(context);

			var classes = new EntityFrameworkRepository<Class>(context);
			var courses = new EntityFrameworkRepository<Course>(context);
			var instructors = new EntityFrameworkRepository<Instructor>(context);
			var schedules = new EntityFrameworkRepository<Schedule>(context); 
			var terms = new EntityFrameworkRepository<Term>(context);
			var users = new EntityFrameworkRepository<User>(context);

			var user = new User { Username = "Andrzej" };

			var sched = new Schedule { Owner = user, Name = "Plan podstawowy" };

			var ins1 = new Instructor { Owner = user, Name = "Andi Herdi" };
			var ins2 = new Instructor { Owner = user, Name = "Pati Mach" };
			var ins3 = new Instructor { Owner = user, Name = "Miro Baran" };

			var course1 = new Course { Owner = user, Name = "Analiza" };
			var class11 = new Class { Owner = user, Name = "Wykład", Instructor = ins3, Course = course1 };
			var class12 = new Class { Owner = user, Name = "Cwiczenia", Instructor = ins3, Course = course1 };
			sched.Courses.Add(course1);

			var course2 = new Course { Owner = user, Name = "Algebra" };
			var class21 = new Class { Owner = user, Name = "Wykład", Instructor = ins1, Course = course2 };
			var class22 = new Class { Owner = user, Name = "Cwiczenia", Instructor = ins2, Course = course2 };
			sched.Courses.Add(course2);

			var term11 = new Term { Owner = user, DayOfWeek = System.DayOfWeek.Thursday, StartTime = new TimeSpan(9, 0, 0), Duration = new TimeSpan(3, 0, 0), Class = class11 };
			var term12 = new Term { Owner = user, StartTime = new TimeSpan(13, 30, 0), Duration = new TimeSpan(1, 30, 0), Class = class12 };
			var term21 = new Term { Owner = user, StartTime = new TimeSpan(7, 30, 0), Duration = new TimeSpan(3, 0, 0), Class = class21 };
			var term22 = new Term { Owner = user, StartTime = new TimeSpan(16, 0, 0), Duration = new TimeSpan(2, 15, 0), Class = class22 };

			var insSeed = new[] { ins1, ins2, ins3 };
			var coursesSeed = new[] { course1, course2 };
			var classesSeed = new[] { class11, class12, class21, class22 };
			var termSeed = new[] { term11, term12, term21, term22 };

			users.Add(user);
			schedules.Add(sched);
			foreach (var c in insSeed) instructors.Add(c);
			foreach (var c in coursesSeed) courses.Add(c);
			foreach (var c in classesSeed) classes.Add(c);
			foreach (var c in termSeed) terms.Add(c);
			

			context.SaveChanges();
		}
	}
}
