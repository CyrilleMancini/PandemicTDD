﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDDTests.Materiel;

namespace PandemicTDD.Materiel.Tests
{
    [TestClass()]
    public class DiseaseCubesBagTests : TestsBase
    {

        [TestMethod()]
        public void DiseaseCubeBagTest()
        {
            DiseaseBags bags = GameBox.GetDiseaseBags();
        }


        [TestMethod()]
        public void CheckColorsCubeTest()
        {
            DiseaseBags bags = GameBox.GetDiseaseBags();
            Assert.AreEqual(24, bags.Blacks.Count, "24 Maladies noires attendues");
        }
        [TestMethod()]
        public void CheckRedColorsCubeTest()
        {
            DiseaseBags bags = GameBox.GetDiseaseBags();
            Assert.AreEqual(24, bags.Reds.Count, "24 Maladies rouges attendues");
        }

        [TestMethod()]
        public void CheckYellowColorsCubeTest()
        {
            DiseaseBags bags = GameBox.GetDiseaseBags();
            Assert.AreEqual(24, bags.Yellows.Count, "24 Maladies Jaunes attendues");
        }

        [TestMethod()]
        public void CheckBluesColorsCubeTest()
        {
            DiseaseBags bags = GameBox.GetDiseaseBags();
            Assert.AreEqual(24, bags.Blues.Count, "24 Maladies Bleues attendues");
        }

    }
}