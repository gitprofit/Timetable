using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimetableCore.Data.Model;

namespace TimetableWebService.Controllers
{
	public class ScheduleController : EntityController<Schedule> { }
	public class CourseController : EntityController<Course> { }
	public class InstructorController : EntityController<Instructor> { }
}