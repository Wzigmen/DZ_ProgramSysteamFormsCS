using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary;

namespace ClientApp
{
	public partial class ClientForm : Form
	{
		private TcpClient _client;
		private NetworkStream _stream;
		private bool _isRunning = true;

		public ClientForm()
		{
			InitializeComponent();
		}

		private async void connectButton_Click(object sender, EventArgs e)
		{
			try
			{
				string ipAddress = ipAddressTextBox.Text;
				int port = int.Parse(portTextBox.Text);

				_client = new TcpClient();
				await _client.ConnectAsync(ipAddress, port);
				_stream = _client.GetStream();

				Log("Подключено к серверу.");

				// Start listening for messages
				_ = Task.Run(() => ReceiveMessages());
			}
			catch (Exception ex)
			{
				Log($"Ошибка: {ex.Message}");
				Stop();
			}
		}

		private async Task ReceiveMessages()
		{
			try
			{
				while (_isRunning && _client.Connected)
				{
					SharedLibrary.Message message = await SharedLibrary.NetworkHelper.ReceiveMessage(_stream);

					if (message == null)
					{
						Log("Соединение с сервером разорвано или произошла ошибка.");
						break;
					}

					Log($"Получено сообщение от {message.Sender}: {message.Content}");
				}
			}
			catch (Exception ex)
			{
				Log($"Ошибка при получении сообщения: {ex.Message}");
			}
			finally
			{
				Stop();
			}
		}

		private async void sendButton_Click(object sender, EventArgs e)
		{
			try
			{
				string messageText = messageTextBox.Text;
				SharedLibrary.Message message = new SharedLibrary.Message { Sender = "Client", Receiver = "Server", Content = messageText };
				await SharedLibrary.NetworkHelper.SendMessage(_stream, message);
				Log($"Отправлено сообщение серверу: {messageText}");
			}
			catch (Exception ex)
			{
				Log($"Ошибка при отправке сообщения: {ex.Message}");
				Stop();
			}
		}

		private void Log(string message)
		{
			if (logTextBox.InvokeRequired)
			{
				logTextBox.Invoke(new Action<string>(Log), message);
			}
			else
			{
				logTextBox.AppendText(message + Environment.NewLine);
			}
		}

		private void Stop()
		{
			_isRunning = false;
			_stream?.Close();
			_client?.Close();
			Log("Соединение закрыто.");
		}

		private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Stop();
		}
	}
}
