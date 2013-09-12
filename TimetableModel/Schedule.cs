using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace TimetableModel
{
	public class Schedule
	{
		public string Name { get; set; }

        public virtual User Owner { get; set; }
		public virtual ICollection<Course> Courses { get; set; }

		public Schedule()
		{
			Courses = new List<Course>();
		}
	}

    class ScheduleMapping : EntityTypeConfiguration<Schedule>
    {
        public ScheduleMapping()
            : base()
        {
            this.HasRequired(t => t.Owner)
                .WithMany(t => t.Schedules)
                .Map(t => t.MapKey("OwnerID"));

			this.ToTable("Schedules");
        }
    }
}
