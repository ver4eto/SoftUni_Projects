using LogForYou.ConsoleApp.CustomLayout;
using LogForYou.Core.Appenders;
using LogForYou.Core.Enums;
using LogForYou.Core.IO;
using LogForYou.Core.Layouts;
using LogForYou.Core.Loggers;

//var simpleLayout = new SimpleLayout();
//var consoleAppender = new ConsoleAppender(simpleLayout);
//consoleAppender.ReportLevel = ReportLevel.Error;

//var logger = new Logger(consoleAppender);

//logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
//logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
//logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
//logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
//logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

//var simpleLayout = new SimpleLayout();
var XmlLayout = new XmlLayout();
var consoleAppender = new ConsoleAppender(XmlLayout);

var file = new LogFile("testXml", "xml", Directory.GetCurrentDirectory());
var fileAppender = new FileAppender(XmlLayout, file);

var logger = new Logger(consoleAppender, fileAppender);
logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");


