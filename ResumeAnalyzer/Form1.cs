using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeAnalyzer
{
	public partial class Form1 : Form
	{
		private List<Resume> _resumes = new List<Resume>();

		public Form1()
		{
			InitializeComponent();
		}

		// Обработчик нажатия кнопки загрузки резюме
		private async void loadResumeButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Multiselect = true;
				openFileDialog.Filter = "Resume files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog.Title = "Выберите резюме";

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					// Запускаем загрузку и анализ резюме параллельно
					await LoadAndAnalyzeResumes(openFileDialog.FileNames);
					UpdateReports(); // Обновляем отчеты после загрузки всех резюме
				}
			}
		}

		// Обработчик нажатия кнопки загрузки папки с резюме
		private async void loadFolderButton_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				folderBrowserDialog.Description = "Выберите папку с резюме";

				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.txt");
					await LoadAndAnalyzeResumes(files);
					UpdateReports(); // Обновляем отчеты после загрузки всех резюме
				}
			}
		}

		// Метод для загрузки и анализа резюме
		private async Task LoadAndAnalyzeResumes(string[] filePaths)
		{
			// Используем Parallel.ForEach для параллельной обработки файлов
			await Task.Run(() =>
			{
				Parallel.ForEach(filePaths, filePath =>
				{
					try
					{
						Resume resume = ParseResume(filePath);
						if (resume != null)
						{
							lock (_resumes) // Синхронизация доступа к списку резюме
							{
								_resumes.Add(resume);
							}
							// Выводим информацию о загруженном резюме
							this.Invoke((MethodInvoker)delegate {
								resumeListBox.Items.Add(resume.Name);
							});
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Ошибка при обработке файла {filePath}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				});
			});
		}

		// Метод для разбора файла резюме
		private Resume ParseResume(string filePath)
		{
			Resume resume = new Resume();

			try
			{
				string[] lines = File.ReadAllLines(filePath);

				resume.Name = GetValue(lines, "Имя");
				resume.City = GetValue(lines, "Город");
				resume.Experience = int.Parse(GetValue(lines, "Опыт"));
				resume.SalaryExpectation = decimal.Parse(GetValue(lines, "Зарплата"));

				return resume;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при разборе файла {filePath}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		// Метод для извлечения значения из строки файла
		private string GetValue(string[] lines, string key)
		{
			string pattern = $"{key}:\\s*(.+)";
			foreach (string line in lines)
			{
				Match match = Regex.Match(line, pattern);
				if (match.Success)
				{
					return match.Groups[1].Value.Trim();
				}
			}
			return string.Empty;
		}

		// Метод для обновления отчетов
		private void UpdateReports()
		{
			if (_resumes.Count == 0)
			{
				MessageBox.Show("Нет загруженных резюме.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
				ClearReports();
				return;
			}

			// Используем Task.Run для каждого отчета, чтобы не блокировать UI
			Task.Run(() => UpdateExperiencedCandidateReport());
			Task.Run(() => UpdateInexperiencedCandidateReport());
			Task.Run(() => UpdateSameCityCandidatesReport());
			Task.Run(() => UpdateLowestSalaryCandidateReport());
			Task.Run(() => UpdateHighestSalaryCandidateReport());
		}

		// Метод для обновления отчета о самом опытном кандидате
		private void UpdateExperiencedCandidateReport()
		{
			Resume mostExperienced = null;
			lock (_resumes)
			{
				mostExperienced = _resumes.OrderByDescending(r => r.Experience).FirstOrDefault();
			}
			this.Invoke((MethodInvoker)delegate {
				experiencedCandidateTextBox.Text = mostExperienced != null ? $"{mostExperienced.Name} ({mostExperienced.Experience} лет)" : "Нет данных";
			});
		}

		// Метод для обновления отчета о самом неопытном кандидате
		private void UpdateInexperiencedCandidateReport()
		{
			Resume leastExperienced = null;
			lock (_resumes)
			{
				leastExperienced = _resumes.OrderBy(r => r.Experience).FirstOrDefault();
			}
			this.Invoke((MethodInvoker)delegate {
				inexperiencedCandidateTextBox.Text = leastExperienced != null ? $"{leastExperienced.Name} ({leastExperienced.Experience} лет)" : "Нет данных";
			});
		}

		// Метод для обновления отчета о кандидатах из одного города
		private void UpdateSameCityCandidatesReport()
		{
			string city = "";
			lock (_resumes)
			{
				if (_resumes.Count > 0)
				{
					city = _resumes[0].City;
				}
			}

			string sameCityCandidates = "";
			lock (_resumes)
			{
				sameCityCandidates = string.Join(", ", _resumes.Where(r => r.City == city).Select(r => r.Name));
			}

			string finalCity = city; // Локальная копия для потока
			this.Invoke((MethodInvoker)delegate {
				sameCityCandidatesTextBox.Text = !string.IsNullOrEmpty(finalCity) ? $"Кандидаты из города {finalCity}: {sameCityCandidates}" : "Нет данных";
			});
		}

		// Метод для обновления отчета о кандидате с самыми низкими зарплатными требованиями
		private void UpdateLowestSalaryCandidateReport()
		{
			Resume lowestSalary = null;
			lock (_resumes)
			{
				lowestSalary = _resumes.OrderBy(r => r.SalaryExpectation).FirstOrDefault();
			}
			this.Invoke((MethodInvoker)delegate {
				lowestSalaryCandidateTextBox.Text = lowestSalary != null ? $"{lowestSalary.Name} ({lowestSalary.SalaryExpectation:C})" : "Нет данных";
			});
		}

		// Метод для обновления отчета о кандидате с самыми высокими зарплатными требованиями
		private void UpdateHighestSalaryCandidateReport()
		{
			Resume highestSalary = null;
			lock (_resumes)
			{
				highestSalary = _resumes.OrderByDescending(r => r.SalaryExpectation).FirstOrDefault();
			}
			this.Invoke((MethodInvoker)delegate {
				highestSalaryCandidateTextBox.Text = highestSalary != null ? $"{highestSalary.Name} ({highestSalary.SalaryExpectation:C})" : "Нет данных";
			});
		}

		// Метод для очистки отчетов
		private void ClearReports()
		{
			experiencedCandidateTextBox.Text = string.Empty;
			inexperiencedCandidateTextBox.Text = string.Empty;
			sameCityCandidatesTextBox.Text = string.Empty;
			lowestSalaryCandidateTextBox.Text = string.Empty;
			highestSalaryCandidateTextBox.Text = string.Empty;
		}
	}

	// Класс для представления резюме
	class Resume
	{
		public string Name { get; set; }
		public string City { get; set; }
		public int Experience { get; set; }
		public decimal SalaryExpectation { get; set; }
	}
}