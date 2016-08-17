using System;
using SQLite.Net.Interop;

namespace QuizInfermiere
{
	public interface IConfig 	{
		string PersonalFolder { get; } 		ISQLitePlatform Piattaforma { get; } 	} 
}

