using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BeepApp
{
	public partial class Form1 : Form
	{
		[DllImport("kernel32.dll")]
		static extern bool Beep(uint dwFreq, uint dwDuration);

		[DllImport("user32.dll")]
		static extern bool MessageBeep(uint uType);

		private int _beepCount = 0; // Счетчик звуковых сигналов
		private bool _isBeeping = false; // Флаг для остановки звучания
		private CancellationTokenSource _cancellationTokenSource; // Для остановки задачи

		public Form1()
		{
			InitializeComponent();
		}

		private async void startButton_Click(object sender, EventArgs e)
		{
			if (_isBeeping) return; // предотвращение повторного запуска

			_isBeeping = true;
			startButton.Enabled = false;
			stopButton.Enabled = true;

			_cancellationTokenSource = new CancellationTokenSource();
			CancellationToken token = _cancellationTokenSource.Token;

			try
			{
				await Task.Run(() => GenerateBeepSequence(token));
			}
			catch (OperationCanceledException)
			{
				// Отмена задачи - это нормально при нажатии стоп-кнопки
			}
			finally
			{
				_isBeeping = false;
				startButton.Enabled = true;
				stopButton.Enabled = false;
			}
		}

		private void GenerateBeepSequence(CancellationToken token)
		{
			int interval = int.TryParse(intervalTextBox.Text, out int intervalValue) ? intervalValue * 1000 : 1000;  // Интервал в мс, по умолчанию 1 секунда
			int duration = int.TryParse(durationTextBox.Text, out int durationValue) ? durationValue : 250; // Длительность в мс, по умолчанию 250 мс
			int frequency = int.TryParse(frequencyTextBox.Text, out int frequencyValue) ? frequencyValue : 440; // Частота в Гц, по умолчанию 440 Гц


			for (int i = 0; i < 5 && !token.IsCancellationRequested; i++) // 5 звуков по умолчанию
			{
				Beep((uint)frequency, (uint)duration); // Используем Beep из API
				Thread.Sleep(interval); // пауза между сигналами
			}

			if (!token.IsCancellationRequested)
			{
				// дополнительный сигнал в конце
				MessageBeep(0);
			}

		}


		private void stopButton_Click(object sender, EventArgs e)
		{
			_cancellationTokenSource?.Cancel();
		}
	}
}
