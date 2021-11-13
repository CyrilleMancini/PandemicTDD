using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDD.Materiel
{
    internal class DistributePlayerCards
    {
        public DistributePlayerCards()
        {
        }

        Random r = new Random(Guid.NewGuid().GetHashCode());
        internal void ExecuteRule(GameBox gameBox, List<Player> players)
        {
            int nbCards = 0;
            switch (players.Count)
            {
                case 2:
                    nbCards = 4;
                    break;
                case 3:
                    nbCards = 3;
                    break;
                case 4:
                    nbCards = 2;
                    break;
                default:
                    throw new ArgumentException("Invalid Player number.");
            }

            List<PlayerCard> PlayerCardsWithoutEpidemic = gameBox.GetPlayersCard()
                                                    .Where(c => !(c is EpidemicPlayerCard))
                                                    .ToList();

            foreach (Player p in players)
            {
                for (int numCard = 0; numCard < nbCards; numCard++)
                {
                    int pCardIndex = r.Next(0, PlayerCardsWithoutEpidemic.Count);
                    PlayerCard card = PlayerCardsWithoutEpidemic[pCardIndex];
                    gameBox.GetPlayersCard().Remove(card);
                    p.PlayerCards.Add(card);
                }
            }
        }
    }
}