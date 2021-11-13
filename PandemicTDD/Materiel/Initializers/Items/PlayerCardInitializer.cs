using PandemicTDD.Materiel.PlayerCards;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializers
{
    public class PlayerCardInitializer
    {
        static List<PlayerCard> SinglePlayerCards = null;

        internal List<PlayerCard> InitCards(Board board)
        {
            if (SinglePlayerCards == null)
            {
                SinglePlayerCards = new List<PlayerCard>();

                foreach (Town town in board.Towns)
                    SinglePlayerCards.Add(new PlayerTownCard(town));

                for (int i = 0; i < 6; i++)
                    SinglePlayerCards.Add(new EpidemicPlayerCard());

                // Add Event Card
                SinglePlayerCards.Add(new AirLiftEventCard());
                SinglePlayerCards.Add(new CalmNigthEventCard());
                SinglePlayerCards.Add(new ResilientPopulationEventCard());
                SinglePlayerCards.Add(new ForcastEventCard());
                SinglePlayerCards.Add(new PublicSubventionEventCard());
            }
            return SinglePlayerCards;
        }

        public void Reset()
        {
            if (SinglePlayerCards == null) return;
            SinglePlayerCards.Clear();
            SinglePlayerCards = null;
        }

    }
}