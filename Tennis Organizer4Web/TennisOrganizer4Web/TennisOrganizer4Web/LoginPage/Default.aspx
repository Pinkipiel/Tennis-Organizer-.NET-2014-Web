<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	
	<link rel="stylesheet" href="css/reset.css"/>
	<link rel="stylesheet" href="css/style.css"/>
	
	<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600' rel='stylesheet' type='text/css'/>

	<script src="js/jquery-1.11.2.min.js"></script>

    <title>Tennis Organizer</title>
	
</head>

<body>
	
	<header>
		
		<div class="content">
			test1
		</div>
		
	</header>
	
	<div class="content">
		
		<div class="login_box">
			
			<div class="center box">
				
				
				<ul>
					<li>
						<input type="text" name="login" class="input" placeholder="Login" />
					</li>
					<li>
						<input type="password" name="password" class="input" placeholder="Hasło"/>
					</li>
					<li>
						<button type="submit" name="loginButton" id="loginButton">Zaloguj</button>
					</li>
					<li>
						nie masz konta? <a href="#">zarejestruj się</a>
					</li>
				</ul>
				
			</div>
			
		</div>
		
	</div>
	
	
	<script>

		$(document).ready(function () {
			$(".login_box").css('height', ($(window).height() + 'px'));
		});

		$(window).resize(function () {
			$(".login_box").css('height', ($(window).height() + 'px'));
		});

	</script>
</body>
</html>