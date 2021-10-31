using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class PlayersCardsTests : TestsBase
    {
        [TestMethod()]
        public void GetPlayersCardsTest()
        {

            List<PlayerCard> AllCards = GameBox.GetPlayersCard();
            Assert.IsNotNull(AllCards);
        }

        [TestMethod()]
        public void RolesCardAre59Test()
        {
            List<PlayerCard> AllCards = GameBox.GetPlayersCard();
            Assert.AreEqual(59, AllCards.Count, "Le jeux devrait contenir 59 cartes Joueurs");
        }

        [TestMethod()]
        public void Expected48TownCardsTest()
        {
            List<PlayerCard> AllCards = GameBox.GetPlayersCard();
            Assert.AreEqual(48, AllCards.Count(it => it is PlayerTownCard), "Les cartes joueurs doivent comporter 48 cartes Villes");
        }

        [TestMethod()]
        public void CheckPlayerTownCardsWithExpectedTownsTest()
        {
            List<PlayerTownCard> AllCards = new();
            GameBox.GetPlayersCard().Where(c => c is PlayerTownCard)
                                    .ToList()
                                    .ForEach(it => AllCards.Add((PlayerTownCard)it));

            foreach (string[] town in expectedTowns)
            {
                try
                {
                    AllCards.Single(it => it.Town.Name == town[1]);
                }
                catch (System.Exception)
                {
                    Console.WriteLine($"Manquant : {town[1]}");
                    throw;
                }

            }
        }

        [TestMethod()]
        public void Expected6EpidemicCardsTest()
        {
            List<PlayerCard> AllCards = GameBox.GetPlayersCard();
            Assert.AreEqual(6, AllCards.Count(it => it is EpidemicPlayerCard), "Les cartes joueurs doivent comporter 6 cartes Epidemie");
        }
        [TestMethod()]
        public void Expected5EvetnsCardsTest()
        {
            List<PlayerCard> AllCards = GameBox.GetPlayersCard();
            Assert.AreEqual(5, AllCards.Count(it => it is EventPlayerCard), "Les cartes joueurs doivent comporter 5 cartes évenements");
        }
    }
}