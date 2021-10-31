using System;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class Board
    {
        public Board()
        {
            InitTowns();
        }

        private void InitTowns()
        {
            Towns = new List<Town>() {
            new Town(), new Town(), new Town(), new Town(), new Town(), new Town(), new Town(),
            new Town(), new Town(), new Town(), new Town(), new Town(), new Town(), new Town(),
            new Town(), new Town(), new Town(), new Town(), new Town(), new Town(), new Town(),
            new Town(), new Town(), new Town(), new Town(), new Town(), new Town(), new Town(),
            new Town(), new Town(), new Town(), new Town(), new Town(), new Town(), new Town(),
            new Town(), new Town(), new Town(), new Town(), new Town(), new Town(), new Town(),
            new Town(), new Town(), new Town(), new Town(), new Town(), new Town(),

            };
        }

        public List<Town> Towns { get; private set; }
    }
}