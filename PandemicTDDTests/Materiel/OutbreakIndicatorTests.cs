using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Events;
using PandemicTDD.Materiel;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class OutbreakIndicatorTests : TestsBase
    {

        [TestMethod]
        public void GetIndicator()
        {
            Board board = GameBox.GetBoard();
            OutBreakIndicator hi = board.GetOutbreakIndicator();
            Assert.IsNotNull(hi);
        }


        [TestMethod]
        public void GetIndicatorInitialized()
        {
            StartGame();
            Board board = GameBox.GetBoard();
            OutBreakIndicator hi = board.GetOutbreakIndicator();
            Assert.AreEqual(0, hi.Level);
        }



        [TestMethod]
        public void ResetOutbreakIndicator()
        {
            Board board = GameBox.GetBoard();
            OutBreakIndicator hi = board.GetOutbreakIndicator();
            hi.Reset();
            Assert.AreEqual(0, hi.Level);
        }


        [TestMethod]
        public void GoToNextOutbreakIndicator()
        {
            Board board = GameBox.GetBoard();
            OutBreakIndicator hi = board.GetOutbreakIndicator();
            hi.Reset();
            hi.Next();
            Assert.AreEqual(1, hi.Level);
        }

        [TestMethod]
        public void EndOfGameAtLevel8Test()
        {
            Board board = GameBox.GetBoard();
            OutBreakIndicator hi = board.GetOutbreakIndicator();
            hi.Reset();

            Assert.ThrowsException<YouLooseException>(() =>
            {
                for (int i = 0; i < 8; i++)
                    hi.Next();
            });

        }

    }
}
