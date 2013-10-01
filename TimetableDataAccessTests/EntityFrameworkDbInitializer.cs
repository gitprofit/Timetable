using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableCore.Data.Model;
using TimetableWebService.Data.Access.EntityFramework;

namespace TimetableDataAccessTests
{
	class EntityFrameworkDbInitializer : DropCreateDatabaseAlways<ModelContext>
	{
		protected override void Seed(ModelContext context)
		{
			base.Seed(context);

			var user1 = new User { Username = "UzytkownikJeden" };
			var user2 = new User { Username = "UzytkownikDwa" };
			var user3 = new User { Username = "UzytkownikTrzy" };

			var sched11 = new Schedule { Owner = user1, Name = "Plan jeden" };
			var sched21 = new Schedule { Owner = user2, Name = "Plan dwa" };
			var sched22 = new Schedule { Owner = user2, Name = "Plan trzy" };
			var sched31 = new Schedule { Owner = user3, Name = "Plan cztery" };
			var sched32 = new Schedule { Owner = user3, Name = "Plan piec" };
			var sched33 = new Schedule { Owner = user3, Name = "Plan szesc" };

			var ins11 = new Instructor { Owner = user1, Name = "Prowadzacy Jeden" };
			var ins12 = new Instructor { Owner = user1, Name = "Prowadzacy Dwa" };
			var ins13 = new Instructor { Owner = user1, Name = "Prowadzacy Trzy" };
			var ins21 = new Instructor { Owner = user2, Name = "Prowadzacy Cztery" };
			var ins22 = new Instructor { Owner = user2, Name = "Prowadzacy Piec" };
			var ins31 = new Instructor { Owner = user3, Name = "Prowadzacy Szesc" };
			var ins32 = new Instructor { Owner = user3, Name = "Prowadzacy Siedem" };
			var ins33 = new Instructor { Owner = user3, Name = "Prowadzacy Osiem" };

			var course11 = new Course { Owner = user1, Name = "Przedmiot jeden" };
				var class111 = new Class { Owner = user1, Name = "Wyklad", Instructor = ins11, Course = course11 };
				var term111 = new Term { Owner = user1, Week = Week.A, DayOfWeek = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(12), Duration = TimeSpan.FromHours(1.5), Class = class111 };
				var class112 = new Class { Owner = user1, Name = "Cwiczenia", Instructor = ins12, Course = course11 };
				var term112 = new Term { Owner = user1, Week = Week.A, DayOfWeek = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(8), Duration = TimeSpan.FromHours(1.5), Class = class112 };
			var course12 = new Course { Owner = user1, Name = "Przedmiot dwa" };
				var class121 = new Class { Owner = user1, Name = "Wyklad", Instructor = ins13, Course = course12 };
				var term121 = new Term { Owner = user1, Week = Week.A, DayOfWeek = DayOfWeek.Friday, StartTime = TimeSpan.FromHours(10), Duration = TimeSpan.FromHours(1.5), Class = class121 };
				var class122 = new Class { Owner = user1, Name = "Cwiczenia", Instructor = ins11, Course = course12 };
				var term122 = new Term { Owner = user1, Week = Week.A, DayOfWeek = DayOfWeek.Thursday, StartTime = TimeSpan.FromHours(14), Duration = TimeSpan.FromHours(1.5), Class = class122 };
			sched11.Courses.Add(course11);
			sched11.Courses.Add(course12);

			var course21 = new Course { Owner = user2, Name = "Przedmiot trzy" };
				var class211 = new Class { Owner = user2, Name = "Wyklad", Instructor = ins21, Course = course21 };
				var term211 = new Term { Owner = user2, Week = Week.A, DayOfWeek = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(10), Duration = TimeSpan.FromHours(1.5), Class = class211 };
				var class212 = new Class { Owner = user2, Name = "Cwiczenia", Instructor = ins22, Course = course21 };
				var term212 = new Term { Owner = user2, Week = Week.A, DayOfWeek = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(12), Duration = TimeSpan.FromHours(1.5), Class = class212 };
			var course22 = new Course { Owner = user2, Name = "Przedmiot cztery" };
				var class221 = new Class { Owner = user2, Name = "Wyklad", Instructor = ins21, Course = course22 };
				var term221 = new Term { Owner = user2, Week = Week.A, DayOfWeek = DayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(16), Duration = TimeSpan.FromHours(1.5), Class = class221 };
				var class222 = new Class { Owner = user2, Name = "Laboratorium", Instructor = ins22, Course = course22 };
				var term222 = new Term { Owner = user2, Week = Week.A, DayOfWeek = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(10), Duration = TimeSpan.FromHours(1.5), Class = class222 };
			var course23 = new Course { Owner = user2, Name = "Przedmiot piec" };
				var class231 = new Class { Owner = user2, Name = "Wyklad", Instructor = ins22, Course = course23 };
				var term231 = new Term { Owner = user2, Week = Week.A, DayOfWeek = DayOfWeek.Friday, StartTime = TimeSpan.FromHours(12), Duration = TimeSpan.FromHours(1.5), Class = class231 };
				var class232 = new Class { Owner = user2, Name = "Cwiczenia", Instructor = ins21, Course = course23 };
				var term232 = new Term { Owner = user2, Week = Week.A, DayOfWeek = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(16), Duration = TimeSpan.FromHours(1.5), Class = class232 };
			sched21.Courses.Add(course21);
			sched21.Courses.Add(course22);
			sched21.Courses.Add(course23);
			sched22.Courses.Add(course21);
			sched22.Courses.Add(course23);

			var course31 = new Course { Owner = user3, Name = "Przedmiot szesc" };
				var class311 = new Class { Owner = user3, Name = "Wyklad", Instructor = ins32, Course = course31 };
				var term311 = new Term { Owner = user3, Week = Week.A, DayOfWeek = DayOfWeek.Thursday, StartTime = TimeSpan.FromHours(10), Duration = TimeSpan.FromHours(1.5), Class = class311 };
				var class312 = new Class { Owner = user3, Name = "Cwiczenia", Instructor = ins31, Course = course31 };
				var term312 = new Term { Owner = user3, Week = Week.A, DayOfWeek = DayOfWeek.Friday, StartTime = TimeSpan.FromHours(16), Duration = TimeSpan.FromHours(1.5), Class = class312 };
			var course32 = new Course { Owner = user3, Name = "Przedmiot siedem" };
				var class321 = new Class { Owner = user3, Name = "Wyklad", Instructor = ins32, Course = course32 };
				var term321 = new Term { Owner = user3, Week = Week.A, DayOfWeek = DayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(8), Duration = TimeSpan.FromHours(1.5), Class = class321 };
				var class322 = new Class { Owner = user3, Name = "Cwiczenia", Instructor = ins33, Course = course32 };
				var term322 = new Term { Owner = user3, Week = Week.A, DayOfWeek = DayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(10), Duration = TimeSpan.FromHours(1.5), Class = class322 };
			sched31.Courses.Add(course31);
			sched31.Courses.Add(course32);
			sched32.Courses.Add(course31);
			sched33.Courses.Add(course32);

			var user = new[] { user1, user2, user3 };
			var sched = new[] { sched11, sched21, sched22, sched31, sched32, sched33 };
			var ins = new[] { ins11, ins12, ins13, ins21, ins22, ins31, ins32, ins33 };
			var course = new[] { course11, course12, course21, course22, course23, course31, course32 };
			var classes = new[] { class111, class112, class121, class122, class211, class212, class221, class222, class231, class232, class311, class312, class321, class322 };
			var term = new[] { term111, term112, term121, term122, term211, term212, term221, term222, term231, term232, term311, term312, term321, term322 };

			foreach (var c in user) context.Users.Add(c);
			foreach (var c in sched) context.Schedules.Add(c);
			foreach (var c in ins) context.Instructors.Add(c);
			foreach (var c in course) context.Courses.Add(c);
			foreach (var c in classes) context.Classes.Add(c);
			foreach (var c in term) context.Terms.Add(c);

			context.SaveChanges();
		}
	}
}
