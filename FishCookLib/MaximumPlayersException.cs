using System;
using System.Runtime.Serialization;

namespace FishCookLib
{
    [Serializable]
    public class MaximumPlayersException : Exception
    {
        public MaximumPlayersException()
        {
        }

        public MaximumPlayersException(string message) : base(message)
        {
        }

        public MaximumPlayersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MaximumPlayersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}