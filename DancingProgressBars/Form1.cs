using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DancingProgressBars
{
	public partial class Form1 : Form
	{
		private List<ProgressBar> _progressBars = new List<ProgressBar>();
		private List<CancellationTokenSource> _cancellationTokenSources = new List<CancellationTokenSource>();
		private Random _random = new Random();

		public Form1()
		{
			InitializeComponent();
		}

		private async void startButton_Click(object sender, EventArgs e)
		{
			flowLayoutPanel.Controls.Clear(); // Очищаем предыдущие прогресс-бары
			_progressBars.Clear();
			_cancellationTokenSources.Clear();

			if (!int.TryParse(progressBarCountTextBox.Text, out int progressBarCount) || progressBarCount <= 0)
			{
				MessageBox.Show("Пожалуйста, введите положительное число прогресс-баров.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			startButton.Enabled = false;

			for (int i = 0; i < progressBarCount; i++)
			{
				ProgressBar progressBar = new ProgressBar();
				progressBar.Width = 200;
				progressBar.Height = 20;
				progressBar.Minimum = 0;
				progressBar.Maximum = 100;
				flowLayoutPanel.Controls.Add(progressBar);
				_progressBars.Add(progressBar);

				CancellationTokenSource cts = new CancellationTokenSource();
				_cancellationTokenSources.Add(cts);

				// Запускаем "танец" прогресс-бара в отдельном потоке
				_ = Task.Run(() => AnimateProgressBar(progressBar, cts.Token));
			}

			await Task.Delay(5000); // Даем время поработать ProgressBar`ам

			startButton.Enabled = true;
		}

		private async Task AnimateProgressBar(ProgressBar progressBar, CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				// Генерируем случайные значения для скорости и цвета
				int increment = _random.Next(1, 10);
				Color color = Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256));

				progressBar.Invoke((MethodInvoker)delegate
				{
					progressBar.Value = (progressBar.Value + increment) % (progressBar.Maximum + 1); // Зацикливаем заполнение
					progressBar.ForeColor = color;

					//  Добавляем эффект "переполнения"
					if (progressBar.Value >= progressBar.Maximum)
					{
						progressBar.Value = 0;
					}
				});

				await Task.Delay(_random.Next(50, 200)); // Случайная задержка
			}
		}

		// Пример остановки одного из Progressbar`ов
		private void StopProgressBar(int index)
		{
			if (index >= 0 && index < _cancellationTokenSources.Count)
			{
				_cancellationTokenSources[index].Cancel();
			}
		}
	}
}