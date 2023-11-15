
namespace LogForYou.Core.Exceptions
{
    public class EmptyFileExtensionException : Exception
    {
        private const string DefaultMessage = "Created file extension cannot be null or witespace";
        public EmptyFileExtensionException() : base(DefaultMessage)
        {

        }
        public EmptyFileExtensionException(string message) : base(message)
        {
        }
    }
}
