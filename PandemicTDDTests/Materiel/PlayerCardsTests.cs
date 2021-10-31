using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class PlayersCardsTests
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

    }
}