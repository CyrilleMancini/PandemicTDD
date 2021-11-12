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
            Assert.AreEqual(45, board.SpreadStack.Count);

        }


        [TestMethod]
        public void Draw3SpreadAndDiscardCards()
        {
            Board board = GameBox.GetInitializedBoard();
            Assert.AreEqual(3, board.SpreadDiscardStack.Count);

        }

        [TestMethod]
        public void Check3DiseasesCubesOnDiscardedCards()
        {
            Board board = GameBox.GetInitializedBoard();
            Town t = board.SpreadDiscardStack.ElementAt(0).Town;
            Assert.AreEqual(3, t.GetDiseaseByColor(t.Color).Count);            
            Assert.AreEqual(3, board.GetTown(t.Name).GetDiseaseByColor(t.Color).Count);

             t = board.SpreadDiscardStack.ElementAt(1).Town;
            Assert.AreEqual(3, t.GetDiseaseByColor(t.Color).Count);
            Assert.AreEqual(3, board.GetTown(t.Name).GetDiseaseByColor(t.Color).Count);

             t = board.SpreadDiscardStack.ElementAt(2).Town;
            Assert.AreEqual(3, t.GetDiseaseByColor(t.Color).Count);
            Assert.AreEqual(3, board.GetTown(t.Name).GetDiseaseByColor(t.Color).Count);


        }


    }

}
