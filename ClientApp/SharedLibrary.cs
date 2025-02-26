using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary
{
	public class Message
	{
		public string Sender { get; set; }
		public string Receiver { get; set; }
		public string Content { get; set; }
	}

	public static class NetworkHelper
	{
		public static async Task SendMessage(NetworkStream stream, Message message)
		{
			string jsonMessage = JsonConvert.SerializeObject(message);
			byte[] data = Encoding.UTF8.GetBytes(jsonMessage);

			byte[] lengthBytes = BitConverter.GetBytes(data.Length);
			await stream.WriteAsync(lengthBytes, 0, 4);
			await stream.FlushAsync();
			await stream.WriteAsync(data, 0, data.Length);
			await stream.FlushAsync();
		}

		public static async Task<Message> ReceiveMessage(NetworkStream stream)
		{
			try
			{
				byte[] lengthBytes = new byte[4];
				int bytesRead = await stream.ReadAsync(lengthBytes, 0, 4);

				if (bytesRead == 0)
				{
					return null; // Connection closed
				}

				int dataLength = BitConverter.ToInt32(lengthBytes, 0);
				byte[] data = new byte[dataLength];
				bytesRead = await stream.ReadAsync(data, 0, dataLength);

				if (bytesRead == 0)
				{
					return null; // Connection closed
				}

				string jsonMessage = Encoding.UTF8.GetString(data, 0, bytesRead);
				return JsonConvert.DeserializeObject<Message>(jsonMessage);
			}
			catch
			{
				return null; // Error occurred, connection closed
			}
		}
	}
}