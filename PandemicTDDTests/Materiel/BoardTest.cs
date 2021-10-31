using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class BoardTests
    {

        string[][] expectedTowns;

        [TestInitialize]
        public void Init()
        {
            string[] rawtowns = File.ReadAllLines("Materiel\\Expected.txt");
            expectedTowns = new string[rawtowns.Length][];

            for (int i = 0; i < rawtowns.Length; i++)
            {
                expectedTowns[i] = rawtowns[i].Split(";");
            }
        }

        [TestMethod()]
        public void GetRolesCardsTest()
        {
            Board Board = GameBox.GetBoard();
            Assert.IsNotNull(Board);
        }

        [TestMethod()]
        public void CheckExpectedTownNumberTest()
        {
            Board Board = GameBox.GetBoard();
            Assert.AreEqual(48, Board.Towns.Count, "Le plateau doit contenir 48 villes");
        }


        [TestMethod()]
        public void CheckExpectedTownsTest()
        {
            Board Board = GameBox.GetBoard();
            foreach(string[] town in expectedTowns)
            {
                try
                {
                    Board.Towns.Single(it => it.Name == town[1]);

                }
                catch (System.Exception)
                {
                    Console.Write("Manquant : " + town[1]);
                    throw;
                }
            }
        }


    }
}