using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class CureSlotsTests : TestsBase
    {
        [TestMethod()]
        public void GetCureSlotsTest()
        {
            Board Board = GameBox.GetBoard();
            Assert.IsNotNull(Board.GetCureSlots());
        }
    }
}
