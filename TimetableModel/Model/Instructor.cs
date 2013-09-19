using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Model
{
	public class Instructor : IEntity
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Class> Classes { get; set; }

		public Instructor()
		{
			Classes = new List<Class>();
		}
	}
}
