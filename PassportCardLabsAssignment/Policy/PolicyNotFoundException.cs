using System.Runtime.Serialization;

namespace PassportCardLabsAssignment.Policy
{
    [Serializable]
    internal class PolicyNotFoundException : Exception
    {
        public PolicyNotFoundException()
        {
        }

        public PolicyNotFoundException(string? message) : base(message)
        {
        }

        public PolicyNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PolicyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}