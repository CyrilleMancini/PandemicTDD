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

            GameState gameState = new GameState(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                        .ChooseLevel(Difficulty.Discovery);

            Assert.AreEqual(4, gameState.ActionsRemaining);


        }

        [TestMethod()]
        public void DoingActionDecrementRemaining()
        {

            GameState gameState = new GameState(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                     .ChooseLevel(Difficulty.Discovery);

            ActionBase action = new FakeAction();
            gameState.DoAction(action);
            Assert.AreEqual(3, gameState.ActionsRemaining);
        }

        [TestMethod()]
        public void DoingImpossibleActionDoesNotChangeAnything()
        {

            GameState gameState = new GameState(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                     .ChooseLevel(Difficulty.Discovery);

            ActionBase action = new FakeFailingAction();
            gameState.DoAction(action);
            Assert.AreEqual(4, gameState.ActionsRemaining);
        }


        [TestMethod()]
        public void TwiceRegisterationImpossible()
        {
            GameState gameState = new GameState(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                     .ChooseLevel(Difficulty.Discovery);

            gameState.RegisterObserver(ConsoleObserver);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                gameState.RegisterObserver(ConsoleObserver);
            });
        }

        [TestMethod()]
        public void ImpossibleSendErrorToView()
        {
            GameState gameState = new GameState(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                     .ChooseLevel(Difficulty.Discovery);

            gameState.RegisterObserver(ConsoleObserver);

            ActionBase action = new FakeFailingAction();
            gameState.DoAction(action);
            Assert.AreEqual(4, gameState.ActionsRemaining);

            Assert.AreEqual(FakeFailingAction.CanNotBeDone, ConsoleObserver.LastErrorReceived);

        }


        [TestMethod()]
        public void FourActionsDoneChangePlayer()
        {

            GameState gameState = new GameState(Players.GetRange(0, 3), GameBox);
            gameState.StartGame()
                     .ChooseLevel(Difficulty.Discovery);
            ActionBase action = new FakeAction();
            // PLayer 1 is the current player
            Assert.AreEqual(Players[0], gameState.CurrentPlayer);

            //DO 4 actions
            for (int a = 0; a < 4; a++)
                gameState.DoAction(action);

            // PLayer has changed and 4 actions remaining
            Assert.AreEqual(Players[1], gameState.CurrentPlayer);
            Assert.AreEqual(4, gameState.ActionsRemaining);

        }



    }

}