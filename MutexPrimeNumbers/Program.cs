using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MutexPrimeNumbers
{
	class Program
	{
		private static readonly string RandomNumbersFile = "random_numbers.txt";
		private static readonly string PrimeNumbersFile = "prime_numbers.txt";
		private static readonly string PrimeNumbers = "prime_numbers_7.txt";
        private static readonly string ReportFile = "report.txt";
		private static readonly Mutex Mutex = new Mutex(false); // Создаём мьютекс

		static async Task Main(string[] args)
		{
			Console.WriteLine("Приложение запущено.");

			// Первый поток: Генерация случайных чисел и запись в файл
			Task generateRandomNumbersTask = Task.Run(() => GenerateRandomNumbers(1000));

			// Второй поток: Анализ файла и создание файла с простыми числами
			Task extractPrimeNumbersTask = generateRandomNumbersTask.ContinueWith(_ => ExtractPrimeNumbers());

			// Третий поток: Анализ файла с простыми числами и создание файла с простыми числами, заканчивающимися на 7
			Task extractPrimeNumbersEndingWith7Task = extractPrimeNumbersTask.ContinueWith(_ => ExtractPrimeNumbersEndingWith7());

			// Четвертый поток: Подготовка и вывод отчета
			Task generateReportTask = Task.WhenAll(generateRandomNumbersTask, extractPrimeNumbersTask, extractPrimeNumbersEndingWith7Task).ContinueWith(_ => GenerateReport());

			// Дожидаемся завершения всех задач
			await Task.WhenAll(generateRandomNumbersTask, extractPrimeNumbersTask, extractPrimeNumbersEndingWith7Task, generateReportTask);

			Console.WriteLine("Приложение завершило работу.");
		}

		// Генерация случайных чисел и запись в файл
		static void GenerateRandomNumbers(int count)
		{
			Console.WriteLine("Генерация случайных чисел...");

			try
			{
				Mutex.WaitOne(); // Захватываем мьютекс, чтобы избежать конфликтов при записи в файл

				using (StreamWriter writer = new StreamWriter(RandomNumbersFile))
				{
					Random random = new Random();
					for (int i = 0; i < count; i++)
					{
						writer.WriteLine(random.Next(1, 10000)); // Генерируем случайные числа от 1 до 10000
					}
				}
				Console.WriteLine("Случайные числа сгенерированы и записаны в файл.");
			}
			finally
			{
				Mutex.ReleaseMutex(); // Освобождаем мьютекс
			}
		}

		// Анализ файла и создание файла с простыми числами
		static void ExtractPrimeNumbers()
		{
			Console.WriteLine("Извлечение простых чисел...");

			try
			{
				Mutex.WaitOne(); // Захватываем мьютекс, чтобы избежать конфликтов при чтении и записи в файл

				List<int> primeNumbers = new List<int>();
				using (StreamReader reader = new StreamReader(RandomNumbersFile))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						if (int.TryParse(line, out int number) && IsPrime(number))
						{
							primeNumbers.Add(number);
						}
					}
				}

				using (StreamWriter writer = new StreamWriter(PrimeNumbersFile))
				{
					foreach (int primeNumber in primeNumbers)
					{
						writer.WriteLine(primeNumber);
					}
				}
				Console.WriteLine("Простые числа извлечены и записаны в файл.");
			}
			finally
			{
				Mutex.ReleaseMutex(); // Освобождаем мьютекс
			}
		}

		// Анализ файла с простыми числами и создание файла с простыми числами, заканчивающимися на 7
		static void ExtractPrimeNumbersEndingWith7()
		{
			Console.WriteLine("Извлечение простых чисел, заканчивающихся на 7...");

			try
			{
				Mutex.WaitOne(); // Захватываем мьютекс, чтобы избежать конфликтов при чтении и записи в файл

				List<int> primeNumbersEndingWith7 = new List<int>();
				using (StreamReader reader = new StreamReader(PrimeNumbersFile))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						if (int.TryParse(line, out int number) && number % 10 == 7)
						{
							primeNumbersEndingWith7.Add(number);
						}
					}
				}

				using (StreamWriter writer = new StreamWriter(PrimeNumbers))
				{
					foreach (int primeNumber in primeNumbersEndingWith7)
					{
						writer.WriteLine(primeNumber);
					}
				}
				Console.WriteLine("Простые числа, заканчивающиеся на 7, извлечены и записаны в файл.");
			}
			finally
			{
				Mutex.ReleaseMutex(); // Освобождаем мьютекс
			}
		}

		// Проверка, является ли число простым
		static bool IsPrime(int number)
		{
			if (number <= 1) return false;
			if (number <= 3) return true;
			if (number % 2 == 0 || number % 3 == 0) return false;

			for (int i = 5; i * i <= number; i = i + 6)
			{
				if (number % i == 0 || number % (i + 2) == 0)
					return false;
			}
			return true;
		}

		// Подготовка и вывод отчета
		static void GenerateReport()
		{
			Console.WriteLine("Генерация отчета...");

			try
			{
				Mutex.WaitOne(); // Захватываем мьютекс, чтобы избежать конфликтов при записи в файл

				using (StreamWriter writer = new StreamWriter(ReportFile))
				{
					writer.WriteLine("Отчет о файлах:");
					writer.WriteLine("--------------------------------------------------");

					WriteFileInfo(writer, RandomNumbersFile);
					WriteFileInfo(writer, PrimeNumbersFile);
					WriteFileInfo(writer, PrimeNumbers);
				}

				Console.WriteLine("Отчет сгенерирован и записан в файл.");
			}
			finally
			{
				Mutex.ReleaseMutex(); // Освобождаем мьютекс
			}
		}

		// Запись информации о файле в отчет
		static void WriteFileInfo(StreamWriter writer, string filePath)
		{
			writer.WriteLine($"Файл: {filePath}");

			// Количество чисел в файле
			int count = 0;
			try
			{
				count = File.ReadLines(filePath).Count();
			}
			catch (FileNotFoundException)
			{
				writer.WriteLine("Файл не найден.");
				return;
			}
			writer.WriteLine($"Количество чисел: {count}");

			// Размер файла в байтах
			FileInfo fileInfo = new FileInfo(filePath);
			writer.WriteLine($"Размер файла: {fileInfo.Length} байт");

			// Содержимое файла
			writer.WriteLine("Содержимое файла:");
			try
			{
				foreach (string line in File.ReadLines(filePath))
				{
					writer.WriteLine(line);
				}
			}
			catch (FileNotFoundException)
			{
				writer.WriteLine("Файл не найден.");
			}

			writer.WriteLine("--------------------------------------------------");
		}
	}
}