namespace ResumeAnalyzer
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
			this.loadResumeButton = new System.Windows.Forms.Button();
			this.loadFolderButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.resumeListBox = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.experiencedCandidateTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.inexperiencedCandidateTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.sameCityCandidatesTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.lowestSalaryCandidateTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.highestSalaryCandidateTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			//
			// loadResumeButton
			//
			this.loadResumeButton.Location = new System.Drawing.Point(12, 12);
			this.loadResumeButton.Name = "loadResumeButton";
			this.loadResumeButton.Size = new System.Drawing.Size(120, 23);
			this.loadResumeButton.TabIndex = 0;
			this.loadResumeButton.Text = "Загрузить резюме";
			this.loadResumeButton.UseVisualStyleBackColor = true;
			this.loadResumeButton.Click += new System.EventHandler(this.loadResumeButton_Click);
			//
			// loadFolderButton
			//
			this.loadFolderButton.Location = new System.Drawing.Point(138, 12);
			this.loadFolderButton.Name = "loadFolderButton";
			this.loadFolderButton.Size = new System.Drawing.Size(140, 23);
			this.loadFolderButton.TabIndex = 1;
			this.loadFolderButton.Text = "Загрузить папку";
			this.loadFolderButton.UseVisualStyleBackColor = true;
			this.loadFolderButton.Click += new System.EventHandler(this.loadFolderButton_Click);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Загруженные резюме:";
			//
			// resumeListBox
			//
			this.resumeListBox.FormattingEnabled = true;
			this.resumeListBox.ItemHeight = 15;
			this.resumeListBox.Location = new System.Drawing.Point(12, 66);
			this.resumeListBox.Name = "resumeListBox";
			this.resumeListBox.Size = new System.Drawing.Size(266, 289);
			this.resumeListBox.TabIndex = 3;
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(293, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 15);
			this.label2.TabIndex = 4;
			this.label2.Text = "Отчеты:";
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(293, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(135, 15);
			this.label3.TabIndex = 5;
			this.label3.Text = "Самый опытный кандидат:";
			//
			// experiencedCandidateTextBox
			//
			this.experiencedCandidateTextBox.Location = new System.Drawing.Point(293, 84);
			this.experiencedCandidateTextBox.Name = "experiencedCandidateTextBox";
			this.experiencedCandidateTextBox.ReadOnly = true;
			this.experiencedCandidateTextBox.Size = new System.Drawing.Size(266, 23);
			this.experiencedCandidateTextBox.TabIndex = 6;
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(293, 110);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(150, 15);
			this.label4.TabIndex = 7;
			this.label4.Text = "Самый неопытный кандидат:";
			//
			// inexperiencedCandidateTextBox
			//
			this.inexperiencedCandidateTextBox.Location = new System.Drawing.Point(293, 128);
			this.inexperiencedCandidateTextBox.Name = "inexperiencedCandidateTextBox";
			this.inexperiencedCandidateTextBox.ReadOnly = true;
			this.inexperiencedCandidateTextBox.Size = new System.Drawing.Size(266, 23);
			this.inexperiencedCandidateTextBox.TabIndex = 8;
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(293, 154);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(106, 15);
			this.label5.TabIndex = 9;
			this.label5.Text = "Кандидаты из города:";
			//
			// sameCityCandidatesTextBox
			//
			this.sameCityCandidatesTextBox.Location = new System.Drawing.Point(293, 172);
			this.sameCityCandidatesTextBox.Name = "sameCityCandidatesTextBox";
			this.sameCityCandidatesTextBox.ReadOnly = true;
			this.sameCityCandidatesTextBox.Size = new System.Drawing.Size(266, 23);
			this.sameCityCandidatesTextBox.TabIndex = 10;
			//
			// label6
			//
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(293, 198);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(210, 15);
			this.label6.TabIndex = 11;
			this.label6.Text = "Кандидат с самыми низкими запросами:";
			//
			// lowestSalaryCandidateTextBox
			//
			this.lowestSalaryCandidateTextBox.Location = new System.Drawing.Point(293, 216);
			this.lowestSalaryCandidateTextBox.Name = "lowestSalaryCandidateTextBox";
			this.lowestSalaryCandidateTextBox.ReadOnly = true;
			this.lowestSalaryCandidateTextBox.Size = new System.Drawing.Size(266, 23);
			this.lowestSalaryCandidateTextBox.TabIndex = 12;
			//
			// label7
			//
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(293, 242);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(214, 15);
			this.label7.TabIndex = 13;
			this.label7.Text = "Кандидат с самыми высокими запросами:";
			//
			// highestSalaryCandidateTextBox
			//
			this.highestSalaryCandidateTextBox.Location = new System.Drawing.Point(293, 260);
			this.highestSalaryCandidateTextBox.Name = "highestSalaryCandidateTextBox";
			this.highestSalaryCandidateTextBox.ReadOnly = true;
			this.highestSalaryCandidateTextBox.Size = new System.Drawing.Size(266, 23);
			this.highestSalaryCandidateTextBox.TabIndex = 14;
			//
			// Form1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 361);
			this.Controls.Add(this.highestSalaryCandidateTextBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.lowestSalaryCandidateTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.sameCityCandidatesTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.inexperiencedCandidateTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.experiencedCandidateTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.resumeListBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.loadFolderButton);
			this.Controls.Add(this.loadResumeButton);
			this.Name = "Form1";
			this.Text = "Resume Analyzer";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button loadResumeButton;
		private System.Windows.Forms.Button loadFolderButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox resumeListBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox experiencedCandidateTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox inexperiencedCandidateTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox sameCityCandidatesTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox lowestSalaryCandidateTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox highestSalaryCandidateTextBox;
	}
}
