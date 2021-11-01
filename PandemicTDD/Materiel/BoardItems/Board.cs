﻿using PandemicTDD.Materiel.BoardItems;
using PandemicTDD.Materiel.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDD.Materiel
{
    public class Board
    {
        public List<Town> Towns { get; private set; }

        private readonly TownsInitializer TownInitializer;

        private CureSlots SinglelCureSlots;

        private HatchingIndicator HatchingIndicator;

        private SpreadIndicator SingleSpreadIndicator;

        private readonly TownSlotsInitializer TownSlotsInitializer;

        public Board(TownsInitializer initializer, TownSlotsInitializer townSlotsInitializer)
        {
            this.TownInitializer = initializer;
            TownSlotsInitializer = townSlotsInitializer;
            Towns = TownInitializer.GetTowns();
        }

        public List<TownSlot> GetTownSlots() => TownSlotsInitializer.TownSlots;

        public void Link2Towns(TownsLink link) => TownSlotsInitializer.Link2Towns(link);

        public CureSlots GetCureSlots()
        {
            if (SinglelCureSlots == null)
                SinglelCureSlots = new CureSlots();

            return SinglelCureSlots;
        }

        public HatchingIndicator GetHatchingIndicator()
        {
            if (HatchingIndicator == null)
                HatchingIndicator = new HatchingIndicator();

            return HatchingIndicator;

        }

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