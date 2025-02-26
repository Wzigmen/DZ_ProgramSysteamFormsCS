using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusTerminalSimulation
{
	class Program
	{
		// Параметры симуляции
		private const int NumberOfBuses = 5;
		private const int BusCapacity = 50;
		private const int SimulationTimeInSeconds = 60; // Симулируем 1 минуту

		// Общие ресурсы
		private static int _peopleAtTerminal = 0;
		private static readonly object PeopleLock = new object(); // Для синхронизации доступа к peopleAtTerminal

		// Событие для прибытия автобуса
		public static event EventHandler<BusArrivalEventArgs> BusArrived;

		static async Task Main(string[] args)
		{
			Console.WriteLine("Симуляция автобусной конечной остановки запущена.");

			// Запускаем потоки для автобусов
			List<Task> busTasks = new List<Task>();
			for (int i = 0; i < NumberOfBuses; i++)
			{
				int busNumber = 175; // Все автобусы имеют один и тот же номер маршрута
				busTasks.Add(Task.Run(() => SimulateBus(busNumber)));
			}

			// Запускаем поток для прибытия людей на остановку
			Task peopleArrivalTask = Task.Run(() => SimulatePeopleArrival());

			// Запускаем симуляцию на заданное время
			await Task.Delay(SimulationTimeInSeconds * 1000);

			Console.WriteLine("Симуляция завершена.");
		}

		// Симуляция прибытия людей на остановку
		static void SimulatePeopleArrival()
		{
			Console.WriteLine("Начало прибытия людей на остановку.");
			Random random = new Random();
			while (true)
			{
				// Генерируем случайное количество людей, прибывших на остановку
				int newArrivals = random.Next(1, 15);

				// Добавляем людей на остановку, используя блокировку для синхронизации
				lock (PeopleLock)
				{
					_peopleAtTerminal += newArrivals;
					Console.WriteLine($"{newArrivals} людей прибыли на остановку.  Всего на остановке: {_peopleAtTerminal}");
				}

				// Ждем некоторое время до следующего прибытия людей
				Thread.Sleep(random.Next(500, 1500)); // Прибывают каждые 0.5 - 1.5 секунды
			}
		}

		// Симуляция работы автобуса
		static void SimulateBus(int busNumber)
		{
			Console.WriteLine($"Автобус {busNumber} начал свой маршрут.");
			Random random = new Random();
			while (true)
			{
				// Имитируем прибытие автобуса на остановку
				Thread.Sleep(random.Next(3000, 7000)); // Автобус прибывает каждые 3 - 7 секунд

				// Поднимаем событие о прибытии автобуса
				BusArrived?.Invoke(null, new BusArrivalEventArgs(busNumber, BusCapacity));

				// Заполняем автобус пассажирами, используя блокировку для синхронизации
				lock (PeopleLock)
				{
					int passengersTaken = Math.Min(BusCapacity, _peopleAtTerminal); // Сколько людей поместилось в автобус
					_peopleAtTerminal -= passengersTaken; // Уменьшаем количество людей на остановке

					Console.WriteLine($"Автобус {busNumber} прибыл.  В автобус село {passengersTaken} человек. Осталось на остановке: {_peopleAtTerminal}");
				}
			}
		}

		// Класс для аргументов события прибытия автобуса
		public class BusArrivalEventArgs : EventArgs
		{
			public int BusNumber { get; }
			public int BusCapacity { get; }

			public BusArrivalEventArgs(int busNumber, int busCapacity)
			{
				BusNumber = busNumber;
				BusCapacity = busCapacity;
			}
		}
	}
}
