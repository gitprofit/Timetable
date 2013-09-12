using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimetableModel;

namespace TimetableWeb
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnLocal"].ConnectionString;

			TimetableContext ctx = new TimetableContext(connStr);
			var x = from Class in ctx.Classes select Class;


			this.Page.Response.Write("lol");
		}
	}
}