using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // Добавляем пространство имен

namespace MessageBoxApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		// Объявляем функцию MessageBox из User32.dll
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int MessageBox(IntPtr hWnd, String text, String caption, int type);

		private void showMessageButton_Click(object sender, EventArgs e)
		{
			// Отображаем MessageBox с помощью вызова API
			MessageBox(IntPtr.Zero, "Привет! Я Русский", "Информация", 0);
			MessageBox(IntPtr.Zero, "Я изучаю разработку на C#", "Информация", 0);
		}
	}
}
