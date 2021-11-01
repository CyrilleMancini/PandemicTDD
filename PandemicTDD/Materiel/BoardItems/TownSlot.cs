using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class TownSlot
    {
        public Town Town { get; private set; }

        public List<TownSlot> Links { get; set; } = new List<TownSlot>();

        public TownSlot(Town town)
        {
            Town = town;
        }

    }
}