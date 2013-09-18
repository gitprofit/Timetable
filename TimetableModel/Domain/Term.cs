using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimetableModel.Domain
{
	public enum Week { A, B };

	public class Term : IEntity
	{
		public int ID { get; set; }

		public Week Week { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan Duration { get; set; }

		public virtual Class Class { get; set; }
	}

	class TermMapping : EntityTypeConfiguration<Term>
	{
		public TermMapping()
			: base()
		{
			this.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasColumnName("TermID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(t => t.Class)
				.WithMany(t => t.Terms)
				.Map(t => t.MapKey("ClassID"));

			this.ToTable("Terms");
		}
	}
}
