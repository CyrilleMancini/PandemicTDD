using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using System;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class MedicActionsTests : TestsBase
    {
        [TestInitialize()]
        public void InitPlayer()
        {
            StartGame();
            Players[0].Role = new MedicRoleCard("Médecin");
          
        }

        [TestMethod]
        public void CureAllDisease_WhenNotCure()
        {
        
//            ActionBase action = new Cure

        }  

    }
}