using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("PandemicTDDTests")]
[assembly: InternalsVisibleTo("CommonTestsTools")]
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

        private readonly TownLinksInitializer TownLinksInitializer;

        private readonly GameInitializer GameInitializer;

        public GameBox(RoleCardInitializer roleCardInitializer,
            DiseaseBagsInitializer diseaseBagsInitializer,
            TownsInitializer TownsInitializer,
            SpreadCardInitializer SpreadCardInitializer,
            PlayerCardInitializer playerCardInitializer,
            TownSlotsInitializer townSlotsInitializer,
            TownLinksInitializer TownLinksInitializer,
            GameInitializer Initializer)
        {
            RoleCardInitializer = roleCardInitializer;
            DiseaseBagsInitializer = diseaseBagsInitializer;
            this.TownsInitializer = TownsInitializer;
            SpreadCardsInitializer = SpreadCardInitializer;
            PlayerCardsInitializer = playerCardInitializer;
            TownSlotsInitializer = townSlotsInitializer;
            this.TownLinksInitializer = TownLinksInitializer;
            this.GameInitializer = Initializer;
        }

        public void Reset()
        {
            Initialized = false;
            TownSlotsInitializer.Reset();
            TownsInitializer.Reset();
            RoleCardInitializer.Reset();
            PlayerCardsInitializer.Reset();
            DiseaseBagsInitializer.Reset();
            SpreadCardsInitializer.Reset();
            if (SingleBoard != null)
            {
                SingleBoard = null;
                GetInitializedBoard();
            }

        }

        Board SingleBoard = null;

        public Board GetBoard()
        {
            if (SingleBoard == null)
            {
                SingleBoard = new Board(TownsInitializer, TownSlotsInitializer, TownLinksInitializer);
            }

            return SingleBoard;
        }

        private void InitFirstCDCInAtlanta()
        {
            TownSlot Atlanta = SingleBoard.GetTownSlot(TownsInitializer.Atlanta);
            Atlanta.BuildStation();
        }

        bool Initialized = false;
        public Board GetInitializedBoard()
        {
            if (Initialized) return SingleBoard;
            GetBoard();
            InitFirstCDCInAtlanta();
            DiseaseBagsInitializer.Reset();

            GameInitializer.InitGame(this);

            Initialized = true;
            return SingleBoard;
        }



        public List<RoleCard> GetRoles() => RoleCardInitializer.InitCards();

        public DiseaseBags GetDiseaseBags() => DiseaseBagsInitializer.InitBags();

        public List<SpreadCard> GetSpeadCards() => SpreadCardsInitializer.InitCards(GetBoard());

        public List<PlayerCard> GetPlayersCard() => PlayerCardsInitializer.InitCards(GetBoard());

    }


}