using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}