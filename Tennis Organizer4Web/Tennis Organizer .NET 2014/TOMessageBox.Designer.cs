namespace Tennis_Organizer.NET_2014
{
	partial class TOMessageBox
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
			this.OkButton = new System.Windows.Forms.Button();
			this.Text = new System.Windows.Forms.Label();
			this.ExitButton = new System.Windows.Forms.Button();
			this.LoginErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.YesButton = new System.Windows.Forms.Button();
			this.NoButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.LoginErrorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// OkButton
			// 
			this.OkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
			this.OkButton.FlatAppearance.BorderSize = 0;
			this.OkButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
			this.OkButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
			this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.OkButton.ForeColor = System.Drawing.Color.White;
			this.OkButton.Location = new System.Drawing.Point(172, 123);
			this.OkButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(157, 36);
			this.OkButton.TabIndex = 3;
			this.OkButton.Text = "Ok";
			this.OkButton.UseVisualStyleBackColor = false;
			this.OkButton.Click += new System.EventHandler(this.OkClick);
			// 
			// Text
			// 
			this.Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Text.ForeColor = System.Drawing.Color.White;
			this.Text.Location = new System.Drawing.Point(0, 55);
			this.Text.Name = "Text";
			this.Text.Size = new System.Drawing.Size(501, 44);
			this.Text.TabIndex = 9;
			this.Text.Text = "TEXT";
			this.Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			// YesButton
			// 
			this.YesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
			this.YesButton.FlatAppearance.BorderSize = 0;
			this.YesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
			this.YesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
			this.YesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.YesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.YesButton.ForeColor = System.Drawing.Color.White;
			this.YesButton.Location = new System.Drawing.Point(69, 123);
			this.YesButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.YesButton.Name = "YesButton";
			this.YesButton.Size = new System.Drawing.Size(157, 36);
			this.YesButton.TabIndex = 11;
			this.YesButton.Text = "Tak";
			this.YesButton.UseVisualStyleBackColor = false;
			this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
			// 
			// NoButton
			// 
			this.NoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(205)))), ((int)(((byte)(255)))));
			this.NoButton.FlatAppearance.BorderSize = 0;
			this.NoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
			this.NoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
			this.NoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.NoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.NoButton.ForeColor = System.Drawing.Color.White;
			this.NoButton.Location = new System.Drawing.Point(280, 123);
			this.NoButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.NoButton.Name = "NoButton";
			this.NoButton.Size = new System.Drawing.Size(157, 36);
			this.NoButton.TabIndex = 12;
			this.NoButton.Text = "Nie";
			this.NoButton.UseVisualStyleBackColor = false;
			this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
			// 
			// TOMessageBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.ClientSize = new System.Drawing.Size(500, 202);
			this.Controls.Add(this.NoButton);
			this.Controls.Add(this.YesButton);
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.Text);
			this.Controls.Add(this.OkButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(500, 202);
			this.Name = "TOMessageBox";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)(this.LoginErrorProvider)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Label Text;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.ErrorProvider LoginErrorProvider;
		private System.Windows.Forms.Button NoButton;
		private System.Windows.Forms.Button YesButton;
	}
}