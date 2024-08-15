using System.Runtime.Serialization;

namespace PassportCardLabsAssignment.Policy
{
    [Serializable]
    internal class PolicyCreationException : Exception
    {
        public PolicyCreationException()
        {
        }

        public PolicyCreationException(string? message) : base(message)
        {
        }

        public PolicyCreationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PolicyCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}