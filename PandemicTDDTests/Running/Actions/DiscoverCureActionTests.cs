using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Materiel;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDDTests.Running.Actions
{
    [TestClass]
    public class DiscoverCureActionTests : TestsBase
    {

        [TestMethod]
        public void PlayerMustBeInTownWithSearchStation()
        {
            StartGame();
            GameBox.GetBoard();

            GameState.Board.GetTownSlot(TownsInitializer.Atlanta).Town.ControlDiseaseCenter = null;
            List<PlayerTownCard> cards = new();

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Black, cards);
            Assert.ThrowsException<CityWithoutControlCenterException>(() =>
            {
                action.Try();
            });
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }

        [TestMethod]
        public void PlayerMustHaveFiveCardFromDiseaseColor()
        {
            StartGame();

            List<PlayerTownCard> cards = new();

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Black, cards);
            Assert.ThrowsException<NotEnoughCardToFindCureException>(() =>
            {
                action.Try();
            });
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }


        [TestMethod]
        public void BlackCureDiscovered()
        {
            StartGame();

            List<PlayerTownCard> cards = new();
            for (int c = 0; c < 5; c++)
                cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Color == DiseaseColor.Black));

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Black, cards);
            GameState.DoAction(action);

            Assert.AreEqual(DiseaseStatus.Treated, GameState.Board.GetCureSlots().BlackSlot.Status);

            Assert.AreEqual(cards[4], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[3], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[2], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[1], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[0], GameState.Board.PlayerDiscardCardStack.Pop());



        }


        [TestMethod]
        public void BlueCureDiscovered()
        {
            StartGame();

            List<PlayerTownCard> cards = new();
            for (int c = 0; c < 5; c++)
                cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Color == DiseaseColor.Blue));

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Blue, cards);
            GameState.DoAction(action);

            Assert.AreEqual(DiseaseStatus.Treated, GameState.Board.GetCureSlots().BlueSlot.Status);

            Assert.AreEqual(cards[4], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[3], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[2], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[1], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[0], GameState.Board.PlayerDiscardCardStack.Pop());
        }


        [TestMethod]
        public void RedCureDiscovered()
        {
            StartGame();
            List<PlayerTownCard> cards = new();
            for (int c = 0; c < 5; c++)
                cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Color == DiseaseColor.Red));

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Red, cards);
            GameState.DoAction(action);

            Assert.AreEqual(DiseaseStatus.Treated, GameState.Board.GetCureSlots().RedSlot.Status);

            Assert.AreEqual(cards[4], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[3], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[2], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[1], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[0], GameState.Board.PlayerDiscardCardStack.Pop());
        }
        [TestMethod]
        public void YellowCureDiscovered()
        {
            StartGame();
            List<PlayerTownCard> cards = new();
            for (int c = 0; c < 5; c++)
                cards.Add((PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Color == DiseaseColor.Yellow));

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Yellow, cards);
            GameState.DoAction(action);

            Assert.AreEqual(DiseaseStatus.Treated, GameState.Board.GetCureSlots().YellowSlot.Status);

            Assert.AreEqual(cards[4], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[3], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[2], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[1], GameState.Board.PlayerDiscardCardStack.Pop());
            Assert.AreEqual(cards[0], GameState.Board.PlayerDiscardCardStack.Pop());
        }
    }
}
