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

    }

    internal class FakeAction : ActionBase
    {
        public override void Execute()
        {
            Console.WriteLine("I do an action");
        }

        public override void Try()
        {
            Console.WriteLine("I Try to do an action");
        }
    }
}