using PandemicTDD.Materiel.PlayerCards;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Initializers
{
    public class PlayerCardInitializer
    {
        static List<PlayerCard> SinglePlayerCards = null;
        private readonly AirLiftEventCard airLiftEventCard;
        private readonly CalmNigthEventCard calmNigthEventCard;
        private readonly ResilientPopulationEventCard resilientPopulationEventCard;
        private readonly ForcastEventCard forcastEventCard;
        private readonly PublicSubventionEventCard publicSubventionEventCard;

        public PlayerCardInitializer(AirLiftEventCard AirLiftEventCard, CalmNigthEventCard CalmNigthEventCard,
            ResilientPopulationEventCard ResilientPopulationEventCard, ForcastEventCard ForcastEventCard, PublicSubventionEventCard PublicSubventionEventCard)
        {
            airLiftEventCard = AirLiftEventCard;
            calmNigthEventCard = CalmNigthEventCard;
            resilientPopulationEventCard = ResilientPopulationEventCard;
            forcastEventCard = ForcastEventCard;
            publicSubventionEventCard = PublicSubventionEventCard;
        }

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
                SinglePlayerCards.Add(airLiftEventCard);
                SinglePlayerCards.Add(calmNigthEventCard);
                SinglePlayerCards.Add(resilientPopulationEventCard);
                SinglePlayerCards.Add(forcastEventCard);
                SinglePlayerCards.Add(publicSubventionEventCard);
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