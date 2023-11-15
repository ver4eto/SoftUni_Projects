
namespace LogForYou.Core.Exceptions
{
    public class EmptyMessageTextException : Exception
    {
        private const string DefaultMessage = "Created text of message cnnot be null or witespace";
        public EmptyMessageTextException() : base(DefaultMessage)
        {

        }
        public EmptyMessageTextException(string message) : base(message)
        {
        }
    }
}
