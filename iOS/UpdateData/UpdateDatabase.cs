using QuizInfermiere.UpdateData;
using System;
using System.IO;
using System.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuizInfermiere.iOS.UpdateDatabase))]


namespace QuizInfermiere.iOS
{
    public class UpdateDatabase : IUpdateDatabase
	{
		public bool UpdateData(string urlDb, string nomeDb, string personalFolder)
        {
			var url = new Uri(urlDb); 
			var cartellaOutputDB = Path.Combine(personalFolder, nomeDb);

			if (!File.Exists(personalFolder))
			{
				Directory.CreateDirectory(personalFolder);
			}

            var webClient = new WebClient();
			webClient.DownloadFile(url, cartellaOutputDB);

			if (!File.Exists(cartellaOutputDB))
			{
                throw new ApplicationException("Database non scaricato");
            }

			return true;
		}

	}

}
