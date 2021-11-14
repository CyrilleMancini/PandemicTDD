using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class TownTests
    {
        [TestMethod()]
        public void TownEqualityTest()
        {
            Town Paris1 = new Town(DiseaseColor.Blue, "Paris", "France");
            Town Paris2 = new Town(DiseaseColor.Blue, "Paris", "France");
            Assert.IsTrue(Paris1 == Paris2);
        }
    }
}