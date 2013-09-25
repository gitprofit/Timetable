using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using TimetableCore.Data.Model;

namespace TimetableWebService.Data.Access.EntityFramework.Mapping
{
	class CourseMapping : EntityTypeConfiguration<Course>
	{
		public CourseMapping()
			: base()
		{
			this.HasKey(t => t.Id)
				.Property(t => t.Id)
				.HasColumnName("CourseID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.Property(t => t.Name)
				.HasColumnName("Name")
				.HasMaxLength(32)
				.IsRequired();

			this.HasRequired(t => t.Owner)
				.WithMany(t => t.Courses)
				.Map(t => t.MapKey("OwnerID"));

			this.ToTable("Courses");
		}
	}
}
