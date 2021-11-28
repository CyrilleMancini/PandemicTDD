using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDDTests.Materiel;

namespace PandemicTDDTests.Running
{
    public class PlayerRoundTest : TestsBase
    {

        [TestMethod]
        public void MovePlayerTestToUnLinkedTown()
        {
            var GameState = new GameState(Players.GetRange(0, 2), GameBox);
            GameState.StartGame().ChooseLevel(Difficulty.Discovery);

        }
    }
}
