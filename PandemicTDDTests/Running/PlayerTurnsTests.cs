using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDDTests.Materiel;

namespace PandemicTDDTests.Running
{
    [TestClass()]
    public class PlayerTurnsTests : TestsBase
    {
        [TestMethod()]
        public void FirstTurn()
        {

            GameState gameState = new GameState(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                        .ChooseLevel(Difficulty.Discovery);

            Assert.IsTrue(gameState.CurrentPlayer == Players[0]);


        }

        [TestMethod()]
        public void SecondTurn()
        {

            GameState gameState = new GameState(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                        .ChooseLevel(Difficulty.Discovery);

            gameState.NextTurn();
            Assert.IsTrue(gameState.CurrentPlayer == Players[1]);


        }

        [TestMethod()]
        public void ThirdTurn()
        {

            GameState gameState = new GameState(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                        .ChooseLevel(Difficulty.Discovery);

            gameState.NextTurn();
            gameState.NextTurn();
            Assert.IsTrue(gameState.CurrentPlayer == Players[2]);


        }

        [TestMethod()]
        public void FourthTurn()
        {

            GameState gameState = new GameState(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                        .ChooseLevel(Difficulty.Discovery);

            gameState.NextTurn();
            gameState.NextTurn();
            gameState.NextTurn();
            Assert.IsTrue(gameState.CurrentPlayer == Players[0]);


        }
    }
}