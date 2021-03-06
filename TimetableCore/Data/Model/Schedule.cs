﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Data.Model
{
	public class Schedule : IEntity, INameable, IOwnable
	{
		// IEntity
		public int Id { get; set; }

		// INameable
		public string Name { get; set; }

		// IOwnable
        public virtual User Owner { get; set; }

		public virtual ICollection<Course> Courses { get; set; }

		public Schedule()
		{
			Courses = new List<Course>();
		}
	}
}
