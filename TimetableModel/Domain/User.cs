using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimetableModel.Domain
{
    public class User : IEntity
    {
		public int ID { get; set; }

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
			this.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasColumnName("UserID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.ToTable("Users");
        }
    }
}
