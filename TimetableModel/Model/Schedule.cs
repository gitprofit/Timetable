using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Model
{
	public class Schedule : IEntity
	{
		public int ID { get; set; }
		public string Name { get; set; }

        public virtual User Owner { get; set; }
		public virtual ICollection<Course> Courses { get; set; }

		public Schedule()
		{
			Courses = new List<Course>();
		}
	}
}
