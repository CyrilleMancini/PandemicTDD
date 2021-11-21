using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel.Initializers;
using PandemicTDDTests.Materiel;

namespace PandemicTDDTests.Running.Actions
{


    [TestClass]
    public class DriveFerryActionTest : TestsBase
    {

        [TestMethod]
        public void MovePlayerTestToUnLinkedTown()
        {
            GameState.StartGame()
                        .ChooseLevel(Difficulty.Discovery);

            ActionBase action = new DriveFerryAction(GameState, GameState.CurrentPlayer, TownsInitializer.Paris);
            GameState.DoAction(action);
            Assert.AreEqual(4, GameState.ActionsRemaining);
            Assert.AreEqual(DriveFerryAction.ErrorDestinationNotLinked, ConsoleObserver.LastErrorReceived);


        }

        [TestMethod]
        public void MovePlayerToPlayerLocationFail()
        {
            GameState.StartGame()
                        .ChooseLevel(Difficulty.Discovery);

            ActionBase action = new DriveFerryAction(GameState, GameState.CurrentPlayer, TownsInitializer.Atlanta);
            GameState.DoAction(action);
            Assert.AreEqual(4, GameState.ActionsRemaining);
            Assert.AreEqual(DriveFerryAction.ErrorSameDestinationAndLocation, ConsoleObserver.LastErrorReceived);
        }


        [TestMethod]
        public void MovePlayerToLinkedLocationSuccess()
        {
            GameState.StartGame()
                        .ChooseLevel(Difficulty.Discovery);

            ActionBase action = new DriveFerryAction(GameState, GameState.CurrentPlayer, TownsInitializer.Chicago);
            GameState.DoAction(action);
            Assert.AreEqual(3, GameState.ActionsRemaining);
            Assert.AreEqual(GameState.CurrentPlayer.Town.Name, TownsInitializer.Chicago);

        }

    }
}
