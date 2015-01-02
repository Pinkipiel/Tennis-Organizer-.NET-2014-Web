namespace Tennis_Organizer.NET_2014
{
	partial class ChallengeNotification
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
			this.Accept = new System.Windows.Forms.Button();
			this.Decline = new System.Windows.Forms.Button();
			this.Text = new System.Windows.Forms.Label();
			this.PlayerName = new System.Windows.Forms.Label();
			this.Date = new System.Windows.Forms.Label();
			this.Hour = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Accept
			// 
			this.Accept.BackColor = System.Drawing.Color.White;
			this.Accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Accept.Location = new System.Drawing.Point(177, 57);
			this.Accept.Name = "Accept";
			this.Accept.Size = new System.Drawing.Size(75, 46);
			this.Accept.TabIndex = 0;
			this.Accept.Text = "Akceptuję";
			this.Accept.UseVisualStyleBackColor = false;
			this.Accept.Click += new System.EventHandler(this.Accept_Click);
			// 
			// Decline
			// 
			this.Decline.BackColor = System.Drawing.Color.White;
			this.Decline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Decline.Location = new System.Drawing.Point(261, 57);
			this.Decline.Name = "Decline";
			this.Decline.Size = new System.Drawing.Size(75, 46);
			this.Decline.TabIndex = 1;
			this.Decline.Text = "Odmawiam";
			this.Decline.UseVisualStyleBackColor = false;
			this.Decline.Click += new System.EventHandler(this.Decline_Click);
			// 
			// Text
			// 
			this.Text.BackColor = System.Drawing.Color.DarkOrange;
			this.Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Text.Location = new System.Drawing.Point(0, 0);
			this.Text.Name = "Text";
			this.Text.Size = new System.Drawing.Size(346, 24);
			this.Text.TabIndex = 2;
			this.Text.Text = "WYZWANIE";
			this.Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PlayerName
			// 
			this.PlayerName.BackColor = System.Drawing.Color.Transparent;
			this.PlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.PlayerName.Location = new System.Drawing.Point(0, 27);
			this.PlayerName.Name = "PlayerName";
			this.PlayerName.Size = new System.Drawing.Size(343, 28);
			this.PlayerName.TabIndex = 3;
			this.PlayerName.Text = "Imię Nazwisko";
			this.PlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Date
			// 
			this.Date.BackColor = System.Drawing.Color.Transparent;
			this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Date.Location = new System.Drawing.Point(0, 55);
			this.Date.Name = "Date";
			this.Date.Size = new System.Drawing.Size(167, 28);
			this.Date.TabIndex = 4;
			this.Date.Text = "12 Pażdziernika 2014";
			this.Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Hour
			// 
			this.Hour.BackColor = System.Drawing.Color.Transparent;
			this.Hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Hour.Location = new System.Drawing.Point(0, 80);
			this.Hour.Name = "Hour";
			this.Hour.Size = new System.Drawing.Size(167, 28);
			this.Hour.TabIndex = 5;
			this.Hour.Text = "godzina 12:30";
			this.Hour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ChallengeNotification
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Orange;
			this.Controls.Add(this.Hour);
			this.Controls.Add(this.Date);
			this.Controls.Add(this.PlayerName);
			this.Controls.Add(this.Text);
			this.Controls.Add(this.Decline);
			this.Controls.Add(this.Accept);
			this.Location = new System.Drawing.Point(10, 10);
			this.Name = "ChallengeNotification";
			this.Size = new System.Drawing.Size(346, 108);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Accept;
		private System.Windows.Forms.Button Decline;
		private System.Windows.Forms.Label Text;
		private System.Windows.Forms.Label PlayerName;
		private System.Windows.Forms.Label Date;
		private System.Windows.Forms.Label Hour;
	}
}
