using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel.Initializers;
using PandemicTDDTests.Materiel;

namespace PandemicTDDTests.Running.Actions
{
    [TestClass]
    public class ShuttleFlightActionTest : TestsBase
    {

        [TestMethod]
        public void ShuttleFromCityWithoutCdcMustFails()
        {
            StartGame();
            GameState.CurrentPlayer.Town = GameState.Board.GetTown(TownsInitializer.Bogota);
            ActionBase action = new ShuttleFlightAction(GameState, TownsInitializer.Paris);

            Assert.ThrowsException<CityWithoutControlCenterException>(() =>
            {
                action.Try();
                action.Execute();
            });

            Assert.AreEqual(TownsInitializer.Bogota, GameState.CurrentPlayer.Town.Name);
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }

        [TestMethod]
        public void ShuttleToCityWithoutCdcMustFails()
        {
            StartGame();
            ActionBase action = new ShuttleFlightAction(GameState, TownsInitializer.Paris);

            Assert.ThrowsException<CityWithoutControlCenterException>(() =>
            {
                action.Try();
                action.Execute();
            });

            Assert.AreEqual(TownsInitializer.Atlanta, GameState.CurrentPlayer.Town.Name);
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }
        [TestMethod]
        public void ShuttleSuccess()
        {

            StartGame();
            GameState.Board.GetTownSlot(TownsInitializer.Paris).BuildStation();
            ActionBase action = new ShuttleFlightAction(GameState, TownsInitializer.Paris);

            GameState.DoAction(action);

            Assert.AreEqual(TownsInitializer.Paris, GameState.CurrentPlayer.Town.Name);
            Assert.AreEqual(3, GameState.ActionsRemaining);
        }
    }
}
