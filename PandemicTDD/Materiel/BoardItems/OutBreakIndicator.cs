using System;

namespace PandemicTDD.Materiel
{
    public class OutBreakIndicator
    {
        public int Level { get; private set; }

        public void Reset()
        {
            Level = 0;
        }

        public void Next()
        {
            Level++;
            if (Level == 8)
                throw new YouLooseException("You Loose, The Maximum Outbreak has been reached!!!");
        }
    }
}