using log4net;

/**
 * This class is used to setup logs
 * Different methods print different messages
 */
namespace SiteDocsAutomationProject.logs
{
    public class Logs
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Logs));

        static Logs()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));

        }

        public static void StartOfTest()
        {
            Log.Info("############       START OF TEST CASE        ############");
        }
        public static void EndOfTest()
        {
            Log.Info("############        END OF TEST CASE        ############");
        }
        public static void Info(String message)
        {
            Log.Info(message);
        }

        public static void Error(String message)
        {
            Log.Error(message);
        }


    }
}
