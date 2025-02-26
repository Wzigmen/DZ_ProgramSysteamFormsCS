namespace ServerApp
{
	partial class ServerForm
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
			this.ipAddressTextBox = new System.Windows.Forms.TextBox();
			this.portTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.messageTextBox = new System.Windows.Forms.TextBox();
			this.logTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// startButton
			//
			this.startButton.Location = new System.Drawing.Point(344, 10);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 0;
			this.startButton.Text = "Запустить";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			//
			// ipAddressTextBox
			//
			this.ipAddressTextBox.Location = new System.Drawing.Point(94, 12);
			this.ipAddressTextBox.Name = "ipAddressTextBox";
			this.ipAddressTextBox.Size = new System.Drawing.Size(100, 20);
			this.ipAddressTextBox.TabIndex = 1;
			this.ipAddressTextBox.Text = "127.0.0.1";
			//
			// portTextBox
			//
			this.portTextBox.Location = new System.Drawing.Point(238, 12);
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Size = new System.Drawing.Size(100, 20);
			this.portTextBox.TabIndex = 2;
			this.portTextBox.Text = "12345";
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "IP Address:";
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(200, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Port:";
			//
			// messageTextBox
			//
			this.messageTextBox.Location = new System.Drawing.Point(12, 61);
			this.messageTextBox.Name = "messageTextBox";
			this.messageTextBox.Size = new System.Drawing.Size(407, 20);
			this.messageTextBox.TabIndex = 5;
			//
			// logTextBox
			//
			this.logTextBox.Location = new System.Drawing.Point(12, 112);
			this.logTextBox.Multiline = true;
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.ReadOnly = true;
			this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.logTextBox.Size = new System.Drawing.Size(407, 237);
			this.logTextBox.TabIndex = 6;
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Сообщение";
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(26, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Лог:";
			//
			// ServerForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 361);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.logTextBox);
			this.Controls.Add(this.messageTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.portTextBox);
			this.Controls.Add(this.ipAddressTextBox);
			this.Controls.Add(this.startButton);
			this.Name = "ServerForm";
			this.Text = "Server";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.TextBox ipAddressTextBox;
		private System.Windows.Forms.TextBox portTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox messageTextBox;
		private System.Windows.Forms.TextBox logTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}

