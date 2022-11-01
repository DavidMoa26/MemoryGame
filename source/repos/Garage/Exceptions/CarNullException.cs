using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    internal class CarNullException : Exception
    {
        public CarNullException()
        {
        }

        public CarNullException(string? message) : base(message)
        {
        }

        public CarNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CarNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}