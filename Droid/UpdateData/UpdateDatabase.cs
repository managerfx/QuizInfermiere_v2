using QuizInfermiere.UpdateData;
using System;
using System.IO;
using System.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuizInfermiere.Droid.UpdateDatabase))]


namespace QuizInfermiere.Droid
{
    public class UpdateDatabase : IUpdateDatabase
	{
        public bool UpdateData(string urlDb, string nomeDb, string personalFolder)
        {
            bool esito = true;

            var url = new Uri(urlDb);
            var cartellaOutputDB = Path.Combine(personalFolder, nomeDb);

            if (!File.Exists(personalFolder))
                Directory.CreateDirectory(personalFolder);

            try
            {
                var webClient = new WebClient();
                webClient.DownloadFile(url, cartellaOutputDB);
            }
            catch (Exception)
            {
                esito = false;
            }

            if (!File.Exists(cartellaOutputDB))
            {
                //db non scaricato
            }

            return esito;
        }

    }

}
