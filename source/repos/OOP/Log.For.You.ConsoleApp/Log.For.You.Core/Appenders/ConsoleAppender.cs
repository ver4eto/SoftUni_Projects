using LogForYou.Core.Appenders.Interfaces;
using LogForYou.Core.Enums;
using LogForYou.Core.Layouts.Interfaces;
using LogForYou.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForYou.Core.Appenders
{
    public class ConsoleAppender : IAppender
    {
       
        public ConsoleAppender(ILayout layout, ReportLevel level = ReportLevel.Info)
        {
            ReportLevel = level;

            Layout = layout;
        }
        public ILayout Layout { get; private set; }
        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended  {get; private set;}


        public void Append(Message message)
        {
            Console.WriteLine(string.Format(Layout.Format,message.CreatedTime,  message.ReportLevel, message.Text));
            MessagesAppended++;
        }
    }
}
