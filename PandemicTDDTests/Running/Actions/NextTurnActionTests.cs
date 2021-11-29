using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PandemicTDD.Actions.Tests
{
    [TestClass()]
    public class NextTurnActionTests : TestsBase
    {
        [TestMethod()]
        public void NextTurnActionTest()
        {
            StartGame();
            GameState.DoAction(new NextTurnAction(GameState));
            Assert.AreEqual(Players[1], GameState.CurrentPlayer);
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }

    }
}