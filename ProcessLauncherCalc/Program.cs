using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessLauncherCalc
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите первое число:");
			string num1 = Console.ReadLine();

			Console.WriteLine("Введите второе число:");
			string num2 = Console.ReadLine();

			Console.WriteLine("Введите операцию (+, -, *, /):");
			string operation = Console.ReadLine();

			// Создаем строку аргументов для дочернего процесса
			string arguments = $"{num1} {num2} {operation}";

			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.FileName = "CalculatorApp.exe"; // Путь к CalculatorApp.exe
				startInfo.Arguments = arguments; // Аргументы
				startInfo.UseShellExecute = false;
				startInfo.RedirectStandardOutput = true;

				Process process = new Process();
				process.StartInfo = startInfo;

				Console.WriteLine("Запускаю CalculatorApp...");
				process.Start();

				string output = process.StandardOutput.ReadToEnd(); // Считываем вывод

				process.WaitForExit();

				Console.WriteLine("Вывод дочернего процесса:");
				Console.WriteLine(output);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при запуске процесса: {ex.Message}");
			}
			finally
			{
				Console.WriteLine("Нажмите любую клавишу для выхода.");
				Console.ReadKey();
			}
		}
	}
}
