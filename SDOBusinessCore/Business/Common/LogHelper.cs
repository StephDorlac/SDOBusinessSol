using log4net;
using log4net.Repository;
using System;
using System.Reflection;
using System.Threading;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace SDOBusinessCore.Business.Common
{
    public static class LogHelper
    {
        #region Enumerations
        /// <summary>
        /// SeverityLevel of message
        /// </summary>
        public enum SeverityLevel
        {
            Info,
            Warn,
            Debug,
            Error,
            Fatal
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Write the message.
        /// </summary>
        /// <param name="message">The message.</param> 
        /// <param name="level">The level.</param>
        public static void LogMessage(string message, SeverityLevel level)
        {
            LogMessage(message, level, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
        }

        /// <summary>
        /// Log message regarding logger name and severity level
        /// </summary>
        public static void LogMessage(String message, SeverityLevel level, String loggerName)
        {
            ILoggerRepository loggerRepository = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            ILog logger = log4net.LogManager.GetLogger(loggerRepository.Name, loggerName);

            switch (level)
            {
                case SeverityLevel.Debug:
                    if (logger.IsDebugEnabled)
                        logger.DebugFormat(Thread.CurrentThread.CurrentCulture, message);
                    break;
                case SeverityLevel.Fatal:
                    if (logger.IsFatalEnabled)
                        logger.FatalFormat(Thread.CurrentThread.CurrentCulture, message);
                    break;
                case SeverityLevel.Info:
                    if (logger.IsInfoEnabled)
                        logger.InfoFormat(Thread.CurrentThread.CurrentCulture, message);
                    break;
                case SeverityLevel.Warn:
                    if (logger.IsWarnEnabled)
                        logger.WarnFormat(Thread.CurrentThread.CurrentCulture, message);
                    break;
                case SeverityLevel.Error:
                    if (logger.IsErrorEnabled)
                        logger.ErrorFormat(Thread.CurrentThread.CurrentCulture, message);
                    break;
            }
        }

        #endregion
    }
}
