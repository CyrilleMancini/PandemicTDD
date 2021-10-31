using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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