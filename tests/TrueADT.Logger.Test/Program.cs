using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using TrueADT.Models;

namespace TrueADT.Logger.Test
{
	class Program
	{

		public static SerializerService serializer = new SerializerService();

		static void Main(string[] args)
		{
			Task result = Task.Factory.StartNew(AsyncMain).GetAwaiter().GetResult();

			if(result.IsFaulted)
			{
				Console.WriteLine($"Failed: {result.Exception?.InnerException?.Message} StackTrace: {result.Exception?.InnerException?.StackTrace}");
				Console.ReadKey();
			}
		}

		private static async Task AsyncMain()
		{
			//While they're typing this let's build the serializer.
			Task serializerReady = Task.Factory.StartNew(() =>
			{
				serializer.RegisterType<AdtFile>();
				serializer.Compile();
			}, TaskCreationOptions.LongRunning);

			string adtName = Console.ReadLine();

			if(String.IsNullOrEmpty(adtName) || !File.Exists(adtName))
				throw new ArgumentException($"No adt file named {adtName} found in the directory.");

			byte[] bytes = File.ReadAllBytes(adtName);

			//wait for the serializer to compile
			await serializerReady;

			AdtFile adtFile = serializer.Deserialize<AdtFile>(bytes);

			foreach(var chunk in adtFile)
				Console.WriteLine(chunk.ToString());

			Console.ReadKey();
		}
	}
}
