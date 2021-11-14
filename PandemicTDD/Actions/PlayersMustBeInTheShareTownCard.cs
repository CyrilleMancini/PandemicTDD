using System;
using System.Runtime.Serialization;

namespace PandemicTDDTests.Running.Actions
{
    [Serializable]
    internal class PlayersMustBeInTheShareTownCard : Exception
    {
        public PlayersMustBeInTheShareTownCard()
        {
        }

        public PlayersMustBeInTheShareTownCard(string message) : base(message)
        {
        }

        public PlayersMustBeInTheShareTownCard(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayersMustBeInTheShareTownCard(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}