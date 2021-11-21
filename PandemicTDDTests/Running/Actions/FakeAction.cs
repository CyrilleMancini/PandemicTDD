using PandemicTDD.Actions;
using System;

namespace PandemicTDDTests.Running
{
    internal class FakeAction : ActionBase
    {
        public override bool ConsumeOneAction => true;

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