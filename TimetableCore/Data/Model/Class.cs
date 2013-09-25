using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Data.Model
{
	public class Class : IEntity, INameable, IOwnable
	{
		// IEntity
		public int Id { get; set; }

		// INameable
		public string Name { get; set; }

		// IOwnable
		public virtual User Owner { get; set; }

		public virtual Course Course { get; set; }
		public virtual Instructor Instructor { get; set; }
		public virtual ICollection<Term> Terms { get; set; }

		public Class()
		{
			Terms = new List<Term>();
		}

		
	}
}
