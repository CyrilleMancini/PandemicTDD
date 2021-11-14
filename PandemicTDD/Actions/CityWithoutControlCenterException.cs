using System;

namespace PandemicTDD.Actions
{
    internal class CityWithoutControlCenterException : Exception

    {
        public CityWithoutControlCenterException(string message) : base(message)
        {
        }
    }
}