namespace HorseRace
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.startButton = new System.Windows.Forms.Button();
			this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.resultsListBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			//
			// startButton
			//
			this.startButton.Location = new System.Drawing.Point(12, 12);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 0;
			this.startButton.Text = "Старт";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			//
			// flowLayoutPanel
			//
			this.flowLayoutPanel.Location = new System.Drawing.Point(12, 41);
			this.flowLayoutPanel.Name = "flowLayoutPanel";
			this.flowLayoutPanel.Size = new System.Drawing.Size(460, 199);
			this.flowLayoutPanel.TabIndex = 1;
			//
			// resultsListBox
			//
			this.resultsListBox.FormattingEnabled = true;
			this.resultsListBox.ItemHeight = 15;
			this.resultsListBox.Location = new System.Drawing.Point(12, 246);
			this.resultsListBox.Name = "resultsListBox";
			this.resultsListBox.Size = new System.Drawing.Size(460, 94);
			this.resultsListBox.TabIndex = 2;
			//
			// Form1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 361);
			this.Controls.Add(this.resultsListBox);
			this.Controls.Add(this.flowLayoutPanel);
			this.Controls.Add(this.startButton);
			this.Name = "Form1";
			this.Text = "Horse Race";
			this.ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
		private System.Windows.Forms.ListBox resultsListBox;
	}
}
