using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Model
{
    public class User : IEntity
    {
		public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }

		public User()
		{
			Schedules = new List<Schedule>();
		}
    }
}
