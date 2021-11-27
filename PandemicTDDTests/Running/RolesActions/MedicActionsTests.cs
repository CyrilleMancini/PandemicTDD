﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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


        [TestMethod]
        public void CureAllDisease_CubesBackInBag()
        {
            var town = GameState.Board.GetTownSlot(TownsInitializer.Atlanta);
            int CountBefore = GameBox.GetDiseaseBags().Blacks.Count;

            var diseases = GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Black, 3);
            town.Town.AddDisease(diseases);

            ActionBase action = new MedicCureAllDiseaseAction(GameState, DiseaseColor.Black);
            GameState.DoAction(action);

            Assert.AreEqual(CountBefore, GameBox.GetDiseaseBags().Blacks.Count);
        }

        [TestMethod]
        public void CureAllDisease_FailsCauseNoCubes()
        {

            var town = GameState.Board.GetTownSlot(TownsInitializer.Atlanta);
            var diseases = GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Black, 3);
            town.Town.CureDiseaseByColor(DiseaseColor.Black);

            ActionBase action = new MedicCureAllDiseaseAction(GameState, DiseaseColor.Black);

            Assert.ThrowsException<InvalidPreconditionsException>(() =>
            {
                action.Try();
            });

            Assert.AreEqual(4, GameState.ActionsRemaining);
        }

    }
}