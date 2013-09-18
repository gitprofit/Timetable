﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimetableModel.Domain
{
	public class Course : IEntity
	{
		public int ID { get; set; }

		public string Name { get; set; }

        public virtual Schedule Schedule { get; set; }

		public virtual ICollection<Class> Classes { get; set; }

		public Course()
		{
			Classes = new List<Class>();
		}
	}

    class CourseMapping : EntityTypeConfiguration<Course>
    {
        public CourseMapping()
            : base()
        {
			this.HasKey(t => t.ID)
				.Property(t => t.ID)
				.HasColumnName("CourseID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(t => t.Schedule)
                .WithMany(t => t.Courses)
                .Map(t => t.MapKey("ScheduleID"));

			this.ToTable("Courses");
        }
    }
}