using PandemicTDD.Materiel.BoardItems;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDD.Materiel
{
    public class Board
    {
        public List<Town> Towns { get; private set; }

        public Stack<SpreadCard> SpreadStack { get; internal set; } = new Stack<SpreadCard>();

        public Stack<SpreadCard> SpreadDiscardStack { get; internal set; } = new Stack<SpreadCard>();

        public Stack<PlayerCard> PlayerCardStack { get; internal set; } = new Stack<PlayerCard>();

        public Stack<PlayerCard> PlayerDiscardCardStack { get; internal set; } = new Stack<PlayerCard>();

        private readonly TownsInitializer TownInitializer;

        private CureSlots SinglelCureSlots;

        private OutBreakIndicator HatchingIndicator;

        private SpreadIndicator SingleSpreadIndicator;

        private readonly TownSlotsInitializer TownSlotsInitializer;
        private readonly TownLinksInitializer TownLinksInitializer;

        public Board(TownsInitializer townInitializer,
            TownSlotsInitializer townSlotsInitializer,
            TownLinksInitializer townLinksInitializer)
        {
            TownInitializer = townInitializer;
            TownSlotsInitializer = townSlotsInitializer;
            TownLinksInitializer = townLinksInitializer;
            InitTowns();
        }

        private void InitTowns()
        {
            Towns = TownInitializer.GetTowns();
            TownLinksInitializer.InitTownsLinks(this);
        }

        public List<TownSlot> GetTownSlots() => TownSlotsInitializer.TownSlots;

        public void Link2Towns(TownsLink link) => TownSlotsInitializer.Link2Towns(link);

        public CureSlots GetCureSlots()
        {
            if (SinglelCureSlots == null)
                SinglelCureSlots = new CureSlots();

            return SinglelCureSlots;
        }

        public OutBreakIndicator GetOutbreakIndicator()
        {
            if (HatchingIndicator == null)
                HatchingIndicator = new OutBreakIndicator();

            return HatchingIndicator;

        }

        public TownSlot GetTownSlot(Town town) => GetTownSlot(town.Name);

        public TownSlot GetTownSlot(string townName) => TownSlotsInitializer.GetTownSlot(townName);

        public SpreadIndicator GetSpreadIndicator()
        {
            if (SingleSpreadIndicator == null)
                SingleSpreadIndicator = new SpreadIndicator(); ;
            return SingleSpreadIndicator;
        }

        public Town GetTown(Town search)
        {
            try
            {
                Town town = Towns.Single(it => it == search);
                return town;
            }
            catch (InvalidOperationException Ex)
            {
                throw new UnkownTownException($"{search.Name} is unknown");
            }
        }

        public Town GetTown(string townName)
        {
            try
            {
                Town town = Towns.Single(it => it.Name == townName);
                return town;
            }
            catch (InvalidOperationException Ex)
            {
                throw new UnkownTownException($"{townName} is unknown");
            }
        }

    }
}