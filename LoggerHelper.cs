using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem
{
    public static class LoggerHelper
    {
        private static readonly string sourceName = "GymSystemApp";
        private static readonly string logName = "Application";

      
        public static void LogError(string message, Exception ex = null)
        {
            string fullMessage = message;
            if (ex != null)
            {
                fullMessage += $"\n[Exception Details]: {ex.Message}\n[Stack Trace]: {ex.StackTrace}";
            }

            WriteToEventLog(fullMessage, EventLogEntryType.Error);
        }

   
        public static void LogWarning(string message)
        {
            WriteToEventLog(message, EventLogEntryType.Warning);
        }

        
        public static void LogInfo(string message)
        {
            WriteToEventLog(message, EventLogEntryType.Information);
        }

      
        private static void WriteToEventLog(string message, EventLogEntryType entryType)
        {
            try
            {
            
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, logName);
                }

            
                EventLog.WriteEntry(sourceName, message, entryType);
            }
            catch (Exception ex)
            {
              
                System.Diagnostics.Debug.WriteLine("Failed to write to EventLog: " + ex.Message);
            }
        }
    }
}
