using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PandemicTDD.Materiel.Tests
{
    [TestClass()]
    public class TownTests
    {
        [TestMethod()]
        public void TownEqualityTest()
        {
            Town Paris1 = new Town("Bleu", "Paris", "France");
            Town Paris2 = new Town("Bleu", "Paris", "France");
            Assert.IsTrue(Paris1 == Paris2);
        }
    }
}