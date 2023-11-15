
namespace LogForYou.Core.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string DefaultMessage = "Path cannot be null or empty";
        public InvalidPathException() : base(DefaultMessage)
        {

        }
        public InvalidPathException(string message) : base(message)
        {
        }
    }
}
