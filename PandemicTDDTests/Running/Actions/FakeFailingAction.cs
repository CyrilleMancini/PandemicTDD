using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using System;

namespace PandemicTDDTests.Running
{
    internal class FakeFailingAction : ActionBase
    {
        public const string CanNotBeDone = "I can not be done";
        public const string Done = "I do an action";

        public override void Execute()
        {
            Console.WriteLine(Done);
        }

        public override void Try()
        {
            throw new InvalidActionException(CanNotBeDone);
        }
    }

}