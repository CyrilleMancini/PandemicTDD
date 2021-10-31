using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class RolesCardsTests
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
            Assert.AreEqual(7,AllCards.Count,"Le jeux devrait contenir 7 cartes roles");
        }

        [TestMethod()]
        public void GetExpectedRolesTest()
        {
            List<RoleCard> AllCards = GameBox.GetRoles();
            AllCards.Any(it => it.Name == "Medecin");
            AllCards.Any(it => it.Name == "Chercheuse");
            AllCards.Any(it => it.Name == "Expert au opérations");
            AllCards.Any(it => it.Name == "Répartiteur");
            AllCards.Any(it => it.Name == "Planificateur d'urgence");
            AllCards.Any(it => it.Name == "Scientifique");
            AllCards.Any(it => it.Name == "Spécialiste de la mise en quanrantaine");
        }

    }
}