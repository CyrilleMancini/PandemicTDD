using PandemicTDD.Materiel.Initializer;
using PandemicTDD.Materiel.PlayerCards;
using System.Collections.Generic;

namespace PandemicTDD.Materiel
{
    public class GameBox
    {
        private readonly RoleCardInitializer RoleCardInitializer;

        private readonly DiseaseBagsInitializer DiseaseBagsInitializer;

        private readonly TownsInitializer TownsInitializer;

        private readonly SpreadCardInitializer SpreadCardsInitializer;

        private readonly PlayerCardInitializer PlayerCardsInitializer;

        private readonly TownSlotsInitializer TownSlotsInitializer;

        public GameBox(RoleCardInitializer roleCardInitializer,
            DiseaseBagsInitializer diseaseBagsInitializer,
            TownsInitializer TownsInitializer,
            SpreadCardInitializer SpreadCardInitializer,
            PlayerCardInitializer playerCardInitializer,
            TownSlotsInitializer townSlotsInitializer)
        {
            RoleCardInitializer = roleCardInitializer;
            DiseaseBagsInitializer = diseaseBagsInitializer;
            this.TownsInitializer = TownsInitializer;
            SpreadCardsInitializer = SpreadCardInitializer;
            PlayerCardsInitializer = playerCardInitializer;
            TownSlotsInitializer = townSlotsInitializer;
        }


        Board SingleBoard = null;

        public Board GetBoard()
        {
            if (SingleBoard == null)
                SingleBoard = new Board(TownsInitializer, TownSlotsInitializer);

            return SingleBoard;
        }

        public List<RoleCard> GetRoles() => RoleCardInitializer.InitCards();

        public DiseaseBags GetDiseaseBags() => DiseaseBagsInitializer.InitBags();

        public List<SpreadCard> GetSpeadCards() => SpreadCardsInitializer.InitCards(GetBoard());

        public List<PlayerCard> GetPlayersCard() => PlayerCardsInitializer.InitCards(GetBoard());

    }
}