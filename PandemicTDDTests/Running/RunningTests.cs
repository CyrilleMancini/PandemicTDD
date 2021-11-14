using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDDTests.Materiel;
using System.Collections.Generic;

namespace PandemicTDD.Materiel.Tests
{
    [TestClass()]
    public class RunningTests : TestsBase
    {
        [TestMethod()]
        public void OneTurn()
        {

            GameState gameState = new GameState(Players.GetRange(0,4), GameBox);
            gameState.StartGame()
                        .ChooseLevel(Difficulty.Discovery);


        }
    }
}