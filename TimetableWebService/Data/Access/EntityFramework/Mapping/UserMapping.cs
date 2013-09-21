﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using TimetableData.Model;

namespace TimetableWebService.Data.Access.EntityFramework.Mapping
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

			this.Property(t => t.Username)
				.HasColumnName("Username")
				.HasMaxLength(32)
				.IsRequired();
				
			this.ToTable("Users");
		}
	}
}