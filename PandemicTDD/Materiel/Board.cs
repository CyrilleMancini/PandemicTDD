using PandemicTDD.Materiel.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDD.Materiel
{
    public class Board
    {
        private readonly TownsInitializer initializer;

        public Board(TownsInitializer initializer)
        {
            this.initializer = initializer;
            InitTowns();
        }

        private void InitTowns()
        {
            Towns = initializer.InitTowns();
        }

        SpreadIndicator SingleSpreadIndicator { get; set; }
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

        public List<Town> Towns { get; private set; }


    }
}