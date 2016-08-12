using System;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuizInfermiere.iOS.Config))]

namespace QuizInfermiere.iOS
{
	class Config : IConfig
	{
		private string directoryDB;
		private ISQLitePlatform piattaforma;


		public string DirectoryDB
		{
			get
			{
				if (string.IsNullOrEmpty(directoryDB))
				{
					var directory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					directoryDB = System.IO.Path.Combine(directory, "..", "Library");
				}
				return directoryDB;
			}
		}

		public ISQLitePlatform Piattaforma
		{
			get
			{
				if (piattaforma == null)
				{
					piattaforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
				}
				return piattaforma;
			}
		}
	}
}

