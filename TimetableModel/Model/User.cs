using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Model
{
    public class User : IEntity
    {
		public int ID { get; set; }

        public string Username { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
		public virtual ICollection<Course> Courses { get; set; }
		public virtual ICollection<Class> Classes { get; set; }
		public virtual ICollection<Term> Terms { get; set; }
		public virtual ICollection<Instructor> Instructors { get; set; }

		public User()
		{
			Schedules = new List<Schedule>();
		}
    }
}
