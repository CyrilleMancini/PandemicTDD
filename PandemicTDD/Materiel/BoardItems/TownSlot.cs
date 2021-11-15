using System;
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

        public override string ToString()
        {
            return $"{Town.Name} {Links.Count} liens";
        }

        internal bool HasSearchStation { get => Town.ControlDiseaseCenter != null; }


        internal void BuildStation()
        {
            if (Town.HasSearchStation) throw new ArgumentException($"Station already build on {Town.Name}");

            Town.ControlDiseaseCenter = new ControlDiseaseCenter();
        }


    }
}