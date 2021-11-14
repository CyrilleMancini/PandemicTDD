using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using System;
using System.Collections.Generic;

namespace PandemicTDD
{

    public class GameState : IChooseLevel
    {

        internal List<Player> Players;

        public Player CurrentPlayer { get => Players[CurrentPlayerIdx]; }

        public int ActionsRemaining { get; internal set; }

        private int CurrentPlayerIdx = 0;

        internal GameBox GameBox { get; private set; }

        internal Board Board { get; private set; }

        internal readonly DiseaseBags DiseaseBags;

        private readonly List<IObserveGameState> Observers = new List<IObserveGameState>();


        public GameState(List<Player> players,
            GameBox gameBox)
        {
            Players = players;
            this.GameBox = gameBox;
            this.Board = gameBox.GetBoard();
            this.DiseaseBags = gameBox.GetDiseaseBags();
        }

        internal void Result(string message)
        {
            Observers.ForEach(o => o.Result(message));
        }
        internal void Error(string message)
        {
            Observers.ForEach(o => o.Error(message));
        }
        internal void Action(string message)
        {
            Observers.ForEach(o => o.Action(message));
        }

        internal IChooseLevel StartGame()
        {
            if (Players.Count < 2) throw new NotEnoughPlayersException("Minimum 2 players");
            if (Players.Count > 4) throw new TooManyPlayersException("No more than 4 players");

            Players.ForEach(p => p.Town = Board.GetTown(TownsInitializer.Atlanta));
            CurrentPlayerIdx = 0;
            ActionsRemaining = 4;
            GameBox.Reset();

            new DistributeRolesRule().ExecuteRule(GameBox, Players);
            new DistributePlayerCards().ExecuteRule(GameBox, Players);



            return this;
        }

        internal void DoAction(ActionBase action)
        {

            try
            {
                action.Try();
                action.Execute();
                ActionsRemaining--;
                if (ActionsRemaining == 0)
                    NextTurn();
                else
                    Action($"{ActionsRemaining} actions remains.");
            }
            catch (System.Exception ex)
            {
                Observers.ForEach(o => o.Error(ex.Message));
            }
        }

        internal void RegisterObserver(IObserveGameState observer)
        {
            if (Observers.Contains(observer)) throw new ArgumentException("Observer already registered");
            Observers.Add(observer);
        }

        internal void NextTurn()
        {
            CurrentPlayerIdx = (++CurrentPlayerIdx) % Players.Count;
            ActionsRemaining = 4;
            Action($"{CurrentPlayer.Name} can play now with {ActionsRemaining} actions");
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
