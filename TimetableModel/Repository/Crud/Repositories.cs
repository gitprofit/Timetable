using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimetableModel.Domain;

namespace TimetableModel.Repository.Crud
{
	public class ClassRepository : CrudRepository<Class>
	{
		public ClassRepository(ModelContext context)
			: base(context) { }
	}

	public class CourseRepository : CrudRepository<Course>
	{
		public CourseRepository(ModelContext context)
			: base(context) { }
	}

	public class ScheduleRepository : CrudRepository<Schedule>
	{
		public ScheduleRepository(ModelContext context)
			: base(context) { }
	}

	public class TermRepository : CrudRepository<Term>
	{
		public TermRepository(ModelContext context)
			: base(context) { }
	}

	public class UserRepository : CrudRepository<User>
	{
		public UserRepository(ModelContext context)
			: base(context) { }
	}
}
