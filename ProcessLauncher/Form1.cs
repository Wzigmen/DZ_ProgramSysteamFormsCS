using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessLauncher
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void launchButton_Click(object sender, EventArgs e) // Запускает exe файлы
		{
			string executablePath = executablePathTextBox.Text;
			string arguments = argumentsTextBox.Text;

			if (string.IsNullOrEmpty(executablePath))
			{
				MessageBox.Show("Пожалуйста, введите путь к исполняемому файлу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.FileName = executablePath;
				startInfo.Arguments = arguments;
				startInfo.UseShellExecute = false;
				startInfo.RedirectStandardOutput = true;
				startInfo.RedirectStandardError = true;

				using (Process process = new Process()) // IDisposable for better resource management
				{
					process.StartInfo = startInfo;
					process.Start();
					process.WaitForExit();

					exitCodeTextBox.Text = process.ExitCode.ToString();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при запуске процесса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
