using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class QuarantineSpecialistActionsTests : TestsBase
    {
        [TestInitialize()]
        public void InitPlayer()
        {
            StartGame();
            Players[0].Role = new QuarantineSpecialistRoleCard("Spécialiste en mise en quarantaine");
        }
    }
}