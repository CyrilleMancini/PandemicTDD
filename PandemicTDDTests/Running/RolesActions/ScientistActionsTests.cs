using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Materiel;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class ScientistActionsTests : TestsBase
    {
        [TestInitialize()]
        public void InitPlayer()
        {
            StartGame();
            Players[0].Role = new ScientistRoleCard("Scientifique");
            Players[1].Role = new DispatcherRoleCard("Répartiteur");
        }
    }
}