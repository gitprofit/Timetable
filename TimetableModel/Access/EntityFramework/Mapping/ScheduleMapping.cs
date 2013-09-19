using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using TimetableCore.Model;

namespace TimetableCore.Access.EntityFramework.Mapping
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

			this.HasRequired(t => t.Owner)
				.WithMany(t => t.Schedules)
				.Map(t => t.MapKey("OwnerID"));

			this.ToTable("Schedules");
		}
	}
}
