using System;

namespace PandemicTDD.Actions.Exceptions
{
    internal class InvalidActionException : Exception
    {
        public InvalidActionException(string message) : base(message)
        {
        }
    }
}