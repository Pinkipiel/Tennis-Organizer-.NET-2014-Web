using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TennisOrganizer4Web
{
	public partial class LoginPage : System.Web.UI.Page
	{
		public bool valid = true;
		protected void Page_Load(object sender, EventArgs e)
		{
			login.Text = "";
			password.Text = "";
		}

		protected void loginButton_Click(object sender, EventArgs e)
		{
			Response.Redirect("MainPage.aspx", true);
			//Server.Transfer("MainPage.aspx", false);
		}
		
	}
}