using System;
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

        internal void BuildStation()
        {
            if (ControlDiseaseCenter != null) throw new ArgumentException($"Station already build on {Town.Name}");

            ControlDiseaseCenter = new ControlDiseaseCenter();
        }


    }
}