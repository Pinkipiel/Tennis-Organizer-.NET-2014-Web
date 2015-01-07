<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="TennisOrganizer4Web.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link rel="stylesheet" href="StyleSheet1.css">
</head>
<body style="height: 450px">
    <form id="form1" runat="server">
		<%--<div id="topMenu">
			<div id="leftMenuPart">
				<asp:Image ID="Logo" runat="server" Height="45px" ImageUrl="~/Resources/TennisOrganizerLogo.png" Width="378px" />
			</div>
			<div id="rightMenuPart">
				<asp:Image ID="PlayerPicture" runat="server" ImageAlign="Right" />
				<asp:Label ID="Name" runat="server" Text="Imię"></asp:Label>
			</div>
		</div>--%>
		<table id="topMenu">
			<tr>
				<td>
					<asp:Image ID="Logo" runat="server" Height="45px" ImageUrl="~/Resources/TennisOrganizerLogo.png" Width="378px" />
				</td>
				<td>
					<asp:ImageButton ID="NotificationButton" runat="server" ImageUrl="~/Resources/NotifyIcon.png" />
					<asp:ImageButton ID="SettingsButton" runat="server" ImageUrl="~/Resources/settings.png" />
					<asp:ImageButton ID="LogoutButton" runat="server" ImageUrl="~/Resources/Logout.png" />
				</td>
			</tr>
		</table>
		<div id="sideMenu">
			<ul>
				<li><asp:Image ID="PlayerPicture" runat="server" ImageUrl="https://fbcdn-sphotos-g-a.akamaihd.net/hphotos-ak-ash2/v/t1.0-9/483981_426943507358308_1698076200_n.jpg?oh=9750c029806d8778f398911db9003606&oe=5531CDE5&__gda__=1429003586_9b4cf83154925b4b06409d73daeb3616" />
					<asp:Label ID="Name" runat="server" Text="Imię"></asp:Label>
				</li>
				<li><asp:ImageButton ID="RankingButton" CssClass="menuButton" runat="server" ImageUrl="~/Resources/ranking.png"  onmouseover="this.src='/Resources/rankingHover.png'" onmouseout="this.src='/Resources/ranking.png'" /></li>
				<li><asp:ImageButton ID="ImageButton1" CssClass="menuButton" runat="server" ImageUrl="~/Resources/ranking.png"  onmouseover="this.src='/Resources/rankingHover.png'" onmouseout="this.src='/Resources/ranking.png'" /></li>
				<li><asp:ImageButton ID="ImageButton2" CssClass="menuButton" runat="server" ImageUrl="~/Resources/ranking.png"  onmouseover="this.src='/Resources/rankingHover.png'" onmouseout="this.src='/Resources/ranking.png'" /></li>
				<li><asp:ImageButton ID="ImageButton3" CssClass="menuButton" runat="server" ImageUrl="~/Resources/ranking.png"  onmouseover="this.src='/Resources/rankingHover.png'" onmouseout="this.src='/Resources/ranking.png'" /></li>
				<li><asp:ImageButton ID="ImageButton4" CssClass="menuButton" runat="server" ImageUrl="~/Resources/ranking.png"  onmouseover="this.src='/Resources/rankingHover.png'" onmouseout="this.src='/Resources/ranking.png'" /></li>
			</ul>
		</div>
		<div id="content">
			<asp:ObjectDataSource ID="RankingDataSource" runat="server" SelectMethod="GetPlayerStatsList" TypeName="TennisOrganizerServices.PlayerService"></asp:ObjectDataSource>
			<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
			</asp:GridView>
		</div>
	</form>
</body>
</html>
