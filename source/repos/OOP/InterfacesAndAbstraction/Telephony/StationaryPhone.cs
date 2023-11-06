using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        private string _phoneNumber;
        public StationaryPhone(string phoneNumber)
        {
            Number = phoneNumber;
        }
        public string Number { get => _phoneNumber;
            set 
            {               
                 bool hasOnlyDigit = value.All(char.IsDigit);

                if (value.Length == 7 && hasOnlyDigit)
                {
                    this._phoneNumber = value;
                }
                //else
                //{
                //    Console.WriteLine("Invalid number!"); 
                //}
            } }

        public string CallPhone(string number)
        {
            return $"Dialing... {Number}";
        }
    }
}
