using System;
using System.Collections.Generic;
using System.Data;
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
			string connStrName = "MySqlConnRemote";
			//string connStrName = "MySqlConnLocal";
			string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[connStrName].ConnectionString;

			TimetableContext ctx = new TimetableContext(connStr);
			//var x = from Class in ctx.Classes select Class;

			Test1(connStr);


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