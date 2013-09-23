using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TimetableCore.Data.Model;
using TimetableCore.Data.Access;
using TimetableCore.Data.Access.WebApi;

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
			var schedules = new WebApiRepository<Schedule>("http://localhost:5966/api/");
			var courses = new WebApiRepository<Course>("http://localhost:5966/api/");
			var instructors = new WebApiRepository<Instructor>("http://localhost:5966/api/");

			SeedList(menuSchedules, schedules);
			SeedList(menuCourses, courses);
			SeedList(menuInstructors, instructors);
		}

		private void SeedList<TEntity>(HtmlControl list, IRepository<TEntity> repository)
			where TEntity : class, IEntity, INameable
		{
			var entities = repository.GetAll();

			foreach (var entity in entities)
			{
				var item = GetHtmlListItem<TEntity>(entity);
				list.Controls.Add(item);
			}
		}

		private HtmlGenericControl GetHtmlListItem<TEntity>(TEntity entity)
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