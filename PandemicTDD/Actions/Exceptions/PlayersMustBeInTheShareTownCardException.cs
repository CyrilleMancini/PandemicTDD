using System;
using System.Runtime.Serialization;

namespace PandemicTDD.Actions.Exceptions
{
    [Serializable]
    internal class PlayersMustBeInTheShareTownCardException : Exception
    {
        public PlayersMustBeInTheShareTownCardException()
        {
        }

        public PlayersMustBeInTheShareTownCardException(string message) : base(message)
        {
        }

        public PlayersMustBeInTheShareTownCardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayersMustBeInTheShareTownCardException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}