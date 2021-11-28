using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class CureSlotsTests : TestsBase
    {
        [TestMethod()]
        public void GetCureSlotsTest()
        {
            Board Board = GameBox.GetBoard();
            Assert.IsNotNull(Board.GetCureSlots());
        }

        [TestMethod()]
        public void ResetCureSlotsTest()
        {
            Board Board = GameBox.GetBoard();
            var cure = Board.GetCureSlots();
            cure.Reset();
            Assert.AreEqual(cure.BlackSlot.Status, DiseaseStatus.None);
            Assert.AreEqual(cure.BlueSlot.Status, DiseaseStatus.None);
            Assert.AreEqual(cure.RedSlot.Status, DiseaseStatus.None);
            Assert.AreEqual(cure.YellowSlot.Status, DiseaseStatus.None);
        }

        [TestMethod()]
        public void NextStateCureSlotsTest()
        {
            Board Board = GameBox.GetBoard();
            var cure = Board.GetCureSlots();

            cure.BlackSlot.Next();
            Assert.AreEqual(DiseaseStatus.Treated, cure.BlackSlot.Status);

            cure.BlackSlot.Next();
            Assert.AreEqual(DiseaseStatus.Eradicated, cure.BlackSlot.Status);

            cure.BlackSlot.Next();
            Assert.AreEqual(DiseaseStatus.Eradicated, cure.BlackSlot.Status);

            cure.Reset();
            Assert.AreEqual(DiseaseStatus.None, cure.BlackSlot.Status);
        }

    }
}
