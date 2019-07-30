using System.Collections.Generic;

namespace PrivateLocatedPackageManager
{
    public static class LogTracer
    {
        public static event LogPrinter OnLogWrote;
        public static event LogPrinter OnErrorLogWrote;
        
        public static void Log(string str)
        {
            OnLogWrote?.Invoke(str);
        }

        public static void LogError(string str)
        {
            OnErrorLogWrote?.Invoke(str);
        }

        public delegate void LogPrinter(string log);
    }
}