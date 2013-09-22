using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TimetableData.Model;
using TimetableData.Access;
using TimetableData.Access.WebApi;

namespace TimetableWeb.Controls
{
	public partial class Navigation : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
				SeedMenu();
		}

		private void SeedMenu()
		{
			System.Diagnostics.Debug.WriteLine("Seeding Menu");

			var schedules = new ScheduleRepository("http://localhost:5966");

			SeedList<Schedule>(menuSchedules, schedules);

			//string connectionString =
			//	System.Configuration.ConfigurationManager.ConnectionStrings["TimetableDbConn"].ConnectionString;
			/*
			using (ModelContext context = new ModelContext(connectionString))
			{
				var schedules = new EntityFrameworkRepository<Schedule>(context);
				var courses = new EntityFrameworkRepository<Course>(context);
				var instructors = new EntityFrameworkRepository<Instructor>(context);

				var sched = schedules.GetAll().Where(t => t.Owner.ID == 1);

				SeedList<Schedule>(menuSchedules, schedules);
				SeedList<Course>(menuCourses, courses);
				SeedList<Instructor>(menuInstructors, instructors);
			}
			 * */
		}

		private void SeedList<TEntity>(HtmlControl list, IRepository<TEntity> repository)
			where TEntity : class, IEntity, INameable
		{
			var entities = repository.GetAll();

			foreach (var entity in entities)
			{
				var item = GetListItem<TEntity>(entity);
				list.Controls.Add(item);
			}
		}

		private HtmlGenericControl GetListItem<TEntity>(TEntity entity)
			where TEntity : IEntity, INameable
		{
			var item = new HtmlGenericControl("li");
			var link = new HtmlAnchor();
			link.HRef = "#";
			link.InnerText = entity.Name;
			item.Controls.Add(link);
			return item;
		}
	}
}