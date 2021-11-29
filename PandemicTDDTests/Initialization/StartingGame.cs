using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Materiel;
using System;
using System.Linq;

namespace PandemicTDDTests.Initialization
{
    [TestClass()]
    public class StartingGame : TestsBase
    {

        [TestMethod]
        public void InitPlayersMax4Players()
        {

            Assert.ThrowsException<TooManyPlayersException>(() =>
            {
                GameState gameState = new GameState(GameBox);
                gameState.SetPlayers(Players)
                .StartGame();
            });
        }

        [TestMethod]
        public void InitPlayersMin2Players()
        {

            Assert.ThrowsException<NotEnoughPlayersException>(() =>
            {
                GameState gameState = new(GameBox);
                gameState.SetPlayers(Players.GetRange(0, 1)).StartGame();
            });
        }

        [TestMethod]
        public void RolesDistibuted()
        {
            GameState gameState = new(GameBox);
            gameState
                .SetPlayers(Players.GetRange(0, 4))
                .StartGame();

            Players.GetRange(0, 4).ForEach(p => Console.WriteLine(p.Role.Name));
            Assert.IsNotNull(Players[0].Role);
            Assert.IsNotNull(Players[1].Role);
            Assert.IsNotNull(Players[2].Role);
            Assert.IsNotNull(Players[3].Role);

        }

        [TestMethod]
        public void DistibutesPlayerCard2Players()
        {

            GameState gameState = new(GameBox);
            gameState
                .SetPlayers(Players.GetRange(0, 2))
                .StartGame();

            Assert.AreEqual(4, Players[0].PlayerCards.Count);
            Assert.AreEqual(4, Players[1].PlayerCards.Count);
            Players.ForEach(p =>
            {
                Console.WriteLine($"Player {p.Name}");
                p.PlayerCards.ForEach(ca => Console.WriteLine(ca.Type));
            });

        }

        [TestMethod]
        public void DistibutesPlayerCard3Players()
        {

            GameState gameState = new(GameBox);
            gameState
                .SetPlayers(Players.GetRange(0, 3))
                .StartGame();

            Assert.AreEqual(3, Players[0].PlayerCards.Count);
            Assert.AreEqual(3, Players[1].PlayerCards.Count);
            Assert.AreEqual(3, Players[2].PlayerCards.Count);
            Players.ForEach(p =>
            {
                Console.WriteLine($"Player {p.Name}");
                p.PlayerCards.ForEach(ca => Console.WriteLine(ca.Type));
            });

        }

        [TestMethod]
        public void DistibutesPlayerCard4Players()
        {

            GameState gameState = new(GameBox);
            gameState.SetPlayers(Players.GetRange(0, 4))
                .StartGame();
            Assert.AreEqual(2, Players[0].PlayerCards.Count);
            Assert.AreEqual(2, Players[1].PlayerCards.Count);
            Assert.AreEqual(2, Players[2].PlayerCards.Count);
            Assert.AreEqual(2, Players[3].PlayerCards.Count);
            Players.ForEach(p =>
            {
                Console.WriteLine($"Player {p.Name}");
                p.PlayerCards.ForEach(ca => Console.WriteLine(ca.Type));
            });

        }

        [TestMethod]
        public void DifficultyDiscovery4EpidemicCards()
        {

            GameState gameState = new(GameBox);
            gameState.SetPlayers(Players.GetRange(0, 2))
                .StartGame()
                .ChooseLevel(Difficulty.Discovery);

            Assert.AreEqual(4, GameBox.GetPlayersCard().Count(c => c is EpidemicPlayerCard));

        }

        [TestMethod]
        public void DifficultyNormal4EpidemicCards()
        {

            GameState gameState = new(GameBox);
            gameState.SetPlayers(Players.GetRange(0, 2))
                    .StartGame()
                    .ChooseLevel(Difficulty.Standard);

            Assert.AreEqual(5, GameBox.GetPlayersCard().Count(c => c is EpidemicPlayerCard));

        }
        [TestMethod]
        public void DifficultyHeroic6EpidemicCards()
        {

            GameState gameState = new(GameBox);
            gameState.SetPlayers(Players.GetRange(0, 2))
                        .StartGame()
                        .ChooseLevel(Difficulty.Heroic);

            Assert.AreEqual(6, GameBox.GetPlayersCard().Count(c => c is EpidemicPlayerCard));

        }

        [TestMethod]
        public void HeroicInitialisedStackOnBoard()
        {
            // Heroic    6 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 51 Cartes
            GameState gameState = new(GameBox);
            gameState.SetPlayers(Players.GetRange(0, 2))
                .StartGame()
                .ChooseLevel(Difficulty.Heroic);

            Assert.AreEqual(51, GameBox.GetBoard().PlayerCardStack.Count);

        }

        [TestMethod]
        public void DiscoveryInitialisedStackOnBoard()
        {
            // Discovery 4 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 49 Cartes
            GameState gameState = new(GameBox);
            gameState.SetPlayers(Players.GetRange(0, 2))
                .StartGame()
                .ChooseLevel(Difficulty.Discovery);

            Assert.AreEqual(49, GameBox.GetBoard().PlayerCardStack.Count);

        }

        [TestMethod]
        public void StandardInitialisedStackOnBoard()
        {
            // Standard 5 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 50 Cartes

            GameState gameState = new(GameBox);
            gameState.SetPlayers(Players.GetRange(0, 2))
                .StartGame()
                .ChooseLevel(Difficulty.Standard);

            Assert.AreEqual(50, GameBox.GetBoard().PlayerCardStack.Count);

        }

        [TestMethod]
        public void AllPLayerInAtlanta()
        {


            GameState gameState = new(GameBox);
            gameState.SetPlayers(Players.GetRange(0, 4))
                .StartGame()
                    .ChooseLevel(Difficulty.Standard);

            Players.GetRange(0, 2).ForEach(p => Assert.AreEqual(TownsInitializer.Atlanta, p.Town.Name, "Should be in Atlanta"));
        }
    }
}
