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
    }
}
