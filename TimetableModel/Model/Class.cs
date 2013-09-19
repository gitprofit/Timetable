using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Model
{
	public class Class : IEntity
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public virtual Course Course { get; set; }
		public virtual Instructor Instructor { get; set; }
		public virtual ICollection<Term> Terms { get; set; }

		public Class()
		{
			Terms = new List<Term>();
		}
	}
}
