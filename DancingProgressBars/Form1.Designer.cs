namespace DancingProgressBars
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
			this.progressBarCountLabel = new System.Windows.Forms.Label();
			this.progressBarCountTextBox = new System.Windows.Forms.TextBox();
			this.startButton = new System.Windows.Forms.Button();
			this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			//
			// progressBarCountLabel
			//
			this.progressBarCountLabel.AutoSize = true;
			this.progressBarCountLabel.Location = new System.Drawing.Point(12, 9);
			this.progressBarCountLabel.Name = "progressBarCountLabel";
			this.progressBarCountLabel.Size = new System.Drawing.Size(156, 15);
			this.progressBarCountLabel.TabIndex = 0;
			this.progressBarCountLabel.Text = "Количество прогресс-баров:";
			//
			// progressBarCountTextBox
			//
			this.progressBarCountTextBox.Location = new System.Drawing.Point(174, 6);
			this.progressBarCountTextBox.Name = "progressBarCountTextBox";
			this.progressBarCountTextBox.Size = new System.Drawing.Size(100, 23);
			this.progressBarCountTextBox.TabIndex = 1;
			this.progressBarCountTextBox.Text = "5";
			//
			// startButton
			//
			this.startButton.Location = new System.Drawing.Point(280, 6);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 2;
			this.startButton.Text = "Начать";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			//
			// flowLayoutPanel
			//
			this.flowLayoutPanel.Location = new System.Drawing.Point(12, 40);  // Указываем конкретное местоположение
			this.flowLayoutPanel.Name = "flowLayoutPanel";
			this.flowLayoutPanel.Size = new System.Drawing.Size(376, 248); // Указываем конкретный размер
			this.flowLayoutPanel.TabIndex = 3;
			//
			// Form1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 300);
			this.Controls.Add(this.flowLayoutPanel);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.progressBarCountTextBox);
			this.Controls.Add(this.progressBarCountLabel);
			this.Name = "Form1";
			this.Text = "Танцующие прогресс-бары";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label progressBarCountLabel;
		private System.Windows.Forms.TextBox progressBarCountTextBox;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
	}
}

