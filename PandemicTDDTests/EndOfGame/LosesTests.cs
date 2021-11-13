using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using PandemicTDDTests.Materiel;

namespace PandemicTDDTests.EndOfGame
{
    [TestClass()]
    public class LosesTests : TestsBase
    {
        [TestMethod()]
        public void TownEqualityTest()
        {
            Assert.ThrowsException<VictoryAllCuresDiscoveredException>(() =>
            {

                GameBox.GetBoard().GetCureSlots().DiscoverCure(DiseaseColor.Black);
                GameBox.GetBoard().GetCureSlots().DiscoverCure(DiseaseColor.Blue);
                GameBox.GetBoard().GetCureSlots().DiscoverCure(DiseaseColor.Red);
                GameBox.GetBoard().GetCureSlots().DiscoverCure(DiseaseColor.Yellow);
            });

        }
    }
}