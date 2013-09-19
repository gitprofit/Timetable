using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using TimetableCore.Model;

namespace TimetableCore.Access.EntityFramework.Mapping
{
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
