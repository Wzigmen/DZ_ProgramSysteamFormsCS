namespace PrimeNumberGenerator
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
			this.lowerBoundTextBox = new System.Windows.Forms.TextBox();
			this.upperBoundTextBox = new System.Windows.Forms.TextBox();
			this.primeNumbersListBox = new System.Windows.Forms.ListBox();
			this.generateButton = new System.Windows.Forms.Button();
			this.stopButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.fibonacciNumbersListBox = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.stopPrimeButton = new System.Windows.Forms.Button();
			this.stopFibonacciButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// lowerBoundTextBox
			//
			this.lowerBoundTextBox.Location = new System.Drawing.Point(12, 35);
			this.lowerBoundTextBox.Name = "lowerBoundTextBox";
			this.lowerBoundTextBox.Size = new System.Drawing.Size(150, 23);
			this.lowerBoundTextBox.TabIndex = 0;
			this.lowerBoundTextBox.Text = "";
			//
			// upperBoundTextBox
			//
			this.upperBoundTextBox.Location = new System.Drawing.Point(178, 35);
			this.upperBoundTextBox.Name = "upperBoundTextBox";
			this.upperBoundTextBox.Size = new System.Drawing.Size(150, 23);
			this.upperBoundTextBox.TabIndex = 1;
			this.upperBoundTextBox.Text = "";
			//
			// primeNumbersListBox
			//
			this.primeNumbersListBox.FormattingEnabled = true;
			this.primeNumbersListBox.ItemHeight = 15;
			this.primeNumbersListBox.Location = new System.Drawing.Point(12, 87);
			this.primeNumbersListBox.Name = "primeNumbersListBox";
			this.primeNumbersListBox.Size = new System.Drawing.Size(150, 199);
			this.primeNumbersListBox.TabIndex = 2;
			//
			// generateButton
			//
			this.generateButton.Location = new System.Drawing.Point(12, 303);
			this.generateButton.Name = "generateButton";
			this.generateButton.Size = new System.Drawing.Size(150, 23);
			this.generateButton.TabIndex = 3;
			this.generateButton.Text = "Начать генерацию";
			this.generateButton.UseVisualStyleBackColor = true;
			this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
			//
			// stopButton
			//
			this.stopButton.Enabled = false;
			this.stopButton.Location = new System.Drawing.Point(178, 303);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(150, 23);
			this.stopButton.TabIndex = 4;
			this.stopButton.Text = "Остановить все";
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Нижняя граница";
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(178, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Верхняя граница";
			//
			// fibonacciNumbersListBox
			//
			this.fibonacciNumbersListBox.FormattingEnabled = true;
			this.fibonacciNumbersListBox.ItemHeight = 15;
			this.fibonacciNumbersListBox.Location = new System.Drawing.Point(178, 87);
			this.fibonacciNumbersListBox.Name = "fibonacciNumbersListBox";
			this.fibonacciNumbersListBox.Size = new System.Drawing.Size(150, 199);
			this.fibonacciNumbersListBox.TabIndex = 7;
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Простые числа";
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(178, 61);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Числа Фибоначчи";
			//
			// stopPrimeButton
			//
			this.stopPrimeButton.Enabled = false;
			this.stopPrimeButton.Location = new System.Drawing.Point(12, 332);
			this.stopPrimeButton.Name = "stopPrimeButton";
			this.stopPrimeButton.Size = new System.Drawing.Size(150, 23);
			this.stopPrimeButton.TabIndex = 10;
			this.stopPrimeButton.Text = "Остановить простые";
			this.stopPrimeButton.UseVisualStyleBackColor = true;
			this.stopPrimeButton.Click += new System.EventHandler(this.stopPrimeButton_Click);
			//
			// stopFibonacciButton
			//
			this.stopFibonacciButton.Enabled = false;
			this.stopFibonacciButton.Location = new System.Drawing.Point(178, 332);
			this.stopFibonacciButton.Name = "stopFibonacciButton";
			this.stopFibonacciButton.Size = new System.Drawing.Size(150, 23);
			this.stopFibonacciButton.TabIndex = 11;
			this.stopFibonacciButton.Text = "Остановить Фибоначчи";
			this.stopFibonacciButton.UseVisualStyleBackColor = true;
			this.stopFibonacciButton.Click += new System.EventHandler(this.stopFibonacciButton_Click);
			//
			// Form1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(340, 365);
			this.Controls.Add(this.stopPrimeButton);
			this.Controls.Add(this.stopFibonacciButton);
			this.Controls.Add(this.lowerBoundTextBox);
			this.Controls.Add(this.upperBoundTextBox);
			this.Controls.Add(this.primeNumbersListBox);
			this.Controls.Add(this.generateButton);
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.fibonacciNumbersListBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Name = "Form1";
			this.Text = "Генератор чисел";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.TextBox lowerBoundTextBox;
		private System.Windows.Forms.TextBox upperBoundTextBox;
		private System.Windows.Forms.ListBox primeNumbersListBox;
		private System.Windows.Forms.Button generateButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox fibonacciNumbersListBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button stopPrimeButton;
		private System.Windows.Forms.Button stopFibonacciButton;
	}
}
