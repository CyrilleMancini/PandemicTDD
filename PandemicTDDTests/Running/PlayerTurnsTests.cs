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

            StartGame();
            Assert.IsTrue(GameState.CurrentPlayer == Players[0]);


        }

        [TestMethod()]
        public void SecondTurn()
        {
            StartGame();

            GameState.NextTurn();
            Assert.IsTrue(GameState.CurrentPlayer == Players[1]);
        }

        [TestMethod()]
        public void ThirdTurn()
        {
            StartGame();

            GameState.NextTurn();
            GameState.NextTurn();
            Assert.IsTrue(GameState.CurrentPlayer == Players[2]);


        }

        [TestMethod()]
        public void FourthTurn()
        {
            StartGame();

            GameState.NextTurn();
            GameState.NextTurn();
            GameState.NextTurn();
            GameState.NextTurn();
            Assert.IsTrue(GameState.CurrentPlayer == Players[0]);
        }
    }
}