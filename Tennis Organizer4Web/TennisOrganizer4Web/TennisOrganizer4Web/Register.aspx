<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TennisOrganizer4Web.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="assets/css/reset.css" />
	<link rel="stylesheet" href="assets/css/registerStyle.css" />
    <title></title>
</head>
<body>
    <form id="register" runat="server">
    <div class="content">
		<div class="register_box">
			<h1>Rejestracja</h1>
			<ul>
				<li>
					Login
				</li>
				<li>
					<asp:TextBox runat="server"
						id="LoginTextBox"
						CssClass="user_input" />
				</li>
				<li>
					Hasło
				</li>
				<li>
					<asp:TextBox runat="server"
						TextMode="Password"
						id="PasswordTextBox" 
						CssClass="user_input"/>
				</li>
				<li>
					Powtórz hasło
				</li>
				<li>
					<asp:TextBox runat="server"
						TextMode="Password" 
						id="RepeatedPasswordTextBox"
						CssClass="user_input"/>
				</li>
			</ul>
			<hr />
			<ul>
				<li>
					Imię
				</li>
				<li>
					<asp:TextBox runat="server"
						id="FirstNameTextBox"
						CssClass="user_input" />
				</li>
				<li>
					Nazwisko
				</li>
				<li>
					<asp:TextBox runat="server"
						id="LastNameTextBox"
						CssClass="user_input" />
				</li>
				<li>
					Wiek
				</li>
				<li>
					<asp:TextBox runat="server"
						id="AgeTextBox"
						CssClass="user_input" />
				</li>
				<li>
					Telefon
				</li>
				<li>
					<asp:TextBox runat="server"
						id="PhoneTextBox"
						CssClass="user_input" />
				</li>
				<li>
					Email
				</li>
				<li>
					<asp:TextBox runat="server"
						id="EmailTextBox"
						CssClass="user_input" />
				</li>
				<li>
					Miasto
				</li>
				<li>
					<asp:TextBox runat="server"
						id="CityTextBox"
						CssClass="user_input" />
				</li>
			</ul>
			<asp:Button ID="RegisterButton" 
				runat="server" 
				CssClass="register_button" 
				Text="Rejestracja"
				/>
			
		</div>
    </div>
    </form>
</body>
</html>
