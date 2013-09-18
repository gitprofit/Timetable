using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimetableModel.Domain
{
	public class Class : IEntity
	{
		public int ID { get; set; }

		public string Name { get; set; }
		public string Instructor { get; set; }

		public virtual Course Course { get; set; }
		public virtual ICollection<Term> Terms { get; set; }

		public Class()
		{
			Terms = new List<Term>();
		}
	}

	class ClassMapping : EntityTypeConfiguration<Class>
	{
		public ClassMapping()
			: base()
		{
			this.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasColumnName("ClassID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(t => t.Course)
                .WithMany(t => t.Classes)
                .Map(t => t.MapKey("CourseID"));

			this.ToTable("Classes");
		}
	}
}
