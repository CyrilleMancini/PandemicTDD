using System;

namespace PandemicTDD.Actions.Exceptions
{
    internal class CityWithoutControlCenterException : Exception

    {
        public CityWithoutControlCenterException(string message) : base(message)
        {
        }
    }
}