using PandemicTDD.Materiel.BoardItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("PandemicTDDTests")]
namespace PandemicTDD.Materiel.Initializer
{
 public class TownSlotsInitializer
    {
        private readonly TownsInitializer TownInitializer;

        public TownSlotsInitializer(TownsInitializer townsInitializer)
        {
            this.TownInitializer = townsInitializer;
            InitTownSlots();
        }

        public List<TownSlot> TownSlots { get; private set; }

        private void InitTownSlots()
        {
            if (TownSlots == null)
            {
                TownSlots = new List<TownSlot>();
                foreach (Town town in TownInitializer.GetTowns())
                {
                    TownSlots.Add(new TownSlot(town));
                }
            }
        }

        internal void Link2Towns(TownsLink link)
        {
            TownSlot t1 = GetTownSlot(link.Town1);
            TownSlot t2 = GetTownSlot(link.Town2);
            t1.Links.Add(t2);
            t2.Links.Add(t1);
        }

        public TownSlot GetTownSlot(string townName)
        {
            try
            {
                TownSlot town = TownSlots.Single(it => it.Town.Name == townName);
                return town;
            }
            catch (InvalidOperationException Ex)
            {
                throw new UnkownTownException($"{townName} is unknown");
            }
        }

    }
}
