using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.BoardItems;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
            Assert.AreEqual(48, slots.Count, "48 villes attendues sur la plateau.");
        }

        [TestMethod]
        public void TestTown1LinkedToTown2Test()
        {
            Board board = GameBox.GetBoard();

            TownsLink link = new TownsLink("Paris", "Londres");
            board.Link2Towns(link);

            TownSlot paris = board.GetTownSlot("Paris");
            TownSlot londres= board.GetTownSlot("Londres");

            TownSlot dest = paris.Links.Single(l => l.Town == londres.Town);

            Assert.IsNotNull(dest);

        }

        [TestMethod]
        public void TestTown2LinkedToTown1Test()
        {
            Board board = GameBox.GetBoard();
            TownsLink link = new TownsLink("Paris", "Londres");
            board.Link2Towns(link);

            TownSlot paris = board.GetTownSlot("Paris");
            TownSlot londres = board.GetTownSlot("Londres");

            TownSlot dest = londres.Links.Single(l => l.Town == paris.Town);

            Assert.IsNotNull(dest);

        }


    }
}
