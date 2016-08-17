using System;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuizInfermiere.iOS.UpdateDatabase))]


namespace QuizInfermiere.iOS
{
	public class UpdateDatabase : IUpdateDatabase
	{
		public bool IsPresenteAggiornamento()
		{
			return true;
		}

		public bool UpdateData()
		{
			
			var config = new Config();
			var url = new Uri("http://www.managerfx.altervista.org/Ftp/InfermieriDataBase.db"); // Html repo DB

			string documentsPath = config.PersonalFolder;
			string localFilename = "InfermieriDataBase.db";
			var fileNameAndPath = Path.Combine(documentsPath, localFilename);



			if (!File.Exists(documentsPath))
			{
				Directory.CreateDirectory(documentsPath);
			}


			var webClient = new WebClient();
			webClient.DownloadFile(url, fileNameAndPath);

			if (File.Exists(fileNameAndPath))
			{
				var a = "ok";
			}

			return true;
		}

	}

}
