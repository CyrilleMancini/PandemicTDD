using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Events;
using PandemicTDD.Materiel;
using PandemicTDDTests.Materiel;

namespace PandemicTDDTests.EndOfGame
{
    [TestClass()]
    public class VictoriesTests : TestsBase
    {
        [TestMethod()]
        public void AllCuresDiscovered()
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