using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using System.Collections.Generic;

namespace PandemicTDD
{
    public class GameState : IChooseLevel
    {

        public List<Player> Players;
        private readonly GameBox GameBox;
        private readonly Board Board;
        private readonly DiseaseBags DiseaseBags;

        public GameState(List<Player> players, GameBox gameBox)
        {
            Players = players;
            this.GameBox = gameBox;
            this.Board = gameBox.GetBoard();
            this.DiseaseBags = gameBox.GetDiseaseBags();

        }


        internal IChooseLevel StartGame()
        {
            if (Players.Count < 2) throw new NotEnoughPlayersException("Minimum 2 players");
            if (Players.Count > 4) throw new TooManyPlayersException("No more than 4 players");

            Players.ForEach(p => p.Town = Board.GetTown(TownsInitializer.Atlanta));

            GameBox.Reset();

            var distribute = new DistributeRolesRule();
            distribute.ExecuteRule(GameBox, Players);

            var distributePlayerCards = new DistributePlayerCards();
            distributePlayerCards.ExecuteRule(GameBox, Players);

            return this;
        }

        public void ChooseLevel(Difficulty Level)
        {
            new EpidemicCardsInitRule().ExecuteRule(GameBox, Level);
            new PreparePlayerCardsStack().ExecuteRule(GameBox);

        }

    }

    internal interface IChooseLevel
    {
        void ChooseLevel(Difficulty difficulty);
    }

    public enum Difficulty
    {
        Discovery,
        Standard,
        Heroic
    }
}
