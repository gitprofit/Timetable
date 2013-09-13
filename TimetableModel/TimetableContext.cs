using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TimetableModel
{
	public class TimetableContext : DbContext
	{
		public DbSet<Schedule> Schedules { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Class> Classes { get; set; }
		public DbSet<Term> Terms { get; set; }

		public TimetableContext(string connectionString)
			: base(connectionString)
		{
			Database.SetInitializer<TimetableContext>(new CreateDatabaseIfNotExists<TimetableContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Configurations.Add(new ClassMapping());
			modelBuilder.Configurations.Add(new CourseMapping());
			modelBuilder.Configurations.Add(new ScheduleMapping());
			//modelBuilder.Configurations.Add(new TermMapping());
			//modelBuilder.Configurations.Add(new UserMapping());
		}
	}
}
