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
	class CourseMapping : EntityTypeConfiguration<Course>
	{
		public CourseMapping()
			: base()
		{
			this.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasColumnName("CourseID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(t => t.Schedule)
				.WithMany(t => t.Courses)
				.Map(t => t.MapKey("ScheduleID"));

			this.ToTable("Courses");
		}
	}
}
