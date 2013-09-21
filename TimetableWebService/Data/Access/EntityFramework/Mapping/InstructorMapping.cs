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
	class InstructorMapping : EntityTypeConfiguration<Instructor>
	{
		public InstructorMapping()
			: base()
		{
			this.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasColumnName("InstructorID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.Property(t => t.Name)
				.HasColumnName("Name")
				.HasMaxLength(32)
				.IsRequired();

			this.HasRequired(t => t.Owner)
				.WithMany(t => t.Instructors)
				.Map(t => t.MapKey("OwnerID"));
				
			this.ToTable("Instructors");
		}
	}
}
