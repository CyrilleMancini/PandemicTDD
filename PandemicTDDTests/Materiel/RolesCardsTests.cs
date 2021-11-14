using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class RolesCardsTests : TestsBase
    {
        [TestMethod()]
        public void GetRolesCardsTest()
        {
            List<RoleCard> AllCards = GameBox.GetRoles();
            Assert.IsNotNull(AllCards);
        }

        [TestMethod()]
        public void RolesCardAre7Test()
        {
            List<RoleCard> AllCards = GameBox.GetRoles();

            Assert.AreEqual(7, AllCards.Count, "Le jeux devrait contenir 7 cartes roles");
        }

        [TestMethod()]
        public void GetExpectedRolesTest()
        {
            List<RoleCard> AllCards = GameBox.GetRoles();
            bool result = true;
            result = result && AllCards.Any(it => it.Name == "Médecin");
            result = result && AllCards.Any(it => it.Name == "Chercheuse");
            result = result && AllCards.Any(it => it.Name == "Expert aux opérations");
            result = result && AllCards.Any(it => it.Name == "Répartiteur");
            result = result && AllCards.Any(it => it.Name == "Planificateur d'urgence");
            result = result && AllCards.Any(it => it.Name == "Scientifique");
            result = result && AllCards.Any(it => it.Name == "Spécialiste en mise en quarantaine");
            Assert.IsTrue(result);
        }

    }
}