using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PandemicTDDTests.Materiel
{
    [TestClass]
    public class TestsBase
    {

        protected string[][] expectedTowns;

        [TestInitialize]
        public void InitExpectedTowns()
        {
            string[] rawtowns = File.ReadAllLines("Materiel\\Expected.txt");
            expectedTowns = new string[rawtowns.Length][];

            for (int i = 0; i < rawtowns.Length; i++)
            {
                expectedTowns[i] = rawtowns[i].Split(";");
            }
        }
    }
}