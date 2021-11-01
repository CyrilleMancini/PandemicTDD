using System;

namespace PandemicTDD.Materiel
{
    public class SpreadIndicator
    {
        public int CurrentLevel { get; set; }

        public int SpreadSpeed
        {
            get
            {
                return Levels[CurrentLevel - 1];
            }
        }

        int[] Levels = new[] { 2, 2, 2, 3, 3, 4, 4 };

        public SpreadIndicator()
        {
            CurrentLevel = 1;
        }

        public void Next()
        {
            CurrentLevel++;
        }

        public void Reset()
        {
            CurrentLevel = 1;
        }
    }
}