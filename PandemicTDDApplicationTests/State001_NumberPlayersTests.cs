using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDDApplication.Exceptions;
using PandemicTDDTests.Materiel;

namespace PandemicTDDApplication.Tests
{

    [TestClass()]
    public class State001_NumberPlayersTests : TestsBase
    {

        [TestMethod()]
        public void State001_NumberPlayersTest()
        {
            State001_NumberPlayers state = new State001_NumberPlayers(GameState, View, ressource);

            BaseState next = state.SetNumberPlayer(4);

            Assert.IsTrue(next is State002_EnterPlayersNames);
        }

        [TestMethod()]
        public void State001_NumberPlayersTest_FailsMOreThanFour()
        {
            State001_NumberPlayers state = new State001_NumberPlayers(GameState, View, ressource);

            Assert.ThrowsException<InvalidInputException>(() =>
            {
                state.SetNumberPlayer(5);
            });

        }

        [TestMethod()]
        public void State001_NumberPlayersTest_FailsLessThanTwo()
        {
            State001_NumberPlayers state = new State001_NumberPlayers(GameState, View, ressource);

            Assert.ThrowsException<InvalidInputException>(() =>
            {
                state.SetNumberPlayer(1);
            });
        }
    }
}