using System;
using SQLite.Net.Interop;

namespace QuizInfermiere
{
	public interface IConfig 	{
		string DirectoryDB { get; } 		ISQLitePlatform Piattaforma { get; } 	} 
}

