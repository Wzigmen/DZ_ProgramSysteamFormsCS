using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ControllerApp
{
	public partial class openWindowButton : Form
	{
		// Константы для сообщений WinAPI
		const int WM_SETTEXT = 0x000C;
		const int WM_CLOSE = 0x0010;

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindow); // Для WM_SETTEXT

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam); // Для WM_CLOSE


		public openWindowButton()
		{
			InitializeComponent();
		}

		private void changeTitleButton_Click(object sender, EventArgs e)
		{
			string windowTitle = "MyTargetWindow";
			IntPtr hwnd = FindWindow(null, windowTitle);

			if (hwnd != IntPtr.Zero)
			{
				string newTitle = titleTextBox.Text;
				IntPtr ptrNewTitle = Marshal.StringToHGlobalUni(newTitle); // Преобразуем строку в IntPtr

				try
				{
					SendMessage(hwnd, WM_SETTEXT, IntPtr.Zero, ptrNewTitle);
					MessageBox.Show("Заголовок окна был успешно изменен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				finally
				{
					Marshal.FreeHGlobal(ptrNewTitle); // Освобождаем выделенную память
				}

			}
			else
			{
				MessageBox.Show($"Окно с заголовком '{windowTitle}' не найдено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		private void closeWindowButton_Click(object sender, EventArgs e)
		{
			string windowTitle = "MyTargetWindow";
			IntPtr hwnd = FindWindow(null, windowTitle);

			if (hwnd != IntPtr.Zero)
			{
				SendMessage(hwnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero); // Закрываем окно
				MessageBox.Show("Окно было успешно закрыто!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show($"Окно с заголовком '{windowTitle}' не найдено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Process[] processes = Process.GetProcessesByName("TargetApp");
			if (processes.Length == 0)
			{
				try
				{
					// Запускаем TargetApp.exe (УБЕДИТЕСЬ, что путь корректный!)
					ProcessStartInfo startInfo = new ProcessStartInfo();
					startInfo.FileName = "TargetApp.exe"; // Имя исполняемого файла TargetApp
					startInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); // Путь к каталогу с исполняемыми файлами
					Process.Start(startInfo);

					MessageBox.Show("Приложение MyTargetWindow запущено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка запуска приложения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Приложение MyTargetWindow уже запущено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
