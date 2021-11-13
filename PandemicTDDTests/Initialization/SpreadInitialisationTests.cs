using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class SpreadInitialisationTests : TestsBase
    {

        [TestMethod]
        public void SpreadStackPopulated()
        {
            Board board = GameBox.GetInitializedBoard();
            Assert.AreEqual(39, board.SpreadStack.Count);
        }


        [TestMethod]
        public void Draw3SpreadAndDiscardCards()
        {
            Board board = GameBox.GetInitializedBoard();
            Assert.AreEqual(9, board.SpreadDiscardStack.Count);
        }

        [TestMethod]
        public void Check3DiseasesCubesOnDiscardedCards()
        {
            Board board = GameBox.GetInitializedBoard();
            for (int nbDisease = 1; nbDisease <= 3; nbDisease++)
            {
                for (int cards = 0; cards < 3; cards++)
                {
                    int cardStackPosition = (nbDisease - 1) * 3 + cards;
                    Town t = board.SpreadDiscardStack.ElementAt(cardStackPosition).Town;
                    Assert.AreEqual(nbDisease, t.GetDiseaseByColor(t.Color).Count);
                    Assert.AreEqual(nbDisease, board.GetTown(t.Name).GetDiseaseByColor(t.Color).Count);
                }
            }
        }
    }
}
