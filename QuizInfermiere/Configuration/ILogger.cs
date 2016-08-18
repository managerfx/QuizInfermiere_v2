namespace QuizInfermiere.Configuration
{
    public interface ILogger
    {
        void LogError(string text);

        void LogInfo(string text);

        void LogDebug(string text);
    }
}
