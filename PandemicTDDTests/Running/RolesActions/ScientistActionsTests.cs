using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Running.Actions;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Materiel
{
    [TestClass()]
    public class ScientistActionsTests : TestsBase
    {
        [TestInitialize()]
        public void InitPlayer()
        {
            StartGame();
            Players[0].Role = new ScientistRoleCard("Scientifique");      
        }


        [TestMethod]
        public void OnlyFourCardsNeededForScientist()
        {
            List<PlayerTownCard> cards = new();
            for (int c = 0; c < 4; c++)
                cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Color == DiseaseColor.Red));

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Red, cards);
            GameState.DoAction(action);

            Assert.AreEqual(DiseaseStatus.Treated, GameState.Board.GetCureSlots().RedSlot.Status);

            Assert.AreEqual(cards[3], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[2], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[1], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[0], GameState.Board.PlayerDiscardCardStack.Pop());
        }
    }
}