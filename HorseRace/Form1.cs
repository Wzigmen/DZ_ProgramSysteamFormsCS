using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRace
{
	public partial class Form1 : Form
	{
		private const int NumberOfHorses = 5;
		private List<ProgressBar> _horseProgressBars = new List<ProgressBar>();
		private Random _random = new Random();
		private List<HorseResult> _raceResults = new List<HorseResult>();
		private CancellationTokenSource _globalCancellationTokenSource = new CancellationTokenSource(); // Для отмены всех гонок

		public Form1()
		{
			InitializeComponent();

			// Инициализируем прогресс-бары
			for (int i = 0; i < NumberOfHorses; i++)
			{
				ProgressBar horseProgressBar = new ProgressBar();
				horseProgressBar.Width = 400;
				horseProgressBar.Height = 20;
				horseProgressBar.Minimum = 0;
				horseProgressBar.Maximum = 1000; // Увеличиваем для более плавной анимации
				flowLayoutPanel.Controls.Add(horseProgressBar);
				_horseProgressBars.Add(horseProgressBar);
			}
		}

		private async void startButton_Click(object sender, EventArgs e)
		{
			startButton.Enabled = false;
			resultsListBox.Items.Clear();
			_raceResults.Clear();

			_globalCancellationTokenSource = new CancellationTokenSource(); // Создаем новый токен отмены для каждой гонки
			CancellationToken globalToken = _globalCancellationTokenSource.Token;

			List<Task> horseTasks = new List<Task>(); // Список для хранения задач

			// Сбрасываем и запускаем лошадей
			for (int i = 0; i < NumberOfHorses; i++)
			{
				_horseProgressBars[i].Value = 0;
				int horseNumber = i + 1;
				ProgressBar horseProgressBar = _horseProgressBars[i]; // Локальная копия для избежания проблем с захватом переменной в лямбда-выражении

				Task horseTask = Task.Run(() => RunHorse(horseNumber, horseProgressBar, globalToken), globalToken);
				horseTasks.Add(horseTask);
			}

			try
			{
				await Task.WhenAll(horseTasks); // Дожидаемся завершения всех задач или отмены
			}
			catch (OperationCanceledException)
			{
				Console.WriteLine("Гонка отменена.");
			}
			finally
			{
				startButton.Enabled = true;
				UpdateResults();
			}
		}

		private async Task RunHorse(int horseNumber, ProgressBar horseProgressBar, CancellationToken token)
		{
			int distance = 0;
			try
			{
				while (distance < horseProgressBar.Maximum && !token.IsCancellationRequested)
				{
					// Случайное приращение дистанции (скорость)
					int speed = _random.Next(1, 15);
					distance += speed;

					horseProgressBar.Invoke((MethodInvoker)delegate
					{
						horseProgressBar.Value = Math.Min(distance, horseProgressBar.Maximum); // Убеждаемся, что не превышаем максимум
					});

					await Task.Delay(_random.Next(20, 100), token); // Случайная задержка для реалистичности, учитываем токен
				}
			}
			catch (TaskCanceledException)
			{
				Console.WriteLine($"Лошадь {horseNumber}: Гонка прервана.");
				return; // Важно выйти из метода, если задача отменена
			}
			finally
			{
				// Записываем результат гонки (только если не была отменена)
				if (!token.IsCancellationRequested)
				{
					_raceResults.Add(new HorseResult { HorseNumber = horseNumber, FinishTime = DateTime.Now });
				}
				Console.WriteLine($"Лошадь {horseNumber}: Финишировала или гонка прервана.");
			}
		}

		private void UpdateResults()
		{
			// Сортируем результаты по времени финиша
			var sortedResults = _raceResults.OrderBy(r => r.FinishTime).ToList();

			resultsListBox.Invoke((MethodInvoker)delegate
			{
				resultsListBox.Items.Clear();
				resultsListBox.Items.Add("Результаты скачек:");
				for (int i = 0; i < sortedResults.Count; i++)
				{
					resultsListBox.Items.Add($"#{i + 1}: Лошадь {sortedResults[i].HorseNumber}");
				}
			});
		}

		// Класс для хранения результатов гонки
		private class HorseResult
		{
			public int HorseNumber { get; set; }
			public DateTime FinishTime { get; set; }
		}
	}
}