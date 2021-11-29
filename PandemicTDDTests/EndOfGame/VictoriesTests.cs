using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Actions;
using PandemicTDD.Events;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Materiel;
using PandemicTDDTests.Running.Actions;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.EndOfGame
{
    [TestClass()]
    public class VictoriesTests : TestsBase
    {
        [TestMethod()]
        public void AllCuresDiscovered()
        {         
          

            Assert.ThrowsException<VictoryAllCuresDiscoveredException>(() =>
            {
                GameBox.GetBoard().GetCureSlots().DiscoverCure(DiseaseColor.Black);
                GameBox.GetBoard().GetCureSlots().DiscoverCure(DiseaseColor.Blue);
                GameBox.GetBoard().GetCureSlots().DiscoverCure(DiseaseColor.Red);
                GameBox.GetBoard().GetCureSlots().DiscoverCure(DiseaseColor.Yellow);
            });


        }

             

        [TestMethod]
        public void YellowCureDiscovered()
        {
            Players[0].Role = new DispatcherRoleCard("Dispatcher");
            StartGame();

            bool VictoryCalled = false;

            GameState.OnVictory += (sender, e) =>
            {
                VictoryCalled = true;
            };

            List<PlayerTownCard> cards = new();
            for (int c = 0; c < 5; c++)
                cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Color == DiseaseColor.Yellow));

            GameState.Board.GetCureSlots().DiscoverCure(DiseaseColor.Black);
            GameState.Board.GetCureSlots().DiscoverCure(DiseaseColor.Blue);
            GameState.Board.GetCureSlots().DiscoverCure(DiseaseColor.Red);

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Yellow, cards);
            GameState.DoAction(action);

            Assert.IsTrue(VictoryCalled);


        }


    }
}