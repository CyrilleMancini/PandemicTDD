using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class HatchingIndicatorTests : TestsBase
    {

        [TestMethod]
        public void GetIndicator()
        {
            Board board = GameBox.GetBoard();
            HatchingIndicator hi = board.GetHatchingIndicator();
        }

        [TestMethod]
        public void ResetHatchingIndicator()
        {
            Board board = GameBox.GetBoard();
            HatchingIndicator hi = board.GetHatchingIndicator();
            hi.Reset();
            Assert.AreEqual(0, hi.Level);
        }


        [TestMethod]
        public void GoToNextHatchingIndicator()
        {
            Board board = GameBox.GetBoard();
            HatchingIndicator hi = board.GetHatchingIndicator();
            hi.Reset();
            hi.Next();
            Assert.AreEqual(1, hi.Level);
        }

    }
}
