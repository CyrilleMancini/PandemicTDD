using System;

namespace PandemicTDD.Actions.Exceptions
{
    internal class ActionCanBeDoneOnlyOncePerTurn : Exception
    {
        public ActionCanBeDoneOnlyOncePerTurn(string message) : base(message)
        {
        }
    }

}