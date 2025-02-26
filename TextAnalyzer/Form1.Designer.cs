namespace TextAnalyzer
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
			this.inputLabel = new System.Windows.Forms.Label();
			this.inputTextBox = new System.Windows.Forms.TextBox();
			this.analyzeButton = new System.Windows.Forms.Button();
			this.outputOptionsGroupBox = new System.Windows.Forms.GroupBox();
			this.saveReportRadioButton = new System.Windows.Forms.RadioButton();
			this.displayReportRadioButton = new System.Windows.Forms.RadioButton();
			this.reportTextBox = new System.Windows.Forms.TextBox();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.outputOptionsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// inputLabel
			// 
			this.inputLabel.AutoSize = true;
			this.inputLabel.Location = new System.Drawing.Point(10, 8);
			this.inputLabel.Name = "inputLabel";
			this.inputLabel.Size = new System.Drawing.Size(83, 13);
			this.inputLabel.TabIndex = 0;
			this.inputLabel.Text = "Введите текст:";
			// 
			// inputTextBox
			// 
			this.inputTextBox.Location = new System.Drawing.Point(10, 26);
			this.inputTextBox.Multiline = true;
			this.inputTextBox.Name = "inputTextBox";
			this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.inputTextBox.Size = new System.Drawing.Size(733, 131);
			this.inputTextBox.TabIndex = 1;
			// 
			// analyzeButton
			// 
			this.analyzeButton.Location = new System.Drawing.Point(10, 161);
			this.analyzeButton.Name = "analyzeButton";
			this.analyzeButton.Size = new System.Drawing.Size(76, 20);
			this.analyzeButton.TabIndex = 2;
			this.analyzeButton.Text = "Анализировать";
			this.analyzeButton.UseVisualStyleBackColor = true;
			this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
			// 
			// outputOptionsGroupBox
			// 
			this.outputOptionsGroupBox.Controls.Add(this.saveReportRadioButton);
			this.outputOptionsGroupBox.Controls.Add(this.displayReportRadioButton);
			this.outputOptionsGroupBox.Location = new System.Drawing.Point(10, 187);
			this.outputOptionsGroupBox.Name = "outputOptionsGroupBox";
			this.outputOptionsGroupBox.Size = new System.Drawing.Size(394, 52);
			this.outputOptionsGroupBox.TabIndex = 3;
			this.outputOptionsGroupBox.TabStop = false;
			this.outputOptionsGroupBox.Text = "Вывод отчета";
			// 
			// saveReportRadioButton
			// 
			this.saveReportRadioButton.AutoSize = true;
			this.saveReportRadioButton.Location = new System.Drawing.Point(154, 19);
			this.saveReportRadioButton.Name = "saveReportRadioButton";
			this.saveReportRadioButton.Size = new System.Drawing.Size(116, 17);
			this.saveReportRadioButton.TabIndex = 1;
			this.saveReportRadioButton.Text = "Сохранить в файл";
			this.saveReportRadioButton.UseVisualStyleBackColor = true;
			// 
			// displayReportRadioButton
			// 
			this.displayReportRadioButton.AutoSize = true;
			this.displayReportRadioButton.Checked = true;
			this.displayReportRadioButton.Location = new System.Drawing.Point(9, 19);
			this.displayReportRadioButton.Name = "displayReportRadioButton";
			this.displayReportRadioButton.Size = new System.Drawing.Size(139, 17);
			this.displayReportRadioButton.TabIndex = 0;
			this.displayReportRadioButton.TabStop = true;
			this.displayReportRadioButton.Text = "Отобразить на экране";
			this.displayReportRadioButton.UseVisualStyleBackColor = true;
			// 
			// reportTextBox
			// 
			this.reportTextBox.Location = new System.Drawing.Point(10, 251);
			this.reportTextBox.Multiline = true;
			this.reportTextBox.Name = "reportTextBox";
			this.reportTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.reportTextBox.Size = new System.Drawing.Size(733, 131);
			this.reportTextBox.TabIndex = 4;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "txt";
			this.saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			this.saveFileDialog.Title = "Сохранить отчет";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(755, 400);
			this.Controls.Add(this.reportTextBox);
			this.Controls.Add(this.outputOptionsGroupBox);
			this.Controls.Add(this.analyzeButton);
			this.Controls.Add(this.inputTextBox);
			this.Controls.Add(this.inputLabel);
			this.Name = "Form1";
			this.Text = "Text Analyzer";
			this.outputOptionsGroupBox.ResumeLayout(false);
			this.outputOptionsGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label inputLabel;
		private System.Windows.Forms.TextBox inputTextBox;
		private System.Windows.Forms.Button analyzeButton;
		private System.Windows.Forms.GroupBox outputOptionsGroupBox;
		private System.Windows.Forms.RadioButton saveReportRadioButton;
		private System.Windows.Forms.RadioButton displayReportRadioButton;
		private System.Windows.Forms.TextBox reportTextBox;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
	}
}