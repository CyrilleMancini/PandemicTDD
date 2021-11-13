using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDD.Materiel
{
    internal class EpidemicCardsInitRule
    {
        public EpidemicCardsInitRule()
        {
        }

        internal void ExecuteRule(GameBox gameBox, Difficulty Level)
        {

            List<PlayerCard> epidemics = gameBox.GetPlayersCard().Where(c => c is EpidemicPlayerCard).ToList();

            switch (Level)
            {
                case Difficulty.Discovery:
                    // Remove 
                    gameBox.GetPlayersCard().Remove(epidemics[0]);
                    gameBox.GetPlayersCard().Remove(epidemics[1]);
                    break;
                case Difficulty.Standard:
                    gameBox.GetPlayersCard().Remove(epidemics[0]);
                    break;
                case Difficulty.Heroic:
                    break;
                default:
                    break;
            }
        }
    }
}