using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace Calculator
{
    class NLogTest
    {
        public void Run()
        {
            //Create configuration object 
            var config = new LoggingConfiguration();

            //Create a File target and add it to the configuration 
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            //Set target properties 
            fileTarget.FileName = "${basedir}/NLogFile.txt";
            fileTarget.Layout = "${message}";

            //Define rules
            var rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule2);

            //Activate the configuration
            LogManager.Configuration = config;

            // Example usage
            //Logger logger = LogManager.GetLogger("NLogTest");
            //logger.Trace("Trace log message");
            //logger.Debug("Debug log message");
            //logger.Info("Info log message");
            //logger.Warn("Warn log message");
            //logger.Error("Error log message");
            //logger.Fatal("Fatal log message");
        }
    }
}
