using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using PandemicTDD.Tools;
using System;
using System.Collections.Generic;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class InitialisationTests : TestsBase
    {

        [TestMethod]
        public void OneCDCOnAtlantaTest()
        {
            Board board = GameBox.GetBoard();
            var atlanta = board.GetTownSlot("Atlanta");

            Assert.IsNotNull(atlanta.ControlDiseaseCenter);

        }

        [TestMethod]
        public void SpreadSpeedInitialized()
        {
            Board board = GameBox.GetBoard();
            Assert.AreEqual(1, board.GetSpreadIndicator().CurrentLevel);
            Assert.AreEqual(2, board.GetSpreadIndicator().SpreadSpeed);
        }


        [TestMethod]
        public void ListShufflerCardSameSize()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ListShuffler shuffler = new ListShuffler();

            var shuffled = shuffler.Shuffle(list);
            Assert.AreEqual(10, shuffled.Count);

        }

        [TestMethod]
        public void ListShufflerCardTestNonShuffled()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> shuffled = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            bool NotShuffled = true;
            for (int i = 0; i < 10; i++)
            {
                NotShuffled = NotShuffled && (shuffled[i] == i);
            }
            Assert.IsTrue(NotShuffled);
        }

        [TestMethod]
        public void ListShufflerCard()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ListShuffler shuffler = new ListShuffler();

            var shuffled = shuffler.Shuffle(list);
            bool NotShuffled = true;
            for (int i = 0; i < 10; i++)
            {
                NotShuffled = NotShuffled && (shuffled[i] == i);
            }
            Assert.IsFalse(NotShuffled);
        }
    }

}
