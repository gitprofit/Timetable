using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableModel
{
	public class Course
	{
		public string Name { get; set; }
		public virtual ICollection<Class> Classes { get; set; }
	}
}
