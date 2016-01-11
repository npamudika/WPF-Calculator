using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using log4net.Config;
using System.IO;

namespace Calculator
{
    class LogFileManager
    {
        #region Static Members
        public static string FILEPATH = "D:/Projects/WPF/Calculator/Calculator/Config/Log.xml";

        static LogFileManager instance = null;
        static readonly object logFileManager = new object();
        #endregion

        #region constructor
        LogFileManager()
        {
            //init();
        }

        public static LogFileManager Instance
        {
            get
            {
                lock (logFileManager)
                {
                    if (instance == null)
                    {
                        try
                        {
                            instance = new LogFileManager();
                            instance.init();
                        }
                        catch
                        {
                        }
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region public methods
        public void init()
        {
            try
            {
                if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(FILEPATH)))
                {
                    XmlConfigurator.Configure(new FileInfo(FILEPATH));
                    return;
                }
            }
            catch (Exception)
            {
            }

            try
            {
                string file = ConfigurationManager.AppSettings["LogFilePath"];
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                FILEPATH = Path.Combine(baseDirectory, file);
                if (File.Exists(FILEPATH))
                {
                    XmlConfigurator.Configure(new FileInfo(FILEPATH));
                    return;
                }
            }
            catch (Exception)
            {
            }
            XmlConfigurator.Configure();
        }

        public log4net.ILog GetRootLogger()
        {
            log4net.ILog log = log4net.LogManager.GetLogger("root");
            return log;
        }
        public log4net.ILog GetErrorLogger()
        {
            log4net.ILog log = log4net.LogManager.GetLogger("error");
            return log;
        }
        public log4net.ILog GetEventLogger()
        {
            log4net.ILog log = log4net.LogManager.GetLogger("event");
            return log;
        }
        public log4net.ILog GetLogger(string loggerName)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(loggerName);
            return log;
        }
        #endregion
    }
}
