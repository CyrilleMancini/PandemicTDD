using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDD
{
    public class Player
    {
        public string Name { get; set; }

        public RoleCard Role { get; set; } = null;

        public List<PlayerCard> PlayerCards { get; internal set; } = new List<PlayerCard>();

        public Town Town { get; internal set; }

        internal PlayerCard GetCityPlayerCard(string cityName)
        {
            try
            {
                return PlayerCards.First(c => c is PlayerTownCard ct && ct.Town.Name == cityName);
            }
            catch (Exception ex)
            {
                throw new NotOwnedCityPlayerCardException();
            }
        }
    }
}