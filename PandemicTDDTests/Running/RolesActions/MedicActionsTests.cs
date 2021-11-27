using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using System;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class MedicActionsTests : TestsBase
    {
        [TestInitialize()]
        public void InitPlayer()
        {
            StartGame();
            Players[0].Role = new MedicRoleCard("Médecin");

        }

        [TestMethod]
        public void CureAllDisease_WhenNotCure()
        {

            var town = GameState.Board.GetTownSlot(TownsInitializer.Atlanta);
            var diseases = GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Black, 3);
            town.Town.AddDisease(diseases);

            ActionBase action = new MedicCureAllDiseaseAction(GameState, DiseaseColor.Black);
            GameState.DoAction(action);

            Assert.AreEqual(0, town.Town.GetDiseaseByColor(DiseaseColor.Black).Count);
            Assert.AreEqual(3, GameState.ActionsRemaining);





        }

    }
}