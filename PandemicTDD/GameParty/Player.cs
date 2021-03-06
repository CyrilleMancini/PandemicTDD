using PandemicTDD.Actions.Exceptions;
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

        internal T GetCityPlayerCard<T>(string cityName) where T : PlayerCard
        {
            try
            {
                return (T)PlayerCards.First(c => c is PlayerTownCard ct && ct.Town.Name == cityName);
            }
            catch (Exception)
            {
                throw new NotOwnedCityPlayerCardException();
            }
        }

        internal PlayerTownCard DiscardCardTown(string cityName)
        {
            try
            {
                var delete = PlayerCards.First(c => c is PlayerTownCard ct && ct.Town.Name == cityName);
                PlayerCards.Remove(delete);
                return (PlayerTownCard)delete;
            }
            catch (Exception)
            {
                throw new NotOwnedCityPlayerCardException();
            }
        }

        public PlayerTownCard[] GetCityCards()
        {
            return PlayerCards.Where(c => c is PlayerTownCard)
                            .Select(c => c as PlayerTownCard)
                            .ToArray();
        }
    }
}