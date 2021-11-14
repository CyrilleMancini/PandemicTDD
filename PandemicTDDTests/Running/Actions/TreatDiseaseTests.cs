using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Materiel;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Running.Actions
{
    [TestClass]
    public class TreatDiseaseTests : TestsBase
    {

        [TestMethod]
        public void TreatDiseaseOnOwnedTownCard()
        {
            StartGame();
            GameBox.GetBoard();
            List<DiseaseCube> cubes = new() { new DiseaseCube(DiseaseColor.Black), new DiseaseCube(DiseaseColor.Black) };
            GameState.Board.GetTownSlot(TownsInitializer.Atlanta).Town.AddDisease(cubes);

            ActionBase action = new TreatDiseaseAction(GameState, DiseaseColor.Black);
            GameState.DoAction(action);

            Assert.AreEqual(3, GameState.ActionsRemaining);
        }

        [TestMethod]
        public void CannotTreatDiseaseWithZeroCubes()
        {
            StartGame();
            GameBox.GetBoard();

            ActionBase action = new TreatDiseaseAction(GameState, DiseaseColor.Black);
            GameState.DoAction(action);

            Assert.AreEqual(4, GameState.ActionsRemaining);
        }
    }
}
