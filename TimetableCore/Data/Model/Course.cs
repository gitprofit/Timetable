using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Data.Model
{
	public class Course : IEntity, INameable, IOwnable
	{
		// IEntity
		public int ID { get; set; }

		// INameable
		public string Name { get; set; }

		// IOwnable
		public virtual User Owner { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
		public virtual ICollection<Class> Classes { get; set; }

		public Course()
		{
			Schedules = new List<Schedule>();
			Classes = new List<Class>();
		}
	}
}
