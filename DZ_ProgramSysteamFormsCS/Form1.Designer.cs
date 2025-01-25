namespace ControllerApp
{
	partial class openWindowButton
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
			this.titleTextBox = new System.Windows.Forms.TextBox();
			this.changeTitleButton = new System.Windows.Forms.Button();
			this.closeWindowButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// titleTextBox
			// 
			this.titleTextBox.Location = new System.Drawing.Point(13, 13);
			this.titleTextBox.Name = "titleTextBox";
			this.titleTextBox.Size = new System.Drawing.Size(259, 20);
			this.titleTextBox.TabIndex = 0;
			// 
			// changeTitleButton
			// 
			this.changeTitleButton.Location = new System.Drawing.Point(13, 40);
			this.changeTitleButton.Name = "changeTitleButton";
			this.changeTitleButton.Size = new System.Drawing.Size(128, 23);
			this.changeTitleButton.TabIndex = 1;
			this.changeTitleButton.Text = "Изменить заголовок";
			this.changeTitleButton.UseVisualStyleBackColor = true;
			this.changeTitleButton.Click += new System.EventHandler(this.changeTitleButton_Click);
			// 
			// closeWindowButton
			// 
			this.closeWindowButton.Location = new System.Drawing.Point(144, 40);
			this.closeWindowButton.Name = "closeWindowButton";
			this.closeWindowButton.Size = new System.Drawing.Size(128, 23);
			this.closeWindowButton.TabIndex = 2;
			this.closeWindowButton.Text = "Закрыть окно";
			this.closeWindowButton.UseVisualStyleBackColor = true;
			this.closeWindowButton.Click += new System.EventHandler(this.closeWindowButton_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(87, 69);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Открыть окно";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// openWindowButton
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.closeWindowButton);
			this.Controls.Add(this.changeTitleButton);
			this.Controls.Add(this.titleTextBox);
			this.Name = "openWindowButton";
			this.Text = "Контроллер окна";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		//private System.Windows.Forms.Button openWindowButton;
		private System.Windows.Forms.TextBox titleTextBox;
		private System.Windows.Forms.Button changeTitleButton;
		private System.Windows.Forms.Button closeWindowButton;
		private System.Windows.Forms.Button button1;
	}
}

