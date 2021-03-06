﻿using SQLite.Net.Interop;
using Xamarin.Forms;
using QuizInfermiere.Configuration;

[assembly: Dependency(typeof(QuizInfermiere.Droid.Config))]

namespace QuizInfermiere.Droid
{
	class Config : IConfig
	{
		private string directoryDB;
		private ISQLitePlatform piattaforma;

		public string PersonalFolder
		{
			get
			{
				if (string.IsNullOrEmpty(directoryDB))
				{
					directoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
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
					piattaforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
				}
				return piattaforma;
			}
		}
	}
}

