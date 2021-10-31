using System;

namespace PandemicTDD.Materiel
{
    public class UnkownTownException : Exception
    {
        public UnkownTownException(string message) : base(message)
        {
        }
    }
}