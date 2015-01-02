namespace Tennis_Organizer.NET_2014
{
	partial class RateNotification
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Hour = new System.Windows.Forms.Label();
			this.Date = new System.Windows.Forms.Label();
			this.PlayerName = new System.Windows.Forms.Label();
			this.Text = new System.Windows.Forms.Label();
			this.HomeScoreTextBox = new System.Windows.Forms.TextBox();
			this.GuestScoreTextBox = new System.Windows.Forms.TextBox();
			this.Ok = new System.Windows.Forms.Button();
			this.Colon = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Hour
			// 
			this.Hour.BackColor = System.Drawing.Color.Transparent;
			this.Hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Hour.Location = new System.Drawing.Point(0, 80);
			this.Hour.Name = "Hour";
			this.Hour.Size = new System.Drawing.Size(167, 28);
			this.Hour.TabIndex = 11;
			this.Hour.Text = "godzina 12:30";
			this.Hour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Date
			// 
			this.Date.BackColor = System.Drawing.Color.Transparent;
			this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Date.Location = new System.Drawing.Point(0, 55);
			this.Date.Name = "Date";
			this.Date.Size = new System.Drawing.Size(167, 28);
			this.Date.TabIndex = 10;
			this.Date.Text = "12 Pażdziernika 2014";
			this.Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PlayerName
			// 
			this.PlayerName.BackColor = System.Drawing.Color.Transparent;
			this.PlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.PlayerName.Location = new System.Drawing.Point(0, 27);
			this.PlayerName.Name = "PlayerName";
			this.PlayerName.Size = new System.Drawing.Size(343, 28);
			this.PlayerName.TabIndex = 9;
			this.PlayerName.Text = "Imię Nazwisko vs Imię Nazwisko";
			this.PlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Text
			// 
			this.Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Text.Location = new System.Drawing.Point(0, 0);
			this.Text.Name = "Text";
			this.Text.Size = new System.Drawing.Size(346, 24);
			this.Text.TabIndex = 8;
			this.Text.Text = "WYNIK MECZU";
			this.Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// HomeScoreTextBox
			// 
			this.HomeScoreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HomeScoreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.HomeScoreTextBox.Location = new System.Drawing.Point(177, 57);
			this.HomeScoreTextBox.Name = "HomeScoreTextBox";
			this.HomeScoreTextBox.Size = new System.Drawing.Size(68, 22);
			this.HomeScoreTextBox.TabIndex = 12;
			this.HomeScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// GuestScoreTextBox
			// 
			this.GuestScoreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.GuestScoreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.GuestScoreTextBox.Location = new System.Drawing.Point(268, 57);
			this.GuestScoreTextBox.Name = "GuestScoreTextBox";
			this.GuestScoreTextBox.Size = new System.Drawing.Size(68, 22);
			this.GuestScoreTextBox.TabIndex = 13;
			this.GuestScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Ok
			// 
			this.Ok.BackColor = System.Drawing.Color.White;
			this.Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Ok.Location = new System.Drawing.Point(177, 80);
			this.Ok.Name = "Ok";
			this.Ok.Size = new System.Drawing.Size(159, 23);
			this.Ok.TabIndex = 7;
			this.Ok.Text = "OK";
			this.Ok.UseVisualStyleBackColor = false;
			this.Ok.Click += new System.EventHandler(this.Ok_Click);
			// 
			// Colon
			// 
			this.Colon.AutoSize = true;
			this.Colon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Colon.Location = new System.Drawing.Point(251, 61);
			this.Colon.Name = "Colon";
			this.Colon.Size = new System.Drawing.Size(11, 13);
			this.Colon.TabIndex = 14;
			this.Colon.Text = ":";
			// 
			// RateNotification
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Yellow;
			this.Controls.Add(this.Colon);
			this.Controls.Add(this.GuestScoreTextBox);
			this.Controls.Add(this.HomeScoreTextBox);
			this.Controls.Add(this.Hour);
			this.Controls.Add(this.Date);
			this.Controls.Add(this.PlayerName);
			this.Controls.Add(this.Text);
			this.Controls.Add(this.Ok);
			this.Location = new System.Drawing.Point(10, 10);
			this.Name = "RateNotification";
			this.Size = new System.Drawing.Size(346, 108);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Hour;
		private System.Windows.Forms.Label Date;
		private System.Windows.Forms.Label PlayerName;
		private System.Windows.Forms.Label Text;
		private System.Windows.Forms.TextBox HomeScoreTextBox;
		private System.Windows.Forms.TextBox GuestScoreTextBox;
		private System.Windows.Forms.Button Ok;
		private System.Windows.Forms.Label Colon;
	}
}
