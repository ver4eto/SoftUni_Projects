using LogForYou.Core.Appenders.Interfaces;
using LogForYou.Core.Enums;
using LogForYou.Core.IO.Interfaces;
using LogForYou.Core.Layouts.Interfaces;
using LogForYou.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForYou.Core.Appenders
{
    public class FileAppender : IAppender
    {
       
        public FileAppender(ILayout layout,ILogFile logFile, ReportLevel level = ReportLevel.Info)
        {
            ReportLevel = level;

            Layout = layout;

            LogFile = logFile;
        }

        public ILogFile LogFile { get; private set; }
        public ILayout Layout { get; private set; }
        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended  {get; private set;}


        public void Append(Message message)
        {
           string content =string.Format(Layout.Format,message.CreatedTime,  message.ReportLevel, message.Text) + Environment.NewLine;

            File.AppendAllText(LogFile.FullPath, content);
            MessagesAppended++;
        }
    }
}
