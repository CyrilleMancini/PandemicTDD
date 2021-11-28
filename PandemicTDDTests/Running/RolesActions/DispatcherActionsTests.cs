using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public partial class DispatcherActionsTests : TestsBase
    {
        [TestInitialize()]
        public void InitPlayer()
        {
            StartGame();
            Players[0].Role = new DispatcherRoleCard("Répartiteur");
            Players[1].Role = new ResearcherRoleCard("Chercheur");
            Players[2].Role = new UndefRoleCard("Undef");
        }

        [TestMethod]
        public void MoveAnotherPlayerAsHisMustBeAnotherPlayer()
        {
            ActionBase action = new DispatcherMoveAnotherPlayerByDriverFerryAsHisAction(GameState, Players[0], TownsInitializer.Chicago);

            Assert.ThrowsException<InvalidPreconditionsException>(() =>
            {
                action.Try();
            });
            Assert.AreEqual(TownsInitializer.Atlanta, Players[0].Town.Name);
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }

        [TestMethod]
        public void MoveAnotherPlayerAsHisByDriveFerry()
        {
            ActionBase action = new DispatcherMoveAnotherPlayerByDriverFerryAsHisAction(GameState, Players[1], TownsInitializer.Chicago);

            GameState.DoAction(action);

            Assert.AreEqual(TownsInitializer.Chicago, Players[1].Town.Name);
            Assert.AreEqual(3, GameState.ActionsRemaining);
        }

        [TestMethod]
        public void MoveAnotherPlayerAsHisByCDDShuttlePlayerMustBeDifferent()
        {
            ActionBase action = new DispatcherMoveAnotherPlayerByShuttleAsHis(GameState, Players[0], TownsInitializer.Chicago);
            Assert.ThrowsException<InvalidPreconditionsException>(() =>
            {
                action.Try();
            });
        }

        [TestMethod]
        public void MoveAnotherPlayerAsHisByCDDShuttle()
        {
            ActionBase action = new DispatcherMoveAnotherPlayerByShuttleAsHis(GameState, Players[1], TownsInitializer.Paris);
            GameState.Board.GetTownSlot(TownsInitializer.Paris).BuildStation();

            GameState.DoAction(action);

            Assert.AreEqual(TownsInitializer.Paris, Players[1].Town.Name);
            Assert.AreEqual(3, GameState.ActionsRemaining);
        }


        [TestMethod]
        public void MoveAnotherPlayerAsHisByDirectFlightFailsCauseNoDestinationCard()
        {
            ActionBase action = new DispatcherMoveAnotherPlayerByDirectFlightAsHisAction(GameState, Players[1], TownsInitializer.Paris);
            GameState.CurrentPlayer.PlayerCards.Clear();

            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                action.Try();
            });

            Assert.AreEqual(TownsInitializer.Atlanta, Players[1].Town.Name);
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }

        [TestMethod]
        public void MoveAnotherPlayerAsHisByCharterFlightFailsCauseNoOrigineCard()
        {
            ActionBase action = new DispatcherMoveAnotherPlayerByCharterFlightAsHisAction(GameState, Players[1], TownsInitializer.Paris);

            GameState.CurrentPlayer.PlayerCards.Clear();
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                action.Try();
            });

            Assert.AreEqual(TownsInitializer.Atlanta, Players[1].Town.Name);
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }


        [TestMethod]
        public void MoveAnotherPlayerAsHisByDirectFlightSuccess()
        {

            GameState.CurrentPlayer.PlayerCards.Clear();
            PlayerTownCard DestCard = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard tc && tc.Town.Name != TownsInitializer.Atlanta);
            GameState.CurrentPlayer.PlayerCards.Add(DestCard);

            ActionBase action = new DispatcherMoveAnotherPlayerByDirectFlightAsHisAction(GameState, Players[1], DestCard.Town.Name);
            GameState.DoAction(action);

            Assert.AreEqual(DestCard.Town.Name, Players[1].Town.Name);
            Assert.AreEqual(3, GameState.ActionsRemaining);
            Assert.AreEqual(DestCard, GameState.Board.PlayerDiscardCardStack.Peek());

        }

        [TestMethod]
        public void MoveAnotherPlayerAsHisByCharterFlightSuccess()
        {

            GameState.CurrentPlayer.PlayerCards.Clear();
            var OrigineCard = GameBox.GetPlayersCard().First(c => c is PlayerTownCard tc && tc.Town.Name == Players[1].Town.Name);
            GameState.CurrentPlayer.PlayerCards.Add(OrigineCard);


            ActionBase action = new DispatcherMoveAnotherPlayerByCharterFlightAsHisAction(GameState, Players[1], TownsInitializer.Paris);
            GameState.DoAction(action);



            Assert.AreEqual(TownsInitializer.Paris, Players[1].Town.Name);
            Assert.AreEqual(3, GameState.ActionsRemaining);
        }




        [TestMethod]
        public void MoveAnotherPlayerToAnAntoherPlayerTownFailsBecauseSamePlayer()
        {
            ActionBase action = new DispatcherMovePlayerToAnotherPlayer(GameState, Players[1], Players[1]);

            Assert.ThrowsException<InvalidPreconditionsException>(() =>
            {
                action.Try();
            });

            Assert.AreEqual(TownsInitializer.Atlanta, Players[1].Town.Name);
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }

        [TestMethod]
        public void MoveAnotherPlayerToAnAntoherPlayerTown()
        {
            Players[1].Role = new ResearcherRoleCard("Chercheur");
            Players[2].Town = GameState.Board.GetTown(TownsInitializer.Paris);
            ActionBase action = new DispatcherMovePlayerToAnotherPlayer(GameState, Players[1], Players[2]);

            GameState.DoAction(action);

            Assert.AreEqual(TownsInitializer.Paris, Players[1].Town.Name);
            Assert.AreEqual(Players[2].Town.Name, Players[1].Town.Name);
            Assert.AreEqual(3, GameState.ActionsRemaining);
        }

    }
}