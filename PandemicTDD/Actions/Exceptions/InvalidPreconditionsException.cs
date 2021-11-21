using System;

namespace PandemicTDD.Actions.Exceptions
{
    internal class InvalidPreconditionsException : Exception
    {
        public InvalidPreconditionsException(string message) : base(message)
        {
        }
    }

}