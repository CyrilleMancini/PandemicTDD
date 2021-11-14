using System;
using System.Runtime.Serialization;

namespace PandemicTDD
{
    [Serializable]
    internal class NotOwnedCityPlayerCardException : Exception
    {
        public NotOwnedCityPlayerCardException()
        {
        }

        public NotOwnedCityPlayerCardException(string message) : base(message)
        {
        }

        public NotOwnedCityPlayerCardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotOwnedCityPlayerCardException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}