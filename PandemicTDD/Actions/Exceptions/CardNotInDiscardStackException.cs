using System;

namespace PandemicTDD.Actions.Exceptions
{
    [Serializable]
    internal class CardNotInDiscardStackException : Exception
    {
        public CardNotInDiscardStackException(string message) : base(message)
        {
        }
    }
}