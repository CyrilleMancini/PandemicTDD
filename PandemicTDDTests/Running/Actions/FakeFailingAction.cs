using PandemicTDD.Actions;
using PandemicTDDTests.Running.Actions;
using System;

namespace PandemicTDDTests.Running
{
    internal class FakeFailingAction : ActionBase
    {
        public override void Execute()
        {
            Console.WriteLine("I do an action");
        }

        public override void Try()
        {
            throw new InvalidActionException("I can not be done");
        }
    }

}