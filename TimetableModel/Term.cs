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

		public int CourseId { get; set; }
		public virtual Course Course { get; set; }
	}

	class TermMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Term>
	{
		public TermMapping()
			: base()
		{
			//this.HasRequired(t => t.Course).
			//this.
			
		}
	}
}
