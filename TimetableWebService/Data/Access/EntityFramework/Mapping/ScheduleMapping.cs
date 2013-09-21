using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using TimetableData.Model;

namespace TimetableWebService.Data.Access.EntityFramework.Mapping
{
	class ScheduleMapping : EntityTypeConfiguration<Schedule>
	{
		public ScheduleMapping()
			: base()
		{
			this.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasColumnName("ScheduleID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.Property(t => t.Name)
				.HasColumnName("Name")
				.HasMaxLength(32)
				.IsRequired();

			this.HasRequired(t => t.Owner)
				.WithMany(t => t.Schedules)
				.Map(t => t.MapKey("OwnerID"));

			this.HasMany(t => t.Courses)
				.WithMany(t => t.Schedules)
				.Map(t => t.MapLeftKey("CourseID")
					.MapRightKey("ScheduleID")
					.ToTable("Schedule_Course"));

			this.ToTable("Schedules");
		}
	}
}
