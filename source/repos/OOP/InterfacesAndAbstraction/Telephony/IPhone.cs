using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public interface IPhone
    {
     string Number {  get; set; }
        string CallPhone(string number);
    }
}
