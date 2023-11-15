using LogForYou.Core.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForYou.Core.Layouts
{
    public class SimpleLayout : ILayout
    {
        private const string SampleFormat = "{0} - {1} - {2}";
        public string Format => SampleFormat;
    }
}
