namespace Tennis_Organizer.NET_2014
{
	partial class LoginForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.NewAccountButton = new System.Windows.Forms.Button();
			this.LogInButton = new System.Windows.Forms.Button();
			this.PasswordTextBox = new System.Windows.Forms.TextBox();
			this.PasswordLabel = new System.Windows.Forms.Label();
			this.LoginTextBox = new System.Windows.Forms.TextBox();
			this.LoginLabel = new System.Windows.Forms.Label();
			this.ExitButton = new System.Windows.Forms.Button();
			this.LoginErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.LoginErrorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// NewAccountButton
			// 
			this.NewAccountButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
			this.NewAccountButton.FlatAppearance.BorderSize = 0;
			this.NewAccountButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
			this.NewAccountButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
			this.NewAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.NewAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.NewAccountButton.ForeColor = System.Drawing.Color.White;
			this.NewAccountButton.Location = new System.Drawing.Point(93, 108);
			this.NewAccountButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.NewAccountButton.Name = "NewAccountButton";
			this.NewAccountButton.Size = new System.Drawing.Size(157, 36);
			this.NewAccountButton.TabIndex = 4;
			this.NewAccountButton.Text = "Nowe konto";
			this.NewAccountButton.UseVisualStyleBackColor = false;
			this.NewAccountButton.Click += new System.EventHandler(this.NewAccountClick);
			// 
			// LogInButton
			// 
			this.LogInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
			this.LogInButton.FlatAppearance.BorderSize = 0;
			this.LogInButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
			this.LogInButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
			this.LogInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LogInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.LogInButton.ForeColor = System.Drawing.Color.White;
			this.LogInButton.Location = new System.Drawing.Point(256, 108);
			this.LogInButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.LogInButton.Name = "LogInButton";
			this.LogInButton.Size = new System.Drawing.Size(157, 36);
			this.LogInButton.TabIndex = 3;
			this.LogInButton.Text = "Zaloguj";
			this.LogInButton.UseVisualStyleBackColor = false;
			this.LogInButton.Click += new System.EventHandler(this.LogInClick);
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.Location = new System.Drawing.Point(93, 80);
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.PasswordChar = '*';
			this.PasswordTextBox.Size = new System.Drawing.Size(320, 20);
			this.PasswordTextBox.TabIndex = 2;
			this.PasswordTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PasswordTextBoxKeyUp);
			// 
			// PasswordLabel
			// 
			this.PasswordLabel.AutoSize = true;
			this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.PasswordLabel.ForeColor = System.Drawing.Color.White;
			this.PasswordLabel.Location = new System.Drawing.Point(25, 80);
			this.PasswordLabel.Name = "PasswordLabel";
			this.PasswordLabel.Size = new System.Drawing.Size(62, 24);
			this.PasswordLabel.TabIndex = 7;
			this.PasswordLabel.Text = "Hasło";
			// 
			// LoginTextBox
			// 
			this.LoginTextBox.Location = new System.Drawing.Point(93, 54);
			this.LoginTextBox.Name = "LoginTextBox";
			this.LoginTextBox.Size = new System.Drawing.Size(320, 20);
			this.LoginTextBox.TabIndex = 1;
			// 
			// LoginLabel
			// 
			this.LoginLabel.AutoSize = true;
			this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.LoginLabel.ForeColor = System.Drawing.Color.White;
			this.LoginLabel.Location = new System.Drawing.Point(25, 54);
			this.LoginLabel.Name = "LoginLabel";
			this.LoginLabel.Size = new System.Drawing.Size(57, 24);
			this.LoginLabel.TabIndex = 9;
			this.LoginLabel.Text = "Login";
			// 
			// ExitButton
			// 
			this.ExitButton.FlatAppearance.BorderSize = 0;
			this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
			this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.ExitButton.ForeColor = System.Drawing.Color.White;
			this.ExitButton.Location = new System.Drawing.Point(462, -1);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(39, 36);
			this.ExitButton.TabIndex = 10;
			this.ExitButton.TabStop = false;
			this.ExitButton.Text = "x";
			this.ExitButton.UseVisualStyleBackColor = true;
			this.ExitButton.Click += new System.EventHandler(this.ExitButtonClick);
			// 
			// LoginErrorProvider
			// 
			this.LoginErrorProvider.ContainerControl = this;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.ClientSize = new System.Drawing.Size(500, 202);
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.LoginLabel);
			this.Controls.Add(this.LoginTextBox);
			this.Controls.Add(this.PasswordLabel);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.LogInButton);
			this.Controls.Add(this.NewAccountButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(500, 202);
			this.Name = "LoginForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Logowanie";
			((System.ComponentModel.ISupportInitialize)(this.LoginErrorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button NewAccountButton;
		private System.Windows.Forms.Button LogInButton;
		private System.Windows.Forms.TextBox PasswordTextBox;
		private System.Windows.Forms.Label PasswordLabel;
		private System.Windows.Forms.TextBox LoginTextBox;
		private System.Windows.Forms.Label LoginLabel;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.ErrorProvider LoginErrorProvider;
	}
}