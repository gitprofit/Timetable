﻿using System;
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
				Response.Write(term.ID + ", " + term.StartTime + ", " + term.Duration + ", " + term.Class.Instructor + ", " + term.Class.Name + ", " + term.Class.Course.Name + "<br />");
			}


			/*
			var rep = new TimetableModel.Repository.Crud.UserRepository(ctx);
			var reps = new TimetableModel.Repository.Crud.ScheduleRepository(ctx);
			var x = rep.GetAll();
			var y = reps.GetAll();

			foreach (var s in x)
				Response.Write(s.ID + ", " + s.Username + ", " + s.Schedules.FirstOrDefault().Name + "<br />");

			Response.Write("<br /><br />");

			foreach (var s in y)
				Response.Write(s.ID + ", " + s.Name + "<br />");
			*/
			this.Page.Response.Write("lol");
		}



		private void Test2(string connectionString)
		{
			/*
			NorthwindContext north = new NorthwindContext(connectionString);

			var suppliers = from Supplier in north.Suppliers
							where Supplier.ContactName.Contains("Mackenzie")
							select new { Supplier.ContactName, Supplier.CompanyName, Supplier.City };

			var sup2 = (from Product in north.Products where Product.Supplier.Country == "Norway" select Product.Supplier).OrderBy(t => t.Country).Take(3);

			//var prod3 = north.Products.Select(t => new { t.ProductID, t.ProductName, t.Supplier }).Where(t => t.Supplier == sup2.FirstOrDefault());

			//var bev = from Category in north.Categories where Category.CategoryName == "Beverages" select Category.Products;
			//var bev2 = from Product in north.Products where Product.Category.CategoryName == "Beverages" select Product;

			foreach (var s in suppliers)
			{
				Response.Write(s.ContactName + ", " + s.CompanyName + ", " + s.City + "<br />");
			}

			Response.Write("<br /><br />");

			foreach (var s in sup2)
			{
				Response.Write(s.ContactName + ", " + s.Country + "<br />");
			}

			Response.Write("<br /><br />");
			*/
			/*
			foreach (var s in prod3)
			{
				Response.Write(s.ProductID + ", " + s.ProductName + "<br />");
			}

			Response.Write("<br />bev1<br />");
			if (bev2 == null) Response.Write("null bev!");
 			else
			foreach (var s in bev2)
				Response.Write(s.ProductName + ", ");

			*/

			//north.Dispose();
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