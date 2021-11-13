using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
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

        protected DiseaseBagsInitializer diseaseBagsInitializer;
        protected RoleCardInitializer roleCardInitializer;
        protected SpreadCardInitializer spreadCardInitializer;
        protected TownsInitializer townsInitializer;
        protected TownSlotsInitializer townSlotsInitializer;
        protected TownLinksInitializer townLinksInitializer;
        protected PlayerCardInitializer playerCardInitializer;
        protected GameBox GameBox;

        [TestInitialize]
        public void InitInitializer()
        {
            diseaseBagsInitializer = new DiseaseBagsInitializer();
            roleCardInitializer = new RoleCardInitializer();
            spreadCardInitializer = new SpreadCardInitializer();
            townsInitializer = new TownsInitializer();
            playerCardInitializer = new PlayerCardInitializer();
            townSlotsInitializer = new TownSlotsInitializer(townsInitializer);
            townLinksInitializer = new TownLinksInitializer();
            GameInitializer gameInitializer = new GameInitializer();
            GameBox = new GameBox(roleCardInitializer, diseaseBagsInitializer,
                townsInitializer, spreadCardInitializer,
                playerCardInitializer, townSlotsInitializer, townLinksInitializer,
                gameInitializer);
        }
    }
}