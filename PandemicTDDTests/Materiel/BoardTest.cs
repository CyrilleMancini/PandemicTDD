using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class BoardTests
    {
        [TestMethod()]
        public void GetRolesCardsTest()
        {
            Board Board = GameBox.GetBoard();
            Assert.IsNotNull(Board);
        }

        [TestMethod()]
        public void CheckExpectedTownNumberTest()
        {
            Board Board = GameBox.GetBoard();
            Assert.AreEqual(48,Board.Towns.Count, "Le plateau doit contenir 48 villes");
        }


    }
}