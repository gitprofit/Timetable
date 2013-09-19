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
	class ClassMapping : EntityTypeConfiguration<Class>
	{
		public ClassMapping()
			: base()
		{
			this.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasColumnName("ClassID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.Property(t => t.Name)
				.HasColumnName("Name")
				.HasMaxLength(32)
				.IsRequired();

			this.HasOptional(t => t.Instructor)
				.WithMany(t => t.Classes)
				.Map(t => t.MapKey("InstructorID"));

			this.HasRequired(t => t.Course)
				.WithMany(t => t.Classes)
				.Map(t => t.MapKey("CourseID"));

			this.ToTable("Classes");
		}
	}
}
