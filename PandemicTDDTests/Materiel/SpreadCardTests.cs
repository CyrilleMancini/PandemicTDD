using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using PandemicTDDTests.Materiel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemicTDD.Materiel.Tests
{
    [TestClass()]
    public class SpreadCardTests : TestsBase
    {

        [TestMethod()]
        public void SpreadCardsTest()
        {
            List<SpreadCard> AllCards = GameBox.GetSpeadCards();
            Assert.IsNotNull(AllCards.Count, "Les cartes de propagation doivent etre au nombre de 48.");
        }

        [TestMethod()]
        public void Expected48SpreadCardsTest()
        {
            List<SpreadCard> AllCards = GameBox.GetSpeadCards();
            Assert.AreEqual(48, AllCards.Count, "Les cartes de propagation doivent etre au nombre de 48.");
        }

        [TestMethod()]
        public void Expected48TownInSpreadCardsTest()
        {
            List<SpreadCard> AllCards = GameBox.GetSpeadCards();

            foreach (string[] town in expectedTowns)
            {
                try
                {
                    AllCards.Single(it => it.Town.Name == town[1]);
                }
                catch (System.Exception)
                {
                    Console.WriteLine($"Manquant : {town[1]}");
                    throw;
                }

            }
        }
    }
}