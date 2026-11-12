using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Events;
using PandemicTDD.Materiel;
using System;

namespace PandemicTDDTests.EndOfGame
{
    [TestClass()]
    public class LosesTests : TestsBase
    {
        [TestMethod()]
        public void HeightOutbreakOccured()
        {
            Assert.Throws<YouLooseException>(() =>
            {
                var board = GameBox.GetBoard();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
            });
        }


        [TestMethod()]
        public void NoMoreCubeDisease()
        {
            Assert.Throws<YouLooseException>(() =>
            {
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Black, 24);
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Black, 1);
            });

        }
        [TestMethod()]
        public void NoMoreCubeBlueDiseases()
        {
            Assert.Throws<YouLooseException>(() =>
            {
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Blue, 24);
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Blue, 1);
            });

        }

        [TestMethod()]
        public void NoMoreCubeYellowDiseases()
        {
            Assert.Throws<YouLooseException>(() =>
            {
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Yellow, 24);
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Yellow, 1);
            });

        }

        [TestMethod()]
        public void NoMoreCubeRedDiseases()
        {
            Assert.Throws<YouLooseException>(() =>
            {
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Red, 24);
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Red, 1);
            });

        }

        [TestMethod()]
        public void BadQuantities()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Blue, 0);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Blue, -1);
            });
        }
    }
}