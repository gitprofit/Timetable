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

namespace TimetableWeb
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//string connStrName = "MySqlConnRemote";
			string connStrName = "MySqlConnLocal";
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
		}

		private void Test1(string connectionString)
		{
			var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
			conn.Open();

			var cmd = conn.CreateCommand();
			cmd.CommandText = "select * from Classes";

			var rdr = cmd.ExecuteReader();

			DataTable table = new DataTable();
			table.Load(rdr);

			foreach (DataRow row in table.Rows)
			{
				foreach (DataColumn col in table.Columns)
				{
					Response.Write(row[col.ColumnName] + ", ");
				}
				Response.Write("<br />");
			}
			rdr.Close();
			rdr.Dispose();
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}
	}
}