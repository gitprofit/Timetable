using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableModel
{
	public class Class
	{
		public string Name { get; set; }
		public string Instructor { get; set; }

		public virtual ICollection<Term> Terms { get; set; }
		public virtual Course Course { get; set; }
	}

	class ClassMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Class>
	{
		public ClassMapping()
			: base()
		{
			//this.Map
		}
	}
}
