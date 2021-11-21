using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;

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
    }
}