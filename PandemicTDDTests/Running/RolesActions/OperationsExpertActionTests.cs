using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class OperationsExpertActionTests : TestsBase
    {
        [TestMethod()]
        public void OperationExpertBuildWihtoutDiscad()
        {
            StartGame();

            Players[0].Role = new OperationExpertRoleCard("Expert au Opérations");
            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Londres).Town;

            ActionBase action = new OperationsExpertBuildStationAction(GameState);
            GameState.DoAction(action);
            Assert.IsTrue(GameState.CurrentPlayer.Town.HasSearchStation);
            Assert.AreEqual(null, ConsoleObserver.LastErrorReceived);
            Assert.AreEqual(3, GameState.ActionsRemaining);

        }

        [TestMethod()]
        public void OperationExpertBuildWihtoutDiscardFailIfStationAlreadyBuild()
        {
            StartGame();

            Players[0].Role = new OperationExpertRoleCard("Expert au Opérations");
            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Atlanta).Town;

            ActionBase action = new OperationsExpertBuildStationAction(GameState);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                action.Try();
            });
            Assert.IsNotNull(ConsoleObserver.LastErrorReceived);
            Assert.AreEqual(4, GameState.ActionsRemaining);

        }


        [TestMethod()]
        public void OperationExpertMoveFromStationMustHaveStation()
        {
            StartGame();

            Players[0].Role = new OperationExpertRoleCard("Expert au Opérations");
            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Londres).Town;

            PlayerTownCard Discarded = (PlayerTownCard)Players[0].PlayerCards.First(c => c is PlayerTownCard);
            ActionBase action = new OperationExpertMoveFromStationToAnyTownAction(GameState, TownsInitializer.Paris, Discarded);
            Assert.ThrowsException<CityWithoutControlCenterException>(() =>
            {
                action.Try();
            });

            Assert.AreEqual(4, GameState.ActionsRemaining);
        }

        [TestMethod()]
        public void OperationExpertMoveFromStationToAnyCity()
        {
            StartGame();
            Players[0].Role = new OperationExpertRoleCard("Expert au Opérations");
            Players[0].Town = GameState.Board.GetTownSlot(TownsInitializer.Atlanta).Town;
            PlayerTownCard Discarded = (PlayerTownCard)Players[0].PlayerCards.First(c => c is PlayerTownCard);
            ActionBase action = new OperationExpertMoveFromStationToAnyTownAction(GameState, TownsInitializer.Paris, Discarded);

            GameState.DoAction(action);

            Assert.AreEqual(TownsInitializer.Paris, GameState.CurrentPlayer.Town.Name);
            Assert.AreEqual(4, GameState.ActionsRemaining); // Ne consomme pas d'action a la réalisation.
            Assert.AreEqual(Discarded, GameState.Board.PlayerDiscardCardStack.Peek());
        }
        }
    }
}