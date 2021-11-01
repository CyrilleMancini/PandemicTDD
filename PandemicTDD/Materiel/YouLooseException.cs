using System;
using System.Runtime.Serialization;

namespace PandemicTDD.Materiel
{
    [Serializable]
    public class YouLooseException : Exception
    {
        public YouLooseException()
        {
        }

        public YouLooseException(string message) : base(message)
        {
        }

        public YouLooseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected YouLooseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}