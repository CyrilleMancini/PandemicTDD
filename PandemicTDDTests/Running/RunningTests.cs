using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDDTests.Materiel;
using System;

namespace PandemicTDDTests.Running
{

    [TestClass()]
    public class RunningTests : TestsBase
    {
        [TestMethod()]
        public void FourActionsOnEeachTurn()
        {

            GameState gameState = new(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                        .ChooseLevel(Difficulty.Discovery);

            Assert.AreEqual(4, gameState.ActionsRemaining);


        }

        [TestMethod()]
        public void DoingActionDecrementRemaining()
        {
            StartGame();
            ActionBase action = new FakeAction();

            GameState.DoAction(action);

            Assert.AreEqual(3, GameState.ActionsRemaining);
        }

        [TestMethod()]
        public void DoingImpossibleActionDoesNotChangeAnything()
        {
            StartGame();
            ActionBase action = new FakeFailingAction();

            GameState.DoAction(action);

            Assert.AreEqual(4, GameState.ActionsRemaining);
        }


        [TestMethod()]
        public void TwiceRegisterationImpossible()
        {
            StartGame();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                GameState.RegisterObserver(ConsoleObserver);
            });
        }

        [TestMethod()]
        public void ImpossibleSendErrorToView()
        {
            StartGame();

            ActionBase action = new FakeFailingAction();
            GameState.DoAction(action);
            Assert.AreEqual(4, GameState.ActionsRemaining);

            Assert.AreEqual(FakeFailingAction.CanNotBeDone, ConsoleObserver.LastErrorReceived);

        }


        [TestMethod()]
        public void FourActionsDoneChangePlayer()
        {

            StartGame();
            ActionBase action = new FakeAction();

            // PLayer 1 is the current player
            Assert.AreEqual(Players[0], GameState.CurrentPlayer);

            //DO 4 actions
            for (int a = 0; a < 4; a++)
                GameState.DoAction(action);

            // PLayer has changed and 4 actions remaining
            Assert.AreEqual(Players[1], GameState.CurrentPlayer);
            Assert.AreEqual(4, GameState.ActionsRemaining);

        }



    }

}