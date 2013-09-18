using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TimetableModel.Domain;
using TimetableModel.Repository.Crud;

namespace TimetableModel
{
	class ModelInitializer : DropCreateDatabaseAlways<ModelContext>
	{
		protected override void Seed(ModelContext context)
		{
			base.Seed(context);

			var classes = new ClassRepository(context);
			var courses = new CourseRepository(context);
			var schedules = new ScheduleRepository(context);
			var terms = new TermRepository(context);
			var users = new UserRepository(context);

			var user = new User { 

			//context.Courses.Add(
		}
	}
}
