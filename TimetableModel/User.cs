using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace TimetableModel
{
    public class User
    {
        public string Username { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }

		public User()
		{
			Schedules = new List<Schedule>();
		}
    }

    class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
            : base()
        {
            //
			this.ToTable("Users");
        }
    }
}
