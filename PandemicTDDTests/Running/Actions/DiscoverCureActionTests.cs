using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Materiel;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Materiel;
using System.Collections.Generic;

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

            GameState.Board.GetTownSlot(TownsInitializer.Atlanta).ControlDiseaseCenter = null;
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
            GameBox.GetBoard();

            List<PlayerTownCard> cards = new();

            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Black, cards);
            Assert.ThrowsException<NotEnoughCardToFindCureException>(() =>
            {
                action.Try();
            });
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }


        [TestMethod]
        public void CureDiscovered()
        {
            StartGame();
            GameBox.GetBoard();
            GameBox.Reset();
            List<PlayerTownCard> cards = new();
            //cards.Add
            ActionBase action = new DiscoverCureAction(GameState, DiseaseColor.Black, cards);
            Assert.ThrowsException<NotEnoughCardToFindCureException>(() =>
            {
                action.Try();
            });
            Assert.AreEqual(4, GameState.ActionsRemaining);
        }


    }
}
