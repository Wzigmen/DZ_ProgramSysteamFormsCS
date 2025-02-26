using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalyzer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private async void analyzeButton_Click(object sender, EventArgs e)
		{
			string text = inputTextBox.Text;

			// Запускаем анализ текста в отдельной задаче
			var report = await Task.Run(() => AnalyzeText(text));

			if (displayReportRadioButton.Checked)
			{
				reportTextBox.Text = report;
			}
			else if (saveReportRadioButton.Checked)
			{
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(saveFileDialog.FileName, report);
						MessageBox.Show("Отчет успешно сохранен в файл.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private string AnalyzeText(string text)
		{
			// Количество предложений
			string[] sentences = Regex.Split(text, @"(?<=[.?!])\s+");
			int sentenceCount = sentences.Length;

			// Количество символов (без пробелов)
			int characterCount = text.Replace(" ", "").Length;

			// Количество слов
			string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
			int wordCount = words.Length;

			// Количество вопросительных предложений
			int questionCount = sentences.Count(s => s.EndsWith("?"));

			// Количество восклицательных предложений
			int exclamationCount = sentences.Count(s => s.EndsWith("!"));

			// Формируем отчет
			string report = $"Отчет об анализе текста:\r\n" +
							$"-----------------------------------\r\n" +
							$"Количество предложений: {sentenceCount}\r\n" +
							$"Количество символов (без пробелов): {characterCount}\r\n" +
							$"Количество слов: {wordCount}\r\n" +
							$"Количество вопросительных предложений: {questionCount}\r\n" +
							$"Количество восклицательных предложений: {exclamationCount}";

			return report;
		}
	}
}
