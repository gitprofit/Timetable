using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimetableCore.Model;

namespace TimetableCore.Access.EntityFramework
{
	public class ClassRepository : EntityFrameworkRepository<Class>
	{
		public ClassRepository(ModelContext context)
			: base(context) { }
	}

	public class CourseRepository : EntityFrameworkRepository<Course>
	{
		public CourseRepository(ModelContext context)
			: base(context) { }
	}

	public class InstructorRepository : EntityFrameworkRepository<Instructor>
	{
		public InstructorRepository(ModelContext context)
			: base(context) { }
	}

	public class ScheduleRepository : EntityFrameworkRepository<Schedule>
	{
		public ScheduleRepository(ModelContext context)
			: base(context) { }
	}

	public class TermRepository : EntityFrameworkRepository<Term>
	{
		public TermRepository(ModelContext context)
			: base(context) { }
	}

	public class UserRepository : EntityFrameworkRepository<User>
	{
		public UserRepository(ModelContext context)
			: base(context) { }
	}
}
