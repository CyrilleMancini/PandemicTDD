using CommonTestsTools;
using PandemicTDD;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDDApplication;
using System;

namespace PandemicClientCLI
{
    class Program
    {


        protected static DiseaseBagsInitializer diseaseBagsInitializer;
        protected static RoleCardInitializer roleCardInitializer;
        protected static SpreadCardInitializer spreadCardInitializer;
        protected static TownsInitializer townsInitializer;
        protected static TownSlotsInitializer townSlotsInitializer;
        protected static TownLinksInitializer townLinksInitializer;
        protected static PlayerCardInitializer playerCardInitializer;
        protected static GameBox GameBox;
        protected static GameStateConsoleObserver ConsoleObserver = new();
        protected static GameState GameState;

        public static void InitInitializer()
        {
            diseaseBagsInitializer = new DiseaseBagsInitializer();
            roleCardInitializer = new RoleCardInitializer();
            spreadCardInitializer = new SpreadCardInitializer();
            townsInitializer = new TownsInitializer();
            playerCardInitializer = new PlayerCardInitializer();
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
            //GameState.RegisterObserver(ConsoleObserver);

            ressource = new PandemicRessource_FR();

            View = new PandemicConsole(ressource);
            GameState.RegisterObserver(View);



        }


        protected static PandemicRessource_FR ressource;
        protected static PandemicConsole View;




        protected void StartGame()
        {

        }

        static void Main(string[] args)
        {
            InitInitializer();

            BaseState baseState = new State001_NumberPlayers(GameState, View, ressource);
            baseState.Instructions();
            baseState = baseState.SetNumberPlayer(2);

            baseState.Instructions();
            baseState = baseState.EnterPlayerName("titi");

            baseState.Instructions();
            baseState = baseState.EnterPlayerName("toto");

            baseState.Instructions();
            RoleBaseState roleState = baseState.ChooseLevel(Difficulty.Standard);

            GameState.OnFailure += GameState_OnFailure;
            GameState.OnVictory += GameState_OnVictory;

            while (true)
            {
                roleState.Instructions();
                roleState = roleState.WaitAction();
            }
        }

        private static void GameState_OnVictory(object sender, string e)
        {
            Console.WriteLine(e);
        }

        private static void GameState_OnFailure(object sender, string e)
        {
            Console.WriteLine(e);
        }
    }
}
