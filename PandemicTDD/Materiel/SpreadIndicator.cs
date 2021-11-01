using System;

namespace PandemicTDD.Materiel
{
    public class SpreadIndicator
    {
        public int CurrentLevel { get; set; }
        
        public int SpreadSpeed { get; set; }

        public SpreadIndicator()
        {
            CurrentLevel = 1;
            SpreadSpeed = 2;
        }

        public void Next()
        {
            CurrentLevel++;
        }
    }
}