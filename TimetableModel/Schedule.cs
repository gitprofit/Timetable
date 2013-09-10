using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableModel
{
	public class Schedule
	{
		public string Name { get; set; }
		public virtual ICollection<Course> Courses { get; set; }
	}
}
