using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TimetableData.Model;

namespace TimetableWebService.Data.Access.EntityFramework
{
	public class ModelContext : DbContext
	{
		public DbSet<Schedule> Schedules { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Class> Classes { get; set; }
		public DbSet<Term> Terms { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<User> Users { get; set; }

		public ModelContext(string connectionString)
			: base(connectionString)
		{
			Database.SetInitializer<ModelContext>(new ModelInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Configurations.Add(new Mapping.ClassMapping());
			modelBuilder.Configurations.Add(new Mapping.CourseMapping());
			modelBuilder.Configurations.Add(new Mapping.InstructorMapping());
			modelBuilder.Configurations.Add(new Mapping.ScheduleMapping());
			modelBuilder.Configurations.Add(new Mapping.TermMapping());
			modelBuilder.Configurations.Add(new Mapping.UserMapping());
		}
	}
}
