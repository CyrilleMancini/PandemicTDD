using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using System;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class BoardTests : TestsBase
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
            Assert.AreEqual(48, Board.Towns.Count, "Le plateau doit contenir 48 villes");
        }


        [TestMethod()]
        public void CheckExpectedTownsTest()
        {
            Board Board = GameBox.GetBoard();
            foreach (string[] town in expectedTowns)
            {
                try
                {
                    Board.Towns.Single(it => it.Name == town[1]);

                }
                catch (System.Exception)
                {
                    Console.Write("Manquant : " + town[1]);
                    throw;
                }
            }
        }

        [TestMethod()]
        public void GetTownByNameFailOnUnkown()
        {
            Assert.ThrowsException<UnkownTownException>(() =>
            {
                Board Board = GameBox.GetBoard();
                Town Paris = Board.GetTown("Plop");
            });
        }

        [TestMethod()]
        public void GetTownByNameSuccessUnkown()
        {
            Board Board = GameBox.GetBoard();
            Town Paris = Board.GetTown("Paris");
            Assert.IsNotNull(Paris);
        }

        [TestMethod()]
        public void GetTownByObjectUnkown()
        {
            Board Board = GameBox.GetBoard();
            Town Paris = new Town("Bleu", "Paris", "France");
            Board.GetTown(Paris);
            Assert.IsNotNull(Paris);
        }

    }
}
