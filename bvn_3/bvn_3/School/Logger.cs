using System;
using System.Configuration;
using System.IO;

namespace bvn_3.School
{
    public static class Logger
    {
        public static void WriteLog(string mess)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} : {mess}");
            }
        }
    }
}
