namespace ProcessLauncher
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
			this.executablePathTextBox = new System.Windows.Forms.TextBox();
			this.argumentsTextBox = new System.Windows.Forms.TextBox();
			this.launchButton = new System.Windows.Forms.Button();
			this.exitCodeLabel = new System.Windows.Forms.Label();
			this.exitCodeTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// executablePathTextBox
			// 
			this.executablePathTextBox.Location = new System.Drawing.Point(45, 29);
			this.executablePathTextBox.Name = "executablePathTextBox";
			this.executablePathTextBox.Size = new System.Drawing.Size(290, 20);
			this.executablePathTextBox.TabIndex = 0;
			// 
			// argumentsTextBox
			// 
			this.argumentsTextBox.Location = new System.Drawing.Point(45, 98);
			this.argumentsTextBox.Name = "argumentsTextBox";
			this.argumentsTextBox.Size = new System.Drawing.Size(290, 20);
			this.argumentsTextBox.TabIndex = 1;
			// 
			// launchButton
			// 
			this.launchButton.Location = new System.Drawing.Point(260, 181);
			this.launchButton.Name = "launchButton";
			this.launchButton.Size = new System.Drawing.Size(75, 23);
			this.launchButton.TabIndex = 2;
			this.launchButton.Text = "Запустить";
			this.launchButton.UseVisualStyleBackColor = true;
			this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
			// 
			// exitCodeLabel
			// 
			this.exitCodeLabel.AutoSize = true;
			this.exitCodeLabel.Location = new System.Drawing.Point(42, 219);
			this.exitCodeLabel.Name = "exitCodeLabel";
			this.exitCodeLabel.Size = new System.Drawing.Size(91, 13);
			this.exitCodeLabel.TabIndex = 3;
			this.exitCodeLabel.Text = "Код завершения";
			// 
			// exitCodeTextBox
			// 
			this.exitCodeTextBox.Location = new System.Drawing.Point(45, 235);
			this.exitCodeTextBox.Name = "exitCodeTextBox";
			this.exitCodeTextBox.ReadOnly = true;
			this.exitCodeTextBox.Size = new System.Drawing.Size(290, 20);
			this.exitCodeTextBox.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(42, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Путь к исполняемому файлу";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 307);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.exitCodeTextBox);
			this.Controls.Add(this.exitCodeLabel);
			this.Controls.Add(this.launchButton);
			this.Controls.Add(this.argumentsTextBox);
			this.Controls.Add(this.executablePathTextBox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox executablePathTextBox;
		private System.Windows.Forms.TextBox argumentsTextBox;
		private System.Windows.Forms.Button launchButton;
		private System.Windows.Forms.Label exitCodeLabel;
		private System.Windows.Forms.TextBox exitCodeTextBox;
		private System.Windows.Forms.Label label1;
	}
}

