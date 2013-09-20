using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Model
{
	public class Course : IEntity
	{
		public int ID { get; set; }
		public string Name { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
		public virtual ICollection<Class> Classes { get; set; }

		public Course()
		{
			Schedules = new List<Schedule>();
			Classes = new List<Class>();
		}
	}
}
