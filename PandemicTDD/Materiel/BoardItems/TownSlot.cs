using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class TownSlot
    {
        public Town Town { get; private set; }

        public List<TownSlot> Links { get; set; } = new List<TownSlot>();
        public ControlDiseaseCenter ControlDiseaseCenter { get; internal set; } = null;

        public TownSlot(Town town)
        {
            Town = town;
        }

        public override string ToString()
        {
            return $"{Town.Name} {Links.Count} liens";
        }
    }

    public class ControlDiseaseCenter
    {
    }
}