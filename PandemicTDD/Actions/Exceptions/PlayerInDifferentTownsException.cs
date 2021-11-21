using System;
using System.Runtime.Serialization;

namespace PandemicTDD.Actions.Exceptions
{
    [Serializable]
    internal class PlayerInDifferentTownsException : Exception
    {
        public PlayerInDifferentTownsException()
        {
        }

        public PlayerInDifferentTownsException(string message) : base(message)
        {
        }

        public PlayerInDifferentTownsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayerInDifferentTownsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
