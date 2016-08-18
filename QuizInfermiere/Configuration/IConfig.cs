using SQLite.Net.Interop;

namespace QuizInfermiere.Configuration
{
    public interface IConfig
	{
		string PersonalFolder { get; }
		ISQLitePlatform Piattaforma { get; }
	}

}

