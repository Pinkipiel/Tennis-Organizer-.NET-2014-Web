using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TennisOrganizer4Web.PlayerService;

namespace TennisOrganizer4Web
{
	public partial class MainPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//InitializeRanking();
		}
		//private void InitializeRanking()
		//{
		//	using (var psc = new PlayerServiceClient())
		//	{
		//		List<TennisOrganizerServices.PlayerStats> ps = new List<TennisOrganizerServices.PlayerStats>();
		//		ps = psc.GetPlayerStatsList().ToList<TennisOrganizerServices.PlayerStats>();
		//		//playerBindingSource.DataSource = ps;
		//		//ObjectDataSource1.
		//	}
		//	//Player.SetPlayerList(PlayerDataGridView);
		//}
	}
}