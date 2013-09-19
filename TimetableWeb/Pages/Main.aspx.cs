using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimetableCore.Model;
using TimetableCore.Access;
using TimetableCore.Access.EntityFramework;
using System.Web.Security;

namespace TimetableWeb.Pages
{
	public partial class Main : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			/*
			string connStrName = "MySqlConnRemote";
			//string connStrName = "MySqlConnLocal";
			string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[connStrName].ConnectionString;

			var context = new ModelContext(connStr);

			var terms = new TermRepository(context);

			foreach (Term term in terms.GetAll())
			{
				Response.Write(term.ID + ", " +
					term.Week + ", " +
					term.DayOfWeek + ", " +
					term.StartTime + ", " +
					term.Duration + ", " +
					term.Class.Instructor.Name + ", "
					+ term.Class.Name + ", "
					+ term.Class.Course.Name + "<br />");
			}

			this.Page.Response.Write("lol");
			 * */

			lblMessage.Text = "Witaj " + Context.User.Identity.Name + "!";
		}

		protected void btnLogout_Click(object sender, EventArgs e)
		{
			FormsAuthentication.SignOut();
			FormsAuthentication.RedirectToLoginPage();
		}
	}
}