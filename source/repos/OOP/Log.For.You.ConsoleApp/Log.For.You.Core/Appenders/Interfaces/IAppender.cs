using LogForYou.Core.Enums;
using LogForYou.Core.Layouts.Interfaces;
using LogForYou.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForYou.Core.Appenders.Interfaces
{
    public interface IAppender
    {
     ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }
        int MessagesAppended {  get; }
        void Append(Message message);

    }
}
