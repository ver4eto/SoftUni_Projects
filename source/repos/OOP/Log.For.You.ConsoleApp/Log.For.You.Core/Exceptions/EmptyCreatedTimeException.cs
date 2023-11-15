

namespace LogForYou.Core.Exceptions
{
    public class EmptyCreatedTimeException : Exception
    {
        private const string DefaultMessage = "Created time of message cnnot be null or witespace";
        public EmptyCreatedTimeException(): base(DefaultMessage) 
        {
            
        }
        public EmptyCreatedTimeException(string message) : base (message)
        { 
        }
    }
}
