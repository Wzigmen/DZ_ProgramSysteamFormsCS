using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EventDrivenArithmetic
{
	class Program
	{
		private static readonly string NumbersFile = "numbers.txt";
		private static readonly string SumsFile = "sums.txt";
		private static readonly string ProductsFile = "products.txt";

		// Объявляем событие, которое будет сигнализировать о завершении генерации чисел
		public static event EventHandler GenerationComplete;

		static async Task Main(string[] args)
		{
			Console.WriteLine("Приложение запущено.");

			// Первый поток: Генерация и сохранение пар чисел в файл
			Task generateNumbersTask = Task.Run(() => GenerateNumbers(10));

			// Второй поток: Подсчет суммы каждой пары и запись в файл
			Task calculateSumsTask = Task.Run(() => CalculateSums());

			// Третий поток: Подсчет произведения каждой пары и запись в файл
			Task calculateProductsTask = Task.Run(() => CalculateProducts());

			// Дожидаемся завершения всех задач
			await Task.WhenAll(generateNumbersTask, calculateSumsTask, calculateProductsTask);

			Console.WriteLine("Приложение завершило работу.");
		}

		// Метод для генерации и сохранения пар чисел в файл
		static void GenerateNumbers(int numberOfPairs)
		{
			Console.WriteLine("Генерация пар чисел...");
			Random random = new Random();
			try
			{
				using (StreamWriter writer = new StreamWriter(NumbersFile))
				{
					for (int i = 0; i < numberOfPairs; i++)
					{
						int number1 = random.Next(1, 100); // Генерируем случайное число от 1 до 100
						int number2 = random.Next(1, 100);
						writer.WriteLine($"{number1},{number2}");
					}
				}
				Console.WriteLine("Пары чисел сгенерированы и записаны в файл.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при генерации чисел: {ex.Message}");
			}
			finally
			{
				// После завершения генерации поднимаем событие
				GenerationComplete?.Invoke(null, EventArgs.Empty);
			}
		}

		// Метод для подсчета суммы каждой пары и записи в файл
		static void CalculateSums()
		{
			// Ожидаем события GenerationComplete, прежде чем начать
			GenerationComplete += (sender, e) =>
			{
				Console.WriteLine("Подсчет сумм...");
				try
				{
					using (StreamReader reader = new StreamReader(NumbersFile))
					using (StreamWriter writer = new StreamWriter(SumsFile))
					{
						string line;
						while ((line = reader.ReadLine()) != null)
						{
							string[] numbers = line.Split(',');
							if (numbers.Length == 2 && int.TryParse(numbers[0], out int number1) && int.TryParse(numbers[1], out int number2))
							{
								writer.WriteLine(number1 + number2);
							}
						}
					}
					Console.WriteLine("Суммы подсчитаны и записаны в файл.");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Ошибка при подсчете сумм: {ex.Message}");
				}
			};
		}

		// Метод для подсчета произведения каждой пары и записи в файл
		static void CalculateProducts()
		{
			// Ожидаем события GenerationComplete, прежде чем начать
			GenerationComplete += (sender, e) =>
			{
				Console.WriteLine("Подсчет произведений...");
				try
				{
					using (StreamReader reader = new StreamReader(NumbersFile))
					using (StreamWriter writer = new StreamWriter(ProductsFile))
					{
						string line;
						while ((line = reader.ReadLine()) != null)
						{
							string[] numbers = line.Split(',');
							if (numbers.Length == 2 && int.TryParse(numbers[0], out int number1) && int.TryParse(numbers[1], out int number2))
							{
								writer.WriteLine(number1 * number2);
							}
						}
					}
					Console.WriteLine("Произведения подсчитаны и записаны в файл.");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Ошибка при подсчете произведений: {ex.Message}");
				}
			};
		}
	}
}
