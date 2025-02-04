using System;

namespace CalculatorApp
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length != 3)
			{
				Console.WriteLine("Использование: CalculatorApp <число1> <число2> <операция>");
				return;
			}

			try
			{
				double num1 = double.Parse(args[0]);
				double num2 = double.Parse(args[1]);
				string operation = args[2];

				double result = 0;

				switch (operation)
				{
					case "+":
						result = num1 + num2;
						break;
					case "-":
						result = num1 - num2;
						break;
					case "*":
						result = num1 * num2;
						break;
					case "/":
						if (num2 != 0)
						{
							result = num1 / num2;
						}
						else
						{
							Console.WriteLine("Деление на ноль!");
							return;
						}
						break;
					default:
						Console.WriteLine("Неизвестная операция!");
						return;
				}

				Console.WriteLine($"Аргументы: {num1}, {num2}, {operation}");
				Console.WriteLine($"Результат: {result}");
			}
			catch (FormatException)
			{
				Console.WriteLine("Некорректный формат чисел!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Произошла ошибка: {ex.Message}");
			}
		}
	}
}
