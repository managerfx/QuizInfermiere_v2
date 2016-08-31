using System;
using System.IO;
using System.Net;
using QuizInfermiere.UpdateData;
using Xamarin.Forms;
using QuizInfermiere.StatusError;

[assembly: Dependency(typeof(QuizInfermiere.iOS.UpdateDatabase))]


namespace QuizInfermiere.iOS
{
	public class UpdateDatabase : IUpdateDatabase
	{
		public ErrorChecker.UpdateStatus UpdateData(string rootUrl, string nameDb, string nameFileVersion, string databaseFolder)
		{
			var check = ErrorChecker.UpdateStatus.Error;

			var webClient = new WebClient();
			var urlVersion = new Uri(String.Format("{0}/{1}", rootUrl, nameFileVersion));
			var urlDb = new Uri(String.Format("{0}/{1}", rootUrl, nameDb));


			try
			{
				Stream stream = webClient.OpenRead(urlVersion);
				StreamReader reader = new StreamReader(stream);
				String appendVersion = reader.ReadToEnd();

				string completeNameDb = String.Concat(Path.GetFileNameWithoutExtension(nameDb), appendVersion, Path.GetExtension(nameDb));
				nameDb = completeNameDb;

				var localPathFileDb = Path.Combine(databaseFolder, nameDb);
				if (!File.Exists(localPathFileDb))
				{
					if (!File.Exists(databaseFolder))
						Directory.CreateDirectory(databaseFolder);

					//cancello tutti i file della cartella
					var fileInDirectory = Directory.GetFiles(databaseFolder);

					try
					{
						webClient.DownloadFile(urlDb, localPathFileDb);
						Array.ForEach(fileInDirectory, File.Delete);
						check = ErrorChecker.UpdateStatus.UpdateOk;
					}
					catch (Exception)
					{
						check = ErrorChecker.UpdateStatus.Error;
					}
				}
				else
				{
					check = ErrorChecker.UpdateStatus.UpdateYet;
				}
			}
			catch (Exception)
			{
				check = ErrorChecker.UpdateStatus.Error;
			}

			return check;
		}
	}
}