using PandemicTDD.Materiel.Initializer;
using PandemicTDD.Materiel.PlayerCards;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class GameBox
    {
        private static RoleCardInitializer RoleCardInitializer;
        private static DiseaseBagsInitializer DiseaseBagsInitializer;
        private static TownsInitializer TownsInitializer;
        private static SpreadCardInitializer SpreadCardsInitializer;
        private static PlayerCardInitializer PlayerCardsInitializer;

        public GameBox(RoleCardInitializer roleCardInitializer,
            DiseaseBagsInitializer diseaseBagsInitializer,
            TownsInitializer TownsInitializer,
            SpreadCardInitializer SpreadCardInitializer,
            PlayerCardInitializer playerCardInitializer)
        {
            RoleCardInitializer = roleCardInitializer;
            DiseaseBagsInitializer = diseaseBagsInitializer;
            GameBox.TownsInitializer = TownsInitializer;
            SpreadCardsInitializer = SpreadCardInitializer;
            PlayerCardsInitializer = playerCardInitializer;
        }


        Board SingleBoard = null;

        public Board GetBoard()
        {
            if (SingleBoard == null)
                SingleBoard = new Board(TownsInitializer);

            return SingleBoard;
        }

        public List<RoleCard> GetRoles() => RoleCardInitializer.InitCards();

        public DiseaseBags GetDiseaseBags() => DiseaseBagsInitializer.InitBags();

        public List<SpreadCard> GetSpeadCards() => SpreadCardsInitializer.InitCards(GetBoard());

        public List<PlayerCard> GetPlayersCard() => PlayerCardsInitializer.InitCards(GetBoard());

    }
}