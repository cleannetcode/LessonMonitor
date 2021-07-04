using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace TryStreams
{
	class Program
	{
		/*
		1) Ничего
		2) Ошибка
		3) Перезапишется сообщение
		4) Сообщение добавится рядом
		 
		 */

		static async Task Main(string[] args)
		{
			await using var file = new FileStream(
				"test.txt",
				FileMode.OpenOrCreate,
				FileAccess.ReadWrite,
				FileShare.ReadWrite);

			using var zipArchive = ZipFile.Open("test.zip", ZipArchiveMode.Create);

			var enitry = zipArchive.CreateEntry("message.txt", CompressionLevel.Optimal);
			await using var dataStream = enitry.Open();
			await file.CopyToAsync(dataStream);


			//var message = "Test Message";
			//var messageBytes = Encoding.UTF8.GetBytes(message);

			//file.Seek(file.Length, SeekOrigin.Begin);

			//for (int i = 0; i < messageBytes.Length; i++)
			//{
			//	messageBytes[i] = (byte)(messageBytes[i] ^ 42);
			//}

			//await file.WriteAsync(messageBytes);
			//await file.WriteAsync(messageBytes);

			//var bytes = new byte[file.Length];

			//await file.ReadAsync(bytes);

			//for (int i = 0; i < bytes.Length; i++)
			//{
			//	bytes[i] = (byte)(bytes[i] ^ 42);
			//}

			//var message = Encoding.UTF8.GetString(bytes);

			//Console.WriteLine(message);

		}
	}
}
