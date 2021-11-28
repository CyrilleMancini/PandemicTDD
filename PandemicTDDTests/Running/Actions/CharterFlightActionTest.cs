using CommonTestsTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandemicTDD;
using PandemicTDD.Actions;
using PandemicTDD.Actions.Exceptions;
using PandemicTDD.Materiel.Initializers;
using PandemicTDD.Materiel.PlayerCards;
using PandemicTDDTests.Materiel;
using System.Linq;

namespace PandemicTDDTests.Running.Actions
{
    [TestClass]
    public class CharterFlightActionTest : TestsBase
    {

        [TestMethod]
        public void CharterFlightFromOwnedTownCard()
        {
            StartGame();
            PlayerTownCard OrigineCard = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct);
            Players[0].Town = GameState.Board.GetTownSlot(OrigineCard.Town.Name).Town;
            Players[0].PlayerCards.Add(OrigineCard);

            ActionBase action = new CharterFlightAction(GameState, GameState.CurrentPlayer, TownsInitializer.Paris);
            GameState.DoAction(action);

            Assert.AreEqual(TownsInitializer.Paris, GameState.CurrentPlayer.Town.Name);
            Assert.AreEqual(3, GameState.ActionsRemaining);
            Assert.AreEqual(OrigineCard, GameState.Board.PlayerDiscardCardStack.Peek());
        }

        [TestMethod]
        public void CharterFlightToNotOwnedTownCard()
        {
            StartGame();
            GameState.CurrentPlayer.PlayerCards.Clear();

            ActionBase action = new CharterFlightAction(GameState, GameState.CurrentPlayer, TownsInitializer.Paris);
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {
                action.Try();
                action.Execute();
            });
            Assert.AreEqual(4, GameState.ActionsRemaining);
            Assert.AreEqual(TownsInitializer.Atlanta, GameState.CurrentPlayer.Town.Name);

        }

        [TestMethod]
        public void UsedCardIsOnTopOfPayerCard()
        {

            PlayerTownCard OrigineCard = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct);
            Players[0].PlayerCards.Add(OrigineCard);
            Players[0].Town = OrigineCard.Town;

            PlayerTownCard DestCardCard = (PlayerTownCard)GameBox.GetPlayersCard().First(c => c is PlayerTownCard ct && ct.Town.Name != OrigineCard.Town.Name);


            ActionBase action = new CharterFlightAction(GameState, GameState.CurrentPlayer, DestCardCard.Town.Name);
            GameState.DoAction(action);


            Assert.AreEqual(OrigineCard, GameState.Board.PlayerDiscardCardStack.Peek(), "Player card shoud be in Discard stack");
            Assert.ThrowsException<NotOwnedCityPlayerCardException>(() =>
            {

                OrigineCard = GameState.CurrentPlayer.GetCityPlayerCard<PlayerTownCard>(DestCardCard.Town.Name);

            }, "Player shouldn't have the used card anymore");

        }

    }
}
