
namespace LogForYou.Core.Exceptions
{
    public class EmptyFileNameException : Exception
    {
        private const string DefaultMessage = "Created file name cannot be null or witespace";
        public EmptyFileNameException() : base(DefaultMessage)
        {

        }
        public EmptyFileNameException
            (string message) : base(message)
        {
        }
    }
}
