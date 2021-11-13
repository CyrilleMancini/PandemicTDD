using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using PandemicTDDTests.Materiel;

namespace PandemicTDDTests.EndOfGame
{
    [TestClass()]
    public class LosesTests : TestsBase
    {
        [TestMethod()]
        public void HeightOutbreakOccured()
        {
            Assert.ThrowsException<YouLooseException>(() =>
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
            Assert.ThrowsException<YouLooseException>(() =>
            {
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Black, 24);
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Black, 1);
            });

        }
        [TestMethod()]
        public void NoMoreCubeBlueDiseases()
        {
            Assert.ThrowsException<YouLooseException>(() =>
            {
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Blue, 24);
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Blue, 1);
            });

        }

        [TestMethod()]
        public void NoMoreCubeYellowDiseases()
        {
            Assert.ThrowsException<YouLooseException>(() =>
            {
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Yellow, 24);
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Yellow, 1);
            });

        }

        [TestMethod()]
        public void NoMoreCubeRedDiseases()
        {
            Assert.ThrowsException<YouLooseException>(() =>
            {
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Red, 24);
                GameBox.GetDiseaseBags().GetCubes(DiseaseColor.Red, 1);
            });

        }

    }
}