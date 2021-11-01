using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class BoardTownSlotsTests : TestsBase
    {

        [TestMethod]
        public void InitTownsSlotsTest()
        {
            Board board = GameBox.GetBoard();
            List<TownSlot> slots = board.GetTownSlots();
            Assert.IsNotNull(slots);
        }

        [TestMethod]
        public void _48TownOnBoardTest()
        {
            Board board = GameBox.GetBoard();
            List<TownSlot> slots = board.GetTownSlots();
            Assert.AreEqual(48,slots.Count,"48 villes attendues sur la plateau.");
        }


    }
}
