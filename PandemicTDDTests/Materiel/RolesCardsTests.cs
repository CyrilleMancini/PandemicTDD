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
    }
}