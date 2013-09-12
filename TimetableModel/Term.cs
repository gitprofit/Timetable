using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace TimetableModel
{
	public enum Week { A, B };

	public class Term
	{
		public Week Week { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public DateTime StartDate { get; set; }
		public TimeSpan Duration { get; set; }

		public virtual Class Class { get; set; }
	}

	class TermMapping : EntityTypeConfiguration<Term>
	{
		public TermMapping()
			: base()
		{
			this.HasRequired(t => t.Class)
				.WithMany(t => t.Terms)
				.Map(t => t.MapKey("ClassID"));

			this.ToTable("Terms");
		}
	}
}
