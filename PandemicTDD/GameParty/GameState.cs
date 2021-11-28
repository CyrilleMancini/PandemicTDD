using PandemicTDD.Actions;
using PandemicTDD.Events;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using System;
using System.Collections.Generic;

namespace PandemicTDD
{

    public class GameState : IChooseLevel
    {


        public readonly ActionsTurnHistory ActionsTurnHistory = new ActionsTurnHistory();
        
        public int ActionsRemaining { get; private set; }
        
        public Player CurrentPlayer { get => Players[CurrentPlayerIdx]; }

        internal Board Board { get; private set; }

        internal readonly DiseaseBags DiseaseBags;
        internal GameBox GameBox { get; private set; }

        internal List<Player> Players;

        private int CurrentPlayerIdx = 0;
        
        private readonly List<IObserveGameState> Observers = new();

        public GameState(List<Player> players,
            GameBox gameBox)
        {
            Players = players;
            GameBox = gameBox;
            Board = gameBox.GetBoard();
            DiseaseBags = gameBox.GetDiseaseBags();
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
                RunAction(action);
                RunAutomaticActions();
                if (ActionsRemaining == 0)
                    NextTurn();
                else
                    Action($"{ActionsRemaining} actions remains.");
            }
            catch (YouLooseException ex)
            {

            }
            catch (VictoryAllCuresDiscoveredException ex)
            {

            }
            catch (Exception ex)
            {
                Observers.ForEach(o => o.Error(ex.Message));
            }
        }

        private void RunAutomaticActions()
        {
            var AutoCleanWhenDisiseaseCured = new MedicAutomaticRemoveCuredDiseaseAction(this);
            AutoCleanWhenDisiseaseCured.Try();
            AutoCleanWhenDisiseaseCured.Execute();

        }

        private void RunAction(ActionBase action)
        {
            action.Try();
            action.Execute();
            ActionsTurnHistory.AddAction(action);
            if (action.ConsumeOneAction)
                ActionsRemaining--;
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
            ActionsTurnHistory.NextTurn();
            Action($"{CurrentPlayer.Name} can play now with {ActionsRemaining} actions");
        }

        public void ChooseLevel(Difficulty Level)
        {
            new EpidemicCardsInitRule().ExecuteRule(GameBox, Level);
            new PreparePlayerCardsStack().ExecuteRule(GameBox);
        }
    }

    public enum Difficulty
    {
        Discovery,
        Standard,
        Heroic
    }
}
