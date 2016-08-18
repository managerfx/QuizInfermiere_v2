using log4net;
using QuizInfermiere.Configuration;
using System.Reflection;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuizInfermiere.iOS.Logger.Log4Net))]


namespace QuizInfermiere.iOS.Logger
{
    public class Log4Net : ILogger
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void LogDebug(string text)
        {
            log.Debug(text);
        }
        public void LogInfo(string text)
        {
            log.Info(text);
        }
        public void LogError(string text)
        {
            log.Error(text);
        }
    }
}