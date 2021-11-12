using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class SpreadInitialisationTests : TestsBase
    {

        [TestMethod]
        public void SpreadStackPopulated()
        {
            Board board = GameBox.GetInitializedBoard();
            Assert.AreEqual(45, board.SpreadStack.Count);

        }


        [TestMethod]
        public void Draw3SpreadAnd3DiseaseCubeCard()
        {
            Board board = GameBox.GetInitializedBoard();
            Assert.AreEqual(3, board.SpreadDiscardStack.Count);

        }


    }

}
