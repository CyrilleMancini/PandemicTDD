using System;
using System.Collections.Generic;

namespace PandemicTDD.Tools
{
    public class ListShuffler
    {
        public ListShuffler()
        {
        }

        Random rnd = new Random(Guid.NewGuid().GetHashCode());

        internal List<T> Shuffle<T>(List<T> list)
        {
            List<T> shuffled = new List<T>();
            while (list.Count != 0)
            {
                int idx = rnd.Next(0, list.Count);
                shuffled.Add(list[idx]);
                list.RemoveAt(idx);
            }
            return shuffled;
        }
    }
}