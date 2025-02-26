using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary;

namespace ServerApp
{
	public partial class ServerForm : Form
	{
		private TcpListener _listener;
		private TcpClient _client;
		private NetworkStream _stream;
		private bool _isRunning = true;

		public ServerForm()
		{
			InitializeComponent();
		}

		private async void startButton_Click(object sender, EventArgs e)
		{
			try
			{
				string ipAddress = ipAddressTextBox.Text;
				int port = int.Parse(portTextBox.Text);

				IPAddress ip = IPAddress.Parse(ipAddress);
				_listener = new TcpListener(ip, port);
				_listener.Start();

				Log("Сервер запущен и ожидает подключений...");

				_client = await _listener.AcceptTcpClientAsync();
				_stream = _client.GetStream();
				Log("Клиент подключился.");

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
						Log("Соединение с клиентом разорвано или произошла ошибка.");
						break;
					}

					Log($"Получено сообщение от {message.Sender}: {message.Content}");

					// Echo back the message
					SharedLibrary.Message response = new SharedLibrary.Message { Sender = "Server", Receiver = message.Sender, Content = "Echo: " + message.Content };
					await SharedLibrary.NetworkHelper.SendMessage(_stream, response);
					Log($"Отправлено эхо-сообщение клиенту.");
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
			_listener?.Stop();
			Log("Сервер остановлен.");
		}

		private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Stop();
		}
	}
}
