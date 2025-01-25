namespace BeepApp
{
	partial class Form1
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
			this.startButton = new System.Windows.Forms.Button();
			this.stopButton = new System.Windows.Forms.Button();
			this.intervalTextBox = new System.Windows.Forms.TextBox();
			this.durationTextBox = new System.Windows.Forms.TextBox();
			this.frequencyTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(12, 171);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 0;
			this.startButton.Text = "Запустить";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// stopButton
			// 
			this.stopButton.Enabled = false;
			this.stopButton.Location = new System.Drawing.Point(376, 171);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(75, 23);
			this.stopButton.TabIndex = 1;
			this.stopButton.Text = "Остановить";
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// intervalTextBox
			// 
			this.intervalTextBox.Location = new System.Drawing.Point(12, 36);
			this.intervalTextBox.Name = "intervalTextBox";
			this.intervalTextBox.Size = new System.Drawing.Size(100, 20);
			this.intervalTextBox.TabIndex = 2;
			// 
			// durationTextBox
			// 
			this.durationTextBox.Location = new System.Drawing.Point(185, 36);
			this.durationTextBox.Name = "durationTextBox";
			this.durationTextBox.Size = new System.Drawing.Size(100, 20);
			this.durationTextBox.TabIndex = 3;
			// 
			// frequencyTextBox
			// 
			this.frequencyTextBox.Location = new System.Drawing.Point(351, 36);
			this.frequencyTextBox.Name = "frequencyTextBox";
			this.frequencyTextBox.Size = new System.Drawing.Size(100, 20);
			this.frequencyTextBox.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Интервал (мс)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(185, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Длительность (мс)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(351, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Частота (Гц)";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 206);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.frequencyTextBox);
			this.Controls.Add(this.durationTextBox);
			this.Controls.Add(this.intervalTextBox);
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.startButton);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.TextBox intervalTextBox;
		private System.Windows.Forms.TextBox durationTextBox;
		private System.Windows.Forms.TextBox frequencyTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

