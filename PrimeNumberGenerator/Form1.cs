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

namespace PrimeNumberGenerator
{
	public partial class Form1 : Form
	{
		private CancellationTokenSource _primeCancellationTokenSource;
		private CancellationTokenSource _fibonacciCancellationTokenSource;

		public Form1()
		{
			InitializeComponent();
		}

		private async void generateButton_Click(object sender, EventArgs e)
		{
			primeNumbersListBox.Items.Clear();
			fibonacciNumbersListBox.Items.Clear();
			generateButton.Enabled = false;
			stopButton.Enabled = true;
			stopPrimeButton.Enabled = true;
			stopFibonacciButton.Enabled = true;

			int lowerBound = 2;
			if (!string.IsNullOrEmpty(lowerBoundTextBox.Text) && int.TryParse(lowerBoundTextBox.Text, out int parsedLowerBound))
			{
				lowerBound = parsedLowerBound;
			}

			long upperBound = long.MaxValue;
			if (!string.IsNullOrEmpty(upperBoundTextBox.Text) && long.TryParse(upperBoundTextBox.Text, out long parsedUpperBound))
			{
				upperBound = parsedUpperBound;
			}

			_primeCancellationTokenSource = new CancellationTokenSource();
			_fibonacciCancellationTokenSource = new CancellationTokenSource();

			CancellationToken primeToken = _primeCancellationTokenSource.Token;
			CancellationToken fibonacciToken = _fibonacciCancellationTokenSource.Token;

			try
			{
				// Запускаем оба потока параллельно
				Task primeTask = Task.Run(() => GeneratePrimeNumbers(lowerBound, upperBound, primeToken));
				Task fibonacciTask = Task.Run(() => GenerateFibonacciNumbers(fibonacciToken));

				await Task.WhenAll(primeTask, fibonacciTask);
			}
			catch (OperationCanceledException)
			{
				// Операция отменена - это нормально
			}
			finally
			{
				generateButton.Enabled = true;
				stopButton.Enabled = false;
				stopPrimeButton.Enabled = false;
				stopFibonacciButton.Enabled = false;
			}
		}

		private void GeneratePrimeNumbers(int lowerBound, long upperBound, CancellationToken token)
		{
			for (long i = lowerBound; i <= upperBound; i++)
			{
				if (token.IsCancellationRequested)
				{
					Console.WriteLine("Prime numbers generation cancelled.");
					break;
				}

				if (IsPrime(i))
				{
					primeNumbersListBox.Invoke((MethodInvoker)delegate
					{
						primeNumbersListBox.Items.Add(i);
					});
				}
			}
		}

		private void GenerateFibonacciNumbers(CancellationToken token)
		{
			long a = 0;
			long b = 1;

			while (!token.IsCancellationRequested)
			{
				fibonacciNumbersListBox.Invoke((MethodInvoker)delegate
				{
					fibonacciNumbersListBox.Items.Add(a);
				});

				long temp = a;
				a = b;
				b = temp + b;

				Thread.Sleep(10);

				if (a < 0 || b < 0) break; // Предотвращение переполнения
			}

			Console.WriteLine("Fibonacci numbers generation cancelled.");
		}

		private bool IsPrime(long number)
		{
			if (number <= 1) return false;
			if (number <= 3) return true;

			if (number % 2 == 0 || number % 3 == 0) return false;

			for (long i = 5; i * i <= number; i = i + 6)
			{
				if (number % i == 0 || number % (i + 2) == 0)
					return false;
			}

			return true;
		}

		private void stopButton_Click(object sender, EventArgs e)
		{
			_primeCancellationTokenSource?.Cancel();
			_fibonacciCancellationTokenSource?.Cancel();
		}

		private void stopPrimeButton_Click(object sender, EventArgs e)
		{
			_primeCancellationTokenSource?.Cancel();
		}

		private void stopFibonacciButton_Click(object sender, EventArgs e)
		{
			_fibonacciCancellationTokenSource?.Cancel();
		}
	}
}