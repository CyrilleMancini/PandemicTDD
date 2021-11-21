using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions.Exceptions;
using PandemicTDDTests.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemicTDD.Tests
{
    [TestClass()]
    public class ActionsTurnHistoryTests
    {

        ActionsTurnHistory history;

        [TestInitialize()]
        public void Init()
        {
            history = new ActionsTurnHistory();

        }

        [TestMethod()]
        public void AddActionTest()
        {
            FakeAction fakeAction = new FakeAction();

            history.AddAction(fakeAction);

            Assert.AreEqual(1, history.PlayedActionsCount);

        }

        [TestMethod()]
        public void AlreadyPlayedTest()
        {
            FakeAction fakeAction = new FakeAction();
            FakeAction fakeAction2 = new FakeAction();

            history.AddAction(fakeAction);

            Assert.AreEqual(history.AlreadyPlayed<FakeAction>(), true);

            Assert.AreEqual(1, history.PlayedActionsCount);
        }
              

        [TestMethod()]
        public void NextTurnTest()
        {
            FakeAction fakeAction = new FakeAction();

            history.AddAction(fakeAction);
            history.NextTurn();

            Assert.AreEqual(0, history.PlayedActionsCount);
        }
    }
}