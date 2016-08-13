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

			var webClient = new WebClient();

			webClient.DownloadStringCompleted += (s, e) =>
			{
				var text = e.Result; // get the downloaded text
				string documentsPath = config.PersonalFolder;
				string localFilename = "InfermieriDataBase.db";
				string localPath = Path.Combine(documentsPath, localFilename);
				File.WriteAllText(localPath, text); // writes to local storage
			};
		//	webClient.DownloadFile(urlRemoteDB, Path.Combine(localPathDB, "InfermieriDataBase.db"));
			webClient.Encoding = Encoding.UTF8;

			webClient.DownloadStringAsync(url);

			return true;
		}

	}

}
