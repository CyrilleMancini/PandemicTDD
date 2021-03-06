using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class SpreadCardTests : TestsBase
    {

        [TestMethod()]
        public void SpreadCardsTest()
        {
            IEnumerable<SpreadCard> AllCards = GameBox.GetSpeadCards();
            Assert.IsNotNull(AllCards.Count(), "Les cartes de propagation doivent etre au nombre de 48.");
        }

        [TestMethod()]
        public void Expected48SpreadCardsTest()
        {
            IEnumerable<SpreadCard> AllCards = GameBox.GetSpeadCards();
            Assert.AreEqual(48, AllCards.Count(), "Les cartes de propagation doivent etre au nombre de 48.");
        }

        [TestMethod()]
        public void Expected48TownInSpreadCardsTest()
        {
            IEnumerable<SpreadCard> AllCards = GameBox.GetSpeadCards();

            foreach (string[] town in expectedTowns)
            {
                try
                {
                    AllCards.Single(it => it.Town.Name == town[1]);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Manquant : {town[1]}");
                    throw;
                }

            }
        }


        [TestMethod]
        public void ListShufflerCard()
        {
            List<SpreadCard> AllCards = GameBox.GetSpeadCards();


            bool NotShuffled = true;

            for (int i = 0; i < expectedTowns.Length; i++)
            {
                string Expected = expectedTowns[i][1];
                NotShuffled = NotShuffled && Expected == AllCards.ElementAt(i).Town.Name;
            }

            Assert.IsFalse(NotShuffled);
        }


    }
}