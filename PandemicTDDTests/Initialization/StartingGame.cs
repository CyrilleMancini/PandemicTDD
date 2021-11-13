﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class StartingGame : TestsBase
    {

        [TestMethod]
        public void InitPlayersMax4Players()
        {

            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
                new() { Name ="PlThree" },
                new() { Name ="PlFour" },
                new() { Name ="PlFive" },
            };
            Assert.ThrowsException<TooManyPlayersException>(() =>
            {
                GameBox.StartGame(Players);
            });
        }

        [TestMethod]
        public void InitPlayersMin2Players()
        {

            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
            };
            Assert.ThrowsException<NotEnoughPlayersException>(() =>
            {
                GameBox.StartGame(Players);
            });
        }

        [TestMethod]
        public void RolesDistibuted()
        {

            List<Player> Players = new List<Player>() {
             new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
                new() { Name ="PlThree" },
                new() { Name ="PlFour" },
               };
            GameBox.StartGame(Players);
            Players.ForEach(p => Console.WriteLine(p.Role.Name));
            Assert.IsNotNull(Players[0].Role);
            Assert.IsNotNull(Players[1].Role);
            Assert.IsNotNull(Players[2].Role);
            Assert.IsNotNull(Players[3].Role);

        }

        [TestMethod]
        public void DistibutesPlayerCard2Players()
        {

            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
               };
            GameBox.StartGame(Players);
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

            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
                new() { Name ="PlThree" },
               };
            GameBox.StartGame(Players);
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
            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
                new() { Name ="PlThree" },
                new() { Name ="PlFour" },
               };
            GameBox.StartGame(Players);
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
            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
               };
            GameBox.StartGame(Players)
                .ChooseLevel(Difficulty.Discovery);

            Assert.AreEqual(4, GameBox.GetPlayersCard().Count(c => c is EpidemicPlayerCard));

        }

        [TestMethod]
        public void DifficultyNormal4EpidemicCards()
        {
            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
               };
            GameBox.StartGame(Players)
                .ChooseLevel(Difficulty.Standard);

            Assert.AreEqual(5, GameBox.GetPlayersCard().Count(c => c is EpidemicPlayerCard));

        }
        [TestMethod]
        public void DifficultyHeroic6EpidemicCards()
        {
            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
               };
            GameBox.StartGame(Players)
                .ChooseLevel(Difficulty.Heroic);

            Assert.AreEqual(6, GameBox.GetPlayersCard().Count(c => c is EpidemicPlayerCard));

        }

        [TestMethod]
        public void HeroicInitialisedStackOnBoard()
        {

            // Heroic    6 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 51 Cartes
            // Standard  5 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 50 Cartes
            // Discovery 4 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 49 Cartes
            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
               };
            GameBox.StartGame(Players)
                .ChooseLevel(Difficulty.Heroic);

            Assert.AreEqual(51, GameBox.GetBoard().PlayerCardStack.Count);        

        }

        [TestMethod]
        public void DiscoveryInitialisedStackOnBoard()
        {

            // Heroic    6 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 51 Cartes
            // Standard  5 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 50 Cartes
            // Discovery 4 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 49 Cartes
            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
               };

            GameBox.StartGame(Players)
                .ChooseLevel(Difficulty.Discovery);

            Assert.AreEqual(49, GameBox.GetBoard().PlayerCardStack.Count);

        }

        [TestMethod]
        public void StandardInitialisedStackOnBoard()
        {

            // Heroic    6 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 51 Cartes
            // Standard  5 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 50 Cartes
            // Discovery 4 : Epidmic + 5 Events + 48 Towns - 2 * 4 Town pour les joueurs => 49 Cartes
            List<Player> Players = new List<Player>() {
                new() { Name ="PlOne" },
                new() { Name ="PlTwo" },
               };
            GameBox.StartGame(Players)
                .ChooseLevel(Difficulty.Standard);

            Assert.AreEqual(50, GameBox.GetBoard().PlayerCardStack.Count);

        }

    }
}