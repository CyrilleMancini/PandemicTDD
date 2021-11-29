using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDDApplication.Exceptions;

namespace PandemicTDDApplication.Tests
{
    [TestClass()]
    public class State002_EnterPlayersNamesTests : TestsBase
    {

        [TestMethod()]
        public void State002_EnterPlayersNames()
        {
            BaseState state = new State002_EnterPlayersNames(GameState, View, ressource,2);

            state = state.EnterPlayerName("Joueur1");
            Assert.IsTrue(state is State002_EnterPlayersNames);
            state = state.EnterPlayerName("Joueur2");
            Assert.IsTrue(state is State003_ChooseLevel);

        }

        [TestMethod()]
        public void State002_EnterPlayersNames_BadActionState()
        {
            BaseState state = new State002_EnterPlayersNames(GameState, View, ressource, 2);

            state = state.EnterPlayerName("Joueur1");
            Assert.IsTrue(state is State002_EnterPlayersNames);
            state = state.EnterPlayerName("Joueur2");
            Assert.IsTrue(state is State003_ChooseLevel);

            Assert.ThrowsException<InvalidActionException>(() =>
            {
                state.EnterPlayerName("Joueurs3");
            });
            Assert.ThrowsException<InvalidActionException>(() =>
            {
                state.DoAction();
            });

        }

    }
}