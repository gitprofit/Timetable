using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using TimetableModel;

namespace TimetableWeb
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			TimetableModel.Class cl = new TimetableModel.Class();
			this.Page.Response.Write("lol");
		}
	}
}