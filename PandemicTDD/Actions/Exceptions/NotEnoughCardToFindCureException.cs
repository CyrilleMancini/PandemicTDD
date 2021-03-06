using System;
using System.Runtime.Serialization;

namespace PandemicTDD.Actions.Exceptions
{
    internal class NotEnoughCardToFindCureException : Exception
    {
        public NotEnoughCardToFindCureException()
        {
        }

        public NotEnoughCardToFindCureException(string message) : base(message)
        {
        }

        public NotEnoughCardToFindCureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotEnoughCardToFindCureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}