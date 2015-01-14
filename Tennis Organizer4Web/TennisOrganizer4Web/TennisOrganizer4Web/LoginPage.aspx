<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="TennisOrganizer4Web.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	
	<link rel="stylesheet" href="assets/css/reset.css"/>
	<link rel="stylesheet" href="assets/css/style.css"/>
	
	<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600' rel='stylesheet' type='text/css'/>

	<script src="assets/js/jquery-1.11.2.min.js"></script>

    <title>Tennis Organizer</title>
	
</head>

<body>
	<form runat="server" method="get">
	<div class="commercial">
		<a class="logo" href="">Tennis Organizer</a>
			
	</div>
	<div class="content">
		
		<div class="login_box">
			
			<div class="center box">
				<ul>
					<li class="text">	
						<h1>Graj z nami już teraz!</h1>
					</li>
					<li class="text">
						Tennis Organizer w prosty sposób pozwala na aranżowanie meczy tenisowych
					</li>
					<% if (valid == false) { %>
					<li>
						<span style="color:red">Błędny login lub hasło</span>
					</li>
					<% } %>

					<li>
						<asp:TextBox runat="server" id="login" class="input" placeholder="Login" />
					</li>
					<li>
						<asp:TextBox  TextMode="Password" runat="server" id="password" class="input" placeholder="Hasło"	/>
					</li>
					<li>
						<asp:Button 
							id="loginButton" 
							runat="server" 
							Text="Zaloguj"
							OnClick="loginButton_Click"
							 />
					</li>
					<li>
						nie masz konta? <a href="./Register.aspx">zarejestruj się</a>
					</li>
				</ul>
			</div>
		</div>
	</div>
	<script>
		$(document).ready(function () {
			$(".login_box").css('height', ($(window).height() + 'px'));
		});
		$(window).load(function () {
			<% if(valid == true) { %>
			$(".login_box").hide().fadeIn(2000);
			<% } %>
		});

		$(window).resize(function () {
			$(".login_box").css('height', ($(window).height() + 'px'));
		});

	</script>
	</form>
	
	</body>
</html>