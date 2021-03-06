using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Ressources;
using System.Collections.Generic;
using System.IO;

namespace CommonTestsTools
{
    [TestClass]
    public class TestsBase
    {

        protected string[][] expectedTowns;

        protected List<Player> Players = new()
        {
            new() { Name = "PlOne" },
            new() { Name = "PlTwo" },
            new() { Name = "PlThree" },
            new() { Name = "PlFour" },
            new() { Name = "PlFive" },
        };


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

        protected GameStateConsoleObserver ConsoleObserver = new();

        protected GameState GameState;

        [TestInitialize]
        public void InitInitializer()
        {
            ressource = new PandemicRessource_FR();
            View = new PandemicConsole(ressource);

            diseaseBagsInitializer = new DiseaseBagsInitializer();
            roleCardInitializer = new RoleCardInitializer();
            spreadCardInitializer = new SpreadCardInitializer();
            townsInitializer = new TownsInitializer();
            playerCardInitializer = new PlayerCardInitializer(
                AirLiftEventCard: new(ressource),
                CalmNigthEventCard: new(ressource),
                ResilientPopulationEventCard: new(ressource),
                ForcastEventCard: new(ressource),
                PublicSubventionEventCard: new(ressource));
            townSlotsInitializer = new TownSlotsInitializer(townsInitializer);
            townLinksInitializer = new TownLinksInitializer();
            GameInitializer gameInitializer = new();
            GameBox = new GameBox(roleCardInitializer, diseaseBagsInitializer,
                townsInitializer, spreadCardInitializer,
                playerCardInitializer, townSlotsInitializer, townLinksInitializer,
                gameInitializer);
            GameBox.Reset();
            GameBox.GetBoard();
            GameState = new GameState(GameBox);
            GameState.RegisterObserver(ConsoleObserver);

        }


        protected PandemicRessource_FR ressource;
        protected PandemicConsole View;




        protected void StartGame()
        {
            GameState.SetPlayers(Players.GetRange(0, 4))
                .StartGame()
                .ChooseLevel(Difficulty.Discovery);
            GameBox.GetInitializedBoard();

        }
    }
}