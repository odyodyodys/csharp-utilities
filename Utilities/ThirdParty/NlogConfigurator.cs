using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog.Config;
using NLog.Targets;
using NLog;

namespace Utilities.ThirdParty
{
    internal static class NlogConfigurator
    {
        internal static void ConfigureLogger(string mainApplicationName, string baseFilename)
        {
            LoggingConfiguration nlogConfig = new LoggingConfiguration();
            FileTarget target = new FileTarget();
            nlogConfig.AddTarget(baseFilename, target);

            // configure target
            target.Layout = @"${date:format=HH\:mm\:ss.ff} Th${threadid} ${level} ${logger} ${message} ${exception:format=tostring}";
            target.FileName = @"${specialfolder:folder=ApplicationData}/" + mainApplicationName + "/logs/" + baseFilename + ".log";
            target.ArchiveFileName = @"${specialfolder:folder=ApplicationData}/" + mainApplicationName + "/logs/" + baseFilename + ".{#}.log";
            target.ArchiveAboveSize = 4194304; // 4Mb
            target.ArchiveNumbering = ArchiveNumberingMode.Sequence;
            target.ConcurrentWrites = true;
            target.MaxArchiveFiles = 10;
            target.KeepFileOpen = false;
            target.Encoding = Encoding.UTF8;

            // define rules
            LoggingRule rule = new LoggingRule("*", LogLevel.Debug, target);
            nlogConfig.LoggingRules.Add(rule);

            LogManager.Configuration = nlogConfig;
        }
    }
}
