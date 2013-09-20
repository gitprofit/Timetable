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
	class TermMapping : EntityTypeConfiguration<Term>
	{
		public TermMapping()
			: base()
		{
			this.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasColumnName("TermID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(t => t.Owner)
				.WithMany(t => t.Terms)
				.Map(t => t.MapKey("OwnerID"));

			this.HasRequired(t => t.Class)
				.WithMany(t => t.Terms)
				.Map(t => t.MapKey("ClassID"));

			this.ToTable("Terms");
		}
	}
}
