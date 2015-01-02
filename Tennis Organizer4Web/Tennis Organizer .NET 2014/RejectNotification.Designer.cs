namespace Tennis_Organizer.NET_2014
{
	partial class RejectNotification
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
			this.Ok = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Hour
			// 
			this.Hour.BackColor = System.Drawing.Color.Transparent;
			this.Hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Hour.Location = new System.Drawing.Point(31, 80);
			this.Hour.Name = "Hour";
			this.Hour.Size = new System.Drawing.Size(167, 28);
			this.Hour.TabIndex = 16;
			this.Hour.Text = "godzina 12:30";
			this.Hour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Date
			// 
			this.Date.BackColor = System.Drawing.Color.Transparent;
			this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Date.Location = new System.Drawing.Point(31, 55);
			this.Date.Name = "Date";
			this.Date.Size = new System.Drawing.Size(167, 28);
			this.Date.TabIndex = 15;
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
			this.PlayerName.TabIndex = 14;
			this.PlayerName.Text = "Imię Nazwisko";
			this.PlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Text
			// 
			this.Text.BackColor = System.Drawing.Color.Maroon;
			this.Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Text.Location = new System.Drawing.Point(0, 0);
			this.Text.Name = "Text";
			this.Text.Size = new System.Drawing.Size(346, 24);
			this.Text.TabIndex = 13;
			this.Text.Text = "ODMOWA";
			this.Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Ok
			// 
			this.Ok.BackColor = System.Drawing.Color.White;
			this.Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Ok.Location = new System.Drawing.Point(231, 57);
			this.Ok.Name = "Ok";
			this.Ok.Size = new System.Drawing.Size(75, 46);
			this.Ok.TabIndex = 12;
			this.Ok.Text = "OK";
			this.Ok.UseVisualStyleBackColor = false;
			this.Ok.Click += new System.EventHandler(this.Ok_Click);
			// 
			// RejectNotification
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Red;
			this.Controls.Add(this.Hour);
			this.Controls.Add(this.Date);
			this.Controls.Add(this.PlayerName);
			this.Controls.Add(this.Text);
			this.Controls.Add(this.Ok);
			this.Location = new System.Drawing.Point(10, 10);
			this.Name = "RejectNotification";
			this.Size = new System.Drawing.Size(346, 108);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label Hour;
		private System.Windows.Forms.Label Date;
		private System.Windows.Forms.Label PlayerName;
		private System.Windows.Forms.Label Text;
		private System.Windows.Forms.Button Ok;
	}
}
