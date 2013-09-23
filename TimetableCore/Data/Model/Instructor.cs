using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Data.Model
{
	public class Instructor : IEntity, INameable, IOwnable
	{
		// IEntity
		public int ID { get; set; }

		// INameable
		public string Name { get; set; }

		// IOwnable
		public virtual User Owner { get; set; }

		public virtual ICollection<Class> Classes { get; set; }

		public Instructor()
		{
			Classes = new List<Class>();
		}
	}
}
