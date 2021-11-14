using System;

namespace PandemicTDDTests.Running.Actions
{
    internal class InvalidActionException : Exception
    {
        public InvalidActionException(string message) : base(message)
        {
        }
    }
}