

namespace LogForYou.Core.Exceptions
{
    public class InvalidDateTimeFormatException : Exception
    {
        private const string DefaultMessage = "Invalid DateTime Format";
        public InvalidDateTimeFormatException(): base(DefaultMessage) 
        {
            
        }
        public InvalidDateTimeFormatException(string message) : base (message)
        { 
        }
    }
}
