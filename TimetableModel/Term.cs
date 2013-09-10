using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableModel
{
	public enum Week { A, B };

	public class Term
	{
		public Week Week { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public DateTime StartDate { get; set; }
		public TimeSpan Duration { get; set; }

		public virtual Course Course { get; set; }
	}
}
