using System.Configuration;

namespace TravelGuideTunisia.Business.Helpers
{
    /// <summary>
    /// Configuration Rate Service
    /// </summary>
    public static class ConfigurationRateService
    {
        public static string MaxRateWindow
        {
            get { return ConfigurationManager.AppSettings["maxRateWindow"]; }
        }

        public static string MaxRateValue
        {
            get { return ConfigurationManager.AppSettings["maxRateValue"]; }
        }

        public static string MaxAttemptsPerCode
        {
            get { return ConfigurationManager.AppSettings["max_attempts_per_code"]; }
        }
    }
}
