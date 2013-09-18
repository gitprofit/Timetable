using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimetableModel.Domain
{
	public class Schedule : IEntity
	{
		public int ID { get; set; }

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
			this.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasColumnName("ScheduleID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(t => t.Owner)
                .WithMany(t => t.Schedules)
                .Map(t => t.MapKey("OwnerID"));

			this.ToTable("Schedules");
        }
    }
}
