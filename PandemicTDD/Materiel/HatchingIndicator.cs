using System;

namespace PandemicTDD.Materiel
{
    public class HatchingIndicator
    {
        public int Level { get; private set; }

        public void Reset()
        {
            Level = 0;
        }

        public void Next()
        {
            Level++;
        }
    }
}