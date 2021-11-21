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


    }
}