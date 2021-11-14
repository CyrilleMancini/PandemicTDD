using System;

namespace PandemicTDD
{
    internal class TooManyPlayersException : Exception
    {
        public TooManyPlayersException(string message) : base(message)
        {
        }
    }
    internal class NotEnoughPlayersException : Exception
    {
        public NotEnoughPlayersException(string message) : base(message)
        {
        }
    }
}