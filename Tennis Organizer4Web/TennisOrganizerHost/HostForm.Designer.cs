namespace TennisOrganizerHost
{
	partial class HostForm
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
			this.TurnOn = new System.Windows.Forms.Button();
			this.TurnOff = new System.Windows.Forms.Button();
			this.Info = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// TurnOn
			// 
			this.TurnOn.Location = new System.Drawing.Point(105, 79);
			this.TurnOn.Name = "TurnOn";
			this.TurnOn.Size = new System.Drawing.Size(75, 23);
			this.TurnOn.TabIndex = 0;
			this.TurnOn.Text = "Włącz";
			this.TurnOn.UseVisualStyleBackColor = true;
			this.TurnOn.Click += new System.EventHandler(this.TurnOn_Click);
			// 
			// TurnOff
			// 
			this.TurnOff.Enabled = false;
			this.TurnOff.Location = new System.Drawing.Point(105, 138);
			this.TurnOff.Name = "TurnOff";
			this.TurnOff.Size = new System.Drawing.Size(75, 23);
			this.TurnOff.TabIndex = 1;
			this.TurnOff.Text = "Wyłącz";
			this.TurnOff.UseVisualStyleBackColor = true;
			this.TurnOff.Click += new System.EventHandler(this.TurnOff_Click);
			// 
			// Info
			// 
			this.Info.AutoSize = true;
			this.Info.Location = new System.Drawing.Point(93, 179);
			this.Info.Name = "Info";
			this.Info.Size = new System.Drawing.Size(0, 13);
			this.Info.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.Info);
			this.Controls.Add(this.TurnOff);
			this.Controls.Add(this.TurnOn);
			this.Name = "Form1";
			this.Text = "Host";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button TurnOn;
		private System.Windows.Forms.Button TurnOff;
		private System.Windows.Forms.Label Info;
	}
}

