using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Model
{
	public enum Week { A, B };

	public class Term : IEntity, IOwnable
	{
		// IEntity
		public int ID { get; set; }

		// IOwnable
		public virtual User Owner { get; set; }

		public Week Week { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan Duration { get; set; }

		public virtual Class Class { get; set; }
	}
}
