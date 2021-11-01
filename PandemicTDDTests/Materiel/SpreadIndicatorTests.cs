using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class SpreadIndicatorTests : TestsBase
    {

        [TestMethod()]
        public void GetSpreadIndicatorTest()
        {
            Board Board = GameBox.GetBoard();
            Assert.IsNotNull(Board.GetSpreadIndicator());
        }

        [TestMethod()]
        public void CheckSpreadIndicatorLevelTest()
        {
            Board Board = GameBox.GetBoard();
            SpreadIndicator si = Board.GetSpreadIndicator();
            Assert.AreEqual(1, si.CurrentLevel);
        }

        [TestMethod()]
        public void CheckSpreadSpeedLevel1Test()
        {
            Board Board = GameBox.GetBoard();
            SpreadIndicator si = Board.GetSpreadIndicator();
            Assert.AreEqual(2, si.SpreadSpeed);
        }

        [TestMethod()]
        public void ResetSpreadSpeedTest()
        {
            Board Board = GameBox.GetBoard();
            SpreadIndicator si = Board.GetSpreadIndicator();
            si.Next();
            si.Next();

            si.Reset();
            Assert.AreEqual(1, si.CurrentLevel);
        }

        [TestMethod()]
        public void GoToNextSpreadSpeedTest()
        {
            Board Board = GameBox.GetBoard();
            SpreadIndicator si = Board.GetSpreadIndicator();
            si.Reset();
            si.Next();
            Assert.AreEqual(2, si.CurrentLevel);
        }

        [TestMethod()]
        public void GoFinalSpreadLevelTest()
        {
            Board Board = GameBox.GetBoard();
            SpreadIndicator si = Board.GetSpreadIndicator();
            si.Reset();

            for (int i = 0; i < 6; i++)
                si.Next();
                        
            Assert.AreEqual(7, si.CurrentLevel);
        }

        [TestMethod()]
        public void GoFinalSpreadSpeedTest()
        {
            Board Board = GameBox.GetBoard();
            SpreadIndicator si = Board.GetSpreadIndicator();
            si.Reset();

            for (int i = 0; i < 6; i++)
                si.Next();
            
            Assert.AreEqual(4, si.SpreadSpeed);
        }
    }
}
