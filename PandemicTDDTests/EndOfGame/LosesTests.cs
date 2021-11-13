using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using PandemicTDDTests.Materiel;

namespace PandemicTDDTests.EndOfGame
{
    [TestClass()]
    public class LosesTests : TestsBase
    {
        [TestMethod()]
        public void HeightOutbreakOccured()
        {
            Assert.ThrowsException<YouLooseException>(() =>
            {
                var board = GameBox.GetBoard();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
                board.GetOutbreakIndicator().Next();
            });

        }
    }
}